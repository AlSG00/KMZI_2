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
    public partial class NumberTheory : Form
    {
        public NumberTheory()
        {
            InitializeComponent();

            panel1.Enabled = false;
            button_Calculate.Enabled = false;

            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;

            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
            label4.Text = "";

            //BasicNumberTheoryMath basicMath = new BasicNumberTheoryMath();
        }

       public BasicNumberTheoryMath basicMath = new BasicNumberTheoryMath();

        private void button_Calculate_Click(object sender, EventArgs e)
        {
            switch(comboBox_Algorithms.SelectedIndex)
            {
                case 0:
                    Perform_ModularExpo();
                    break;

                case 1:
                    Perform_GCD();
                    break;

                case 2:
                    Perform_Inversion();
                    break;
            }
        }

        private void Perform_ModularExpo()
        {
            if (BigInteger.TryParse(textBox1.Text, out BigInteger a) && a > 0)
            {
                if (BigInteger.TryParse(textBox2.Text, out BigInteger x) /*&& x > 0*/)
                {
                    if (BigInteger.TryParse(textBox3.Text, out BigInteger p) && p > 0)
                    {
                        if (x < 0)
                        {
                            if (basicMath.Find_GCD(x, p) == 1)
                            {
                                textBox_Answer.Text = Convert.ToString(basicMath.Find_ModularExpo(a, x, p));
                            }
                            else
                            {
                                MessageBox.Show("Основание и модуль н еявляются взаимно простыми", "Ошибка", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            textBox_Answer.Text = Convert.ToString(basicMath.Find_ModularExpo(a, x, p));
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неверный формат третьего числа", "Ошибка", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Неверный формат второго числа", "Ошибка", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Неверный формат первого числа", "Ошибка", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void Perform_GCD()
        {
            if (BigInteger.TryParse(textBox1.Text, out BigInteger a))
            {
                if (BigInteger.TryParse(textBox2.Text, out BigInteger b))
                {
                    textBox_Answer.Text = Convert.ToString(basicMath.Find_GCD(a, b));
                }
                else
                {
                    MessageBox.Show("Неверный формат второго числа", "Ошибка", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Неверный формат первого числа", "Ошибка", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void Perform_Inversion()
        {
            if (BigInteger.TryParse(textBox1.Text, out BigInteger x) && x > 0)
            {
                if (BigInteger.TryParse(textBox2.Text, out BigInteger p) && p > 0)
                {
                    if (basicMath.Find_GCD(x, p) == 1)
                    {
                        textBox_Answer.Text = Convert.ToString(basicMath.Find_Inversion(x, p));
                    }
                    else
                    {
                        MessageBox.Show("Основание и модуль не являются взаимно простыми", "Ошибка", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Неверный формат второго числа", "Ошибка", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Неверный формат первого числа", "Ошибка", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            if(textBox2.Visible == true)
            {
                textBox3.Clear();
            }
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBox_Algorithms_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            button_Calculate.Enabled = true;
            button_Clear.Enabled = true;

            label1.Visible = true;
            label2.Visible = true;
            label4.Visible = true;

            switch(comboBox_Algorithms.SelectedIndex)
            {
                case 0: // Степень по модулю
                    label3.Visible = true;
                    textBox3.Visible = true;
                    label1.Text = "a:";
                    label2.Text = "x:";
                    label3.Text = "p:";
                    label4.Text = "a^x mod p";
                    break;

                case 1: // НОД
                    label3.Visible = false;
                    textBox3.Visible = false;
                    label1.Text = "a:";
                    label2.Text = "b:";
                    label4.Text = "НОД (a,b)";
                    break;

                case 2: // Инверсия
                    label3.Visible = false;
                    textBox3.Visible = false;
                    label1.Text = "x:";
                    label2.Text = "p:";
                    label4.Text = "x^(-1) mod p";
                    break;

                default:
                    panel1.Enabled = false;
                    label1.Text = "";
                    label2.Text = "";
                    label3.Text = "";
                    label4.Text = "";                  
                    break;

            }
        }
    }
}
