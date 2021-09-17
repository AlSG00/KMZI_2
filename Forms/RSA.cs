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
    public partial class RSA : Form
    {
        public RSA()
        {
            InitializeComponent();

            label2.Text = "p = ~";
            label3.Text = "q = ~";
            label4.Text = "n = ~";
            label5.Text = "fi = ~";
            label6.Text = "e = ~";
            label7.Text = "d = ~";

            button_encode.Enabled = false;
            button_generateKey.Enabled = false;
        }

        PrimeNumbers pNumbers = new PrimeNumbers();
        BasicNumberTheoryMath basicMath = new BasicNumberTheoryMath();
        
        Random rnd = new Random();

        BigInteger p;
        BigInteger q;
        BigInteger n;   
        BigInteger euler;
        BigInteger exp;
        BigInteger d;

        char[] charSeparators = new char[] { ' ' };
        byte[] inFile;
        byte[] outFile;

        BigInteger[] test_in;
        BigInteger[] test_out;

        bool is_text_from_file = false;

        private void button_encode_Click(object sender, EventArgs e)
        {
            text_out.Clear();

            if (is_text_from_file == false && test_in == null)
            {
                inFile = Encoding.Default.GetBytes(text_in.Text);
                test_in = new BigInteger[inFile.Length];               
                
                for (int i = 0; i < inFile.Length; i++)
                {
                    test_in[i] = Convert.ToInt32(inFile[i]);
                }                                  
            }
            outFile = new byte[inFile.Length];
            test_out = new BigInteger[inFile.Length];
            int h = 0;
            // Шифрование
            if (radioButton1.Checked)
            {
                for (int i = 0; i < inFile.Length; i++)
                {
                    test_out[i] = basicMath.Find_ModularExpo(test_in[i], exp, n);
                    outFile[i] = (byte)(test_out[i] % 256);
                    h++;
                }
                text_out.Text = Encoding.Default.GetString(outFile);
            }

            // Расшифрование
            if (radioButton2.Checked)
            {
                for (int i = 0; i < outFile.Length; i++)
                {
                    test_out[i] = basicMath.Find_ModularExpo(test_in[i], d, n);
                    outFile[i] = (byte)(test_out[i] % 256);
                }
                
                text_out.Text = Encoding.Default.GetString(outFile);
            }
        }

        private void button_generateKey_Click(object sender, EventArgs e)
        {
            if(text_p.TextLength == 0 || text_q.TextLength == 0 || text_p.TextLength > 100 || text_q.TextLength > 100)
            {
                MessageBox.Show("Минимум одно из чисел отсутствует или введено неверно", "Ошибка", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            p = BigInteger.Parse(text_p.Text);
            q = BigInteger.Parse(text_q.Text);

            GenerateKey();
        }

        private void GenerateKey()
        {
            if(!pNumbers.IsPrime(p) || !pNumbers.IsPrime(q) || p == 1 || q == 1)
            {
                MessageBox.Show("Одно из чисел не является простым", "Ошибка", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            if (p == q)
            {
                MessageBox.Show("Числа равны", "Ошибка", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            n = p * q;

            euler = (p - 1) * (q - 1);

            exp = GetExp(euler);

            if (exp == 0)
            {
                EraseKey();
                return;
            }

            d = basicMath.Find_Inversion(exp, euler);
            if (d == 0)
            {
                MessageBox.Show("Секретная экспонента не найдена");
                return;
            }

            label2.Text = "p = " + p.ToString();
            label3.Text = "q = " + q.ToString();
            label4.Text = "n = " + n.ToString();
            label5.Text = "fi = " + euler.ToString();
            label6.Text = "e = " + exp.ToString();
            label7.Text = "d = " + d.ToString();
        }

        private BigInteger GetExp(BigInteger x)
        {
            BigInteger result = p / int.MaxValue;

            while ( result > int.MaxValue)
            {
                result /= 2;
            }

            while (!pNumbers.IsPrime(result) || basicMath.Find_GCD(result, x) != 1 || result >= x)
            {
                result++;
            }

            return result;
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void text_seed_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < text_p.TextLength; i++)
            {
                if (!Char.IsDigit(text_p.Text[i]))
                {
                    text_p.Text= text_p.Text.Replace(text_p.Text[i].ToString(), "");
                }
            }

            if (text_p.TextLength > 100 || text_p.TextLength == 0)
            {
                button_generateKey.Enabled = false;
            }
            else
            {
                button_generateKey.Enabled = true;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button_encode.Text = "Зашифровать";

            if (button_encode.Enabled == false)
            {
                button_encode.Enabled = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            button_encode.Text = "Расшифровать";

            if (button_encode.Enabled == false)
            {
                button_encode.Enabled = true;
            }
        }

        private void button_transferData_Click(object sender, EventArgs e)
        {
            if (test_out != null)
            {
                if(test_in == null)
                {
                    test_in = new BigInteger[test_out.Length];
                    inFile = new byte[test_in.Length];
                }

                test_out.CopyTo(test_in, 0);
                outFile.CopyTo(inFile, 0);
                text_in.Clear();
                text_in.Text = text_out.Text;

                // Для удобства шифрование автоматически переклчается на расшифрование и обратно
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
        
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RSA_SaveType rsaSave = new RSA_SaveType();
            rsaSave.ShowDialog();

            //Если собираемся сохранять открытый текст
            if(rsaSave.DialogResult == DialogResult.Yes)
            {
                Save_File(dataType.decoded);
            }
            
            //Если собираемся сохранять шифртекст
            if(rsaSave.DialogResult == DialogResult.No)
            {
                Save_File(dataType.encoded);
            }          
        }

        //Функция не проверена
        private void Save_File(dataType type)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (type == dataType.decoded)
                {
                    System.IO.File.WriteAllBytes(saveFileDialog1.FileName, outFile);
                }

                if(type == dataType.encoded)
                {
                    string[] outText = new string[test_out.Length];
                    for(int i = 0; i < test_out.Length; i++)
                    {
                        outText[i] = test_out[i].ToString();
                    }
                    System.IO.File.WriteAllLines(saveFileDialog1.FileName, outText);
                }
            }
        }
        //смотреть, куда считыватся данные
        private void Open_File(dataType type)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    //Если открываем незашифрованный файл
                    if (type == dataType.decoded)
                    {
                        inFile = System.IO.File.ReadAllBytes(openFileDialog1.FileName);
                        test_in = new BigInteger[inFile.Length];
                        for (int i = 0; i < inFile.Length; i++)
                        {
                            test_in[i] = (BigInteger)inFile[i];
                        }
                    }

                    //Если открываем зашифрованный файл
                    if (type == dataType.encoded)
                    {
                        inFile = System.IO.File.ReadAllBytes(openFileDialog1.FileName);


                        string[] result = System.IO.File.ReadAllLines(openFileDialog1.FileName);

                        test_in = new BigInteger[result.Length];
                        for (int i = 0; i < result.Length; i++)
                        {
                            test_in[i] = BigInteger.Parse(result[i]);
                        }

                        inFile = new byte[test_in.Length];
                        for (int i = 0; i < inFile.Length; i++)
                        {
                            inFile[i] = (byte)(test_in[i] % 256);
                        }
                    }

                    is_text_from_file = true;

                    text_in.Text = Encoding.Default.GetString(inFile);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка открыти файла.\n Убедитесь, что размер файла не превышает допустимых размеров(~400 МБ)\n и верно был выбран тип открываемого файла", "Ошибка", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        public enum dataType
        {
            encoded,
            decoded
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RSA_SaveType rsaSave = new RSA_SaveType();
            rsaSave.ShowDialog();

            //Если собираемся сохранять открытый текст
            if (rsaSave.DialogResult == DialogResult.Yes)
            {
                Open_File(dataType.decoded);
            }

            //Если собираемся сохранять шифртекст
            if (rsaSave.DialogResult == DialogResult.No)
            {
                Open_File(dataType.encoded);
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EraseKey();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RSA_SaveType rsaSave = new RSA_SaveType();
            rsaSave.ShowDialog();

            //Если собираемся сохранять открытый текст
            if (rsaSave.DialogResult == DialogResult.Yes)
            {
                Open_File(dataType.decoded);
            }

            //Если собираемся сохранять шифртекст
            if (rsaSave.DialogResult == DialogResult.No)
            {
                Open_File(dataType.encoded);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RSA_SaveType rsaSave = new RSA_SaveType();
            rsaSave.ShowDialog();

            //Если собираемся сохранять открытый текст
            if (rsaSave.DialogResult == DialogResult.Yes)
            {
                Save_File(dataType.decoded);
            }

            //Если собираемся сохранять шифртекст
            if (rsaSave.DialogResult == DialogResult.No)
            {
                Save_File(dataType.encoded);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EraseKey();

            text_in.Clear();
            text_out.Clear();

            test_in = null;
            test_out = null;
            inFile = null;
            outFile = null;

            is_text_from_file = false;
        }

        private void EraseKey()
        {
            text_p.Clear();
            text_q.Clear();

            p = 0;
            q = 0;
            n = 0;
            euler = 0;
            exp = 0;
            d = 0;

            label2.Text = "p = ~";
            label3.Text = "q = ~";
            label4.Text = "n = ~";
            label5.Text = "fi = ~";
            label6.Text = "e = ~";
            label7.Text = "d = ~";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            inFile = null;
            test_in = null;

            is_text_from_file = false;

            text_in.Clear();
        }

        private void button_RandomKey_Click(object sender, EventArgs e)
        {
            text_p.Clear();
            text_q.Clear();

            text_p.Text = pNumbers.GeneratePrime();           
            text_q.Text = pNumbers.GeneratePrime();
        }

        private void text_q_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < text_q.TextLength; i++)
            {
                if (!Char.IsDigit(text_q.Text[i]))
                {
                    text_q.Text = text_q.Text.Replace(text_q.Text[i].ToString(), "");
                }
            }

            if (text_q.TextLength > 100 || text_q.TextLength == 0)
            {
                button_generateKey.Enabled = false;
            }
            else
            {
                button_generateKey.Enabled = true;
            }
        }
    }
}
