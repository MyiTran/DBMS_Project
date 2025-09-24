#nullable disable
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DBMS.Models;
using DBMS.Service;

namespace DBMS.Forms
{
    public partial class VeForm : Form
    {
        private VeService veService;
        private int selectedVeId = 0; // 0 = thêm mới, >0 = sửa

        public VeForm()
        {
            InitializeComponent();
            veService = new VeService();

            this.Load += VeForm_Load;
        }

        private void VeForm_Load(object sender, EventArgs e)
        {
            SetupForm();
            SetupDataGridView();
            SetupDateTimePicker();
            SetupNumericUpDown();
            LoadData();
        }

        private void SetupForm()
        {
            this.Text = "Quản lý Vé";
            this.StartPosition = FormStartPosition.CenterParent;
            this.WindowState = FormWindowState.Maximized;

            if (txtLoaiVe != null) txtLoaiVe.Focus();
        }

        private void SetupDataGridView()
        {
            if (dgvVe == null) return;

            dgvVe.Columns.Clear();
            dgvVe.Columns.Add("VeId", "ID");
            dgvVe.Columns.Add("LoaiVe", "Loại vé");
            dgvVe.Columns.Add("Gia", "Giá (VND)");
            dgvVe.Columns.Add("NgayHieuLuc", "Ngày hiệu lực");
            dgvVe.Columns.Add("NgayHetHan", "Ngày hết hạn");
            dgvVe.Columns.Add("SoLuongOnline", "SL Online");
            dgvVe.Columns.Add("SoLuongOffline", "SL Offline");
            dgvVe.Columns.Add("TongSoLuong", "Tổng SL");
            dgvVe.Columns.Add("TrangThai", "Trạng thái");

            // Cấu hình columns
            dgvVe.Columns["VeId"].Visible = false;
            dgvVe.Columns["LoaiVe"].Width = 150;
            dgvVe.Columns["Gia"].Width = 100;
            dgvVe.Columns["NgayHieuLuc"].Width = 120;
            dgvVe.Columns["NgayHetHan"].Width = 120;
            dgvVe.Columns["SoLuongOnline"].Width = 80;
            dgvVe.Columns["SoLuongOffline"].Width = 80;
            dgvVe.Columns["TongSoLuong"].Width = 80;
            dgvVe.Columns["TrangThai"].Width = 120;

            // Format
            dgvVe.Columns["Gia"].DefaultCellStyle.Format = "N0";
            dgvVe.Columns["NgayHieuLuc"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvVe.Columns["NgayHetHan"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dgvVe.ReadOnly = true;
            dgvVe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVe.AllowUserToAddRows = false;
        }

        private void SetupDateTimePicker()
        {
            // Tìm DateTimePicker theo tên có thể khác nhau
            var dtpHieuLuc = this.Controls.Find("dtpNgayHieuLuc", true).FirstOrDefault() as DateTimePicker ??
                            this.Controls.Find("dateTimeNgayHieuLuc", true).FirstOrDefault() as DateTimePicker;

            var dtpHetHan = this.Controls.Find("dtpNgayHetHan", true).FirstOrDefault() as DateTimePicker ??
                           this.Controls.Find("dateTimeNgayHetHan", true).FirstOrDefault() as DateTimePicker;

            if (dtpHieuLuc != null)
            {
                dtpHieuLuc.Format = DateTimePickerFormat.Custom;
                dtpHieuLuc.CustomFormat = "dd/MM/yyyy";
                dtpHieuLuc.Value = DateTime.Today;
                dtpHieuLuc.MinDate = DateTime.Today;
            }

            if (dtpHetHan != null)
            {
                dtpHetHan.Format = DateTimePickerFormat.Custom;
                dtpHetHan.CustomFormat = "dd/MM/yyyy";
                dtpHetHan.Value = DateTime.Today.AddMonths(6);
                dtpHetHan.MinDate = DateTime.Today.AddDays(1);
            }
        }

        private void SetupNumericUpDown()
        {
            if (numGia != null)
            {
                numGia.Maximum = 999999999;
                numGia.ThousandsSeparator = true;
                numGia.DecimalPlaces = 0;
            }

            if (numSoLuongOnline != null)
            {
                numSoLuongOnline.Maximum = 999999;
                numSoLuongOnline.Minimum = 0;
            }

            if (numSoLuongOffline != null)
            {
                numSoLuongOffline.Maximum = 999999;
                numSoLuongOffline.Minimum = 0;
            }
        }

        private void LoadData()
        {
            try
            {
                if (dgvVe == null) return;

                var danhSach = veService.LayTatCaVe();
                dgvVe.Rows.Clear();

                foreach (var ve in danhSach)
                {
                    dgvVe.Rows.Add(
                        ve.VeId,
                        ve.LoaiVe ?? "",
                        ve.Gia,
                        ve.NgayHieuLuc.ToString("dd/MM/yyyy"),
                        ve.NgayHetHan.ToString("dd/MM/yyyy"),
                        ve.SoLuongOnline,
                        ve.SoLuongOffline,
                        ve.TongSoLuong,
                        ve.TrangThai ?? ""
                    );
                }

                this.Text = $"Quản lý Vé - Tổng: {danhSach.Count} loại vé";

                var thongKe = veService.ThongKeSoLuongVe();
                this.Text += $" - Tổng SL: {thongKe.tongTatCa} (Online: {thongKe.tongOnline}, Offline: {thongKe.tongOffline})";
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
                var ve = new Ve
                {
                    LoaiVe = txtLoaiVe?.Text?.Trim() ?? "",
                    Gia = numGia?.Value ?? 0,
                    NgayHieuLuc = GetNgayHieuLuc(),
                    NgayHetHan = GetNgayHetHan(),
                    SoLuongOnline = (int)(numSoLuongOnline?.Value ?? 0),
                    SoLuongOffline = (int)(numSoLuongOffline?.Value ?? 0)
                };

                var ketQua = veService.ThemVe(ve);

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
            if (selectedVeId == 0)
            {
                MessageBox.Show("Vui lòng chọn vé cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput()) return;

            try
            {
                var ve = new Ve
                {
                    VeId = selectedVeId,
                    LoaiVe = txtLoaiVe?.Text?.Trim() ?? "",
                    Gia = numGia?.Value ?? 0,
                    NgayHieuLuc = GetNgayHieuLuc(),
                    NgayHetHan = GetNgayHetHan(),
                    SoLuongOnline = (int)(numSoLuongOnline?.Value ?? 0),
                    SoLuongOffline = (int)(numSoLuongOffline?.Value ?? 0)
                };

                var ketQua = veService.SuaVe(ve);

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
            if (selectedVeId == 0)
            {
                MessageBox.Show("Vui lòng chọn vé cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var ve = veService.LayVeTheoId(selectedVeId);
            if (ve == null)
            {
                MessageBox.Show("Vé không tồn tại!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa vé:\n{ve.LoaiVe} - {ve.Gia:N0} VND?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var ketQua = veService.XoaVe(selectedVeId);

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
                string keyword = txtTimKiem?.Text?.Trim().ToLower() ?? "";
                var danhSach = veService.LayTatCaVe();

                if (!string.IsNullOrEmpty(keyword))
                {
                    danhSach = danhSach.Where(v =>
                        (v.LoaiVe ?? "").ToLower().Contains(keyword) ||
                        (v.TrangThai ?? "").ToLower().Contains(keyword) ||
                        v.Gia.ToString().Contains(keyword)
                    ).ToList();
                }

                if (dgvVe != null)
                {
                    dgvVe.Rows.Clear();
                    foreach (var ve in danhSach)
                    {
                        dgvVe.Rows.Add(
                            ve.VeId,
                            ve.LoaiVe ?? "",
                            ve.Gia,
                            ve.NgayHieuLuc.ToString("dd/MM/yyyy"),
                            ve.NgayHetHan.ToString("dd/MM/yyyy"),
                            ve.SoLuongOnline,
                            ve.SoLuongOffline,
                            ve.TongSoLuong,
                            ve.TrangThai ?? ""
                        );
                    }
                }

                this.Text = $"Quản lý Vé - Tìm thấy: {danhSach.Count} vé";

                if (danhSach.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy vé nào!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tìm kiếm: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvVe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvVe?.Rows[e.RowIndex]?.Cells["VeId"]?.Value != null)
            {
                try
                {
                    selectedVeId = Convert.ToInt32(dgvVe.Rows[e.RowIndex].Cells["VeId"].Value);

                    // Load thông tin lên form
                    if (txtLoaiVe != null)
                        txtLoaiVe.Text = dgvVe.Rows[e.RowIndex].Cells["LoaiVe"].Value?.ToString() ?? "";

                    if (numGia != null)
                        numGia.Value = Convert.ToDecimal(dgvVe.Rows[e.RowIndex].Cells["Gia"].Value ?? 0);

                    SetNgayHieuLuc(dgvVe.Rows[e.RowIndex].Cells["NgayHieuLuc"].Value?.ToString());
                    SetNgayHetHan(dgvVe.Rows[e.RowIndex].Cells["NgayHetHan"].Value?.ToString());

                    if (numSoLuongOnline != null)
                        numSoLuongOnline.Value = Convert.ToInt32(dgvVe.Rows[e.RowIndex].Cells["SoLuongOnline"].Value ?? 0);

                    if (numSoLuongOffline != null)
                        numSoLuongOffline.Value = Convert.ToInt32(dgvVe.Rows[e.RowIndex].Cells["SoLuongOffline"].Value ?? 0);

                    // Cập nhật trạng thái - dùng lblTrangThai1
                    string trangThai = dgvVe.Rows[e.RowIndex].Cells["TrangThai"].Value?.ToString() ?? "";
                    SetTrangThai(trangThai);

                    if (btnSua != null) btnSua.Text = $"Sửa (ID: {selectedVeId})";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi chọn vé: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearForm()
        {
            selectedVeId = 0;

            if (txtLoaiVe != null) txtLoaiVe.Clear();
            if (numGia != null) numGia.Value = 0;
            if (numSoLuongOnline != null) numSoLuongOnline.Value = 0;
            if (numSoLuongOffline != null) numSoLuongOffline.Value = 0;
            if (txtTimKiem != null) txtTimKiem.Clear();

            SetupDateTimePicker(); // Reset về giá trị mặc định
            SetTrangThai(""); // Clear trạng thái

            if (btnSua != null) btnSua.Text = "Sửa";
            if (txtLoaiVe != null) txtLoaiVe.Focus();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtLoaiVe?.Text))
            {
                MessageBox.Show("Vui lòng nhập loại vé!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLoaiVe?.Focus();
                return false;
            }

            if (numGia?.Value <= 0)
            {
                MessageBox.Show("Giá vé phải lớn hơn 0!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numGia?.Focus();
                return false;
            }

            if (GetNgayHetHan() <= GetNgayHieuLuc())
            {
                MessageBox.Show("Ngày hết hạn phải sau ngày hiệu lực!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if ((numSoLuongOnline?.Value ?? 0) + (numSoLuongOffline?.Value ?? 0) <= 0)
            {
                MessageBox.Show("Tổng số lượng vé phải lớn hơn 0!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        // Helper methods
        private DateTime GetNgayHieuLuc()
        {
            var dtp = this.Controls.Find("dtpNgayHieuLuc", true).FirstOrDefault() as DateTimePicker ??
                     this.Controls.Find("dateTimeNgayHieuLuc", true).FirstOrDefault() as DateTimePicker;
            return dtp?.Value ?? DateTime.Today;
        }

        private DateTime GetNgayHetHan()
        {
            var dtp = this.Controls.Find("dtpNgayHetHan", true).FirstOrDefault() as DateTimePicker ??
                     this.Controls.Find("dateTimeNgayHetHan", true).FirstOrDefault() as DateTimePicker;
            return dtp?.Value ?? DateTime.Today.AddMonths(6);
        }

        private void SetNgayHieuLuc(string ngayStr)
        {
            var dtp = this.Controls.Find("dtpNgayHieuLuc", true).FirstOrDefault() as DateTimePicker ??
                     this.Controls.Find("dateTimeNgayHieuLuc", true).FirstOrDefault() as DateTimePicker;
            if (dtp != null && DateTime.TryParseExact(ngayStr, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime ngay))
            {
                dtp.Value = ngay;
            }
        }

        private void SetNgayHetHan(string ngayStr)
        {
            var dtp = this.Controls.Find("dtpNgayHetHan", true).FirstOrDefault() as DateTimePicker ??
                     this.Controls.Find("dateTimeNgayHetHan", true).FirstOrDefault() as DateTimePicker;
            if (dtp != null && DateTime.TryParseExact(ngayStr, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime ngay))
            {
                dtp.Value = ngay;
            }
        }

        private void SetTrangThai(string trangThai)
        {
            // Tìm lblTrangThai1 hoặc lblTrangThai
            var lblTrangThai = this.Controls.Find("lblTrangThai1", true).FirstOrDefault() as Label ??
                              this.Controls.Find("lblTrangThai", true).FirstOrDefault() as Label;

            if (lblTrangThai != null)
            {
                lblTrangThai.Text = trangThai;

                // Đổi màu theo trạng thái
                switch (trangThai?.ToLower())
                {
                    case "còn hạn":
                        lblTrangThai.ForeColor = Color.Green;
                        break;
                    case "hết hạn":
                        lblTrangThai.ForeColor = Color.Red;
                        break;
                    case "hết hàng":
                        lblTrangThai.ForeColor = Color.Orange;
                        break;
                    case "chưa có hiệu lực":
                        lblTrangThai.ForeColor = Color.Blue;
                        break;
                    default:
                        lblTrangThai.ForeColor = Color.Black;
                        break;
                }
            }
        }

        // Các events trống để tránh lỗi
        private void label2_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void lblLoaiVe_Click(object sender, EventArgs e) { }
        private void txtLoaiVe_TextChanged(object sender, EventArgs e) { }
        private void numGia_ValueChanged(object sender, EventArgs e) { }
        private void lblNgayHieuLuc_Click(object sender, EventArgs e) { }
        private void dateTimeNgayHieuLuc_ValueChanged(object sender, EventArgs e) { }
        private void lblNgayHetHan_Click(object sender, EventArgs e) { }
        private void dateTimeNgayHetHan_ValueChanged(object sender, EventArgs e) { }
        private void lblSLOnline_Click(object sender, EventArgs e) { }
        private void numSoLuongOnline_ValueChanged(object sender, EventArgs e) { }
        private void lblSLOffline_Click(object sender, EventArgs e) { }
        private void numSoLuongOffline_ValueChanged(object sender, EventArgs e) { }
        private void lblTimKiem_Click(object sender, EventArgs e) { }
        private void txtTimKiem_TextChanged(object sender, EventArgs e) { }
    }
}