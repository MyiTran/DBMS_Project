#nullable disable
using System;
using System.Windows.Forms;
using DBMS.Service;
using DBMS.Forms;
using DBMS.Data;

namespace DBMS
{
    public partial class Form1 : Form
    {
        private TaiKhoanService taiKhoanService;

        public Form1()
        {
            InitializeComponent();
            taiKhoanService = new TaiKhoanService(); // Khởi tạo service
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Test kết nối Azure SQL
            if (!DatabaseHelper.TestConnection())
            {
                MessageBox.Show("Không thể kết nối Azure SQL Database!\nKiểm tra firewall và connection string.",
                    "Lỗi Kết Nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }

            txtUsername.Focus();
            this.Text = "Hệ thống Quản lý Vé & Dịch vụ - Đăng nhập (Azure SQL)";
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Event cho label1
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ form
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Disable buttons để tránh spam click
            button1.Enabled = false;
            button2.Enabled = false;

            try
            {
                // Gọi Service để xử lý đăng nhập
                var ketQua = taiKhoanService.DangNhap(username, password);

                if (ketQua.thanhCong)
                {
                    // Đăng nhập thành công
                    MessageBox.Show(ketQua.thongBao, "Đăng nhập thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Mở form chính dựa trên vai trò
                    MoMainForm(ketQua.taiKhoan.VaiTro);
                }
                else
                {
                    // Đăng nhập thất bại
                    MessageBox.Show(ketQua.thongBao, "Lỗi đăng nhập",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    txtPassword.Clear();
                    txtUsername.SelectAll();
                    txtUsername.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi hệ thống",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Enable lại buttons
                button1.Enabled = true;
                button2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát ứng dụng?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// Mở MainForm dựa trên vai trò
        /// </summary>
        private void MoMainForm(string vaiTro)
        {
            try
            {
                this.Hide(); // Ẩn form đăng nhập

                // Tạo và hiển thị MainForm
                MainForm mainForm = new MainForm(vaiTro);
                mainForm.Show();

                // Khi MainForm đóng, hiện lại form đăng nhập
                mainForm.FormClosed += (s, e) =>
                {
                    taiKhoanService.DangXuat(); // Đăng xuất
                    ResetForm();
                    this.Show();
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở form chính: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show(); // Hiện lại form đăng nhập nếu có lỗi
            }
        }

        private void ResetForm()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                button1_Click(null, null);
                return true;
            }
            else if (keyData == Keys.Escape)
            {
                button2_Click(null, null);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}