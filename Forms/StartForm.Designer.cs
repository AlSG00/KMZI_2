namespace KMZI_2
{
    partial class StartForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_basicTheory = new System.Windows.Forms.Button();
            this.button_RSA = new System.Windows.Forms.Button();
            this.button_Shamir = new System.Windows.Forms.Button();
            this.button_DiMan = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_exit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_SecretChat = new System.Windows.Forms.Button();
            this.button_epGOST = new System.Windows.Forms.Button();
            this.button_ElGamal = new System.Windows.Forms.Button();
            this.button_gost = new System.Windows.Forms.Button();
            this.button_sha = new System.Windows.Forms.Button();
            this.button_md5 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_basicTheory
            // 
            this.button_basicTheory.Location = new System.Drawing.Point(6, 19);
            this.button_basicTheory.Name = "button_basicTheory";
            this.button_basicTheory.Size = new System.Drawing.Size(196, 23);
            this.button_basicTheory.TabIndex = 0;
            this.button_basicTheory.Text = "Базовая теория чисел";
            this.button_basicTheory.UseVisualStyleBackColor = true;
            this.button_basicTheory.Click += new System.EventHandler(this.button_basicTheory_Click);
            // 
            // button_RSA
            // 
            this.button_RSA.Location = new System.Drawing.Point(6, 48);
            this.button_RSA.Name = "button_RSA";
            this.button_RSA.Size = new System.Drawing.Size(196, 23);
            this.button_RSA.TabIndex = 1;
            this.button_RSA.Text = "RSA";
            this.button_RSA.UseVisualStyleBackColor = true;
            this.button_RSA.Click += new System.EventHandler(this.button_RSA_Click);
            // 
            // button_Shamir
            // 
            this.button_Shamir.Location = new System.Drawing.Point(6, 106);
            this.button_Shamir.Name = "button_Shamir";
            this.button_Shamir.Size = new System.Drawing.Size(196, 23);
            this.button_Shamir.TabIndex = 2;
            this.button_Shamir.Text = "Шамир";
            this.button_Shamir.UseVisualStyleBackColor = true;
            this.button_Shamir.Click += new System.EventHandler(this.button_Shamir_Click);
            // 
            // button_DiMan
            // 
            this.button_DiMan.Location = new System.Drawing.Point(6, 77);
            this.button_DiMan.Name = "button_DiMan";
            this.button_DiMan.Size = new System.Drawing.Size(196, 23);
            this.button_DiMan.TabIndex = 3;
            this.button_DiMan.Text = "Диффи-Хеллман";
            this.button_DiMan.UseVisualStyleBackColor = true;
            this.button_DiMan.Click += new System.EventHandler(this.button_DiMan_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(236, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // button_exit
            // 
            this.button_exit.Location = new System.Drawing.Point(19, 347);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(196, 23);
            this.button_exit.TabIndex = 0;
            this.button_exit.Text = "Выход";
            this.button_exit.UseVisualStyleBackColor = true;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_SecretChat);
            this.groupBox1.Controls.Add(this.button_epGOST);
            this.groupBox1.Controls.Add(this.button_ElGamal);
            this.groupBox1.Controls.Add(this.button_gost);
            this.groupBox1.Controls.Add(this.button_sha);
            this.groupBox1.Controls.Add(this.button_md5);
            this.groupBox1.Controls.Add(this.button_basicTheory);
            this.groupBox1.Controls.Add(this.button_DiMan);
            this.groupBox1.Controls.Add(this.button_Shamir);
            this.groupBox1.Controls.Add(this.button_RSA);
            this.groupBox1.Location = new System.Drawing.Point(13, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 313);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // button_SecretChat
            // 
            this.button_SecretChat.Location = new System.Drawing.Point(6, 280);
            this.button_SecretChat.Name = "button_SecretChat";
            this.button_SecretChat.Size = new System.Drawing.Size(196, 23);
            this.button_SecretChat.TabIndex = 11;
            this.button_SecretChat.Text = "Секретный чат";
            this.button_SecretChat.UseVisualStyleBackColor = true;
            this.button_SecretChat.Click += new System.EventHandler(this.button_SecretChat_Click);
            // 
            // button_epGOST
            // 
            this.button_epGOST.Location = new System.Drawing.Point(6, 251);
            this.button_epGOST.Name = "button_epGOST";
            this.button_epGOST.Size = new System.Drawing.Size(196, 23);
            this.button_epGOST.TabIndex = 10;
            this.button_epGOST.Text = "ЭП ГОСТ и FIPS";
            this.button_epGOST.UseVisualStyleBackColor = true;
            this.button_epGOST.Click += new System.EventHandler(this.button_epGOST_Click);
            // 
            // button_ElGamal
            // 
            this.button_ElGamal.Location = new System.Drawing.Point(6, 135);
            this.button_ElGamal.Name = "button_ElGamal";
            this.button_ElGamal.Size = new System.Drawing.Size(196, 23);
            this.button_ElGamal.TabIndex = 9;
            this.button_ElGamal.Text = "Эль-Гамаль";
            this.button_ElGamal.UseVisualStyleBackColor = true;
            this.button_ElGamal.Click += new System.EventHandler(this.button_ElGamal_Click);
            // 
            // button_gost
            // 
            this.button_gost.Location = new System.Drawing.Point(6, 222);
            this.button_gost.Name = "button_gost";
            this.button_gost.Size = new System.Drawing.Size(196, 23);
            this.button_gost.TabIndex = 6;
            this.button_gost.Text = "ГОСТ";
            this.button_gost.UseVisualStyleBackColor = true;
            this.button_gost.Click += new System.EventHandler(this.button_gost_Click);
            // 
            // button_sha
            // 
            this.button_sha.Location = new System.Drawing.Point(6, 193);
            this.button_sha.Name = "button_sha";
            this.button_sha.Size = new System.Drawing.Size(196, 23);
            this.button_sha.TabIndex = 5;
            this.button_sha.Text = "SHA";
            this.button_sha.UseVisualStyleBackColor = true;
            this.button_sha.Click += new System.EventHandler(this.button_sha_Click);
            // 
            // button_md5
            // 
            this.button_md5.Location = new System.Drawing.Point(6, 164);
            this.button_md5.Name = "button_md5";
            this.button_md5.Size = new System.Drawing.Size(196, 23);
            this.button_md5.TabIndex = 4;
            this.button_md5.Text = "MD5 и ЭП";
            this.button_md5.UseVisualStyleBackColor = true;
            this.button_md5.Click += new System.EventHandler(this.button_md5_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 387);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "StartForm";
            this.Text = "KMZI 2";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_basicTheory;
        private System.Windows.Forms.Button button_RSA;
        private System.Windows.Forms.Button button_Shamir;
        private System.Windows.Forms.Button button_DiMan;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_SecretChat;
        private System.Windows.Forms.Button button_epGOST;
        private System.Windows.Forms.Button button_ElGamal;
        private System.Windows.Forms.Button button_gost;
        private System.Windows.Forms.Button button_sha;
        private System.Windows.Forms.Button button_md5;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
    }
}