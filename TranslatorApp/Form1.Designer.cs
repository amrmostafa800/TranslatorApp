namespace TranslatorApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            BtnTranslate = new Button();
            BtnClear = new Button();
            SuspendLayout();
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 233);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.RightToLeft = RightToLeft.Yes;
            textBox2.Size = new Size(492, 205);
            textBox2.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 12);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(492, 205);
            textBox1.TabIndex = 1;
            // 
            // BtnTranslate
            // 
            BtnTranslate.Location = new Point(627, 194);
            BtnTranslate.Name = "BtnTranslate";
            BtnTranslate.Size = new Size(75, 23);
            BtnTranslate.TabIndex = 3;
            BtnTranslate.Text = "Translate";
            BtnTranslate.UseVisualStyleBackColor = true;
            BtnTranslate.Click += BtnTranslate_Click;
            // 
            // BtnClear
            // 
            BtnClear.Location = new Point(627, 249);
            BtnClear.Name = "BtnClear";
            BtnClear.Size = new Size(75, 23);
            BtnClear.TabIndex = 4;
            BtnClear.Text = "Clear";
            BtnClear.UseVisualStyleBackColor = true;
            BtnClear.Click += BtnClear_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BtnClear);
            Controls.Add(BtnTranslate);
            Controls.Add(textBox1);
            Controls.Add(textBox2);
            Name = "Form1";
            Text = "Translator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox2;
        private TextBox textBox1;
        private Button BtnTranslate;
        private Button BtnClear;
    }
}