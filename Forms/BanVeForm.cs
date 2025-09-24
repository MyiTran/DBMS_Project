#nullable disable
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DBMS.Models;
using DBMS.DAO;

namespace DBMS.Forms
{
    public partial class BanVeForm : Form
    {
        private VeDAO veDAO;
        private KhachHangDAO khachHangDAO;
        private BanVeDAO banVeDAO;

        private Ve veHienTai = null; // Vé đang chọn

        public BanVeForm()
        {
            InitializeComponent();
            veDAO = new VeDAO();
            khachHangDAO = new KhachHangDAO();
            banVeDAO = new BanVeDAO();

            this.Load += BanVeForm_Load;
        }

        private void BanVeForm_Load(object sender, EventArgs e)
        {
            SetupForm();
            SetupDataGridView();
            LoadComboBoxVe();
            LoadComboBoxKhachHang();
            LoadDanhSachBanVe();
        }

        private void SetupForm()
        {
            this.Text = "Bán Vé";
            this.StartPosition = FormStartPosition.CenterParent;
            this.WindowState = FormWindowState.Maximized;

            // Set font cho label tổng tiền
            if (lblTongTien != null)
            {
                lblTongTien.Font = new Font("Arial", 16, FontStyle.Bold);
                lblTongTien.ForeColor = Color.Red;
            }

            // Set default
            if (numSoLuong != null) numSoLuong.Value = 1;
            if (numGiamGia != null) numGiamGia.Value = 0;
        }

