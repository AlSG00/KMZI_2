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
    public partial class SHA : Form
    {
        public SHA()
        {
            InitializeComponent();

            panel1.Visible = false;
            label2.Visible = false;
            text_buffer.Visible = false;
            button3.Visible = false;
            button2.Enabled = false;
            label1.Text = "";
        }

        MySHA sha = new MySHA();
        BasicNumberTheoryMath basicMath = new BasicNumberTheoryMath();

        bool is_text_from_file = false;

        byte[] inFile;
        byte[] inData;

       

        private void button_process_Click(object sender, EventArgs e)
        {

            text_out.Clear();

            BigInteger A = 0x67452301;
            BigInteger B = 0xEFCDAB89;
            BigInteger C = 0x98BADCFE;
            BigInteger D = 0x10325476;
            BigInteger E = 0xC3D2E1F0;

            if (is_text_from_file == false)
            {
                inFile = Encoding.UTF8.GetBytes(text_in.Text);
            }

            inData = inFile;
            BigInteger length = inData.Length;
            BigInteger length2 = inData.Length + 1;

            byte[] temp = new byte[inData.Length];
            inData.CopyTo(temp, 0);

            while (basicMath.Find_ModularExpo(length2, 1, 64) != 56)
            {
                length2++;
            }

            length2 += 8;
            inData = new byte[(int)length2];
            temp.CopyTo(inData, 0);
            inData[(int)length] = 128;
            byte[] bLength = ((length * 8) & 0xFFFFFFFFFFFFFFFF).ToByteArray();
            Array.Reverse(bLength);

            for (int i = 0; i < 8; i++)
            {
                if (i >= bLength.Length)
                {
                    break;
                }

                inData[inData.Length - 1 - i] = bLength[bLength.Length - 1 - i];
            }

            Stopwatch sWatch = new Stopwatch();

            temp = new byte[64];
            BigInteger[] result;
            BigInteger[] blocks;

            progressBar1.Maximum = inData.Length / 64;
            progressBar1.Value = 0;
            progressBar1.Step = 1;

            sWatch.Start();
            for (int i = 0; i < inData.Length; i += 64)
            {
                Array.Copy(inData, i, temp, 0, 64);

                blocks = sha.CutBlocks_80(temp);
                
                result = sha.Rounds(A, B, C, D, E, blocks);

                A = (A + result[0]) & 0xFFFFFFFF;
                B = (B + result[1]) & 0xFFFFFFFF;
                C = (C + result[2]) & 0xFFFFFFFF;
                D = (D + result[3]) & 0xFFFFFFFF;
                E = (E + result[4]) & 0xFFFFFFFF;

                progressBar1.PerformStep();
            }
            sWatch.Stop();

            TimeSpan ts = sWatch.Elapsed;

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds);

            label1.Text = elapsedTime;

            byte[] buff = new byte[20];

            byte[] a = A.ToByteArray();
            byte[] b = B.ToByteArray();
            byte[] c = C.ToByteArray();
            byte[] d = D.ToByteArray();
            byte[] e1 = E.ToByteArray();

            Array.Reverse(a);
            Array.Reverse(b);
            Array.Reverse(c);
            Array.Reverse(d);
            Array.Reverse(e1);

            a = FixLength(a, 4);
            b = FixLength(b, 4);
            c = FixLength(c, 4);
            d = FixLength(d, 4);
            e1 = FixLength(e1, 4);

            text_out.Text += BitConverter.ToString(a, 0);
            text_out.Text += BitConverter.ToString(b, 0);
            text_out.Text += BitConverter.ToString(c, 0);
            text_out.Text += BitConverter.ToString(d, 0);
            text_out.Text += BitConverter.ToString(e1, 0);
        
            text_out.Text = text_out.Text.Replace("-", "");
            text_out.Text = text_out.Text.ToLower();
        }

        public byte[] FixLength(byte[] arr, int length)
        {
            byte[] result = arr;
            byte[] temp = new byte[length];

            if(arr.Length < length)
            {
                result = new byte[4];
                Array.Copy(arr, 0, result, 1, arr.Length);
            }
            if (arr.Length > length)
            {
                result = new byte[4];
                Array.Copy(arr, 1, result, 0, 4);
            }

            return result;
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

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open_File();
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

        private void button1_Click(object sender, EventArgs e)
        {
            text_in.Clear();
            CloseFile();
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
