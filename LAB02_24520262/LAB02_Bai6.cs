using System;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LAB02_24520262
{
    public partial class LAB02_Bai6 : Form
    {
        private string dbPath = "Data Source=Lab2.db"; // Đường dẫn CSDL SQLite

        public LAB02_Bai6()
        {
            InitializeComponent();

            // Đặt chế độ hiển thị ảnh vừa khung
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            // Tạo CSDL và bảng nếu chưa có
            TaoCoSoDuLieu();

            // Hiển thị dữ liệu lên TableLayoutPanel
            HienThiDuLieu();
        }

        private void TaoCoSoDuLieu()
        {
            // Nếu file DB chưa có thì tạo mới
            if (!File.Exists("monan.db"))
                SQLiteConnection.CreateFile("monan.db");

            using (var conn = new SQLiteConnection(dbPath))
            {
                conn.Open();

                // Bật khóa ngoại
                using (var pragma = new SQLiteCommand("PRAGMA foreign_keys = ON;", conn))
                    pragma.ExecuteNonQuery();

                // Tạo bảng NGUOIDUNG
                string sqlNguoiDung = @"
                    CREATE TABLE IF NOT EXISTS NguoiDung(
                        IDNCC TEXT PRIMARY KEY,
                        HoVaTen TEXT NOT NULL,
                        QuyenHan TEXT
                    );
                ";

                // Tạo bảng MONAN
                string sqlMonAn = @"
                    CREATE TABLE IF NOT EXISTS MonAn(
                        IDMA INTEGER PRIMARY KEY AUTOINCREMENT,
                        TenMonAn TEXT,
                        HinhAnh TEXT,
                        IDNCC TEXT,
                        FOREIGN KEY(IDNCC) REFERENCES NguoiDung(IDNCC)
                    );
                ";

                // Thực thi tạo bảng
                new SQLiteCommand(sqlNguoiDung, conn).ExecuteNonQuery();
                new SQLiteCommand(sqlMonAn, conn).ExecuteNonQuery();

                // Nếu bảng trống thì thêm dữ liệu mẫu
                string checkData = "SELECT COUNT(*) FROM MonAn";
                var cmdCheck = new SQLiteCommand(checkData, conn);
                long count = (long)cmdCheck.ExecuteScalar();

                if (count == 0)
                {
                    string insertSQL = @"
                        INSERT INTO NguoiDung VALUES
                            ('AD0', 'Nguyen Tan Danh', 'Admin'),
                            ('ND1', 'Nguyen Van A', 'User'),
                            ('ND2', 'Tran Thi B', 'User');

                        INSERT INTO MonAn (TenMonAn, HinhAnh, IDNCC) VALUES
                            ('Cháo lòng', 'chaolong.jpg', 'AD0'),
                            ('Bánh mì', 'banhmi.jpg', 'AD0'),
                            ('Phở bò', 'pho.jpg', 'ND1'),
                            ('Bún chả', 'buncha.jpg', 'ND1'),
                            ('Cơm tấm', 'comtam.jpg', 'ND2'),
                            ('Bánh xèo', 'banhxeo.jpg', 'ND2');
                    ";
                    new SQLiteCommand(insertSQL, conn).ExecuteNonQuery();
                }
            }
        }

        private void HienThiDuLieu()
        {
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.ColumnCount = 4;

            // Load data into a temporary list first
            var rows = new System.Collections.Generic.List<(string ID, string Ten, string NCC, string Quyen)>();
            using (var conn = new SQLiteConnection(dbPath))
            {
                conn.Open();

                string sql = @"
                    SELECT M.IDMA, M.TenMonAn, N.HoVaTen, N.QuyenHan
                    FROM MonAn M
                    JOIN NguoiDung N ON M.IDNCC = N.IDNCC
                    ORDER BY M.IDMA;
                ";

                var cmd = new SQLiteCommand(sql, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rows.Add((
                        reader["IDMA"].ToString(),
                        reader["TenMonAn"].ToString(),
                        reader["HoVaTen"].ToString(),
                        reader["QuyenHan"].ToString()
                    ));
                }
            }

            // Include header row in the count
            int totalRows = 1 + rows.Count;
            tableLayoutPanel1.RowCount = totalRows;

            // Make every row take an equal percentage of the panel's height
            float percent = 100f / Math.Max(1, totalRows);
            for (int i = 0; i < totalRows; i++)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, percent));
            }

            // Add header (row 0)
            ThemTieuDe("ID Món Ăn", "Tên Món Ăn", "Người Cung Cấp", "Quyền Hạn");

            // Add data rows starting at row 1
            for (int i = 0; i < rows.Count; i++)
            {
                int rowIndex = i + 1;
                var r = rows[i];

                tableLayoutPanel1.Controls.Add(new Label()
                {
                    Text = r.ID,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                }, 0, rowIndex);

                tableLayoutPanel1.Controls.Add(new Label()
                {
                    Text = r.Ten,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                }, 1, rowIndex);

                tableLayoutPanel1.Controls.Add(new Label()
                {
                    Text = r.NCC,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                }, 2, rowIndex);

                tableLayoutPanel1.Controls.Add(new Label()
                {
                    Text = r.Quyen,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                }, 3, rowIndex);
            }
        }

        private void ThemTieuDe(params string[] headers)
        {
            var boldFont = new Font("Cascadia code", 11, FontStyle.Bold);

            for (int i = 0; i < headers.Length; i++)
            {
                tableLayoutPanel1.Controls.Add(new Label()
                {
                    Text = headers[i],
                    Font = boldFont,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = Color.DarkBlue
                }, i, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            pictureBox1.Image = null;

            using (var conn = new SQLiteConnection(dbPath))
            {
                conn.Open();
                string sql = @"
                    SELECT M.TenMonAn, M.HinhAnh, N.HoVaTen, N.QuyenHan
                    FROM MonAn M
                    JOIN NguoiDung N ON M.IDNCC = N.IDNCC
                    ORDER BY RANDOM()
                    LIMIT 1;
                ";

                var cmd = new SQLiteCommand(sql, conn);
                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string ten = reader["TenMonAn"].ToString();
                    string hinh = reader["HinhAnh"].ToString();
                    string ncc = reader["HoVaTen"].ToString();
                    string quyen = reader["QuyenHan"].ToString();

                    // Hiển thị text
                    richTextBox1.AppendText($"Tên món ăn: {ten}\n");
                    richTextBox1.AppendText($"Người cung cấp: {ncc}\n");
                    richTextBox1.AppendText($"Quyền hạn: {quyen}\n");

                    // Hiển thị ảnh
                    string imagePath = Path.Combine(Application.StartupPath, hinh);
                    if (File.Exists(imagePath))
                        pictureBox1.Image = Image.FromFile(imagePath);
                    else
                        MessageBox.Show($"Không tìm thấy ảnh: {hinh}");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            richTextBox1.Clear();
            HienThiDuLieu();
        }
    }
}
