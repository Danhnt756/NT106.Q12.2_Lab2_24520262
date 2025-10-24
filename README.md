# NT106.Q12.2 - Lab 2: File and Stream I/O in C#
---

## Tác giả
Nguyễn Tấn Danh  
MSSV: 24520262  
Lớp: NT106.Q12.2

## Giới thiệu
Đây là bài thực hành Lab 2 của môn Lập trình mạng căn bản  
Trường Đại học Công nghệ Thông tin – ĐHQG TP.HCM (UIT)  
Giảng viên hướng dẫn: Thầy Phan Trung Phát

Mục tiêu của Lab:
- Hiểu và thao tác được với File và Stream I/O trong C#
- Sử dụng được các lớp: FileStream, StreamReader, StreamWriter, JsonSerializer, v.v.
- Ứng dụng đọc, ghi, xử lý dữ liệu từ file và hiển thị kết quả qua giao diện WinForms

---

## Nội dung chính

### Bài 1 – Ghi và đọc file
Đọc nội dung từ `input1.txt`, hiển thị, sau đó ghi lại dưới dạng in hoa vào `output1.txt`.

### Bài 2 – Đọc thông tin file .txt
Hiển thị: tên file, kích thước, đường dẫn, số dòng, số từ, số ký tự và nội dung.

### Bài 3 – Đọc, ghi và tính toán
Đọc các phép tính từ `input3.txt`, tính kết quả, ghi ra `output3.txt`.

### Bài 4 – Quản lý sinh viên
Nhập, ghi, đọc và tính điểm trung bình sinh viên; ghi dữ liệu ra file.

### Bài 5 – Quản lý phòng vé
Đọc thông tin phim, tính doanh thu, số vé bán ra, vé tồn, tỉ lệ bán, xếp hạng và ghi ra `output5.txt`.

### Bài 6 – CSDL món ăn (SQLite)
Tạo cơ sở dữ liệu gồm bảng người dùng và món ăn.  
Hiển thị danh sách món ăn và thông tin người cung cấp, quyền hạn.  
Có chức năng hiển thị ngẫu nhiên một món ăn và ảnh minh họa.

### Bài 7 – Duyệt thư mục
Ứng dụng TreeView hiển thị toàn bộ ổ đĩa và thư mục.  
- Xem trước hình ảnh (jpg, png, bmp, gif) trong PictureBox.  
- Xem nội dung văn bản (txt, rtf) trong RichTextBox.  
- Nhấn đúp chuột để chuyển sang file kế tiếp trong cùng thư mục.

---

## Cách chạy
1. Mở project bằng Visual Studio 2022 hoặc mới hơn.  
2. Chạy từng bài trong project `NT106.Q12.2_Lab2_24520262`.  
3. Đảm bảo các file input/output nằm cùng thư mục chạy chương trình.

---

## Công nghệ sử dụng
- C# (.NET Framework)
- Windows Forms Application (WinForms)
- System.IO (File, Directory, StreamReader, StreamWriter, FileStream)
- SQLite
- JsonSerializer
