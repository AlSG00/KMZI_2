namespace KMZI_2
{
    partial class Diffi_Hellman
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
            this.textBox = new System.Windows.Forms.TextBox();
            this.button_genKey = new System.Windows.Forms.Button();
            this.text_p = new System.Windows.Forms.TextBox();
            this.text_q = new System.Windows.Forms.TextBox();
            this.text_g = new System.Windows.Forms.TextBox();
            this.text_Xa = new System.Windows.Forms.TextBox();
            this.text_Xb = new System.Windows.Forms.TextBox();
            this.text_Ya = new System.Windows.Forms.TextBox();
            this.text_Yb = new System.Windows.Forms.TextBox();
            this.text_Zab = new System.Windows.Forms.TextBox();
            this.text_Zba = new System.Windows.Forms.TextBox();
            this.button_genRandom = new System.Windows.Forms.Button();
            this.button_close = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_clearAll = new System.Windows.Forms.Button();
            this.text_length = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(79, 19);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(141, 20);
            this.textBox.TabIndex = 0;
            this.textBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // button_genKey
            // 
            this.button_genKey.Location = new System.Drawing.Point(226, 17);
            this.button_genKey.Name = "button_genKey";
            this.button_genKey.Size = new System.Drawing.Size(38, 23);
            this.button_genKey.TabIndex = 1;
            this.button_genKey.Text = "ОК";
            this.button_genKey.UseVisualStyleBackColor = true;
            this.button_genKey.Click += new System.EventHandler(this.button_genKey_Click);
            // 
            // text_p
            // 
            this.text_p.Location = new System.Drawing.Point(28, 19);
            this.text_p.Name = "text_p";
            this.text_p.ReadOnly = true;
            this.text_p.Size = new System.Drawing.Size(141, 20);
            this.text_p.TabIndex = 2;
            // 
            // text_q
            // 
            this.text_q.Location = new System.Drawing.Point(191, 19);
            this.text_q.Name = "text_q";
            this.text_q.ReadOnly = true;
            this.text_q.Size = new System.Drawing.Size(141, 20);
            this.text_q.TabIndex = 3;
            // 
            // text_g
            // 
            this.text_g.Location = new System.Drawing.Point(360, 19);
            this.text_g.Name = "text_g";
            this.text_g.ReadOnly = true;
            this.text_g.Size = new System.Drawing.Size(147, 20);
            this.text_g.TabIndex = 4;
            // 
            // text_Xa
            // 
            this.text_Xa.Location = new System.Drawing.Point(31, 19);
            this.text_Xa.Name = "text_Xa";
            this.text_Xa.ReadOnly = true;
            this.text_Xa.Size = new System.Drawing.Size(211, 20);
            this.text_Xa.TabIndex = 5;
            // 
            // text_Xb
            // 
            this.text_Xb.Location = new System.Drawing.Point(296, 19);
            this.text_Xb.Name = "text_Xb";
            this.text_Xb.ReadOnly = true;
            this.text_Xb.Size = new System.Drawing.Size(211, 20);
            this.text_Xb.TabIndex = 6;
            // 
            // text_Ya
            // 
            this.text_Ya.Location = new System.Drawing.Point(31, 45);
            this.text_Ya.Name = "text_Ya";
            this.text_Ya.ReadOnly = true;
            this.text_Ya.Size = new System.Drawing.Size(211, 20);
            this.text_Ya.TabIndex = 7;
            // 
            // text_Yb
            // 
            this.text_Yb.Location = new System.Drawing.Point(296, 45);
            this.text_Yb.Name = "text_Yb";
            this.text_Yb.ReadOnly = true;
            this.text_Yb.Size = new System.Drawing.Size(211, 20);
            this.text_Yb.TabIndex = 8;
            // 
            // text_Zab
            // 
            this.text_Zab.Location = new System.Drawing.Point(31, 71);
            this.text_Zab.Name = "text_Zab";
            this.text_Zab.ReadOnly = true;
            this.text_Zab.Size = new System.Drawing.Size(211, 20);
            this.text_Zab.TabIndex = 9;
            // 
            // text_Zba
            // 
            this.text_Zba.Location = new System.Drawing.Point(296, 71);
            this.text_Zba.Name = "text_Zba";
            this.text_Zba.ReadOnly = true;
            this.text_Zba.Size = new System.Drawing.Size(211, 20);
            this.text_Zba.TabIndex = 10;
            // 
            // button_genRandom
            // 
            this.button_genRandom.Location = new System.Drawing.Point(270, 17);
            this.button_genRandom.Name = "button_genRandom";
            this.button_genRandom.Size = new System.Drawing.Size(75, 23);
            this.button_genRandom.TabIndex = 11;
            this.button_genRandom.Text = "Генерация";
            this.button_genRandom.UseVisualStyleBackColor = true;
            this.button_genRandom.Click += new System.EventHandler(this.button_genRandom_Click);
            // 
            // button_close
            // 
            this.button_close.Location = new System.Drawing.Point(444, 281);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(75, 23);
            this.button_close.TabIndex = 12;
            this.button_close.Text = "Закрыть";
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "p:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.text_p);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.text_q);
            this.groupBox1.Controls.Add(this.text_g);
            this.groupBox1.Location = new System.Drawing.Point(12, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(525, 54);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(338, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "g:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "q:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.text_Xb);
            this.groupBox2.Controls.Add(this.text_Yb);
            this.groupBox2.Controls.Add(this.text_Zba);
            this.groupBox2.Controls.Add(this.text_Xa);
            this.groupBox2.Controls.Add(this.text_Zab);
            this.groupBox2.Controls.Add(this.text_Ya);
            this.groupBox2.Location = new System.Drawing.Point(12, 151);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(525, 109);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(267, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Zba:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Zab:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(267, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Yb:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Ya:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(267, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Xb:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Xa:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.text_length);
            this.groupBox3.Controls.Add(this.button_clearAll);
            this.groupBox3.Controls.Add(this.textBox);
            this.groupBox3.Controls.Add(this.button_genKey);
            this.groupBox3.Controls.Add(this.button_genRandom);
            this.groupBox3.Location = new System.Drawing.Point(12, 31);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(525, 54);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            // 
            // button_clearAll
            // 
            this.button_clearAll.Location = new System.Drawing.Point(351, 17);
            this.button_clearAll.Name = "button_clearAll";
            this.button_clearAll.Size = new System.Drawing.Size(23, 23);
            this.button_clearAll.TabIndex = 12;
            this.button_clearAll.Text = "С";
            this.button_clearAll.UseVisualStyleBackColor = true;
            this.button_clearAll.Click += new System.EventHandler(this.button_clearAll_Click);
            // 
            // text_length
            // 
            this.text_length.Location = new System.Drawing.Point(28, 19);
            this.text_length.Name = "text_length";
            this.text_length.Size = new System.Drawing.Size(45, 20);
            this.text_length.TabIndex = 13;
            this.text_length.TextChanged += new System.EventHandler(this.text_length_TextChanged);
            // 
            // Diffi_Hellman
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 316);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_close);
            this.Name = "Diffi_Hellman";
            this.Text = "Диффи-Хеллман";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button button_genKey;
        private System.Windows.Forms.TextBox text_p;
        private System.Windows.Forms.TextBox text_q;
        private System.Windows.Forms.TextBox text_g;
        private System.Windows.Forms.TextBox text_Xa;
        private System.Windows.Forms.TextBox text_Xb;
        private System.Windows.Forms.TextBox text_Ya;
        private System.Windows.Forms.TextBox text_Yb;
        private System.Windows.Forms.TextBox text_Zab;
        private System.Windows.Forms.TextBox text_Zba;
        private System.Windows.Forms.Button button_genRandom;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button_clearAll;
        private System.Windows.Forms.TextBox text_length;
    }
}