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
using System.Collections;
using System.Diagnostics;

namespace KMZI_2
{
    public partial class MD5 : Form
    {
        public MD5()
        {
            InitializeComponent();

            panel1.Visible = false;
            label2.Visible = false;
            text_buffer.Visible = false;
            button3.Visible = false;
            button2.Enabled = false;
            button4.Visible = false;
            button5.Visible = false;
            label1.Text = "";
            label3.Text = "Режим MD5";
        }

        BasicNumberTheoryMath basicMath = new BasicNumberTheoryMath();
        PrimeNumbers pNumbers = new PrimeNumbers();
        RSA rsa = new RSA();
        MyMD5 md5 = new MyMD5();
        MD5_info info;       

        byte[] inFile;

        bool is_text_from_file;
        bool electronicSign_RSA = false;
        bool electronicSign_ElGamal = false;
        bool hasBuffer = false;

        string hashBuf;

        BigInteger p;
        BigInteger q;
        BigInteger n;
        BigInteger euler;
        BigInteger exp;
        BigInteger d;
        BigInteger s;
        BigInteger y_temp;
        BigInteger g_temp;
        BigInteger p_temp;
        BigInteger s_temp;
        BigInteger r_temp;

        BigInteger g;
        BigInteger k;
        BigInteger r;
        BigInteger x;
        BigInteger y;
        //BigInteger cb;
        //BigInteger db;

        BigInteger md51;

        BigInteger md5Buf;

        Random rnd = new Random();

        private void button_process_Click(object sender, EventArgs e)
        {
            text_buffer.BackColor = SystemColors.Control;

            BigInteger A = 0x67452301;
            BigInteger B = 0xEFCDAB89;
            BigInteger C = 0x98BADCFE;
            BigInteger D = 0x10325476;

            if (is_text_from_file == false)
            {
                inFile = Encoding.UTF8.GetBytes(text_in.Text);
            }

            byte[] inData = inFile;

            BigInteger length = inData.Length;
            BigInteger length2 = inData.Length + 1; // вспомогательная переменная

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

            for (int i = 0; i < 8; i++)
            {
                if (i >= bLength.Length)
                {
                    break;
                }

                inData[inData.Length - 8 + i] = bLength[i];
            }

            progressBar1.Maximum = inData.Length / 64;
            progressBar1.Value = 0;
            progressBar1.Step = 1;

            Stopwatch sWatch = new Stopwatch();

            temp = new byte[64];
            BigInteger[] result;
            BigInteger[] blocks;

            // берём блоки по 512 бит и начинаем их обработку
            sWatch.Start();
            for (int i = 0; i < inData.Length; i += 64)
            {
                // разбиваем взятый блок на шестнадцать 32-битных слов
                Array.Copy(inData, i, temp, 0, 64);

                blocks = md5.CutBlocks_32(temp);

                result = md5.Rounds(A, B, C, D, blocks);

                A = (A + result[0]) & 0xFFFFFFFF;
                B = (B + result[1]) & 0xFFFFFFFF;
                C = (C + result[2]) & 0xFFFFFFFF;
                D = (D + result[3]) & 0xFFFFFFFF;

                progressBar1.PerformStep();
            }
            sWatch.Stop();
            TimeSpan ts = sWatch.Elapsed;

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds);

            label1.Text = elapsedTime;

            text_out.Clear();

            text_out.Text = text_out.Text.Replace("-", "");
            text_out.Text = text_out.Text.ToLower();


            md51 = (A + (B << 32) + (C << 64) + (D << 96));

            byte[] answer = md51.ToByteArray();

            if (answer.Length > 16)
            {
                byte[] temp1 = new byte[16];
                for (int i = 0; i < 16; i++)
                {
                    temp1[i] = answer[i];
                }
                text_out.Text += BitConverter.ToString(temp1, 0);
            }
            else
            {
                text_out.Text += BitConverter.ToString(answer, 0);
            }
            hashBuf = text_out.Text;

            //Режим электронной подписи RSA
            if (electronicSign_RSA)
            {
                text_out.Clear();
                p = BigInteger.Parse(pNumbers.GeneratePrime(50));
                q = BigInteger.Parse(pNumbers.GeneratePrime(50));
                while (p == q)
                {
                    q = BigInteger.Parse(pNumbers.GeneratePrime(50));
                }
                n = p * q;
                euler = (p - 1) * (q - 1);
                exp = rsa.GetExp(euler, p);
                d = basicMath.Find_Inversion(exp, euler);

                s = basicMath.Find_ModularExpo(md51, d, n);
                answer = s.ToByteArray();
                text_out.Text += BitConverter.ToString(answer, 0);
            }

