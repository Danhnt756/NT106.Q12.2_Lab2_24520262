using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LAB02_24520262
{
    public partial class LAB02_Bai4 : Form
    {
        private List<SinhVien> danhSach = new List<SinhVien>();
        private string inputPath = "input4.txt";
        private string outputPath = "output4.txt";
        private int currentPage = 0;
        public LAB02_Bai4()
        {
            InitializeComponent();
        }
        // ====== CẤU TRÚC SINH VIÊN ======
        [Serializable]
        public class SinhVien
        {
            public string HoTen { get; set; }
            public int MSSV { get; set; }
            public string DienThoai { get; set; }
            public float Diem1 { get; set; }
            public float Diem2 { get; set; }
            public float Diem3 { get; set; }
            public float DiemTB { get; set; }
            public void TinhDiemTB()
            {
                DiemTB = (Diem1 + Diem2 + Diem3) / 3;
            }
            public bool KiemTraDuLieu(out string error)
            {
                error = "";

                if (string.IsNullOrWhiteSpace(HoTen))
                    error += "Họ và tên không được để trống." + Environment.NewLine;

                string mssvStr = MSSV.ToString();
                if (MSSV <= 0 || mssvStr.Length != 8 || !Regex.IsMatch(mssvStr, @"^\d{8}$"))
                    error += "MSSV phải là số nguyên dương có đúng 8 chữ số." + Environment.NewLine;

                if (string.IsNullOrWhiteSpace(DienThoai) || !Regex.IsMatch(DienThoai, @"^0\d{9}$"))
                    error += "Số điện thoại phải bắt đầu bằng 0 và có đúng 10 chữ số." + Environment.NewLine;

                if (Diem1 < 0 || Diem1 > 10)
                    error += "Điểm môn 1 phải từ 0 đến 10." + Environment.NewLine;
                if (Diem2 < 0 || Diem2 > 10)
                    error += "Điểm môn 2 phải từ 0 đến 10." + Environment.NewLine;
                if (Diem3 < 0 || Diem3 > 10)
                    error += "Điểm môn 3 phải từ 0 đến 10." + Environment.NewLine;

                return string.IsNullOrEmpty(error);
            }
        }
        private void UpdatePageLabel()
        {
            if (danhSach.Count == 0)
                label7.Text = "0 / 0";
            else
                label7.Text = $"{currentPage + 1} / {danhSach.Count}";
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Tạo đối tượng sinh viên
            SinhVien sv = new SinhVien
            {
                HoTen = textBox14.Text.Trim(),
                MSSV = int.TryParse(textBox13.Text, out int mssv) ? mssv : 0,
                DienThoai = textBox12.Text.Trim(),
                Diem1 = float.TryParse(textBox11.Text, out float d1) ? d1 : -1,
                Diem2 = float.TryParse(textBox10.Text, out float d2) ? d2 : -1,
                Diem3 = float.TryParse(textBox9.Text, out float d3) ? d3 : -1
            };

            // Gọi hàm kiểm tra dữ liệu
            if (sv.KiemTraDuLieu(out string error))
            {
                // Hợp lệ → thêm vào richtextbox
                richTextBox1.AppendText(
                    $"{sv.HoTen}{Environment.NewLine}" +
                    $"{sv.MSSV}{Environment.NewLine}" +
                    $"{sv.DienThoai}{Environment.NewLine}" +
                    $"{sv.Diem1}{Environment.NewLine}" +
                    $"{sv.Diem2}{Environment.NewLine}" +
                    $"{sv.Diem3}{Environment.NewLine}" +
                    $"{Environment.NewLine}");
                danhSach.Add(sv);
                UpdatePageLabel();
            }
            else
            {
                // Không hợp lệ → hiển thị thông báo lỗi
                MessageBox.Show(error, "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Xóa ô nhập
            textBox14.Clear();
            textBox13.Clear();
            textBox12.Clear();
            textBox11.Clear();
            textBox10.Clear();
            textBox9.Clear();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu RichTextBox rỗng
            if (string.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                MessageBox.Show("Không có dữ liệu để ghi! Vui lòng thêm dữ liệu trước.",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                // Ghi nội dung RichTextBox xuống file input4.txt
                using (StreamWriter sw = new StreamWriter(inputPath))
                {
                    sw.Write(richTextBox1.Text);
                }

                MessageBox.Show("Ghi dữ liệu xuống file thành công!",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi ghi file: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void HienThiSinhVien(SinhVien sv)
        {
            textBox1.Text = sv.HoTen;
            textBox2.Text = sv.MSSV.ToString();
            textBox3.Text = sv.DienThoai;
            textBox4.Text = sv.Diem1.ToString();
            textBox5.Text = sv.Diem2.ToString();
            textBox6.Text = sv.Diem3.ToString();
            textBox7.Text = sv.DiemTB.ToString("F2");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Đọc file input4.txt theo dạng text
                string[] lines = File.ReadAllLines(inputPath)
                                     .Where(l => !string.IsNullOrWhiteSpace(l))
                                     .ToArray();

                danhSach.Clear();

                for (int i = 0; i < lines.Length; i += 6)
                {
                    if (i + 5 < lines.Length)
                    {
                        SinhVien sv = new SinhVien
                        {
                            HoTen = lines[i].Trim(),
                            MSSV = int.Parse(lines[i + 1].Trim()),
                            DienThoai = lines[i + 2].Trim(),
                            Diem1 = float.Parse(lines[i + 3].Trim()),
                            Diem2 = float.Parse(lines[i + 4].Trim()),
                            Diem3 = float.Parse(lines[i + 5].Trim())
                        };
                        sv.TinhDiemTB();
                        danhSach.Add(sv);
                    }
                }

                // Ghi sang file output4.txt
                using (StreamWriter sw = new StreamWriter(outputPath))
                {
                    foreach (var sv in danhSach)
                    {
                        sw.WriteLine($"{sv.HoTen}, {sv.MSSV}, {sv.DienThoai}, " +
                                     $"{sv.Diem1}, {sv.Diem2}, {sv.Diem3}, TB={sv.DiemTB:F2}");
                    }
                }

                // Hiển thị sinh viên đầu tiên
                if (danhSach.Count > 0)
                {
                    currentPage = 0;
                    HienThiSinhVien(danhSach[currentPage]);
                    UpdatePageLabel();
                }

                MessageBox.Show("Đọc, tính điểm trung bình và ghi file thành công!",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xử lý dữ liệu: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (currentPage < danhSach.Count - 1)
            {
                currentPage++;
                HienThiSinhVien(danhSach[currentPage]);
                UpdatePageLabel();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (currentPage > 0)
            {
                currentPage--;
                HienThiSinhVien(danhSach[currentPage]);
                UpdatePageLabel();
            }

        }
    }
}
