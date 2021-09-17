using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KMZI_2
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();

            button_basicTheory.Enabled = true;
            button_RSA.Enabled = true;
            button_DiMan.Enabled = true;
            button3.Enabled = false;
            button11.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;
            button12.Enabled = false;
            button13.Enabled = false;
        }

        NumberTheory numTheory;
        RSA rsa;
        Diffi_Hellman diMan;
        

        private void button_basicTheory_Click(object sender, EventArgs e)
        {
            if (numTheory == null || numTheory.IsDisposed)
            {
                numTheory = new NumberTheory();
                numTheory.Show();
            }
            else
            {
                numTheory.Activate();
            }
        }

        private void button_RSA_Click(object sender, EventArgs e)
        {
            if (rsa == null || rsa.IsDisposed)
            {
                rsa = new RSA();
                rsa.Show();
            }
            else
            {
                rsa.Activate();
            }
        }

        private void button_DiMan_Click(object sender, EventArgs e)
        {
            if (diMan == null || diMan.IsDisposed)
            {
                diMan = new Diffi_Hellman();
                diMan.Show();
            }
            else
            {
                diMan.Activate();
            }
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