            //Режим электронной подписи по Эль Гамалю
            if (electronicSign_ElGamal)
            {
                text_out.Clear();

                p = BigInteger.Parse(pNumbers.GeneratePrime(60));
                g = 0;

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

                    if (g < p - 1 && basicMath.Find_ModularExpo(g, rnd.Next(1, int.MaxValue), p) != 1)
                    {
                        isOk = true;
                    }
                }

                x = rnd.Next(2, int.MaxValue);
                y = basicMath.Find_ModularExpo(g, x, p);
                while (basicMath.Find_GCD(k, p - 1) != 1)
                {
                    k = rnd.Next(2, int.MaxValue);
                }

                r = basicMath.Find_ModularExpo(g, k, p); // Вычисляем r
                BigInteger u = (md51 - x * r) % (p - 1);
                s = (basicMath.Find_Inversion(k, p - 1) * u) % (p - 1);
                text_out.Text += BitConverter.ToString(r.ToByteArray(), 0) + BitConverter.ToString(s.ToByteArray(), 0); 
            }

            text_out.Text = text_out.Text.Replace("-", "");
            text_out.Text = text_out.Text.ToLower();

            if (text_out.Text == text_buffer.Text)
            {
                text_buffer.BackColor = Color.LimeGreen;
            }
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

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            panel1.BackgroundImage = KMZI_2.Properties.Resources.File_icon2;
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackgroundImage = KMZI_2.Properties.Resources.File_icon;
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

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            CloseFile();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
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

        // Кнопка для записи хэша в буфер
        private void button2_Click(object sender, EventArgs e)
        {
            text_buffer.Visible = true;
            text_buffer.Text = text_out.Text;
            button3.Visible = true;                    

            if(electronicSign_RSA || electronicSign_ElGamal)
            {
                hasBuffer = true;
                button4.Visible = true;
                button5.Visible = true;
                md5Buf = md51;

                y_temp = y;
                g_temp = g;
                p_temp = p;
                r_temp = r;
                s_temp = s;
            }
        }

        // Кнопка очистки буфера
        private void button3_Click(object sender, EventArgs e)
        {
            text_buffer.BackColor = SystemColors.Control;
            text_buffer.Visible = false;
            text_buffer.Clear();
            button3.Visible = false;
            hasBuffer = false;
            button4.Visible = false;
            button5.Visible = false;
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

        private void справкаToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            if (info == null || info.IsDisposed)
            {
                info = new MD5_info();
                info.Show();
            }
            else
            {
                info.Activate();
            }
        }

        private void эПRSAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            electronicSign_RSA = true;
            electronicSign_ElGamal = false;
            label3.Text = "Режим ЭП RSA";
            button4.Visible = false;
            button5.Visible = false;
        }

        private void хэшMD5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            electronicSign_RSA = false;
            electronicSign_ElGamal = false;
            label3.Text = "Режим MD5";
            if (hasBuffer)
            {
                button4.Visible = true;
                button5.Visible = true;
            }
        }
        private void эПЭльГамаляToolStripMenuItem_Click(object sender, EventArgs e)
        {
            electronicSign_ElGamal = true;
            electronicSign_RSA = false;
            label3.Text = "Режим ЭП Эль Гамаля";
            button4.Visible = false;
            button5.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string moreInfo = "";

            if (electronicSign_RSA)
            {
                moreInfo = String.Format("p = {0},\n q = {1},\n n = {2},\n euler = {3},\n exp = {4},\n Hash = {5}",
                                p.ToString(), q.ToString(), n.ToString(), euler.ToString(), exp.ToString(), hashBuf.ToString());
            }
            if (electronicSign_ElGamal)
            {
            //    moreInfo = String.Format("p = {0},\n q = {1},\n g = {2},\n cb = {3},\n db = {4},\n k = {5},\n r = {6},\n exp = {7},\n Hash = {8}",
            }

            MessageBox.Show(moreInfo, "Содержимое буфера", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BigInteger result = 0;

            if (electronicSign_RSA)
            {
                if (hasBuffer)
                {
                    if (md5Buf != 0 && md51 != 0 && s != 0)
                    {
                        result = basicMath.Find_ModularExpo(s, exp, n);

                        if (result == md5Buf)
                        {
                            MessageBox.Show("Целостность данных подтверждена", "Проверка пройдена",
                                            MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Исходные данные были изменены", "Проверка не пройдена",
                                            MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        }
                    }
                }
            }

            if (electronicSign_ElGamal)
            {
                if (hasBuffer)
                {
                    if (md5Buf != 0 && md51 != 0)
                    {
                        if (basicMath.Find_ModularExpo(y_temp, r_temp, p_temp) * basicMath.Find_ModularExpo(r_temp, s_temp, p_temp) % p_temp == basicMath.Find_ModularExpo(g_temp, md51, p_temp))
                        {
                            MessageBox.Show("Целостность данных подтверждена", "Проверка пройдена",
                                            MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Исходные данные были изменены", "Проверка не пройдена",
                                            MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }       
    }
}
