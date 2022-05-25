using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Numerics;

// Заменить везде функцию на %
// Проверить необходимость biginteger
// Допилить генерацию сертного ключа
// Вынести генераци случайного числа в отдельную функцию

namespace KMZI_2
{
    public partial class EpGOST : Form
    {
        public EpGOST()
        {
            InitializeComponent();

            button4.Enabled = false;
            button3.Enabled = false;

            label2.Visible = false;
            panel1.Visible = false;
        }


        PrimeNumbers pNumbers = new PrimeNumbers();
        BasicNumberTheoryMath basicMath = new BasicNumberTheoryMath();
        Random rnd = new Random();
        byte[] inData;

        int counter = 0;
        int offset = 2;

        BigInteger x = 0;
        BigInteger y = 0;

        BigInteger hash;
        BigInteger r = 0;
        BigInteger s = 0;
        BigInteger g = 1;
        BigInteger q = 4;
        BigInteger p = 4;

        BigInteger r_temp = 0;
        BigInteger s_temp = 0;
        BigInteger g_temp = 1;
        BigInteger q_temp = 4;
        BigInteger p_temp = 4;
        BigInteger y_temp;
        BigInteger x_temp;

        bool isFromFile = false;
        bool isDetailed = false;

        private void button1_Click(object sender, EventArgs e)
        {
            if (isFromFile == false)
            {
                inData = Encoding.UTF8.GetBytes(text_in.Text);
            }

            q = 4;
            p = 4;
            byte[] seed = null;

            while (!pNumbers.IsPrime(p, false))
            {
                while (!pNumbers.IsPrime(q, false))
                {
                    // Шаг 1
                    seed = new byte[21];
                    seed[seed.Length - 2] = (byte)rnd.Next(128, 255);
                    for (int i = seed.Length - 3; i >= 0; i--)
                    {
                        seed[i] = (byte)rnd.Next(0, 255);
                    }

                    while ((int)seed[0] % 2 == 0)
                    {
                        seed[0] = (byte)rnd.Next(0, 255);
                    }

                    // Шаг 2
                    hash = new BigInteger(GetHash_SHA(seed).Concat(new byte[] { 0 }).ToArray());
                    BigInteger hashTemp = basicMath.Find_ModularExpo(hash + 1, 1, BigInteger.Pow(2, 160));
                    BigInteger hash2 = new BigInteger(GetHash_SHA(hashTemp.ToByteArray()).Concat(new byte[] { 0 }).ToArray());
                    BigInteger U = hash ^ hash2;

                    // Шаг 3
                    q = U | BigInteger.Pow(2, 159) | 1;
                }
                // Шаг 4 - проверка на простоту
                // Шаг 5 - если q - не простое число, возвращаемся к шагу 1 
                // Шаг 6 - объявили counter и offset
                // Шаг 7
                int L = 1024; // длина р в битах
                int n = L / 160;
                int b = L - 1 - n * 160;

                while (counter < 4096)
                {
                    BigInteger[] V = new BigInteger[n + 1];
                    BigInteger temp = 0;
                    for (int i = 0; i < n; i++)
                    {
                        temp = new BigInteger(seed);
                        temp = basicMath.Find_ModularExpo(temp + offset + i, 1, BigInteger.Pow(2, 160));
                        V[i] = new BigInteger(GetHash_SHA(temp.ToByteArray()).Concat(new byte[] { 0 }).ToArray());
                    }

                    // шаг 8
                    BigInteger W = V[0];
                    for (int i = 1; i < n; i++)
                    {
                        W += V[i] * BigInteger.Pow(2, i * 160);
                    }
                    W += basicMath.Find_ModularExpo(V[n], 1, BigInteger.Pow(2, b)) * BigInteger.Pow(2, n * 160);
                    BigInteger X = W + BigInteger.Pow(2, L - 1);

                    // Шаг 9
                    BigInteger c = X % (2 * q);
                    p = X - (c - 1);

                    // Шаг 10 - если р < 2 ^ L - 1, то идём на шаг 13
                    if (p < BigInteger.Pow(2, L - 1))
                    {
                        counter++;
                        offset += n + 1;
                    }
                    else if (pNumbers.IsPrime(p, false))
                    {
                        break;
                    }
                    else
                    {
                        counter++;
                        offset += n + 1;
                    }
                }
            }

            //_______________________________
            // Приступаем к генерации подписи
            // Шаг 1 - вычисляем хеш сообщения
           
            hash =  new BigInteger(GetHash_SHA(inData).Concat(new byte[] { 0 }).ToArray());
            BigInteger pow = (p - 1) / q;
            // Шаг 2 - формируем случайное число к (0 < k < q)
            // шаг 3 - вычисляем r = (g^k mod p) mod q. Если r == 0, возвращаемся к шагу 2

            r = 0;
            s = 0;
            g = 1;
            int h = 1;

            while (g == 1)
            {
                h++;
                g = basicMath.Find_ModularExpo(h, (p - 1) / q, p);
            }

            x = rnd.Next(0, int.MaxValue); // секретный ключ
            y = basicMath.Find_ModularExpo(g, x, p); // открытый ключ
            while (r == 0 || s == 0)
            {
                int k = rnd.Next(1, int.MaxValue);
                r = basicMath.Find_ModularExpo(g, k, p) % q;
               
                s = basicMath.Find_Inversion(k, q) * (hash + x * r) % q;
            }

            text_out.Text += BitConverter.ToString(r.ToByteArray(), 0);
            text_out.Text += BitConverter.ToString(s.ToByteArray(), 0);
            text_out.Text = text_out.Text.Replace("-", "");
            text_out.Text = text_out.Text.ToLower();

            button3.Enabled = true;
        }

