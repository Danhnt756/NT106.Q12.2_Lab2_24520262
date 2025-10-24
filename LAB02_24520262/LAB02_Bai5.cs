using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace LAB02_24520262
{
    public partial class LAB02_Bai5 : Form
    {
        public LAB02_Bai5()
        {
            InitializeComponent();
        }

        public class Phim
        {
            public string Ten { get; set; }
            public int GiaVe { get; set; }
            public int PhongChieu { get; set; }
            public int SoVe { get; set; }
            public List<string> Ghe { get; set; }
            public float DoanhThu => GiaVe * SoVe;
            public float TiLeBan => SoVe / 15f * 100; // giả sử có 15 ghế (A,B,C mỗi hàng 5)
            public int SoVeTon => 15 - SoVe;

        }

        List<Phim> danhSachPhim = new List<Phim>();
        int currentIndex = 0;

        // ====== Hiển thị phim hiện tại ======
        private void HienThiPhim(Phim p)
        {
            textBox1.Text = p.Ten;
            textBox2.Text = p.GiaVe.ToString();
            textBox3.Text = p.PhongChieu.ToString();
            textBox4.Text = p.SoVe.ToString();

            // Bỏ chọn tất cả checkbox
            foreach (var ctrl in this.Controls)
            {
                if (ctrl is CheckBox chk)
                    chk.Checked = false;
            }

            // Đánh dấu các ghế đã bán (dựa trên tên control)
            foreach (string ghe in p.Ghe)
            {
                var chk = this.Controls.Find(ghe, true).FirstOrDefault() as CheckBox;
                if (chk != null)
                    chk.Checked = true;
            }

            // Cập nhật số thứ tự phim
            label13.Text = $"{currentIndex + 1} / {danhSachPhim.Count}";
        }

        // ====== Nút "Đọc" ======
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string[] lines = File.ReadAllLines("input5.txt");
                danhSachPhim.Clear();

                for (int i = 0; i < lines.Length; i += 5)
                {
                    if (i + 4 < lines.Length)
                    {
                        Phim p = new Phim
                        {
                            Ten = lines[i].Trim(),
                            GiaVe = int.Parse(lines[i + 1]),
                            PhongChieu = int.Parse(lines[i + 2]),
                            SoVe = int.Parse(lines[i + 3]),
                            Ghe = lines[i + 4]
                                .Split(',')
                                .Select(g => g.Trim().ToUpper()) // Ví dụ "A2", "B4"
                                .ToList()
                        };
                        danhSachPhim.Add(p);
                    }
                }

                if (danhSachPhim.Count > 0)
                {
                    currentIndex = 0;
                    HienThiPhim(danhSachPhim[currentIndex]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đọc file: " + ex.Message);
            }
        }
        // ====== Nút "Trước" ======
        private void button2_Click(object sender, EventArgs e)
        {
            if (danhSachPhim.Count == 0) return;
            currentIndex = (currentIndex - 1 + danhSachPhim.Count) % danhSachPhim.Count;
            HienThiPhim(danhSachPhim[currentIndex]);
        }
        // ====== Nút "Sau" ======
        private void button3_Click(object sender, EventArgs e)
        {
            if (danhSachPhim.Count == 0) return;
            currentIndex = (currentIndex + 1) % danhSachPhim.Count;
            HienThiPhim(danhSachPhim[currentIndex]);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (danhSachPhim.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu phim để thống kê.");
                return;
            }

            progressBar1.Value = 0;
            progressBar1.Maximum = danhSachPhim.Count;

            // Tính doanh thu & xếp hạng
            var thongKe = danhSachPhim
                .OrderByDescending(p => p.DoanhThu)
                .Select((p, index) => new
                {
                    Hang = index + 1,
                    p.Ten,
                    p.SoVe,
                    p.SoVeTon,
                    p.TiLeBan,
                    p.DoanhThu
                })
                .ToList();

            // Ghi ra file output5.txt
            using (StreamWriter sw = new StreamWriter("output5.txt"))
            {
                foreach (var p in thongKe)
                {
                    sw.WriteLine($"Hạng {p.Hang}: {p.Ten}");
                    sw.WriteLine($"   Số vé bán ra: {p.SoVe}");
                    sw.WriteLine($"   Số vé tồn: {p.SoVeTon}");
                    sw.WriteLine($"   Tỉ lệ vé bán ra: {p.TiLeBan:F2}%");
                    sw.WriteLine($"   Doanh thu: {p.DoanhThu:N0} VND");
                    sw.WriteLine();

                    // Cập nhật progress bar
                    progressBar1.Value += 1;
                    progressBar1.Refresh();
                    System.Threading.Thread.Sleep(200); // để thấy thanh tiến trình di chuyển
                }
            }

            // Hiển thị vào RichTextBox
            richTextBox1.Clear();
            foreach (var p in thongKe)
            {
                richTextBox1.AppendText($"Hạng {p.Hang}: {p.Ten}\n");
                richTextBox1.AppendText($"   Số vé bán ra: {p.SoVe}\n");
                richTextBox1.AppendText($"   Số vé tồn: {p.SoVeTon}\n");
                richTextBox1.AppendText($"   Tỉ lệ vé bán ra: {p.TiLeBan:F2}%\n");
                richTextBox1.AppendText($"   Doanh thu: {p.DoanhThu:N0} VND\n\n");
            }

            MessageBox.Show("Đã xuất thống kê ra output5.txt!");
        }
    }
}
