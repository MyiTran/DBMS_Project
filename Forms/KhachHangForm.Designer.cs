namespace DBMS.Forms
{
    partial class KhachHangForm
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
            txtHoTen = new TextBox();
            lblHoTen = new Label();
            groupBox1 = new GroupBox();
            dtpNgaySinh = new DateTimePicker();
            btnLamMoi = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            cboGioiTinh = new ComboBox();
            lblGioiTinh = new Label();
            lblNgaySinh = new Label();
            lblSoDienThoai = new Label();
            lblEmail = new Label();
            txtEmail = new TextBox();
            txtSoDienThoai = new TextBox();
            dgvKhachHang = new DataGridView();
            label1 = new Label();
            txtTimKiem = new TextBox();
            btnTimKiem = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).BeginInit();
            SuspendLayout();
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(160, 38);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(488, 39);
            txtHoTen.TabIndex = 1;
            txtHoTen.TextChanged += txtHoTen_TextChanged;
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(17, 45);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(99, 32);
            lblHoTen.TabIndex = 6;
            lblHoTen.Text = "Ho Ten";
            lblHoTen.Click += label1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dtpNgaySinh);
            groupBox1.Controls.Add(btnLamMoi);
            groupBox1.Controls.Add(btnXoa);
            groupBox1.Controls.Add(btnSua);
            groupBox1.Controls.Add(btnThem);
            groupBox1.Controls.Add(cboGioiTinh);
            groupBox1.Controls.Add(lblHoTen);
            groupBox1.Controls.Add(txtHoTen);
            groupBox1.Controls.Add(lblGioiTinh);
            groupBox1.Controls.Add(lblNgaySinh);
            groupBox1.Controls.Add(lblSoDienThoai);
            groupBox1.Controls.Add(lblEmail);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(txtSoDienThoai);
            groupBox1.Font = new Font("Arial", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(33, 318);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1439, 344);
            groupBox1.TabIndex = 17;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin Khách hàng";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.Location = new Point(160, 99);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.ShowCheckBox = true;
            dtpNgaySinh.Size = new Size(400, 39);
            dtpNgaySinh.TabIndex = 21;
            dtpNgaySinh.Value = new DateTime(2005, 9, 26, 0, 0, 0, 0);
            dtpNgaySinh.ValueChanged += dtpNgaySinh_ValueChanged;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.Beige;
            btnLamMoi.Font = new Font("Arial", 10.125F);
            btnLamMoi.Location = new Point(632, 268);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(150, 46);
            btnLamMoi.TabIndex = 20;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.RosyBrown;
            btnXoa.Font = new Font("Arial", 10.125F);
            btnXoa.Location = new Point(444, 268);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(150, 46);
            btnXoa.TabIndex = 19;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.CornflowerBlue;
            btnSua.Font = new Font("Arial", 10.125F);
            btnSua.Location = new Point(242, 268);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(150, 46);
            btnSua.TabIndex = 18;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.MediumSeaGreen;
            btnThem.Font = new Font("Arial", 10.125F);
            btnThem.Location = new Point(62, 268);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(150, 46);
            btnThem.TabIndex = 17;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // cboGioiTinh
            // 
            cboGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGioiTinh.FormattingEnabled = true;
            cboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            cboGioiTinh.Location = new Point(901, 46);
            cboGioiTinh.Name = "cboGioiTinh";
            cboGioiTinh.Size = new Size(242, 40);
            cboGioiTinh.TabIndex = 16;
            cboGioiTinh.SelectedIndexChanged += cboGioiTinh_SelectedIndexChanged;
            // 
            // lblGioiTinh
            // 
            lblGioiTinh.AutoSize = true;
            lblGioiTinh.Location = new Point(709, 46);
            lblGioiTinh.Name = "lblGioiTinh";
            lblGioiTinh.Size = new Size(114, 32);
            lblGioiTinh.TabIndex = 9;
            lblGioiTinh.Text = "Gioi tinh";
            lblGioiTinh.Click += lblGioiTinh_Click;
            // 
            // lblNgaySinh
            // 
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Location = new Point(13, 99);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.Size = new Size(139, 32);
            lblNgaySinh.TabIndex = 7;
            lblNgaySinh.Text = "Ngay Sinh";
            lblNgaySinh.Click += label2_Click;
            // 
            // lblSoDienThoai
            // 
            lblSoDienThoai.AutoSize = true;
            lblSoDienThoai.Location = new Point(709, 99);
            lblSoDienThoai.Name = "lblSoDienThoai";
            lblSoDienThoai.Size = new Size(186, 32);
            lblSoDienThoai.TabIndex = 10;
            lblSoDienThoai.Text = "So Dien Thoai";
            lblSoDienThoai.Click += lblSoDienThoai_Click;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(17, 166);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(81, 32);
            lblEmail.TabIndex = 8;
            lblEmail.Text = "Email";
            lblEmail.Click += label3_Click;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(160, 159);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(488, 39);
            txtEmail.TabIndex = 5;
            txtEmail.TextChanged += textBox4_TextChanged;
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.Location = new Point(901, 96);
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(486, 39);
            txtSoDienThoai.TabIndex = 3;
            txtSoDienThoai.TextChanged += textBox2_TextChanged;
            // 
            // dgvKhachHang
            // 
            dgvKhachHang.AllowUserToAddRows = false;
            dgvKhachHang.AllowUserToDeleteRows = false;
            dgvKhachHang.BackgroundColor = Color.White;
            dgvKhachHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKhachHang.Dock = DockStyle.Top;
            dgvKhachHang.Location = new Point(0, 0);
            dgvKhachHang.Name = "dgvKhachHang";
            dgvKhachHang.ReadOnly = true;
            dgvKhachHang.RowHeadersWidth = 82;
            dgvKhachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKhachHang.Size = new Size(1484, 300);
            dgvKhachHang.TabIndex = 18;
            dgvKhachHang.CellContentClick += dgvKhachHang_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(133, 678);
            label1.Name = "label1";
            label1.Size = new Size(146, 33);
            label1.TabIndex = 19;
            label1.Text = "Tìm kiếm:";
            label1.Click += label1_Click_1;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(275, 676);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(200, 39);
            txtTimKiem.TabIndex = 20;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = Color.Azure;
            btnTimKiem.Location = new Point(493, 672);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(114, 46);
            btnTimKiem.TabIndex = 21;
            btnTimKiem.Text = "Tìm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // KhachHangForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1484, 864);
            Controls.Add(btnTimKiem);
            Controls.Add(txtTimKiem);
            Controls.Add(label1);
            Controls.Add(dgvKhachHang);
            Controls.Add(groupBox1);
            Name = "KhachHangForm";
            Text = "KhachHangForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtHoTen;
        private Label lblHoTen;
        private GroupBox groupBox1;
        private ComboBox cboGioiTinh;
        private Label lblGioiTinh;
        private Label lblNgaySinh;
        private Label lblSoDienThoai;
        private Label lblEmail;
        private TextBox txtEmail;
        private TextBox txtSoDienThoai;
        private DataGridView dgvKhachHang;
        private Button btnLamMoi;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
        private Label label1;
        private DateTimePicker dtpNgaySinh;
        private TextBox txtTimKiem;
        private Button btnTimKiem;
    }
}