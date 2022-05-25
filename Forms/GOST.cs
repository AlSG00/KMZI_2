using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.Diagnostics;

namespace KMZI_2
{
    public partial class GOST : Form
    {
        public GOST()
        {
            InitializeComponent();

            panel1.Visible = false;
            label2.Visible = false;
            text_buffer.Visible = false;
            button3.Visible = false;
            button2.Enabled = false;
            label1.Text = "";
        }

        BasicNumberTheoryMath basicMath = new BasicNumberTheoryMath();
        Hash_GOST _gost = new Hash_GOST();

        bool is_text_from_file = false;

        byte[] inFile;

        private void button_process_Click(object sender, EventArgs e)
        {
            text_out.Clear();
            if (is_text_from_file == false)
            {
                if (text_in.TextLength == 0)
                {
                    //text_in.Text = "This is message, length=32 bytes";
                }
                inFile = Encoding.UTF8.GetBytes(text_in.Text);
            }

            if (inFile.Length == 0)
            {

            }

            byte[] inData = inFile;

            hash_GOST(inData);          
        }

        private void hash_GOST(byte[] inData)
        {
            text_buffer.BackColor = SystemColors.Control;

            BigInteger length = inData.Length;
            BigInteger L = inData.Length * 8; // длина в битах
            BigInteger length2 = inData.Length;
            BigInteger checkSum;

            string c = "73657479622032333D6874676E656C202C6567617373656D2073692073696854";
            //string k1 = "733D2C20656865737474676979676120626E737320657369326C656833206D54";
            //string k2 = "110C733D0D166568130E7474064179671D00626E161A2065090D326C4D393320";
            //string k3 = "0080B111F3730DF216850013F1C7E1F941620C1DFF3ABAE91A3FA109F2F513B239";
            //string k4 = "00A0E2804EFF1B73F2ECE27A00E7B8C7E1EE1D620CAC0CC5BAA804C05EA18B0AEC";

            BigInteger M = BigInteger.Parse(c, System.Globalization.NumberStyles.HexNumber);
            //BigInteger K1 = BigInteger.Parse(k1, System.Globalization.NumberStyles.HexNumber);
            //BigInteger K2 = BigInteger.Parse(k2, System.Globalization.NumberStyles.HexNumber);
            //BigInteger K3 = BigInteger.Parse(k3, System.Globalization.NumberStyles.HexNumber);
            //BigInteger K4 = BigInteger.Parse(k4, System.Globalization.NumberStyles.HexNumber);

            BigInteger hash = 0; // ЗАДАТЬ ХЭШУ ЗНАЧЕНИЕ (ВОЗМОЖНО, СО СТОРОНЫ ПОЛЬЗОВАТЕЛЯ)

            byte[] temp = new byte[inData.Length];
            inData.CopyTo(temp, 0);

            while (length2 % 32 != 0)
            {
                length2++;
            }

            inData = new byte[(int)length2];
            temp.CopyTo(inData, 0);
            //temp.CopyTo(inData, (int)(length2 - length));
            BigInteger h = 0;
            BigInteger H = 0;

            BigInteger[] tempBlocks = _gost.CheckSum(inData);
            BigInteger[] blocks = new BigInteger[tempBlocks.Length];
            Array.Copy(tempBlocks, 0, blocks, 0, blocks.Length);
            checkSum = tempBlocks[tempBlocks.Length - 1];

            progressBar1.Value = 0;
            progressBar1.Maximum = blocks.Length - 1;
            progressBar1.Step = 1;

            for (int i = blocks.Length - 2; i >=  0; i--)
            {
                hash = _gost.BlockHashing(hash, blocks[i]);
                progressBar1.PerformStep();
            }

            
            BigInteger mod = BigInteger.Pow(2, 256);
            hash = _gost.BlockHashing(hash, L & mod);
            hash = _gost.BlockHashing(hash, checkSum & mod);
            byte[] test = hash.ToByteArray();

            if (test.Length > 32)
            {
                temp = new byte[32];
                Array.Copy(test, 0, temp, 0, 32);
               // Array.Reverse(temp);
                text_out.Text += BitConverter.ToString(temp, 0);
            }
            else
            {
               // Array.Reverse(test);
                text_out.Text += BitConverter.ToString(test, 0);
            }
            

            text_out.Text = text_out.Text.Replace("-", "");
            text_out.Text = text_out.Text.ToLower();

            if (text_out.Text == text_buffer.Text)
            {
                text_buffer.BackColor = Color.LimeGreen;
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open_File();
        }

        private void Open_File()
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    inFile = System.IO.File.ReadAllBytes(openFileDialog1.FileName);

                    is_text_from_file = true;

                    panel1.Visible = true;
                    text_in.Enabled = false;
                    label2.Visible = true;
                }
            }
            catch
            {
                MessageBox.Show("Ошибка открыти файла.", "Ошибка", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            panel1.BackgroundImage = KMZI_2.Properties.Resources.File_icon2;
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackgroundImage = KMZI_2.Properties.Resources.File_icon;
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            CloseFile();
        }

        private void CloseFile()
        {
            inFile = null;
            panel1.Visible = false;
            text_in.Enabled = true;
            label2.Visible = false;
            label1.Text = "";
            is_text_from_file = false;
            progressBar1.Value = 0;
            text_buffer.BackColor = SystemColors.Control;
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            text_in.Clear();
            CloseFile();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            text_buffer.Visible = true;
            text_buffer.Text = text_out.Text;
            button3.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            text_buffer.BackColor = SystemColors.Control;
            text_buffer.Visible = false;
            text_buffer.Clear();
            button3.Visible = false;
        }

        private void text_out_TextChanged(object sender, EventArgs e)
        {
            if (text_out.TextLength > 0)
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
        }
    }
}
