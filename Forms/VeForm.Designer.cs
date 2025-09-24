namespace DBMS.Forms
{
    partial class VeForm
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
            groupBox1 = new GroupBox();
            lblTrangThai1 = new Label();
            btnLamMoi = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnThem = new Button();
            numSoLuongOffline = new NumericUpDown();
            numSoLuongOnline = new NumericUpDown();
            dateTimeNgayHetHan = new DateTimePicker();
            dateTimeNgayHieuLuc = new DateTimePicker();
            numGia = new NumericUpDown();
            lblTrangThai = new Label();
            txtLoaiVe = new TextBox();
            lblKhungTrangThai = new Label();
            lblSLOffline = new Label();
            lblSLOnline = new Label();
            lblNgayHetHan = new Label();
            lblNgayHieuLuc = new Label();
            lblGia = new Label();
            lblLoaiVe = new Label();
            lblTimKiem = new Label();
            txtTimKiem = new TextBox();
            btnTimKiem = new Button();
            dgvVe = new DataGridView();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSoLuongOffline).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuongOnline).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numGia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvVe).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Honeydew;
            groupBox1.Controls.Add(lblTrangThai1);
            groupBox1.Controls.Add(btnLamMoi);
            groupBox1.Controls.Add(btnSua);
            groupBox1.Controls.Add(btnXoa);
            groupBox1.Controls.Add(btnThem);
            groupBox1.Controls.Add(numSoLuongOffline);
            groupBox1.Controls.Add(numSoLuongOnline);
            groupBox1.Controls.Add(dateTimeNgayHetHan);
            groupBox1.Controls.Add(dateTimeNgayHieuLuc);
            groupBox1.Controls.Add(numGia);
            groupBox1.Controls.Add(lblTrangThai);
            groupBox1.Controls.Add(txtLoaiVe);
            groupBox1.Controls.Add(lblKhungTrangThai);
            groupBox1.Controls.Add(lblSLOffline);
            groupBox1.Controls.Add(lblSLOnline);
            groupBox1.Controls.Add(lblNgayHetHan);
            groupBox1.Controls.Add(lblNgayHieuLuc);
            groupBox1.Controls.Add(lblGia);
            groupBox1.Controls.Add(lblLoaiVe);
            groupBox1.Font = new Font("Tahoma", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(25, 324);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1502, 406);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin Vé";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // lblTrangThai1
            // 
            lblTrangThai1.BackColor = SystemColors.ButtonFace;
            lblTrangThai1.BorderStyle = BorderStyle.FixedSingle;
            lblTrangThai1.Location = new Point(212, 218);
            lblTrangThai1.Name = "lblTrangThai1";
            lblTrangThai1.Size = new Size(200, 52);
            lblTrangThai1.TabIndex = 18;
            lblTrangThai1.Text = "Còn hạn";
            lblTrangThai1.Click += label1_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.Beige;
            btnLamMoi.Font = new Font("Arial", 12F);
            btnLamMoi.Location = new Point(788, 300);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(150, 46);
            btnLamMoi.TabIndex = 17;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.LightSteelBlue;
            btnSua.Font = new Font("Arial", 12F);
            btnSua.Location = new Point(580, 300);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(150, 46);
            btnSua.TabIndex = 16;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.RosyBrown;
            btnXoa.Font = new Font("Arial", 12F);
            btnXoa.Location = new Point(368, 300);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(150, 46);
            btnXoa.TabIndex = 15;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.DarkSeaGreen;
            btnThem.Font = new Font("Arial", 12F);
            btnThem.Location = new Point(154, 300);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(150, 46);
            btnThem.TabIndex = 14;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // numSoLuongOffline
            // 
            numSoLuongOffline.Location = new Point(824, 174);
            numSoLuongOffline.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            numSoLuongOffline.Name = "numSoLuongOffline";
            numSoLuongOffline.Size = new Size(240, 40);
            numSoLuongOffline.TabIndex = 13;
            numSoLuongOffline.ValueChanged += numSoLuongOffline_ValueChanged;
            // 
            // numSoLuongOnline
            // 
            numSoLuongOnline.Location = new Point(212, 162);
            numSoLuongOnline.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            numSoLuongOnline.Name = "numSoLuongOnline";
            numSoLuongOnline.Size = new Size(240, 40);
            numSoLuongOnline.TabIndex = 12;
            numSoLuongOnline.ValueChanged += numSoLuongOnline_ValueChanged;
            // 
            // dateTimeNgayHetHan
            // 
            dateTimeNgayHetHan.CustomFormat = "dd/MM/yyyy";
            dateTimeNgayHetHan.Format = DateTimePickerFormat.Custom;
            dateTimeNgayHetHan.Location = new Point(822, 121);
            dateTimeNgayHetHan.Name = "dateTimeNgayHetHan";
            dateTimeNgayHetHan.Size = new Size(400, 40);
            dateTimeNgayHetHan.TabIndex = 11;
            dateTimeNgayHetHan.ValueChanged += dateTimeNgayHetHan_ValueChanged;
            // 
            // dateTimeNgayHieuLuc
            // 
            dateTimeNgayHieuLuc.CustomFormat = "dd/MM/yyyy";
            dateTimeNgayHieuLuc.Format = DateTimePickerFormat.Custom;
            dateTimeNgayHieuLuc.Location = new Point(212, 110);
            dateTimeNgayHieuLuc.Name = "dateTimeNgayHieuLuc";
            dateTimeNgayHieuLuc.Size = new Size(400, 40);
            dateTimeNgayHieuLuc.TabIndex = 10;
            dateTimeNgayHieuLuc.Value = new DateTime(2019, 6, 11, 0, 0, 0, 0);
            dateTimeNgayHieuLuc.ValueChanged += dateTimeNgayHieuLuc_ValueChanged;
            // 
            // numGia
            // 
            numGia.Location = new Point(822, 68);
            numGia.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            numGia.Name = "numGia";
            numGia.Size = new Size(240, 40);
            numGia.TabIndex = 9;
            numGia.ThousandsSeparator = true;
            numGia.ValueChanged += numGia_ValueChanged;
            // 
            // lblTrangThai
            // 
            lblTrangThai.AutoSize = true;
            lblTrangThai.Location = new Point(1162, 162);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(0, 33);
            lblTrangThai.TabIndex = 8;
            // 
            // txtLoaiVe
            // 
            txtLoaiVe.Location = new Point(212, 58);
            txtLoaiVe.Name = "txtLoaiVe";
            txtLoaiVe.Size = new Size(200, 40);
            txtLoaiVe.TabIndex = 7;
            txtLoaiVe.TextChanged += txtLoaiVe_TextChanged;
            // 
            // lblKhungTrangThai
            // 
            lblKhungTrangThai.AutoSize = true;
            lblKhungTrangThai.Location = new Point(28, 219);
            lblKhungTrangThai.Name = "lblKhungTrangThai";
            lblKhungTrangThai.Size = new Size(147, 33);
            lblKhungTrangThai.TabIndex = 6;
            lblKhungTrangThai.Text = "Trạng thái:";
            lblKhungTrangThai.Click += label7_Click;
            // 
            // lblSLOffline
            // 
            lblSLOffline.AutoSize = true;
            lblSLOffline.Location = new Point(638, 181);
            lblSLOffline.Name = "lblSLOffline";
            lblSLOffline.Size = new Size(139, 33);
            lblSLOffline.TabIndex = 5;
            lblSLOffline.Text = "SL Offline:";
            lblSLOffline.Click += lblSLOffline_Click;
            // 
            // lblSLOnline
            // 
            lblSLOnline.AutoSize = true;
            lblSLOnline.Location = new Point(28, 158);
            lblSLOnline.Name = "lblSLOnline";
            lblSLOnline.Size = new Size(136, 33);
            lblSLOnline.TabIndex = 4;
            lblSLOnline.Text = "SL Online:";
            lblSLOnline.Click += lblSLOnline_Click;
            // 
            // lblNgayHetHan
            // 
            lblNgayHetHan.AutoSize = true;
            lblNgayHetHan.Location = new Point(634, 121);
            lblNgayHetHan.Name = "lblNgayHetHan";
            lblNgayHetHan.Size = new Size(183, 33);
            lblNgayHetHan.TabIndex = 3;
            lblNgayHetHan.Text = "Ngày hết hạn:";
            lblNgayHetHan.Click += lblNgayHetHan_Click;
            // 
            // lblNgayHieuLuc
            // 
            lblNgayHieuLuc.AutoSize = true;
            lblNgayHieuLuc.Location = new Point(28, 110);
            lblNgayHieuLuc.Name = "lblNgayHieuLuc";
            lblNgayHieuLuc.Size = new Size(185, 33);
            lblNgayHieuLuc.TabIndex = 2;
            lblNgayHieuLuc.Text = "Ngày hiệu lực:";
            lblNgayHieuLuc.Click += lblNgayHieuLuc_Click;
            // 
            // lblGia
            // 
            lblGia.AutoSize = true;
            lblGia.Location = new Point(634, 68);
            lblGia.Name = "lblGia";
            lblGia.Size = new Size(143, 33);
            lblGia.TabIndex = 1;
            lblGia.Text = "Giá (VND):";
            lblGia.Click += label2_Click;
            // 
            // lblLoaiVe
            // 
            lblLoaiVe.AutoSize = true;
            lblLoaiVe.Location = new Point(28, 58);
            lblLoaiVe.Name = "lblLoaiVe";
            lblLoaiVe.Size = new Size(108, 33);
            lblLoaiVe.TabIndex = 0;
            lblLoaiVe.Text = "Loại vé:";
            lblLoaiVe.Click += lblLoaiVe_Click;
            // 
            // lblTimKiem
            // 
            lblTimKiem.AutoSize = true;
            lblTimKiem.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTimKiem.Location = new Point(128, 750);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Size = new Size(155, 36);
            lblTimKiem.TabIndex = 1;
            lblTimKiem.Text = "Tìm kiếm:";
            lblTimKiem.Click += lblTimKiem_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(283, 748);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(232, 39);
            txtTimKiem.TabIndex = 2;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = SystemColors.ButtonFace;
            btnTimKiem.Location = new Point(521, 748);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(82, 46);
            btnTimKiem.TabIndex = 3;
            btnTimKiem.Text = "Tìm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // dgvVe
            // 
            dgvVe.AllowUserToAddRows = false;
            dgvVe.AllowUserToDeleteRows = false;
            dgvVe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVe.Dock = DockStyle.Top;
            dgvVe.Location = new Point(0, 0);
            dgvVe.Name = "dgvVe";
            dgvVe.ReadOnly = true;
            dgvVe.RowHeadersWidth = 82;
            dgvVe.Size = new Size(1556, 300);
            dgvVe.TabIndex = 4;
            dgvVe.CellContentClick += dgvVe_CellContentClick;
            // 
            // VeForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(1556, 842);
            Controls.Add(dgvVe);
            Controls.Add(btnTimKiem);
            Controls.Add(txtTimKiem);
            Controls.Add(lblTimKiem);
            Controls.Add(groupBox1);
            Name = "VeForm";
            Text = "VeForm";
            Load += VeForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSoLuongOffline).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuongOnline).EndInit();
            ((System.ComponentModel.ISupportInitialize)numGia).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvVe).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label lblKhungTrangThai;
        private Label lblSLOffline;
        private Label lblSLOnline;
        private Label lblNgayHetHan;
        private Label lblNgayHieuLuc;
        private Label lblGia;
        private Label lblLoaiVe;
        private Label lblTrangThai;
        private TextBox txtLoaiVe;
        private NumericUpDown numGia;
        private DateTimePicker dateTimeNgayHetHan;
        private DateTimePicker dateTimeNgayHieuLuc;
        private Button btnLamMoi;
        private Button btnSua;
        private Button btnXoa;
        private Button btnThem;
        private NumericUpDown numSoLuongOffline;
        private NumericUpDown numSoLuongOnline;
        private Label lblTimKiem;
        private TextBox txtTimKiem;
        private Button btnTimKiem;
        private DataGridView dgvVe;
        private Label lblTrangThai1;
    }
}