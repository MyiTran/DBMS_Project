#nullable disable
using System;
using System.Drawing;
using System.Windows.Forms;
using DBMS.Models;
using DBMS.Service;

namespace DBMS.Forms
{
    public partial class KhachHangForm : Form
    {
        private KhachHangService khachHangService;
        private int selectedKhachHangId = 0;

        public KhachHangForm()
        {
            InitializeComponent();
            khachHangService = new KhachHangService();

            this.Load += KhachHangForm_Load;
        }

        private void KhachHangForm_Load(object sender, EventArgs e)
        {
            SetupForm();
            SetupDataGridView();
            LoadData();
        }

        private void SetupForm()
        {
            this.Text = "Quản lý Khách hàng";
            this.StartPosition = FormStartPosition.CenterParent;

            if (txtHoTen != null) txtHoTen.Focus();
        }

        private void SetupDataGridView()
        {
            if (dgvKhachHang == null) return;

            dgvKhachHang.Columns.Clear();
            dgvKhachHang.Columns.Add("KhachHangId", "ID");
            dgvKhachHang.Columns.Add("HoTen", "Họ tên");
            dgvKhachHang.Columns.Add("GioiTinh", "Giới tính");
            dgvKhachHang.Columns.Add("NgaySinh", "Ngày sinh");
            dgvKhachHang.Columns.Add("SoDienThoai", "Số điện thoại");
            dgvKhachHang.Columns.Add("Email", "Email");
            dgvKhachHang.Columns.Add("NgayDangKy", "Ngày đăng ký");

            dgvKhachHang.Columns["KhachHangId"].Visible = false;
            dgvKhachHang.ReadOnly = true;
            dgvKhachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKhachHang.AllowUserToAddRows = false;
        }

