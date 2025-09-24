#nullable disable
using System;
using System.Drawing;
using System.Windows.Forms;
using DBMS.Service;

namespace DBMS.Forms
{
    public partial class MainForm : Form
    {
        private TaiKhoanService taiKhoanService;
        private string vaiTro;

        // Các panel để chứa nội dung
        private Panel panelMain;
        private Label lblWelcome;
        private Label lblThongTinDangNhap;

        // Constructor mặc định (để Designer không lỗi)
        public MainForm() : this("User")
        {
        }

        // Constructor chính
        public MainForm(string vaiTro)
        {
            InitializeComponent();
            this.vaiTro = vaiTro;
            taiKhoanService = new TaiKhoanService();

            SetupMainForm();
            PhanQuyenMenu();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Event này sẽ chạy khi form load
        }

        private void SetupMainForm()
        {
            // Cấu hình form chính
            this.Text = $"Hệ thống Quản lý Vé & Dịch vụ - {vaiTro} ({PhienDangNhap.TenDangNhap})";
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Tạo panel chính để chứa nội dung
            panelMain = new Panel();
            panelMain.Dock = DockStyle.Fill;
            panelMain.BackColor = Color.FromArgb(245, 245, 245);
            this.Controls.Add(panelMain);
            panelMain.BringToFront(); // Đưa panel lên trên cùng

            // Label chào mừng
            lblWelcome = new Label();
            lblWelcome.Text = $"Chào mừng {PhienDangNhap.TenDangNhap} - {vaiTro}!";
            lblWelcome.Font = new Font("Arial", 18, FontStyle.Bold);
            lblWelcome.ForeColor = Color.FromArgb(0, 102, 204);
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(50, 50);
            panelMain.Controls.Add(lblWelcome);

            // Thông tin đăng nhập
            lblThongTinDangNhap = new Label();
            lblThongTinDangNhap.Text = PhienDangNhap.ThongTinPhien();
            lblThongTinDangNhap.Font = new Font("Arial", 10);
            lblThongTinDangNhap.ForeColor = Color.FromArgb(108, 117, 125);
            lblThongTinDangNhap.AutoSize = true;
            lblThongTinDangNhap.Location = new Point(50, 90);
            panelMain.Controls.Add(lblThongTinDangNhap);

            // Hiển thị quyền của user
            var quyenList = taiKhoanService.LayDanhSachQuyen();
            var lblQuyen = new Label();
            lblQuyen.Text = "Quyền truy cập của bạn:\n• " + string.Join("\n• ", quyenList);
            lblQuyen.Font = new Font("Arial", 10);
            lblQuyen.AutoSize = true;
            lblQuyen.Location = new Point(50, 130);
            lblQuyen.MaximumSize = new Size(600, 0);
            panelMain.Controls.Add(lblQuyen);

            // Hướng dẫn sử dụng
            var lblHuongDan = new Label();
            lblHuongDan.Text = "Hướng dẫn sử dụng:\n- Sử dụng menu trên để truy cập các chức năng\n- Menu được hiển thị dựa trên quyền của bạn\n- Chọn 'Hệ thống' > 'Đăng xuất' để thoát";
            lblHuongDan.Font = new Font("Arial", 9);
            lblHuongDan.ForeColor = Color.FromArgb(73, 80, 87);
            lblHuongDan.AutoSize = true;
            lblHuongDan.Location = new Point(50, 250);
            lblHuongDan.MaximumSize = new Size(600, 0);
            panelMain.Controls.Add(lblHuongDan);
        }

        private void PhanQuyenMenu()
        {
            // Kiểm tra và ẩn/hiện menu dựa trên quyền
            // Menu Quan Ly
            bool coQuyenQuanLy = taiKhoanService.KiemTraQuyen("QUAN_LY_KHACH_HANG") ||
                                taiKhoanService.KiemTraQuyen("QUAN_LY_VE") ||
                                taiKhoanService.KiemTraQuyen("QUAN_LY_DICH_VU");

            // Menu Báo cáo
            bool coQuyenBaoCao = taiKhoanService.KiemTraQuyen("XEM_BAO_CAO");

            // Cập nhật status bar hoặc hiển thị thông tin quyền
            this.Text = $"Hệ thống Quản lý Vé & Dịch vụ - {vaiTro} ({PhienDangNhap.TenDangNhap})";
        }

        // Event handlers cho menu items
        private void khachHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (taiKhoanService.KiemTraQuyen("QUAN_LY_KHACH_HANG"))
            {
                MoFormKhachHang();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng Quản lý Khách hàng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void veToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (taiKhoanService.KiemTraQuyen("QUAN_LY_VE"))
            {
                try
                {
                    VeForm veForm = new VeForm();
                    veForm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi mở form vé: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng Quản lý Vé!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dichVuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (taiKhoanService.KiemTraQuyen("QUAN_LY_DICH_VU"))
            {
                MessageBox.Show("Chức năng Quản lý Dịch vụ sẽ được phát triển trong bước tiếp theo!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng Quản lý Dịch vụ!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void baoCaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (taiKhoanService.KiemTraQuyen("XEM_BAO_CAO"))
            {
                MessageBox.Show("Chức năng Báo cáo sẽ được phát triển trong bước tiếp theo!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền xem báo cáo!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void baoCaoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            // Event trùng, có thể xóa hoặc gọi event chính
            baoCaoToolStripMenuItem_Click(sender, e);
        }

        private void dangXuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất khỏi hệ thống?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                taiKhoanService.DangXuat();
                MessageBox.Show("Đã đăng xuất thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void MoFormKhachHang()
        {
            try
            {
                KhachHangForm khachHangForm = new KhachHangForm();
                khachHangForm.ShowDialog(); // Mở dạng modal
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở form khách hàng: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Xác nhận trước khi đóng form chính
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi hệ thống?",
                "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }

            base.OnFormClosing(e);
        }

        private void banVeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (taiKhoanService.KiemTraQuyen("BAN_VE"))
            {
                BanVeForm banVeForm = new BanVeForm();
                banVeForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền bán vé!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
