using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB02_24520262
{
    public partial class LAB02_Bai2 : Form
    {
        public LAB02_Bai2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofd.SafeFileName;

                textBox3.Text = ofd.FileName;

                string text = System.IO.File.ReadAllText(ofd.FileName);
                richTextBox1.Text = text;

                long size = new System.IO.FileInfo(ofd.FileName).Length;
                textBox2.Text = size.ToString() + " bytes";

                string[] lines = text.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                textBox4.Text = lines.Length.ToString();

                string[] words = text.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                textBox5.Text = words.Length.ToString();

                textBox6.Text = text.Length.ToString();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
