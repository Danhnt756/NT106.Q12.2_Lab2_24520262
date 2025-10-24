namespace LAB02_24520262
{
    partial class LAB02_Bai3
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
            richTextBox1 = new RichTextBox();
            button2 = new Button();
            button1 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.OldLace;
            richTextBox1.Font = new Font("Cascadia Code", 10.2F);
            richTextBox1.ForeColor = Color.SaddleBrown;
            richTextBox1.Location = new Point(390, 65);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(537, 147);
            richTextBox1.TabIndex = 5;
            richTextBox1.Text = "";
            // 
            // button2
            // 
            button2.BackColor = Color.OldLace;
            button2.Font = new Font("Cascadia Code", 10.2F);
            button2.ForeColor = Color.SaddleBrown;
            button2.Location = new Point(67, 162);
            button2.Name = "button2";
            button2.Size = new Size(200, 50);
            button2.TabIndex = 4;
            button2.Text = "Ghi file";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.OldLace;
            button1.Font = new Font("Cascadia Code", 10.2F);
            button1.ForeColor = Color.SaddleBrown;
            button1.Location = new Point(67, 65);
            button1.Name = "button1";
            button1.Size = new Size(200, 50);
            button1.TabIndex = 3;
            button1.Text = "Đọc file";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.OldLace;
            button3.Font = new Font("Cascadia Code", 10.2F);
            button3.ForeColor = Color.SaddleBrown;
            button3.Location = new Point(390, 218);
            button3.Name = "button3";
            button3.Size = new Size(135, 41);
            button3.TabIndex = 6;
            button3.Text = "Xóa";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // LAB02_Bai3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AntiqueWhite;
            ClientSize = new Size(1022, 293);
            Controls.Add(button3);
            Controls.Add(richTextBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "LAB02_Bai3";
            Text = "Bai3 - Doc, ghi file va tinh toan";
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox richTextBox1;
        private Button button2;
        private Button button1;
        private Button button3;
    }
}