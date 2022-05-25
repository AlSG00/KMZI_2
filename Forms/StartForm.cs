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

           
            button_epGOST.Enabled = true;
            button_SecretChat.Enabled = true;
        }

        NumberTheory numTheory;
        RSA rsa;
        Diffi_Hellman diMan;
        Shamir shamir;
        ElGamal elgamal;
        MD5 md5;
        SHA sha;
        GOST gost;
        EpGOST epGOST;
        SecretChat secretChat;

        // Базовые алгоритмы теории чисел
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

        // Шифр RSA
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

        // Протокол Диффи-Хеллмана
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

        // Шифр Шамира
        private void button_Shamir_Click(object sender, EventArgs e)
        {
            if (shamir == null || shamir.IsDisposed)
            {
                shamir = new Shamir();
                shamir.Show();
            }
            else
            {
                shamir.Activate();
            }
        }

        // Шифр Эль-Гамаля
        private void button_ElGamal_Click(object sender, EventArgs e)
        {
            if (elgamal == null || elgamal.IsDisposed)
            {
                elgamal = new ElGamal();
                elgamal.Show();
            }
            else
            {
                elgamal.Activate();
            }
        }

        // Хеширование MD5
        private void button_md5_Click(object sender, EventArgs e)
        {
            if (md5 == null || md5.IsDisposed)
            {
                md5 = new MD5();
                md5.Show();
            }
            else
            {
                md5.Activate();
            }
        }

        // Хеширование SHA
        private void button_sha_Click(object sender, EventArgs e)
        {
            if (sha == null || sha.IsDisposed)
            {
                sha = new SHA();
                sha.Show();
            }
            else
            {
                sha.Activate();
            }
        }

        // Хеширование ГОСТ
        private void button_gost_Click(object sender, EventArgs e)
        {
            if (gost == null || gost.IsDisposed)
            {
                gost = new GOST();
                gost.Show();
            }
            else
            {
                gost.Activate();
            }
        }

        // ЭП ГОСТ и FIPS
        private void button_epGOST_Click(object sender, EventArgs e)
        {
            if (epGOST == null || epGOST.IsDisposed)
            {
                epGOST = new EpGOST();
                epGOST.Show();
            }
            else
            {
                epGOST.Activate();
            }
        }

        // Секретный чат
        private void button_SecretChat_Click(object sender, EventArgs e)
        {
            if (secretChat == null || secretChat.IsDisposed)
            {
                secretChat = new SecretChat();
                secretChat.Show();
            }
            else
            {
                secretChat.Activate();
            }
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
