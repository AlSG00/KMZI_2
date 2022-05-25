namespace KMZI_2
{
    partial class Shamir
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
            this.text_p = new System.Windows.Forms.TextBox();
            this.button_OK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button_openFile = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button_start = new System.Windows.Forms.Button();
            this.text_third = new System.Windows.Forms.RichTextBox();
            this.text_second = new System.Windows.Forms.RichTextBox();
            this.text_first = new System.Windows.Forms.RichTextBox();
            this.text_out = new System.Windows.Forms.RichTextBox();
            this.text_in = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.button_generateP = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.text_db = new System.Windows.Forms.TextBox();
            this.text_Cb = new System.Windows.Forms.TextBox();
            this.text_da = new System.Windows.Forms.TextBox();
            this.text_Ca = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // text_p
            // 
            this.text_p.Location = new System.Drawing.Point(18, 47);
            this.text_p.Name = "text_p";
            this.text_p.ReadOnly = true;
            this.text_p.Size = new System.Drawing.Size(168, 20);
            this.text_p.TabIndex = 0;
            this.text_p.TextChanged += new System.EventHandler(this.text_p_TextChanged);
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(18, 73);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 1;
            this.button_OK.Text = "ОК";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.button_openFile);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button_start);
            this.groupBox1.Controls.Add(this.text_third);
            this.groupBox1.Controls.Add(this.text_second);
            this.groupBox1.Controls.Add(this.text_first);
            this.groupBox1.Controls.Add(this.text_out);
            this.groupBox1.Controls.Add(this.text_in);
            this.groupBox1.Location = new System.Drawing.Point(12, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(627, 422);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(23, 23);
            this.button3.TabIndex = 16;
            this.button3.Text = "C";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(148, 19);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(263, 23);
            this.progressBar1.TabIndex = 12;
            // 
            // button_openFile
            // 
            this.button_openFile.Location = new System.Drawing.Point(417, 19);
            this.button_openFile.Name = "button_openFile";
            this.button_openFile.Size = new System.Drawing.Size(96, 23);
            this.button_openFile.TabIndex = 11;
            this.button_openFile.Text = "Открыть...";
            this.button_openFile.UseVisualStyleBackColor = true;
            this.button_openFile.Click += new System.EventHandler(this.button_openFile_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(519, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Сохранить...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(35, 19);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(107, 23);
            this.button_start.TabIndex = 9;
            this.button_start.Text = "Преобразовать";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // text_third
            // 
            this.text_third.Location = new System.Drawing.Point(416, 172);
            this.text_third.Name = "text_third";
            this.text_third.ReadOnly = true;
            this.text_third.Size = new System.Drawing.Size(199, 118);
            this.text_third.TabIndex = 4;
            this.text_third.Text = "";
            // 
            // text_second
            // 
            this.text_second.Location = new System.Drawing.Point(211, 172);
            this.text_second.Name = "text_second";
            this.text_second.ReadOnly = true;
            this.text_second.Size = new System.Drawing.Size(199, 118);
            this.text_second.TabIndex = 3;
            this.text_second.Text = "";
            // 
            // text_first
            // 
            this.text_first.Location = new System.Drawing.Point(6, 172);
            this.text_first.Name = "text_first";
            this.text_first.ReadOnly = true;
            this.text_first.Size = new System.Drawing.Size(199, 118);
            this.text_first.TabIndex = 2;
            this.text_first.Text = "";
            // 
            // text_out
            // 
            this.text_out.Location = new System.Drawing.Point(6, 296);
            this.text_out.Name = "text_out";
            this.text_out.ReadOnly = true;
            this.text_out.Size = new System.Drawing.Size(609, 118);
            this.text_out.TabIndex = 1;
            this.text_out.Text = "";
            // 
            // text_in
            // 
            this.text_in.Location = new System.Drawing.Point(6, 48);
            this.text_in.Name = "text_in";
            this.text_in.Size = new System.Drawing.Size(609, 118);
            this.text_in.TabIndex = 0;
            this.text_in.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(655, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.toolStripSeparator1,
            this.сохранитьToolStripMenuItem,
            this.toolStripSeparator2,
            this.toolStripMenuItem1});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(130, 6);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(130, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(133, 22);
            this.toolStripMenuItem1.Text = "Выход";
            // 
            // button_generateP
            // 
            this.button_generateP.Location = new System.Drawing.Point(99, 73);
            this.button_generateP.Name = "button_generateP";
            this.button_generateP.Size = new System.Drawing.Size(87, 23);
            this.button_generateP.TabIndex = 6;
            this.button_generateP.Text = "Генерация";
            this.button_generateP.UseVisualStyleBackColor = true;
            this.button_generateP.Click += new System.EventHandler(this.button_generateP_Click);
            // 
            // button_clear
            // 
            this.button_clear.Location = new System.Drawing.Point(557, 47);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(70, 54);
            this.button_clear.TabIndex = 7;
            this.button_clear.Text = "Очистить всё";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(384, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Db";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(384, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Cb";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(207, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Da";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(207, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Ca";
            // 
            // text_db
            // 
            this.text_db.Location = new System.Drawing.Point(410, 81);
            this.text_db.Name = "text_db";
            this.text_db.ReadOnly = true;
            this.text_db.Size = new System.Drawing.Size(141, 20);
            this.text_db.TabIndex = 12;
            // 
            // text_Cb
            // 
            this.text_Cb.Location = new System.Drawing.Point(410, 47);
            this.text_Cb.Name = "text_Cb";
            this.text_Cb.ReadOnly = true;
            this.text_Cb.Size = new System.Drawing.Size(141, 20);
            this.text_Cb.TabIndex = 11;
            this.text_Cb.TextChanged += new System.EventHandler(this.text_Cb_TextChanged);
            // 
            // text_da
            // 
            this.text_da.Location = new System.Drawing.Point(234, 81);
            this.text_da.Name = "text_da";
            this.text_da.ReadOnly = true;
            this.text_da.Size = new System.Drawing.Size(141, 20);
            this.text_da.TabIndex = 10;
            // 
            // text_Ca
            // 
            this.text_Ca.Location = new System.Drawing.Point(234, 47);
            this.text_Ca.Name = "text_Ca";
            this.text_Ca.ReadOnly = true;
            this.text_Ca.Size = new System.Drawing.Size(141, 20);
            this.text_Ca.TabIndex = 9;
            this.text_Ca.TextChanged += new System.EventHandler(this.text_Ca_TextChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(531, 562);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Закрыть";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Shamir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 597);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_generateP);
            this.Controls.Add(this.text_db);
            this.Controls.Add(this.text_Cb);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.text_da);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.text_Ca);
            this.Controls.Add(this.text_p);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Shamir";
            this.Text = "Шамир";
            this.groupBox1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox text_p;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox text_in;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.Button button_generateP;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox text_db;
        private System.Windows.Forms.TextBox text_Cb;
        private System.Windows.Forms.TextBox text_da;
        private System.Windows.Forms.TextBox text_Ca;
        private System.Windows.Forms.RichTextBox text_out;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.RichTextBox text_third;
        private System.Windows.Forms.RichTextBox text_second;
        private System.Windows.Forms.RichTextBox text_first;
        private System.Windows.Forms.Button button_openFile;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Button button3;
    }
}