        private void LoadData()
        {
            try
            {
                if (dgvKhachHang == null) return;

                var danhSach = khachHangService.LayTatCaKhachHang();
                dgvKhachHang.Rows.Clear();

                foreach (var kh in danhSach)
                {
                    dgvKhachHang.Rows.Add(
                        kh.KhachHangId,
                        kh.HoTen ?? "",
                        kh.GioiTinh ?? "",
                        kh.NgaySinh?.ToString("dd/MM/yyyy") ?? "",
                        kh.SoDienThoai ?? "",
                        kh.Email ?? "",
                        kh.NgayDangKy.ToString("dd/MM/yyyy")
                    );
                }

                this.Text = $"Quản lý Khách hàng - Tổng: {danhSach.Count} khách hàng";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                var khachHang = new KhachHang
                {
                    HoTen = txtHoTen?.Text?.Trim() ?? "",
                    GioiTinh = cboGioiTinh?.SelectedItem?.ToString() ?? "",
                    NgaySinh = GetNgaySinh(),
                    SoDienThoai = GetSoDienThoai(),
                    Email = txtEmail?.Text?.Trim() ?? "",
                    NgayDangKy = DateTime.Now
                };

                var ketQua = khachHangService.ThemKhachHang(khachHang);

                MessageBox.Show(ketQua.thongBao,
                    ketQua.thanhCong ? "Thành công" : "Lỗi",
                    MessageBoxButtons.OK,
                    ketQua.thanhCong ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (ketQua.thanhCong)
                {
                    LoadData();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedKhachHangId == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput()) return;

            try
            {
                var khachHang = new KhachHang
                {
                    KhachHangId = selectedKhachHangId,
                    HoTen = txtHoTen?.Text?.Trim() ?? "",
                    GioiTinh = cboGioiTinh?.SelectedItem?.ToString() ?? "",
                    NgaySinh = GetNgaySinh(),
                    SoDienThoai = GetSoDienThoai(),
                    Email = txtEmail?.Text?.Trim() ?? ""
                };

                var ketQua = khachHangService.SuaKhachHang(khachHang);

                MessageBox.Show(ketQua.thongBao,
                    ketQua.thanhCong ? "Thành công" : "Lỗi",
                    MessageBoxButtons.OK,
                    ketQua.thanhCong ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (ketQua.thanhCong)
                {
                    LoadData();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedKhachHangId == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var khachHang = khachHangService.LayKhachHangTheoId(selectedKhachHangId);
            if (khachHang == null)
            {
                MessageBox.Show("Khách hàng không tồn tại!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa khách hàng:\n{khachHang.HoTen} - {khachHang.SoDienThoai}?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var ketQua = khachHangService.XoaKhachHang(selectedKhachHangId);

                MessageBox.Show(ketQua.thongBao,
                    ketQua.thanhCong ? "Thành công" : "Lỗi",
                    MessageBoxButtons.OK,
                    ketQua.thanhCong ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (ketQua.thanhCong)
                {
                    LoadData();
                    ClearForm();
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadData();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTimKiem?.Text?.Trim() ?? "";
                var danhSach = khachHangService.TimKhachHang(keyword);

                if (dgvKhachHang != null)
                {
                    dgvKhachHang.Rows.Clear();
                    foreach (var kh in danhSach)
                    {
                        dgvKhachHang.Rows.Add(
                            kh.KhachHangId,
                            kh.HoTen ?? "",
                            kh.GioiTinh ?? "",
                            kh.NgaySinh?.ToString("dd/MM/yyyy") ?? "",
                            kh.SoDienThoai ?? "",
                            kh.Email ?? "",
                            kh.NgayDangKy.ToString("dd/MM/yyyy")
                        );
                    }
                }

                this.Text = $"Quản lý Khách hàng - Tìm thấy: {danhSach.Count} khách hàng";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tìm kiếm: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvKhachHang?.Rows[e.RowIndex]?.Cells["KhachHangId"]?.Value != null)
            {
                try
                {
                    selectedKhachHangId = Convert.ToInt32(dgvKhachHang.Rows[e.RowIndex].Cells["KhachHangId"].Value);

                    if (txtHoTen != null)
                        txtHoTen.Text = dgvKhachHang.Rows[e.RowIndex].Cells["HoTen"].Value?.ToString() ?? "";

                    string gioiTinh = dgvKhachHang.Rows[e.RowIndex].Cells["GioiTinh"].Value?.ToString() ?? "";
                    if (cboGioiTinh != null && !string.IsNullOrEmpty(gioiTinh))
                    {
                        for (int i = 0; i < cboGioiTinh.Items.Count; i++)
                        {
                            if (cboGioiTinh.Items[i].ToString() == gioiTinh)
                            {
                                cboGioiTinh.SelectedIndex = i;
                                break;
                            }
                        }
                    }

                    SetSoDienThoai(dgvKhachHang.Rows[e.RowIndex].Cells["SoDienThoai"].Value?.ToString() ?? "");

                    if (txtEmail != null)
                        txtEmail.Text = dgvKhachHang.Rows[e.RowIndex].Cells["Email"].Value?.ToString() ?? "";

                    if (btnSua != null) btnSua.Text = $"Sửa (ID: {selectedKhachHangId})";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi chọn khách hàng: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearForm()
        {
            selectedKhachHangId = 0;

            if (txtHoTen != null) txtHoTen.Clear();
            if (cboGioiTinh != null) cboGioiTinh.SelectedIndex = -1;
            if (txtEmail != null) txtEmail.Clear();
            if (txtTimKiem != null) txtTimKiem.Clear();

            SetSoDienThoai("");

            if (btnSua != null) btnSua.Text = "Sửa";
            if (txtHoTen != null) txtHoTen.Focus();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen?.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen?.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(GetSoDienThoai()))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private DateTime? GetNgaySinh()
        {
            if (dtpNgaySinh == null) return null;
            return dtpNgaySinh.Value;
        }

        private string GetSoDienThoai()
        {
            // Tìm textbox số điện thoại (có thể có tên khác nhau)
            if (txtSoDienThoai != null) return txtSoDienThoai.Text?.Trim() ?? "";

            // Tìm theo tên khác
            foreach (Control control in this.Controls)
            {
                if (control is TextBox txt && (control.Name.Contains("SoDien") || control.Name.Contains("Phone")))
                {
                    return txt.Text?.Trim() ?? "";
                }
            }
            return "";
        }

        private void SetSoDienThoai(string value)
        {
            if (txtSoDienThoai != null)
            {
                txtSoDienThoai.Text = value;
                return;
            }

            foreach (Control control in this.Controls)
            {
                if (control is TextBox txt && (control.Name.Contains("SoDien") || control.Name.Contains("Phone")))
                {
                    txt.Text = value;
                    return;
                }
            }
        }

        // Các events trống để tránh lỗi
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void txtHoTen_TextChanged(object sender, EventArgs e) { }
        private void dtpNgaySinh_ValueChanged(object sender, EventArgs e) { }
        private void textBox4_TextChanged(object sender, EventArgs e) { }
        private void lblGioiTinh_Click(object sender, EventArgs e) { }
        private void cboGioiTinh_SelectedIndexChanged(object sender, EventArgs e) { }
        private void lblSoDienThoai_Click(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void label1_Click_1(object sender, EventArgs e) { }
        private void txtTimKiem_TextChanged(object sender, EventArgs e) { }
    }
}