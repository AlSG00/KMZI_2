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
namespace KMZI_2
{
    public partial class Shamir : Form
    {
        public Shamir()
        {
            InitializeComponent();

            groupBox1.Enabled = false;
        }

        PrimeNumbers pNumbers = new PrimeNumbers();
        BasicNumberTheoryMath basicMath = new BasicNumberTheoryMath();
        BigIntBlocks bib = new BigIntBlocks();
        Random rnd = new Random();

        BigInteger p = 0;
        BigInteger ca = 0;
        BigInteger cb = 0;
        BigInteger da = 0;
        BigInteger db = 0;
        BigInteger[] textIn_int;
        BigInteger[] textOut_int;

        byte[] inFile;
        byte[] outFile;

        bool is_text_from_file = false;

        private void button_generateP_Click(object sender, EventArgs e)
        {
            text_p.Text = pNumbers.GeneratePrime(100);
        }

        // Здесь генерируем необходимые переменные
        private void button_OK_Click(object sender, EventArgs e)
        {
            p = BigInteger.Parse(text_p.Text);
            if (!pNumbers.IsPrime(p, false))
            {
                MessageBox.Show("ВВедённое число не является простым", "Ошибка", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            ca = GenDigit(p);
            text_Ca.Text = ca.ToString();

            while (cb == ca || cb == 0)
            {
                cb = GenDigit(p);
            }
            text_Cb.Text = cb.ToString();

            da = basicMath.Find_Inversion(ca, p - 1);
            text_da.Text = da.ToString();

            db = basicMath.Find_Inversion(cb, p - 1);
            text_db.Text = db.ToString();

            groupBox1.Enabled = true;
        }

        // ВОЗМОЖНО, ПРИДЁТСЯ ПЕРЕРАБОТАТЬ ФУНКЦИЮ
        private BigInteger GenDigit(BigInteger max)
        {
            rnd = new Random();
            BigInteger result = 0;

            while (basicMath.Find_GCD(result, max - 1) != 1)
            {
                //while (result < max / 2)
                //{
                result += rnd.Next(2, int.MaxValue);
                //}

                result %= max;
                if (result % 2 == 0)
                {
                    result--;
                }
            }

            return result;
        }

        private void text_p_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < text_p.TextLength; i++)
            {
                if (!Char.IsDigit(text_p.Text[i]))
                {
                    text_p.Text = text_p.Text.Replace(text_p.Text[i].ToString(), "");
                }
            }

            if (text_p.TextLength == 0)
            {
                button_OK.Enabled = false;
            }
            else
            {
                button_OK.Enabled = true;
            }
        }

        private void text_Ca_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < text_Ca.TextLength; i++)
            {
                if (!Char.IsDigit(text_Ca.Text[i]))
                {
                    text_Ca.Text = text_Ca.Text.Replace(text_Ca.Text[i].ToString(), "");
                }
            }

            if (text_Ca.TextLength == 0)
            {
                button_OK.Enabled = false;
            }
            else
            {
                button_OK.Enabled = true;
            }
        }

        private void text_Cb_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < text_Cb.TextLength; i++)
            {
                if (!Char.IsDigit(text_Cb.Text[i]))
                {
                    text_Cb.Text = text_Cb.Text.Replace(text_Cb.Text[i].ToString(), "");
                }
            }

            if (text_Cb.TextLength == 0)
            {
                button_OK.Enabled = false;
            }
            else
            {
                button_OK.Enabled = true;
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            p = 0;
            ca = 0;
            cb = 0;
            da = 0;
            db = 0;

            text_p.Clear();
            text_Ca.Clear();
            text_Cb.Clear();
            text_da.Clear();
            text_db.Clear();

            text_in.Clear();
            text_out.Clear();
            text_first.Clear();
            text_second.Clear();
            text_third.Clear();

            progressBar1.Value = 0;

            inFile = null;
            outFile = null;
            groupBox1.Enabled = false;
            is_text_from_file = false;
        }


        private void button_openFile_Click(object sender, EventArgs e)
        {
            Open_File();
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

                    text_in.Text = Encoding.Default.GetString(inFile);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка открытия файла.", "Ошибка", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        // Здесь имитируется передача сообщения
        private void button_start_Click(object sender, EventArgs e)
        {
            text_first.Clear();
            text_second.Clear();
            text_third.Clear();
            text_out.Clear();

            if (is_text_from_file == false && inFile == null)
            {
                inFile = Encoding.Default.GetBytes(text_in.Text);
            }
            outFile = new byte[inFile.Length];

            textIn_int = bib.GenerateBlocks(inFile, 33); // Входной массив байтов разбивается на блоки BigInteger

            textOut_int = new BigInteger[textIn_int.Length];
            byte[] x1 = new byte[textIn_int.Length];
            byte[] x2 = new byte[textIn_int.Length];
            byte[] x3 = new byte[textIn_int.Length];
            byte[] x4 = new byte[textIn_int.Length];

            progressBar1.Maximum = textIn_int.Length;
            progressBar1.Value = 0;
            progressBar1.Step = 1;

            // В цикле каждый блок BigInt обрабатывается и передается между абонентами
            for (int i = 0; i < textIn_int.Length; i++)
            {
                // 1) А зашифровывает и передает В
                textIn_int[i] = basicMath.Find_ModularExpo(textIn_int[i], ca, p);
                x1[i] = (byte)(textIn_int[i] % 256);

                // 2) А <- B
                textIn_int[i] = basicMath.Find_ModularExpo(textIn_int[i], cb, p);
                x2[i] = (byte)(textIn_int[i] % 256);

                // 3) А -> B
                textIn_int[i] = basicMath.Find_ModularExpo(textIn_int[i], da, p);
                x3[i] = (byte)(textIn_int[i] % 256);

                // 4) B расшифровывает
                textOut_int[i] = basicMath.Find_ModularExpo(textIn_int[i], db, p);
                byte[] tmp = bib.DecomposeBlocks(textOut_int[i]);
                tmp.CopyTo(outFile, i * 33);
                x4[i] = (byte)(textOut_int[i] % 256);

                // Пересчитываем переменные для большей криптостойкости
                ca = GenDigit(p);
                while (cb == ca)
                {
                    cb = GenDigit(p);
                }
                da = basicMath.Find_Inversion(ca, p - 1);
                db = basicMath.Find_Inversion(cb, p - 1);

                progressBar1.PerformStep();
            }

            text_first.Text = Encoding.Default.GetString(x1);
            text_second.Text = Encoding.Default.GetString(x2);
            text_third.Text = Encoding.Default.GetString(x3);
            text_out.Text = Encoding.Default.GetString(outFile);
        }

        // Кнопка "Закрыть"
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Кнопка "Сохранить"
        private void button1_Click(object sender, EventArgs e)
        {
            Save_File();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save_File();
        }

        private void Save_File()
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                    System.IO.File.WriteAllBytes(saveFileDialog1.FileName, outFile);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            text_in.Clear();
            inFile = null;
            is_text_from_file = false;
            progressBar1.Value = 0;
        }
    }
}
