using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LAB02_24520262
{
    public partial class LAB02_Bai7 : Form
    {
        public LAB02_Bai7()
        {
            InitializeComponent();

            // Gắn sự kiện Load và TreeView
            this.Load += LAB02_Bai7_Load;
            treeView1.BeforeExpand += treeView1_BeforeExpand;
            treeView1.AfterSelect += treeView1_AfterSelect;
            treeView1.MouseDoubleClick += treeView1_MouseDoubleClick; // Nhấn đúp chuột để chuyển file kế tiếp
        }

        private void LAB02_Bai7_Load(object sender, EventArgs e)
        {
            string[] drives = Directory.GetLogicalDrives();

            foreach (string drive in drives)
            {
                TreeNode driveNode = new TreeNode(drive);
                driveNode.Tag = drive; // Lưu đường dẫn thật vào Tag
                treeView1.Nodes.Add(driveNode);
                driveNode.Nodes.Add("dummy"); // Tạo hiệu ứng có thể mở rộng
            }
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode selectedNode = e.Node;

            if (selectedNode.Nodes.Count == 1 && selectedNode.Nodes[0].Text == "dummy")
            {
                selectedNode.Nodes.Clear();

                try
                {
                    string path = selectedNode.Tag.ToString();
                    string[] dirs = Directory.GetDirectories(path);

                    foreach (string dir in dirs)
                    {
                        TreeNode dirNode = new TreeNode(Path.GetFileName(dir));
                        dirNode.Tag = dir;
                        dirNode.Nodes.Add("dummy");
                        selectedNode.Nodes.Add(dirNode);
                    }

                    string[] files = Directory.GetFiles(path);
                    foreach (string file in files)
                    {
                        TreeNode fileNode = new TreeNode(Path.GetFileName(file));
                        fileNode.Tag = file;
                        selectedNode.Nodes.Add(fileNode);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể truy cập thư mục: " + ex.Message);
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag == null) return;
            string fullPath = e.Node.Tag.ToString();
            HienThiFile(fullPath);
        }

        // ====== HÀM HIỂN THỊ FILE (ảnh hoặc text) ======
        private void HienThiFile(string fullPath)
        {
            pictureBox1.Visible = false;
            richTextBox1.Visible = false;

            if (File.Exists(fullPath))
            {
                string extension = Path.GetExtension(fullPath).ToLower();
                try
                {
                    if (extension == ".jpg" || extension == ".png" || extension == ".bmp" || extension == ".gif")
                    {
                        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom; // Co giãn vừa khung
                        pictureBox1.Image = Image.FromFile(fullPath);
                        pictureBox1.Visible = true;
                    }
                    else if (extension == ".txt" || extension == ".rtf")
                    {
                        richTextBox1.Text = File.ReadAllText(fullPath);
                        richTextBox1.Visible = true;
                    }
                    else
                    {
                        richTextBox1.Text = "Không hỗ trợ xem trước cho loại file này.";
                        richTextBox1.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi mở file: " + ex.Message);
                }
            }
        }

        // ====== SỰ KIỆN NHẤN ĐÚP CHUỘT ======
        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
            if (node == null || node.Tag == null) return;

            string currentFile = node.Tag.ToString();
            if (!File.Exists(currentFile)) return;

            string directory = Path.GetDirectoryName(currentFile);
            string[] allFiles = Directory.GetFiles(directory);

            // Tìm vị trí file hiện tại
            int currentIndex = Array.IndexOf(allFiles, currentFile);
            if (currentIndex >= 0)
            {
                // Nếu là file cuối thì quay lại file đầu tiên
                int nextIndex = (currentIndex + 1) % allFiles.Length;
                string nextFile = allFiles[nextIndex];

                // Cập nhật node hiện tại và hiển thị file kế tiếp
                node.Text = Path.GetFileName(nextFile);
                node.Tag = nextFile;
                HienThiFile(nextFile);
            }
        }
    }
}
