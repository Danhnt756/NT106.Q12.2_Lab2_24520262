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
    public partial class LAB02_Bai3 : Form
    {
        public LAB02_Bai3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //tên file nằm cùng với file exe
                string path = "input3.txt";

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

        private void button2_Click(object sender, EventArgs e)
        {
            string pathOut = "output3.txt";
            // → Chỉ định nơi ghi kết quả, cố định cho dễ kiểm tra và không cần chọn lại mỗi lần.

            StringBuilder sb = new StringBuilder();
            // → Dùng StringBuilder để nối chuỗi hiệu quả hơn khi phải cộng nhiều dòng kết quả.

            foreach (string line in richTextBox1.Lines)
            {
                string trimmed = line.Trim();
                // → Loại bỏ khoảng trắng dư để tránh lỗi khi dòng trống hoặc có space đầu/cuối.

                if (string.IsNullOrEmpty(trimmed)) continue;
                // → Bỏ qua các dòng rỗng, tránh xử lý vô nghĩa và lỗi khi Evaluate("").

                try
                {
                    double result = Evaluate(trimmed);
                    // → Gọi hàm tự viết để tính biểu thức, tách logic xử lý cho gọn gàng.

                    sb.AppendLine($"{trimmed} = {result}");
                    // → Ghi lại biểu thức kèm kết quả để hiển thị đẹp dạng “a + b = c”.
                }
                catch
                {
                    sb.AppendLine($"{trimmed} = Lỗi cú pháp");
                    // → Nếu Evaluate ném lỗi (ví dụ phép chia sai cú pháp), vẫn ghi kết quả có thông báo.
                }
            }

            File.WriteAllText(pathOut, sb.ToString());
            // → Ghi toàn bộ kết quả ra file output3.txt, ghi đè để đảm bảo kết quả mới nhất.

            richTextBox1.Text = sb.ToString();
            // → Cập nhật ngay giao diện để người dùng thấy kết quả không cần mở file ngoài.

            MessageBox.Show("Đã tính toán và ghi vào output3.txt!");
            // → Thông báo hoàn tất để người dùng biết chương trình đã chạy xong.
        }


        // ====== HÀM TÍNH BIỂU THỨC ======

        private double Evaluate(string expression)
        {
            expression = expression.Replace(" ", "");
            // → Xóa khoảng trắng giúp quá trình duyệt ký tự không bị gián đoạn bởi dấu cách.

            Stack<double> values = new Stack<double>();
            Stack<char> ops = new Stack<char>();
            // → Dùng hai stack: một giữ số, một giữ toán tử — giúp xử lý đúng thứ tự ưu tiên.

            for (int i = 0; i < expression.Length; i++)
            {
                char c = expression[i];
                // → Lấy từng ký tự trong biểu thức để phân loại và xử lý.

                if (char.IsDigit(c))
                {
                    string num = "";
                    // → Gom các chữ số liên tiếp lại thành một số hoàn chỉnh (vì có thể nhiều chữ số).

                    while (i < expression.Length && (char.IsDigit(expression[i]) || expression[i] == '.'))
                    {
                        num += expression[i];
                        i++;
                    }
                    i--;
                    // → Giảm i vì vòng for sẽ tự tăng tiếp, tránh bỏ qua 1 ký tự sau số.

                    values.Push(double.Parse(num));
                    // → Đưa số vừa đọc vào stack giá trị để chờ tính.
                }
                else if (c == '(')
                {
                    ops.Push(c);
                    // → Đưa dấu '(' vào stack để đánh dấu bắt đầu một cụm ưu tiên cao.
                }
                else if (c == ')')
                {
                    while (ops.Count > 0 && ops.Peek() != '(')
                    {
                        // → Khi gặp ')', lấy toán tử trước đó ra để tính đến khi thấy '('.
                        values.Push(ApplyOp(ops.Pop(), values.Pop(), values.Pop()));
                    }
                    if (ops.Count > 0) ops.Pop();
                    // → Bỏ dấu '(' vì nó chỉ dùng để giới hạn phạm vi.
                }
                else if (IsOperator(c))
                {
                    while (ops.Count > 0 && Precedence(ops.Peek()) >= Precedence(c))
                    {
                        // → Nếu toán tử cũ có độ ưu tiên >= toán tử mới, thì tính trước.
                        values.Push(ApplyOp(ops.Pop(), values.Pop(), values.Pop()));
                    }
                    ops.Push(c);
                    // → Cuối cùng, đẩy toán tử hiện tại vào stack để tính sau.
                }
            }

            while (ops.Count > 0)
            {
                // → Khi duyệt hết chuỗi, vẫn có thể còn phép tính chưa thực hiện.
                values.Push(ApplyOp(ops.Pop(), values.Pop(), values.Pop()));
            }

            return values.Pop();
            // → Trả về kết quả cuối cùng trong stack (duy nhất còn lại sau khi tính xong).
        }

        private bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/';
            // → Chỉ chấp nhận 4 phép toán cơ bản, giúp kiểm soát dữ liệu đầu vào.
        }

        private int Precedence(char op)
        {
            if (op == '+' || op == '-') return 1;
            if (op == '*' || op == '/') return 2;
            return 0;
            // → Gán độ ưu tiên để xác định toán tử nào nên tính trước (*/ > +-).
        }

        private double ApplyOp(char op, double b, double a)
        {
            switch (op)
            {
                case '+': return a + b;
                case '-': return a - b;
                case '*': return a * b;
                case '/': return b != 0 ? a / b : double.NaN;
                    // → Kiểm tra chia cho 0 để tránh crash chương trình.
            }
            return 0;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }
    }
}
