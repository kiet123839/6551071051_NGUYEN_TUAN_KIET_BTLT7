namespace BTCh8_Bai4
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTieuDe = new Label();

            lblTenBenhNhan = new Label();
            txtTenBenhNhan = new TextBox();

            lblSDT = new Label();
            txtSDT = new TextBox();

            lblNgayKham = new Label();
            dtpNgayKham = new DateTimePicker();

            lblGioKham = new Label();
            dtpGioKham = new DateTimePicker();

            lblBacSi = new Label();
            cboBacSi = new ComboBox();

            lblTrangThai = new Label();
            cboTrangThai = new ComboBox();

            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();

            lblTuNgay = new Label();
            dtpTuNgay = new DateTimePicker();

            lblDenNgay = new Label();
            dtpDenNgay = new DateTimePicker();

            lblTimBacSi = new Label();
            cboTimBacSi = new ComboBox();

            btnTimKiem = new Button();
            btnQuanLyBacSi = new Button();

            dgvLichKham = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)dgvLichKham).BeginInit();

            SuspendLayout();

            // =========================
            // TIÊU ĐỀ
            // =========================
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTieuDe.Location = new Point(260, 15);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(390, 30);
            lblTieuDe.Text = "QUẢN LÝ LỊCH KHÁM BỆNH";

            // =========================
            // TÊN BỆNH NHÂN
            // =========================
            lblTenBenhNhan.AutoSize = true;
            lblTenBenhNhan.Location = new Point(25, 75);
            lblTenBenhNhan.Name = "lblTenBenhNhan";
            lblTenBenhNhan.Size = new Size(96, 15);
            lblTenBenhNhan.Text = "Tên bệnh nhân:";

            txtTenBenhNhan.Location = new Point(130, 71);
            txtTenBenhNhan.Name = "txtTenBenhNhan";
            txtTenBenhNhan.Size = new Size(230, 23);

            // =========================
            // SĐT
            // =========================
            lblSDT.AutoSize = true;
            lblSDT.Location = new Point(25, 115);
            lblSDT.Name = "lblSDT";
            lblSDT.Size = new Size(79, 15);
            lblSDT.Text = "Số điện thoại:";

            txtSDT.Location = new Point(130, 111);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(230, 23);

            // =========================
            // NGÀY KHÁM
            // =========================
            lblNgayKham.AutoSize = true;
            lblNgayKham.Location = new Point(25, 155);
            lblNgayKham.Name = "lblNgayKham";
            lblNgayKham.Size = new Size(68, 15);
            lblNgayKham.Text = "Ngày khám:";

            dtpNgayKham.Format = DateTimePickerFormat.Short;
            dtpNgayKham.Location = new Point(130, 151);
            dtpNgayKham.Name = "dtpNgayKham";
            dtpNgayKham.Size = new Size(230, 23);

            // =========================
            // GIỜ KHÁM
            // =========================
            lblGioKham.AutoSize = true;
            lblGioKham.Location = new Point(400, 75);
            lblGioKham.Name = "lblGioKham";
            lblGioKham.Size = new Size(61, 15);
            lblGioKham.Text = "Giờ khám:";

            dtpGioKham.Format = DateTimePickerFormat.Time;
            dtpGioKham.ShowUpDown = true;
            dtpGioKham.Location = new Point(485, 71);
            dtpGioKham.Name = "dtpGioKham";
            dtpGioKham.Size = new Size(180, 23);

            // =========================
            // BÁC SĨ
            // =========================
            lblBacSi.AutoSize = true;
            lblBacSi.Location = new Point(400, 115);
            lblBacSi.Name = "lblBacSi";
            lblBacSi.Size = new Size(42, 15);
            lblBacSi.Text = "Bác sĩ:";

            cboBacSi.DropDownStyle = ComboBoxStyle.DropDownList;
            cboBacSi.FormattingEnabled = true;
            cboBacSi.Location = new Point(485, 111);
            cboBacSi.Name = "cboBacSi";
            cboBacSi.Size = new Size(300, 23);

            // =========================
            // TRẠNG THÁI
            // =========================
            lblTrangThai.AutoSize = true;
            lblTrangThai.Location = new Point(400, 155);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(61, 15);
            lblTrangThai.Text = "Trạng thái:";

            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Location = new Point(485, 151);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(180, 23);

            // =========================
            // BUTTON CRUD
            // =========================
            btnThem.Location = new Point(810, 70);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(80, 30);
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;

            btnSua.Location = new Point(900, 70);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(80, 30);
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;

            btnXoa.Location = new Point(810, 115);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(80, 30);
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;

            btnLamMoi.Location = new Point(900, 115);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(80, 30);
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;

            // =========================
            // TÌM KIẾM
            // =========================
            lblTuNgay.AutoSize = true;
            lblTuNgay.Location = new Point(25, 215);
            lblTuNgay.Name = "lblTuNgay";
            lblTuNgay.Size = new Size(50, 15);
            lblTuNgay.Text = "Từ ngày:";

            dtpTuNgay.Format = DateTimePickerFormat.Short;
            dtpTuNgay.Location = new Point(85, 211);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(150, 23);

            lblDenNgay.AutoSize = true;
            lblDenNgay.Location = new Point(250, 215);
            lblDenNgay.Name = "lblDenNgay";
            lblDenNgay.Size = new Size(61, 15);
            lblDenNgay.Text = "Đến ngày:";

            dtpDenNgay.Format = DateTimePickerFormat.Short;
            dtpDenNgay.Location = new Point(320, 211);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(150, 23);

            lblTimBacSi.AutoSize = true;
            lblTimBacSi.Location = new Point(490, 215);
            lblTimBacSi.Name = "lblTimBacSi";
            lblTimBacSi.Size = new Size(42, 15);
            lblTimBacSi.Text = "Bác sĩ:";

            cboTimBacSi.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTimBacSi.FormattingEnabled = true;
            cboTimBacSi.Location = new Point(545, 211);
            cboTimBacSi.Name = "cboTimBacSi";
            cboTimBacSi.Size = new Size(260, 23);

            btnTimKiem.Location = new Point(820, 208);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(85, 30);
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;

            btnQuanLyBacSi.Location = new Point(915, 208);
            btnQuanLyBacSi.Name = "btnQuanLyBacSi";
            btnQuanLyBacSi.Size = new Size(120, 30);
            btnQuanLyBacSi.Text = "Quản lý bác sĩ";
            btnQuanLyBacSi.UseVisualStyleBackColor = true;

            // =========================
            // DATAGRIDVIEW
            // =========================
            dgvLichKham.AllowUserToAddRows = false;
            dgvLichKham.AllowUserToDeleteRows = false;
            dgvLichKham.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvLichKham.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            dgvLichKham.Location = new Point(25, 260);
            dgvLichKham.MultiSelect = false;
            dgvLichKham.Name = "dgvLichKham";
            dgvLichKham.ReadOnly = true;
            dgvLichKham.RowHeadersWidth = 51;

            dgvLichKham.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvLichKham.Size = new Size(1010, 370);
            dgvLichKham.TabIndex = 0;

            // =========================
            // FORM
            // =========================
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;

            ClientSize = new Size(1065, 660);

            Controls.Add(lblTieuDe);

            Controls.Add(lblTenBenhNhan);
            Controls.Add(txtTenBenhNhan);

            Controls.Add(lblSDT);
            Controls.Add(txtSDT);

            Controls.Add(lblNgayKham);
            Controls.Add(dtpNgayKham);

            Controls.Add(lblGioKham);
            Controls.Add(dtpGioKham);

            Controls.Add(lblBacSi);
            Controls.Add(cboBacSi);

            Controls.Add(lblTrangThai);
            Controls.Add(cboTrangThai);

            Controls.Add(btnThem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnLamMoi);

            Controls.Add(lblTuNgay);
            Controls.Add(dtpTuNgay);

            Controls.Add(lblDenNgay);
            Controls.Add(dtpDenNgay);

            Controls.Add(lblTimBacSi);
            Controls.Add(cboTimBacSi);

            Controls.Add(btnTimKiem);
            Controls.Add(btnQuanLyBacSi);

            Controls.Add(dgvLichKham);

            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý lịch khám bệnh - An Khang Clinic";

            ((System.ComponentModel.ISupportInitialize)dgvLichKham).EndInit();

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTieuDe;

        private Label lblTenBenhNhan;
        private TextBox txtTenBenhNhan;

        private Label lblSDT;
        private TextBox txtSDT;

        private Label lblNgayKham;
        private DateTimePicker dtpNgayKham;

        private Label lblGioKham;
        private DateTimePicker dtpGioKham;

        private Label lblBacSi;
        private ComboBox cboBacSi;

        private Label lblTrangThai;
        private ComboBox cboTrangThai;

        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;

        private Label lblTuNgay;
        private DateTimePicker dtpTuNgay;

        private Label lblDenNgay;
        private DateTimePicker dtpDenNgay;

        private Label lblTimBacSi;
        private ComboBox cboTimBacSi;

        private Button btnTimKiem;
        private Button btnQuanLyBacSi;

        private DataGridView dgvLichKham;
    }
}