        private void SetupDataGridView()
        {
            if (dgvBanVe == null) return;

            dgvBanVe.Columns.Clear();
            dgvBanVe.Columns.Add("BanVeId", "Mã");
            dgvBanVe.Columns.Add("LoaiVe", "Loại vé");
            dgvBanVe.Columns.Add("TenKhachHang", "Khách hàng");
            dgvBanVe.Columns.Add("SoLuong", "SL");
            dgvBanVe.Columns.Add("DonGia", "Đơn giá");
            dgvBanVe.Columns.Add("GiamGia", "Giảm giá");
            dgvBanVe.Columns.Add("TongTien", "Tổng tiền");
            dgvBanVe.Columns.Add("ThanhToan", "Thanh toán");
            dgvBanVe.Columns.Add("Kenh", "Kênh");
            dgvBanVe.Columns.Add("NgayBan", "Ngày bán");

            dgvBanVe.Columns["BanVeId"].Width = 60;
            dgvBanVe.Columns["LoaiVe"].Width = 150;
            dgvBanVe.Columns["TenKhachHang"].Width = 150;
            dgvBanVe.Columns["SoLuong"].Width = 50;
            dgvBanVe.Columns["DonGia"].Width = 100;
            dgvBanVe.Columns["GiamGia"].Width = 100;
            dgvBanVe.Columns["TongTien"].Width = 120;
            dgvBanVe.Columns["ThanhToan"].Width = 120;
            dgvBanVe.Columns["Kenh"].Width = 80;
            dgvBanVe.Columns["NgayBan"].Width = 120;

            dgvBanVe.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            dgvBanVe.Columns["GiamGia"].DefaultCellStyle.Format = "N0";
            dgvBanVe.Columns["TongTien"].DefaultCellStyle.Format = "N0";
            dgvBanVe.Columns["NgayBan"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
        }

        private void LoadComboBoxVe()
        {
            if (cboVe == null) return;

            try
            {
                var danhSachVe = veDAO.LayTatCaVe()
                    .Where(v => v.ConHan)
                    .ToList();

                int currentSelectedId = 0;
                if (cboVe.SelectedItem != null)
                {
                    dynamic current = cboVe.SelectedItem;
                    currentSelectedId = current.VeId; // Lưu ID vé đang chọn
                }

                cboVe.Items.Clear();
                cboVe.DisplayMember = "Display";
                cboVe.ValueMember = "VeId";

                int indexToSelect = 0;
                for (int i = 0; i < danhSachVe.Count; i++)
                {
                    var ve = danhSachVe[i];
                    cboVe.Items.Add(new
                    {
                        VeId = ve.VeId,
                        Display = $"{ve.LoaiVe} - {ve.Gia:N0}đ",
                        Ve = ve
                    });

                    if (ve.VeId == currentSelectedId)
                        indexToSelect = i;
                }

                if (cboVe.Items.Count > 0)
                {
                    cboVe.SelectedIndex = indexToSelect; // Chọn lại vé cũ với data MỚI
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi load danh sách vé: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadComboBoxKhachHang()
        {
            if (cboKhachHang == null) return;

            try
            {
                var danhSachKH = khachHangDAO.LayTatCaKhachHang();

                cboKhachHang.Items.Clear();
                cboKhachHang.DisplayMember = "Display";
                cboKhachHang.ValueMember = "KhachHangId";

                foreach (var kh in danhSachKH)
                {
                    cboKhachHang.Items.Add(new
                    {
                        KhachHangId = kh.KhachHangId,
                        Display = $"{kh.HoTen} - {kh.SoDienThoai}"
                    });
                }

                if (cboKhachHang.Items.Count > 0) cboKhachHang.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi load danh sách khách hàng: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDanhSachBanVe()
        {
            if (dgvBanVe == null) return;

            try
            {
                var danhSach = banVeDAO.LayDanhSachBanVe();
                dgvBanVe.Rows.Clear();

                foreach (var bv in danhSach)
                {
                    dgvBanVe.Rows.Add(
                        bv.BanVeId,
                        bv.LoaiVe,
                        bv.TenKhachHang,
                        bv.SoLuong,
                        bv.DonGia,
                        bv.GiamGia,
                        bv.TongTien,
                        bv.ThanhToan,
                        bv.Kenh,
                        bv.NgayBan
                    );
                }

                this.Text = $"Bán Vé - Tổng: {danhSach.Count} giao dịch";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi load danh sách bán vé: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboVe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboVe?.SelectedItem == null) return;

            try
            {
                dynamic selected = cboVe.SelectedItem;
                veHienTai = selected.Ve as Ve;

                if (veHienTai != null)
                {
                    // Cập nhật đơn giá
                    if (txtDonGia != null)
                        txtDonGia.Text = veHienTai.Gia.ToString("N0");

                    // Cập nhật số lượng còn
                    CapNhatSoLuongCon();

                    // Tính lại tổng tiền
                    TinhTongTien();
                }
            }
            catch { }
        }

        private void rdoOnline_CheckedChanged(object sender, EventArgs e)
        {
            CapNhatSoLuongCon();
            TinhTongTien();
        }

        private void rdoOffline_CheckedChanged(object sender, EventArgs e)
        {
            CapNhatSoLuongCon();
            TinhTongTien();
        }

        private void CapNhatSoLuongCon()
        {
            if (veHienTai == null || lblConLai == null) return;

            try
            {
                int soLuongCon = 0;

                if (rdoOnline?.Checked == true)
                    soLuongCon = veHienTai.SoLuongOnline;
                else if (rdoOffline?.Checked == true)
                    soLuongCon = veHienTai.SoLuongOffline;

                lblConLai.Text = $"{soLuongCon:N0} vé";
                lblConLai.ForeColor = soLuongCon > 0 ? Color.Blue : Color.Red;

                // Cập nhật max của numSoLuong
                if (numSoLuong != null)
                {
                    numSoLuong.Maximum = soLuongCon > 0 ? soLuongCon : 1;
                    if (numSoLuong.Value > soLuongCon)
                        numSoLuong.Value = soLuongCon > 0 ? 1 : 0;
                }
            }
            catch { }
        }

        private void numSoLuong_ValueChanged(object sender, EventArgs e)
        {
            TinhTongTien();
        }

        private void numGiamGia_ValueChanged(object sender, EventArgs e)
        {
            TinhTongTien();
        }

        private void TinhTongTien()
        {
            if (lblTongTien == null || veHienTai == null) return;

            try
            {
                decimal donGia = veHienTai.Gia;
                int soLuong = (int)(numSoLuong?.Value ?? 0);
                decimal giamGia = numGiamGia?.Value ?? 0;

                decimal tong = (donGia * soLuong) - giamGia;
                if (tong < 0) tong = 0;

                lblTongTien.Text = $"{tong:N0} đ";
            }
            catch { }
        }

        private void btnBanVe_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                dynamic selectedVe = cboVe.SelectedItem;
                dynamic selectedKH = cboKhachHang.SelectedItem;

                var banVe = new BanVe
                {
                    VeId = selectedVe.VeId,
                    KhachHangId = selectedKH.KhachHangId,
                    SoLuong = (int)numSoLuong.Value,
                    DonGia = veHienTai.Gia,
                    GiamGia = numGiamGia.Value,
                    ThanhToan = rdoTienMat?.Checked == true ? "Tiền mặt" : "Chuyển khoản",
                    Kenh = rdoOnline?.Checked == true ? "online" : "offline"
                };

                banVe.TinhLaiTongTien(); // Tính tổng tiền

                var ketQua = banVeDAO.BanVe(banVe);

                MessageBox.Show(ketQua.thongBao,
                    ketQua.thanhCong ? "Thành công" : "Lỗi",
                    MessageBoxButtons.OK,
                    ketQua.thanhCong ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (ketQua.thanhCong)
                {
                    LoadDanhSachBanVe();
                    LoadComboBoxVe(); // Reload → sẽ tự trigger cboVe_SelectedIndexChanged → cập nhật veHienTai mới
                    ResetForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private bool ValidateInput()
        {
            if (cboVe?.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn vé!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboVe?.Focus();
                return false;
            }

            if (cboKhachHang?.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboKhachHang?.Focus();
                return false;
            }

            if (numSoLuong?.Value <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numSoLuong?.Focus();
                return false;
            }

            decimal tongTien = (veHienTai?.Gia ?? 0) * (int)(numSoLuong?.Value ?? 0);
            if (numGiamGia?.Value > tongTien)
            {
                MessageBox.Show("Giảm giá không được lớn hơn tổng tiền!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numGiamGia?.Focus();
                return false;
            }

            return true;
        }

        private void ResetForm()
        {
            if (numSoLuong != null) numSoLuong.Value = 1;
            if (numGiamGia != null) numGiamGia.Value = 0;
            if (rdoOffline != null) rdoOffline.Checked = true;
            if (rdoTienMat != null) rdoTienMat.Checked = true;

            // QUAN TRỌNG: Chọn lại vé để trigger update số lượng
            if (cboVe?.Items.Count > 0)
            {
                cboVe.SelectedIndex = -1; // Reset
                cboVe.SelectedIndex = 0;  // Chọn lại → trigger cboVe_SelectedIndexChanged
            }

            if (cboKhachHang?.Items.Count > 0)
                cboKhachHang.SelectedIndex = 0;
        }

        // Empty events (tránh lỗi Designer)
        private void label1_Click(object sender, EventArgs e) { }
        private void label1_Click_1(object sender, EventArgs e) { }
        private void dgvBanVe_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void grpThongTinBanVe_Enter(object sender, EventArgs e) { }
        private void lblConLai_Click(object sender, EventArgs e) { }
        private void lblConLaiKhung_Click(object sender, EventArgs e) { }
        private void lblChonVe_Click(object sender, EventArgs e) { }
        private void lblKenhBan_Click(object sender, EventArgs e) { }
        private void cboKhachHang_SelectedIndexChanged(object sender, EventArgs e) { }
        private void lblDonGia_Click(object sender, EventArgs e) { }
        private void txtDonGia_TextChanged(object sender, EventArgs e) { }
        private void lblGiamGia_Click(object sender, EventArgs e) { }
        private void lblTongTienKhung_Click(object sender, EventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void lblTongTien_Click(object sender, EventArgs e) { }
        private void lblThanhToan_Click(object sender, EventArgs e) { }
        private void rdoTienMat_CheckedChanged(object sender, EventArgs e) { }
        private void rdoChuyenKhoan_CheckedChanged(object sender, EventArgs e) { }
    }
}