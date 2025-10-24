using System.IO;

namespace LAB02_24520262
{
    public partial class LAB02_Bai1 : Form
    {
        public LAB02_Bai1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string text = richTextBox1.Text;
            text = text.ToUpper();
            richTextBox1.Text = text;
            string path = "output1.txt";

            try
            {
                System.IO.File.WriteAllText(path, text);
                MessageBox.Show("Đã ghi dữ liệu vào file " + path, "Thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi ghi file: " + ex.Message);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                //tên file cùng với file exe
                string path = "input1.txt";

                if (!File.Exists(path))
                {
                    MessageBox.Show("File không tồn tại!");
                    return;
                }

                using (StreamReader sr = new StreamReader(path))
                {
                    string content = sr.ReadToEnd();
                    richTextBox1.Text = content;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("$Lỗi khi đọc file: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string xt = richTextBox1.Text;
            xt = xt.ToUpper();
            richTextBox1.Text = xt;
        }

        private void LAB02_Bai1_Load(object sender, EventArgs e)
        {

        }
    }
}