        private byte[] GetHash_SHA(byte[] data)
        {
            SHA1 sha = SHA1.Create();
            byte[] result = sha.ComputeHash(data);

            return result;
        }

        // Проверка подписи
        private void button4_Click(object sender, EventArgs e)
        {
            hash = new BigInteger(GetHash_SHA(inData).Concat(new byte[] { 0 }).ToArray());

            BigInteger w = basicMath.Find_ModularExpo(s_temp, -1, q_temp);
            BigInteger u1 = hash * w % q_temp;
            BigInteger u2 = r_temp * w % q_temp;
            BigInteger v = (basicMath.Find_ModularExpo(g_temp, u1, p_temp) *
                            basicMath.Find_ModularExpo(y_temp, u2, p_temp) % p_temp) % q_temp;

            if (v == r_temp)
            {
                MessageBox.Show("Подлинность данных подтверждена", "Проверка пройдена", 
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Подлинность данных не подтверждена", "Проверка не пройдена",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            x_temp = x;
            y_temp = y;
            p_temp = p;
            q_temp = q;
            r_temp = r;
            s_temp = s;
            g_temp = g;

            textBox1.Text = x_temp.ToString();
            textBox2.Text = y_temp.ToString();
            textBox3.Text = p_temp.ToString();
            textBox4.Text = q_temp.ToString();
            textBox5.Text = r_temp.ToString();
            textBox6.Text = s_temp.ToString();
            textBox7.Text = g_temp.ToString();

            button4.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File_Open();
        }

        private void File_Open()
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    inData = System.IO.File.ReadAllBytes(openFileDialog1.FileName);

                    isFromFile = true;

                    panel1.Visible = true;
                    label2.Visible = true;
                    text_in.Enabled = false;
                }
            }
            catch
            {
                MessageBox.Show("Ошибка открыти файла.", "Ошибка", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            text_in.Clear();
            text_out.Clear();            

            button3.Enabled = false;
            button4.Enabled = false;

            File_Close();
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
            File_Close();
        }

        private void File_Close()
        {
            inData = null;
            panel1.Visible = false;
            text_in.Enabled = true;
            label2.Visible = false;
            isFromFile = false;

            button3.Enabled = false;           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (isDetailed)
            {
                isDetailed = false;
                button5.Text = "Свернуть";

                MinimumSize = new Size(391, 368);
                MaximumSize = new Size(391, 368);
            }
            else
            {
                isDetailed = true;
                button5.Text = "Подробности";

                MinimumSize = new Size(391, 570);
                MaximumSize = new Size(391, 570);
            }         
        }
    }
}
