namespace DBMS.Forms
{
    partial class BanVeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvBanVe = new DataGridView();
            grpThongTinBanVe = new GroupBox();
            numGiamGia = new NumericUpDown();
            lblGiamGia = new Label();
            txtDonGia = new TextBox();
            lblDonGia = new Label();
            numSoLuong = new NumericUpDown();
            lblSoLuong = new Label();
            cboKhachHang = new ComboBox();
            lblKhachHang = new Label();
            lblConLai = new Label();
            lblConLaiKhung = new Label();
            rdoOffline = new RadioButton();
            rdoOnline = new RadioButton();
            lblKenhBan = new Label();
            cboVe = new ComboBox();
            lblChonVe = new Label();
            lblTongTienKhung = new Label();
            lblTongTien = new Label();
            lblThanhToan = new Label();
            rdoTienMat = new RadioButton();
            rdoChuyenKhoan = new RadioButton();
            btnBanVe = new Button();
            btnLamMoi = new Button();
            groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dgvBanVe).BeginInit();
            grpThongTinBanVe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numGiamGia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvBanVe
            // 
            dgvBanVe.AllowUserToAddRows = false;
            dgvBanVe.BackgroundColor = Color.Snow;
            dgvBanVe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBanVe.Dock = DockStyle.Top;
            dgvBanVe.Location = new Point(0, 0);
            dgvBanVe.Name = "dgvBanVe";
            dgvBanVe.ReadOnly = true;
            dgvBanVe.RowHeadersWidth = 82;
            dgvBanVe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBanVe.Size = new Size(1168, 324);
            dgvBanVe.TabIndex = 0;
            dgvBanVe.CellContentClick += dgvBanVe_CellContentClick;
            // 
            // grpThongTinBanVe
            // 
            grpThongTinBanVe.Controls.Add(numGiamGia);
            grpThongTinBanVe.Controls.Add(lblGiamGia);
            grpThongTinBanVe.Controls.Add(txtDonGia);
            grpThongTinBanVe.Controls.Add(lblDonGia);
            grpThongTinBanVe.Controls.Add(numSoLuong);
            grpThongTinBanVe.Controls.Add(lblSoLuong);
            grpThongTinBanVe.Controls.Add(cboKhachHang);
            grpThongTinBanVe.Controls.Add(lblKhachHang);
            grpThongTinBanVe.Controls.Add(lblConLai);
            grpThongTinBanVe.Controls.Add(lblConLaiKhung);
            grpThongTinBanVe.Controls.Add(rdoOffline);
            grpThongTinBanVe.Controls.Add(rdoOnline);
            grpThongTinBanVe.Controls.Add(lblKenhBan);
            grpThongTinBanVe.Controls.Add(cboVe);
            grpThongTinBanVe.Controls.Add(lblChonVe);
            grpThongTinBanVe.Font = new Font("Arial", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpThongTinBanVe.ForeColor = Color.Maroon;
            grpThongTinBanVe.Location = new Point(21, 350);
            grpThongTinBanVe.Name = "grpThongTinBanVe";
            grpThongTinBanVe.Size = new Size(1114, 416);
            grpThongTinBanVe.TabIndex = 1;
            grpThongTinBanVe.TabStop = false;
            grpThongTinBanVe.Text = "Thông tin bán vé";
            grpThongTinBanVe.Enter += grpThongTinBanVe_Enter;
            // 
            // numGiamGia
            // 
            numGiamGia.Location = new Point(264, 361);
            numGiamGia.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            numGiamGia.Name = "numGiamGia";
            numGiamGia.Size = new Size(240, 41);
            numGiamGia.TabIndex = 14;
            numGiamGia.ThousandsSeparator = true;
            numGiamGia.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numGiamGia.ValueChanged += numGiamGia_ValueChanged;
            // 
            // lblGiamGia
            // 
            lblGiamGia.AutoSize = true;
            lblGiamGia.Location = new Point(72, 363);
            lblGiamGia.Name = "lblGiamGia";
            lblGiamGia.Size = new Size(148, 34);
            lblGiamGia.TabIndex = 13;
            lblGiamGia.Text = "Giảm giá:";
            lblGiamGia.Click += lblGiamGia_Click;
            // 
            // txtDonGia
            // 
            txtDonGia.BackColor = Color.SeaShell;
            txtDonGia.Location = new Point(264, 305);
            txtDonGia.Name = "txtDonGia";
            txtDonGia.ReadOnly = true;
            txtDonGia.Size = new Size(242, 41);
            txtDonGia.TabIndex = 12;
            txtDonGia.TabStop = false;
            txtDonGia.TextChanged += txtDonGia_TextChanged;
            // 
            // lblDonGia
            // 
            lblDonGia.AutoSize = true;
            lblDonGia.Location = new Point(72, 305);
            lblDonGia.Name = "lblDonGia";
            lblDonGia.Size = new Size(135, 34);
            lblDonGia.TabIndex = 11;
            lblDonGia.Text = "Đơn giá:";
            lblDonGia.Click += lblDonGia_Click;
            // 
            // numSoLuong
            // 
            numSoLuong.Location = new Point(266, 248);
            numSoLuong.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numSoLuong.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numSoLuong.Name = "numSoLuong";
            numSoLuong.Size = new Size(240, 41);
            numSoLuong.TabIndex = 10;
            numSoLuong.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numSoLuong.ValueChanged += numSoLuong_ValueChanged;
            // 
            // lblSoLuong
            // 
            lblSoLuong.AutoSize = true;
            lblSoLuong.Location = new Point(72, 256);
            lblSoLuong.Name = "lblSoLuong";
            lblSoLuong.Size = new Size(156, 34);
            lblSoLuong.TabIndex = 9;
            lblSoLuong.Text = "Số lượng:";
            lblSoLuong.Click += label1_Click_1;
            // 
            // cboKhachHang
            // 
            cboKhachHang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKhachHang.FormattingEnabled = true;
            cboKhachHang.Location = new Point(264, 190);
            cboKhachHang.Name = "cboKhachHang";
            cboKhachHang.Size = new Size(242, 42);
            cboKhachHang.TabIndex = 8;
            cboKhachHang.SelectedIndexChanged += cboKhachHang_SelectedIndexChanged;
            // 
            // lblKhachHang
            // 
            lblKhachHang.AutoSize = true;
            lblKhachHang.Location = new Point(72, 198);
            lblKhachHang.Name = "lblKhachHang";
            lblKhachHang.Size = new Size(192, 34);
            lblKhachHang.TabIndex = 7;
            lblKhachHang.Text = "Khách hàng:";
            lblKhachHang.Click += label1_Click;
            // 
            // lblConLai
            // 
            lblConLai.AutoSize = true;
            lblConLai.Font = new Font("Arial", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblConLai.ForeColor = SystemColors.MenuHighlight;
            lblConLai.Location = new Point(264, 150);
            lblConLai.Name = "lblConLai";
            lblConLai.Size = new Size(72, 34);
            lblConLai.TabIndex = 6;
            lblConLai.Text = "0 vé";
            lblConLai.Click += lblConLai_Click;
            // 
            // lblConLaiKhung
            // 
            lblConLaiKhung.AutoSize = true;
            lblConLaiKhung.Location = new Point(72, 151);
            lblConLaiKhung.Name = "lblConLaiKhung";
            lblConLaiKhung.Size = new Size(122, 34);
            lblConLaiKhung.TabIndex = 5;
            lblConLaiKhung.Text = "Còn lại:";
            lblConLaiKhung.Click += lblConLaiKhung_Click;
            // 
            // rdoOffline
            // 
            rdoOffline.AutoSize = true;
            rdoOffline.Location = new Point(460, 96);
            rdoOffline.Name = "rdoOffline";
            rdoOffline.Size = new Size(138, 38);
            rdoOffline.TabIndex = 4;
            rdoOffline.Text = "Offline";
            rdoOffline.UseVisualStyleBackColor = true;
            rdoOffline.CheckedChanged += rdoOffline_CheckedChanged;
            // 
            // rdoOnline
            // 
            rdoOnline.AutoSize = true;
            rdoOnline.Checked = true;
            rdoOnline.Location = new Point(264, 94);
            rdoOnline.Name = "rdoOnline";
            rdoOnline.Size = new Size(136, 38);
            rdoOnline.TabIndex = 3;
            rdoOnline.TabStop = true;
            rdoOnline.Text = "Online";
            rdoOnline.UseVisualStyleBackColor = true;
            rdoOnline.CheckedChanged += rdoOnline_CheckedChanged;
            // 
            // lblKenhBan
            // 
            lblKenhBan.AutoSize = true;
            lblKenhBan.Location = new Point(72, 96);
            lblKenhBan.Name = "lblKenhBan";
            lblKenhBan.Size = new Size(158, 34);
            lblKenhBan.TabIndex = 2;
            lblKenhBan.Text = "Kênh bán:";
            lblKenhBan.Click += lblKenhBan_Click;
            // 
            // cboVe
            // 
            cboVe.DropDownStyle = ComboBoxStyle.DropDownList;
            cboVe.FormattingEnabled = true;
            cboVe.Location = new Point(264, 44);
            cboVe.Name = "cboVe";
            cboVe.Size = new Size(242, 42);
            cboVe.TabIndex = 1;
            cboVe.SelectedIndexChanged += cboVe_SelectedIndexChanged;
            // 
            // lblChonVe
            // 
            lblChonVe.AutoSize = true;
            lblChonVe.Location = new Point(72, 52);
            lblChonVe.Name = "lblChonVe";
            lblChonVe.Size = new Size(141, 34);
            lblChonVe.TabIndex = 0;
            lblChonVe.Text = "Chọn vé:";
            lblChonVe.Click += lblChonVe_Click;
            // 
            // lblTongTienKhung
            // 
            lblTongTienKhung.AutoSize = true;
            lblTongTienKhung.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblTongTienKhung.ForeColor = Color.DarkRed;
            lblTongTienKhung.Location = new Point(72, 45);
            lblTongTienKhung.Name = "lblTongTienKhung";
            lblTongTienKhung.Size = new Size(198, 37);
            lblTongTienKhung.TabIndex = 15;
            lblTongTienKhung.Text = "TỔNG TIỀN:";
            lblTongTienKhung.Click += lblTongTienKhung_Click;
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblTongTien.ForeColor = Color.DarkRed;
            lblTongTien.Location = new Point(288, 45);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(64, 37);
            lblTongTien.TabIndex = 16;
            lblTongTien.Text = "0 đ";
            lblTongTien.Click += lblTongTien_Click;
            // 
            // lblThanhToan
            // 
            lblThanhToan.AutoSize = true;
            lblThanhToan.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblThanhToan.ForeColor = Color.DarkRed;
            lblThanhToan.Location = new Point(74, 94);
            lblThanhToan.Name = "lblThanhToan";
            lblThanhToan.Size = new Size(198, 37);
            lblThanhToan.TabIndex = 17;
            lblThanhToan.Text = "Thanh toán:";
            lblThanhToan.Click += lblThanhToan_Click;
            // 
            // rdoTienMat
            // 
            rdoTienMat.AutoSize = true;
            rdoTienMat.Checked = true;
            rdoTienMat.Font = new Font("Arial", 12F, FontStyle.Bold);
            rdoTienMat.ForeColor = Color.DarkRed;
            rdoTienMat.Location = new Point(278, 94);
            rdoTienMat.Name = "rdoTienMat";
            rdoTienMat.Size = new Size(180, 41);
            rdoTienMat.TabIndex = 18;
            rdoTienMat.TabStop = true;
            rdoTienMat.Text = "Tiền mặt";
            rdoTienMat.UseVisualStyleBackColor = true;
            rdoTienMat.CheckedChanged += rdoTienMat_CheckedChanged;
            // 
            // rdoChuyenKhoan
            // 
            rdoChuyenKhoan.AutoSize = true;
            rdoChuyenKhoan.Font = new Font("Arial", 12F, FontStyle.Bold);
            rdoChuyenKhoan.ForeColor = Color.DarkRed;
            rdoChuyenKhoan.Location = new Point(472, 94);
            rdoChuyenKhoan.Name = "rdoChuyenKhoan";
            rdoChuyenKhoan.Size = new Size(265, 41);
            rdoChuyenKhoan.TabIndex = 19;
            rdoChuyenKhoan.Text = "Chuyển khoản";
            rdoChuyenKhoan.UseVisualStyleBackColor = true;
            rdoChuyenKhoan.CheckedChanged += rdoChuyenKhoan_CheckedChanged;
            // 
            // btnBanVe
            // 
            btnBanVe.BackColor = Color.Green;
            btnBanVe.Font = new Font("Arial", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBanVe.ForeColor = SystemColors.ControlLightLight;
            btnBanVe.Location = new Point(375, 1013);
            btnBanVe.Name = "btnBanVe";
            btnBanVe.Size = new Size(150, 46);
            btnBanVe.TabIndex = 2;
            btnBanVe.Text = "Bán vé";
            btnBanVe.UseVisualStyleBackColor = false;
            btnBanVe.Click += btnBanVe_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.PeachPuff;
            btnLamMoi.Font = new Font("Arial", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLamMoi.Location = new Point(545, 1013);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(150, 46);
            btnLamMoi.TabIndex = 3;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rdoChuyenKhoan);
            groupBox1.Controls.Add(lblTongTienKhung);
            groupBox1.Controls.Add(rdoTienMat);
            groupBox1.Controls.Add(lblTongTien);
            groupBox1.Controls.Add(lblThanhToan);
            groupBox1.Location = new Point(21, 758);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1114, 225);
            groupBox1.TabIndex = 20;
            groupBox1.TabStop = false;
            groupBox1.Enter += groupBox1_Enter;
            // 
            // BanVeForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MistyRose;
            ClientSize = new Size(1168, 1118);
            Controls.Add(groupBox1);
            Controls.Add(btnLamMoi);
            Controls.Add(btnBanVe);
            Controls.Add(grpThongTinBanVe);
            Controls.Add(dgvBanVe);
            Name = "BanVeForm";
            Text = "BanVeForm";
            ((System.ComponentModel.ISupportInitialize)dgvBanVe).EndInit();
            grpThongTinBanVe.ResumeLayout(false);
            grpThongTinBanVe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numGiamGia).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvBanVe;
        private GroupBox grpThongTinBanVe;
        private ComboBox cboVe;
        private Label lblChonVe;
        private Label lblConLaiKhung;
        private RadioButton rdoOffline;
        private RadioButton rdoOnline;
        private Label lblKenhBan;
        private Label lblKhachHang;
        private Label lblConLai;
        private Label lblSoLuong;
        private ComboBox cboKhachHang;
        private NumericUpDown numSoLuong;
        private Label lblDonGia;
        private TextBox txtDonGia;
        private Label lblThanhToan;
        private Label lblTongTien;
        private Label lblTongTienKhung;
        private NumericUpDown numGiamGia;
        private Label lblGiamGia;
        private RadioButton rdoChuyenKhoan;
        private RadioButton rdoTienMat;
        private Button btnBanVe;
        private Button btnLamMoi;
        private GroupBox groupBox1;
    }
}