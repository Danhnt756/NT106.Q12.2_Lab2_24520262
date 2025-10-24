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
    public partial class LAB02 : Form
    {
        public LAB02()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LAB02_Bai5 f = new LAB02_Bai5();
            f.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LAB02_Bai6 f = new LAB02_Bai6();
            f.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            LAB02_Bai7 f = new LAB02_Bai7();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LAB02_Bai1 f = new LAB02_Bai1();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LAB02_Bai2 f = new LAB02_Bai2();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LAB02_Bai3 f = new LAB02_Bai3();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LAB02_Bai4 f = new LAB02_Bai4();
            f.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
