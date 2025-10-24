namespace LAB02_24520262
{
    partial class LAB02_Bai1
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
            button1 = new Button();
            button2 = new Button();
            richTextBox1 = new RichTextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.OldLace;
            button1.Font = new Font("Cascadia Code", 10.8F);
            button1.ForeColor = Color.DarkRed;
            button1.Location = new Point(79, 75);
            button1.Name = "button1";
            button1.Size = new Size(200, 50);
            button1.TabIndex = 0;
            button1.Text = "Đọc file";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // button2
            // 
            button2.BackColor = Color.OldLace;
            button2.Font = new Font("Cascadia Code", 10.8F);
            button2.ForeColor = Color.DarkRed;
            button2.Location = new Point(79, 172);
            button2.Name = "button2";
            button2.Size = new Size(200, 50);
            button2.TabIndex = 1;
            button2.Text = "Ghi file";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.OldLace;
            richTextBox1.Font = new Font("Cascadia Code", 10.8F);
            richTextBox1.ForeColor = Color.DarkRed;
            richTextBox1.Location = new Point(402, 75);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(537, 147);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // LAB02_Bai1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AntiqueWhite;
            ClientSize = new Size(1036, 309);
            Controls.Add(richTextBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "LAB02_Bai1";
            Text = "Bai1 - Ghi va Doc file";
            Load += LAB02_Bai1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private RichTextBox richTextBox1;
    }
}
