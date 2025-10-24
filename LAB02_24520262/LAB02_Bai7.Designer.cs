namespace LAB02_24520262
{
    partial class LAB02_Bai7
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
            treeView1 = new TreeView();
            pictureBox1 = new PictureBox();
            richTextBox1 = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // treeView1
            // 
            treeView1.BackColor = Color.Wheat;
            treeView1.Font = new Font("Cascadia Code SemiBold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            treeView1.Location = new Point(12, 12);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(221, 738);
            treeView1.TabIndex = 0;
            treeView1.AfterSelect += treeView1_AfterSelect;
            treeView1.MouseDoubleClick += treeView1_MouseDoubleClick;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(239, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1031, 739);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.OldLace;
            richTextBox1.Font = new Font("Cascadia Code SemiBold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            richTextBox1.Location = new Point(239, 13);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(1031, 738);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "";
            // 
            // LAB02_Bai7
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AntiqueWhite;
            ClientSize = new Size(1282, 763);
            Controls.Add(richTextBox1);
            Controls.Add(pictureBox1);
            Controls.Add(treeView1);
            Name = "LAB02_Bai7";
            Text = "Bài7 - Duyet thu muc";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TreeView treeView1;
        private PictureBox pictureBox1;
        private RichTextBox richTextBox1;
    }
}