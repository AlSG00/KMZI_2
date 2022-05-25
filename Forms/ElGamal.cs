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
    public partial class ElGamal : Form
    {
        public ElGamal()
        {
            InitializeComponent();

            button5.Enabled = false;
            button_OK.Enabled = false;
        }

        BasicNumberTheoryMath basicMath = new BasicNumberTheoryMath();
        PrimeNumbers pNumbers = new PrimeNumbers();
        BigIntBlocks bib = new BigIntBlocks();

        BigInteger p = 0;
        BigInteger g = 0;
        BigInteger k = 0;
        BigInteger exp = 0;
        BigInteger r = 0;
        BigInteger ca = 0;
        BigInteger cb = 0;
        BigInteger da = 0;
        BigInteger db = 0;
        BigInteger[] textIn_int;
        BigInteger[] textOut_int;

        byte[] inFile;
        byte[] outFile;

        bool is_text_from_file = false;

        Random rnd = new Random();

        // Генерируем число Q 
        private void button_generateP_Click(object sender, EventArgs e)
        {
            text_p.Text = pNumbers.GeneratePrime(50);
            button_OK.Enabled = true;
        }

        // На основе Q вычисляем P и G, по аналогии с диффи-хеллманом
        private void button_OK_Click(object sender, EventArgs e)
        {           
            BigInteger q = BigInteger.Parse(text_p.Text);
            if (!pNumbers.IsPrime(q, false))
            {
                MessageBox.Show("Введенное число не является простым", "Ошибка", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
             p = 2 * q + 1;
             g = 0;

            while (!pNumbers.IsPrime(p, false))
            {
                text_p.Text = pNumbers.GeneratePrime(50);
                q = BigInteger.Parse(text_p.Text);
                p = 2 * q + 1;
            }

            bool isOk = false;
            while (!isOk)
            {
                if (p >= int.MaxValue)
                {
                    g = rnd.Next(2, int.MaxValue);
                }
                else
                {
                    g = rnd.Next(2, (int)p);
                }

                if (g < p - 1 && basicMath.Find_ModularExpo(g, q, p) != 1)
                {
                    isOk = true;
                }
            }

            // Вычисляем c и d только для B, потому что отправителем будет только А
            cb = GenDigit(p);
            db = basicMath.Find_ModularExpo(g, cb, p);

            textBox1.Text = p.ToString();
            textBox2.Text = g.ToString();
            textBox3.Text = cb.ToString();
            textBox4.Text = db.ToString();

            button5.Enabled = true;
        }


        private BigInteger GenDigit(BigInteger max)
        {
            rnd = new Random();
            BigInteger result = 0;

            while (basicMath.Find_GCD(result, max - 1) != 1)
            {
                result += rnd.Next(2, int.MaxValue);
                result %= max - 2;
            }

            if (result <= 1)
            {
                result += 2;
            }

            return result;
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            text_in.Clear();
            text_2.Clear();
            text_out.Clear();
            progressBar1.Value = 0;

            inFile = null;
            is_text_from_file = false;
        }

        // Преобразование сообщения
        private void button5_Click(object sender, EventArgs e)
        {
            if (is_text_from_file == false && inFile == null)
            {
                inFile = Encoding.Default.GetBytes(text_in.Text);
            }
            outFile = new byte[inFile.Length];

            textIn_int = bib.GenerateBlocks(inFile, 16); // разбиваем на блоки по 16 байт
            textOut_int = new BigInteger[textIn_int.Length];
            byte[] x = new byte[textIn_int.Length];

            progressBar1.Maximum = textIn_int.Length;
            progressBar1.Value = 0;
            progressBar1.Step = 1;

            // В цикле обрабатываем и передаем каждый блок
            for (int i = 0; i < textIn_int.Length; i++)
            {
                k = GenDigit(p); // Генерируем случайное К
                r = basicMath.Find_ModularExpo(g, k, p); // Вычисляем r
                exp = (textIn_int[i] * basicMath.Find_ModularExpo(db, k, p)) % p; // вычисляем е
                x[i] = (byte)(exp % 256);
                textOut_int[i] = (exp * basicMath.Find_ModularExpo(r, p - 1 - cb, p)) % p; // Используя переданные значения, расшифровываем сообщение
                byte[] tmp = bib.DecomposeBlocks(textOut_int[i]); // Раскладываем сообщение на отдельные байты
                tmp.CopyTo(outFile, i * 16);
                progressBar1.PerformStep();
            }

            text_2.Text = Encoding.Default.GetString(x);
            text_out.Text = Encoding.Default.GetString(outFile);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Open_File();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open_File();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Save_File();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save_File();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            p = 0;
            g = 0;
            cb = 0;
            db = 0;

            inFile = null;
            outFile = null;
            textIn_int = null;
            textOut_int = null;
      
            text_2.Clear();
            text_p.Clear();
            text_in.Clear();
            text_out.Clear();   
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

            button5.Enabled = false;
            button_OK.Enabled = false;

            progressBar1.Value = 0;
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
                MessageBox.Show("Ошибка открыти файла.", "Ошибка", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void Save_File()
        {
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.WriteAllBytes(saveFileDialog1.FileName, outFile);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка сохранения файла.", "Ошибка", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }
    }
}
