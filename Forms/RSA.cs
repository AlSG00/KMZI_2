using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Numerics;
namespace KMZI_2
{
    // ПРОРАБОТАТЬ ВВОД ДАННЫХ
    //порешать проблемы с большими числами
    // Не ясно, как все это сохранять
    // Сломается, если закрыть окно и попробовать расшифровать обратно
    public partial class RSA : Form
    {
        public RSA()
        {
            InitializeComponent();
        }

        PrimeNumbers pNumbers = new PrimeNumbers();
        BasicNumberTheoryMath basicMath = new BasicNumberTheoryMath();
        Random rnd = new Random();

        BigInteger p;
        BigInteger q;
        BigInteger n;   
        BigInteger euler;
        long exp;
        long d;
        int[] primePair;

        byte[] inFile;
        byte[] outFile;

        BigInteger[] test_in;
        BigInteger[] test_out;

        bool is_text_from_file = false;

        private void button_encode_Click(object sender, EventArgs e)
        {
            if (is_text_from_file == false && test_in == null)
            {
                inFile = Encoding.Default.GetBytes(text_in.Text);
                for (int i = 0; i < inFile.Length; i++)
                {
                    test_in[i] = Convert.ToInt32(inFile[i]);
                }
                    test_in = new BigInteger[inFile.Length];                
            }
            outFile = new byte[inFile.Length];
            test_out = new BigInteger[inFile.Length];

            // ОШИБКА В ТОМ, ЧТО МАССИВЫ ОБНУЛЯЮТСЯ КАЖДЫЙ РАЗ
            //if (test_in == null)
            //{
            //    test_in = new BigInteger[inFile.Length];
            //    test_out = new BigInteger[inFile.Length];
            //}

            // Шифрование
            if (radioButton1.Checked)
            {
                for (int i = 0; i < inFile.Length; i++)
                {
                    //test_in[i] = Convert.ToInt32(inFile[i]);
                    test_out[i] = basicMath.Find_ModularExpo(test_in[i], exp, n);
                    outFile[i] = (byte)(test_out[i] % 256);
                }

                text_out.Text = Encoding.Default.GetString(outFile);
            }

            // Расшифрование
            if (radioButton2.Checked)
            {
                // ОШИБКА. ОТКУДА БРАТЬ ДАННЫЕ ДЛЯ ЭТИХ ЕБУЧИХ МАССИВОВ
                for (int i = 0; i < outFile.Length; i++)
                {
                    //test_in[i] = Convert.ToInt32(inFile[i]);
                    test_out[i] = basicMath.Find_ModularExpo(test_in[i], d, n);
                   // outFile[i] = (byte)(test_out[i] % 256);
                }
                
                text_out2.Text = Encoding.Default.GetString(outFile);
            }
        }

        private void button_generateKey_Click(object sender, EventArgs e)
        {
            primePair = pNumbers.GeneratePrimePair(Convert.ToInt32(text_seed.Text));

            // ТУТ БУДЕТ ОШИБКА ИЗ-ЗА СЛИШКОМ БОЛЬШОГО ЧИСЛА
            // Проработать максимально допустимые числа!!!
            // Возможно, стоит запихивать резульаты в отдельный массив с пометкой "открытый/закрытый ключ"
            // http://www.michurin.net/computer-science/rsa.html

            p = primePair[0];
            q = primePair[1];
            n = p * q;
            euler = (p - 1) * (q - 1);

            BigInteger test = euler % int.MaxValue;
            int randEuler = (int)test;

            exp = rnd.Next(2, randEuler);
            while (!pNumbers.IsPrime(exp) || basicMath.Find_GCD(exp, euler) != 1)
            {
                exp = rnd.Next(2, randEuler);
            }

            d = rnd.Next(1, pNumbers.primeMax);
            while ((d * exp) % euler != 1)
            {
                d = rnd.Next(1, pNumbers.primeMax);
            }
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void text_seed_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < text_seed.TextLength; i++)
            {
                if (!Char.IsDigit(text_seed.Text[i]))
                {
                    text_seed.Text= text_seed.Text.Replace(text_seed.Text[i].ToString(), "");
                }
            }

            if (text_seed.TextLength > 4)
            {
                button_generateKey.Enabled = false;
            }
            else
            {
                button_generateKey.Enabled = true;
            }
        }

        private void Open_File()
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    is_text_from_file = true;
                    inFile = System.IO.File.ReadAllBytes(openFileDialog1.FileName);

                    //ProgressBar_Reset();

                    // Если объем файла превышает 400 Мб, то будет ошибка (число в байтах)
                    if (inFile.Length > 419430400)
                    {
                        MessageBox.Show("Превышен допустимый размер файла.\n  Размер открываемого файла не должен превышать 400 Мб", "Ошибка", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        inFile = null;
                        return;
                    }
                    else
                    {
                        text_in.Text = Encoding.Default.GetString(inFile);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Не удалось открыть файл.", "Ошибка", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void Save_File()
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllBytes(saveFileDialog1.FileName, outFile);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button_encode.Text = "Зашифровать";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            button_encode.Text = "Расшифровать";
        }

        private void button_transferData_Click(object sender, EventArgs e)
        {
            // НЕ РАБОТАЕТ, ПЕРЕДЕЛАТЬ
            if (test_out != null)
            {
                //inFile = new byte[outFile.Length];
                test_out.CopyTo(test_in, 0);
                text_in.Clear();
                text_in.Text = text_out.Text;

                // Для удобства шифроваание автоматически переклчается на расшифрование и обратно
                if (radioButton1.Checked)
                {
                    radioButton2.Checked = true;
                }
                else if (radioButton2.Checked)
                {
                    radioButton1.Checked = true;
                }
            }
        }
    }
}
