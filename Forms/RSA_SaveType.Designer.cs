namespace KMZI_2
{
    partial class RSA_SaveType
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
            this.button_encoded = new System.Windows.Forms.Button();
            this.button_decoded = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_encoded
            // 
            this.button_encoded.Location = new System.Drawing.Point(162, 72);
            this.button_encoded.Name = "button_encoded";
            this.button_encoded.Size = new System.Drawing.Size(125, 23);
            this.button_encoded.TabIndex = 0;
            this.button_encoded.Text = "Шифртекст";
            this.button_encoded.UseVisualStyleBackColor = true;
            this.button_encoded.Click += new System.EventHandler(this.button_encoded_Click);
            // 
            // button_decoded
            // 
            this.button_decoded.Location = new System.Drawing.Point(12, 72);
            this.button_decoded.Name = "button_decoded";
            this.button_decoded.Size = new System.Drawing.Size(125, 23);
            this.button_decoded.TabIndex = 1;
            this.button_decoded.Text = "открытый текст";
            this.button_decoded.UseVisualStyleBackColor = true;
            this.button_decoded.Click += new System.EventHandler(this.button_decoded_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выберите тип данных";
            // 
            // RSA_SaveType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 110);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_decoded);
            this.Controls.Add(this.button_encoded);
            this.Name = "RSA_SaveType";
            this.Text = "Сохранить";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_encoded;
        private System.Windows.Forms.Button button_decoded;
        private System.Windows.Forms.Label label1;
    }
}