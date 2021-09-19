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
    public partial class Diffi_Hellman : Form
    {
        public Diffi_Hellman()
        {
            InitializeComponent();

            button_genRandom.Enabled = false;
            button_genKey.Enabled = false;
        }

        PrimeNumbers pNumbers = new PrimeNumbers();
        BasicNumberTheoryMath basicMath = new BasicNumberTheoryMath();

        private void button_genRandom_Click(object sender, EventArgs e)
        {
            textBox.Text = pNumbers.GeneratePrime(Convert.ToInt32(text_length.Text));
        }

        private void button_genKey_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            BigInteger q = BigInteger.Parse(textBox.Text);
            BigInteger p = 2 * q + 1;
            BigInteger g = 0;

            //сначала сделаем p, q, g
            bool isPrime = false;
            while (!isPrime)
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
                    isPrime = true;
                }
            }

            //Делаем случайныйе большие числа
            BigInteger Xa = BigInteger.Parse(pNumbers.GeneratePrime(10));
            BigInteger Xb = BigInteger.Parse(pNumbers.GeneratePrime(10));

            BigInteger Ya = basicMath.Find_ModularExpo(q, Xa, p);
            BigInteger Yb = basicMath.Find_ModularExpo(q, Xb, p);

            BigInteger Zab = basicMath.Find_ModularExpo(Yb, Xa, p);
            BigInteger Zba = basicMath.Find_ModularExpo(Ya, Xb, p);

            text_p.Text = p.ToString();
            text_q.Text = q.ToString();
            text_g.Text = g.ToString();
            text_Xa.Text = Xa.ToString();
            text_Xb.Text = Xb.ToString();
            text_Ya.Text = Ya.ToString();
            text_Yb.Text = Yb.ToString();
            text_Zab.Text = Zab.ToString();
            text_Zba.Text = Zba.ToString();
        }

        private void button_clearAll_Click(object sender, EventArgs e)
        {
            text_length.Clear();
            textBox.Clear();
            text_p.Clear();
            text_q.Clear();
            text_g.Clear();
            text_Xa.Clear();
            text_Xb.Clear();
            text_Ya.Clear();
            text_Yb.Clear();
            text_Zab.Clear();
            text_Zba.Clear();
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void text_length_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < text_length.TextLength; i++)
            {
                if (!Char.IsDigit(text_length.Text[i]))
                {
                    text_length.Text = text_length.Text.Replace(text_length.Text[i].ToString(), "");
                }
            }

            if (text_length.TextLength > 3 || text_length.TextLength < 2)
            {
                button_genRandom.Enabled = false;
            }
            else
            {
                button_genRandom.Enabled = true;
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < textBox.TextLength; i++)
            {
                if (!Char.IsDigit(textBox.Text[i]))
                {
                    textBox.Text = textBox.Text.Replace(textBox.Text[i].ToString(), "");
                }
            }

            if (textBox.TextLength > 1000 || textBox.TextLength < 10)
            {
                button_genKey.Enabled = false;
            }
            else
            {
                button_genKey.Enabled = true;
            }
        }
    }
}
