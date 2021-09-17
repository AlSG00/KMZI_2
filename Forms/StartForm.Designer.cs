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
            this.button3 = new System.Windows.Forms.Button();
            this.button_DiMan = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_exit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
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
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 106);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(196, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "***";
            this.button3.UseVisualStyleBackColor = true;
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
            this.button_exit.Location = new System.Drawing.Point(19, 420);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(196, 23);
            this.button_exit.TabIndex = 0;
            this.button_exit.Text = "Выход";
            this.button_exit.UseVisualStyleBackColor = true;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button13);
            this.groupBox1.Controls.Add(this.button12);
            this.groupBox1.Controls.Add(this.button11);
            this.groupBox1.Controls.Add(this.button10);
            this.groupBox1.Controls.Add(this.button9);
            this.groupBox1.Controls.Add(this.button8);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.button_basicTheory);
            this.groupBox1.Controls.Add(this.button_DiMan);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button_RSA);
            this.groupBox1.Location = new System.Drawing.Point(13, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 371);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(6, 338);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(196, 23);
            this.button13.TabIndex = 11;
            this.button13.Text = "***";
            this.button13.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(6, 309);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(196, 23);
            this.button12.TabIndex = 10;
            this.button12.Text = "***";
            this.button12.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(6, 135);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(196, 23);
            this.button11.TabIndex = 9;
            this.button11.Text = "***";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(6, 280);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(196, 23);
            this.button10.TabIndex = 8;
            this.button10.Text = "***";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(6, 251);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(196, 23);
            this.button9.TabIndex = 7;
            this.button9.Text = "***";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(6, 222);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(196, 23);
            this.button8.TabIndex = 6;
            this.button8.Text = "***";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(6, 193);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(196, 23);
            this.button7.TabIndex = 5;
            this.button7.Text = "***";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(6, 164);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(196, 23);
            this.button6.TabIndex = 4;
            this.button6.Text = "***";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 455);
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
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button_DiMan;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
    }
}