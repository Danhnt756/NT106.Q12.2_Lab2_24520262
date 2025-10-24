namespace LAB02_24520262
{
    partial class LAB02_Bai6
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
            tableLayoutPanel1 = new TableLayoutPanel();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            richTextBox1 = new RichTextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.OldLace;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.Font = new Font("Cascadia Code", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tableLayoutPanel1.ForeColor = Color.DarkRed;
            tableLayoutPanel1.Location = new Point(79, 338);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(900, 200);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = Color.OldLace;
            button1.Font = new Font("Cascadia Code", 10.8F);
            button1.ForeColor = Color.DarkRed;
            button1.Location = new Point(79, 110);
            button1.Name = "button1";
            button1.Size = new Size(130, 50);
            button1.TabIndex = 1;
            button1.Text = "Tìm kiếm";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.OldLace;
            pictureBox1.Location = new Point(779, 110);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(200, 200);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.OldLace;
            richTextBox1.Font = new Font("Cascadia Code", 10.8F);
            richTextBox1.ForeColor = Color.DarkRed;
            richTextBox1.Location = new Point(79, 166);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(600, 100);
            richTextBox1.TabIndex = 4;
            richTextBox1.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cascadia Code", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkRed;
            label1.Location = new Point(385, 9);
            label1.Name = "label1";
            label1.Size = new Size(320, 45);
            label1.TabIndex = 6;
            label1.Text = "Hôm nay ăn gì ?";
            // 
            // LAB02_Bai6
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AntiqueWhite;
            ClientSize = new Size(1075, 574);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(richTextBox1);
            Controls.Add(button1);
            Controls.Add(tableLayoutPanel1);
            Name = "LAB02_Bai6";
            Text = "Bai6 - Hom nay an gi";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button button1;
        private PictureBox pictureBox1;
        private RichTextBox richTextBox1;
        private Label label1;
    }
}