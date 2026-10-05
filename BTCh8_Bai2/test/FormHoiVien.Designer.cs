namespace BTCh8_Bai2_
{
    partial class FormHoiVien
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
            this.gbThongTin = new System.Windows.Forms.GroupBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.gbGioiTinh = new System.Windows.Forms.GroupBox();
            this.rdbNam = new System.Windows.Forms.RadioButton();
            this.rdbNu = new System.Windows.Forms.RadioButton();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.lblSDT = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblHangThanhVien = new System.Windows.Forms.Label();
            this.cboHangThanhVien = new System.Windows.Forms.ComboBox();
            this.chkTrangThai = new System.Windows.Forms.CheckBox();

            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();

            this.gbTimKiem = new System.Windows.Forms.GroupBox();
            this.lblTimKiemHoTen = new System.Windows.Forms.Label();
            this.txtTimKiemHoTen = new System.Windows.Forms.TextBox();
            this.lblTimKiemHang = new System.Windows.Forms.Label();
            this.cboTimKiemHang = new System.Windows.Forms.ComboBox();
            this.btnTimKiem = new System.Windows.Forms.Button();

            this.dgvHoiVien = new System.Windows.Forms.DataGridView();

            this.gbThongTin.SuspendLayout();
            this.gbGioiTinh.SuspendLayout();
            this.gbTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoiVien)).BeginInit();
            this.SuspendLayout();

            // 
            // gbThongTin
            // 
            this.gbThongTin.Controls.Add(this.lblHoTen);
            this.gbThongTin.Controls.Add(this.txtHoTen);
            this.gbThongTin.Controls.Add(this.gbGioiTinh);
            this.gbThongTin.Controls.Add(this.lblNgaySinh);
            this.gbThongTin.Controls.Add(this.dtpNgaySinh);
            this.gbThongTin.Controls.Add(this.lblSDT);
            this.gbThongTin.Controls.Add(this.txtSDT);
            this.gbThongTin.Controls.Add(this.lblEmail);
            this.gbThongTin.Controls.Add(this.txtEmail);
            this.gbThongTin.Controls.Add(this.lblHangThanhVien);
            this.gbThongTin.Controls.Add(this.cboHangThanhVien);
            this.gbThongTin.Controls.Add(this.chkTrangThai);
            this.gbThongTin.Controls.Add(this.btnThem);
            this.gbThongTin.Controls.Add(this.btnSua);
            this.gbThongTin.Controls.Add(this.btnXoa);
            this.gbThongTin.Controls.Add(this.btnLamMoi);
            this.gbThongTin.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbThongTin.Location = new System.Drawing.Point(12, 12);
            this.gbThongTin.Name = "gbThongTin";
            this.gbThongTin.Size = new System.Drawing.Size(860, 210);
            this.gbThongTin.TabIndex = 0;
            this.gbThongTin.TabStop = false;
            this.gbThongTin.Text = "Thông Tin Hội Viên";

            // lblHoTen
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(20, 32);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(50, 17);
            this.lblHoTen.Text = "Họ tên:";

            // txtHoTen
            this.txtHoTen.Location = new System.Drawing.Point(100, 29);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(280, 25);
            this.txtHoTen.TabIndex = 1;

            // gbGioiTinh
            this.gbGioiTinh.Controls.Add(this.rdbNam);
            this.gbGioiTinh.Controls.Add(this.rdbNu);
            this.gbGioiTinh.Location = new System.Drawing.Point(20, 65);
            this.gbGioiTinh.Name = "gbGioiTinh";
            this.gbGioiTinh.Size = new System.Drawing.Size(360, 50);
            this.gbGioiTinh.TabIndex = 2;
            this.gbGioiTinh.TabStop = false;
            this.gbGioiTinh.Text = "Giới tính";

            // rdbNam
            this.rdbNam.AutoSize = true;
            this.rdbNam.Checked = true;
            this.rdbNam.Location = new System.Drawing.Point(80, 20);
            this.rdbNam.Name = "rdbNam";
            this.rdbNam.Size = new System.Drawing.Size(53, 21);
            this.rdbNam.TabIndex = 0;
            this.rdbNam.TabStop = true;
            this.rdbNam.Text = "Nam";
            this.rdbNam.UseVisualStyleBackColor = true;

            // rdbNu
            this.rdbNu.AutoSize = true;
            this.rdbNu.Location = new System.Drawing.Point(180, 20);
            this.rdbNu.Name = "rdbNu";
            this.rdbNu.Size = new System.Drawing.Size(43, 21);
            this.rdbNu.TabIndex = 1;
            this.rdbNu.Text = "Nữ";
            this.rdbNu.UseVisualStyleBackColor = true;

            // lblNgaySinh
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Location = new System.Drawing.Point(20, 128);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(68, 17);
            this.lblNgaySinh.Text = "Ngày sinh:";

            // dtpNgaySinh
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgaySinh.Location = new System.Drawing.Point(100, 124);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(280, 25);
            this.dtpNgaySinh.TabIndex = 3;

            // lblSDT
            this.lblSDT.AutoSize = true;
            this.lblSDT.Location = new System.Drawing.Point(440, 32);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(34, 17);
            this.lblSDT.Text = "SĐT:";

            // txtSDT
            this.txtSDT.Location = new System.Drawing.Point(540, 29);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(290, 25);
            this.txtSDT.TabIndex = 4;

            // lblEmail
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(440, 72);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(42, 17);
            this.lblEmail.Text = "Email:";

            // txtEmail
            this.txtEmail.Location = new System.Drawing.Point(540, 69);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(290, 25);
            this.txtEmail.TabIndex = 5;

            // lblHangThanhVien
            this.lblHangThanhVien.AutoSize = true;
            this.lblHangThanhVien.Location = new System.Drawing.Point(440, 112);
            this.lblHangThanhVien.Name = "lblHangThanhVien";
            this.lblHangThanhVien.Size = new System.Drawing.Size(62, 17);
            this.lblHangThanhVien.Text = "Hạng TV:";

            // cboHangThanhVien
            this.cboHangThanhVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHangThanhVien.FormattingEnabled = true;
            this.cboHangThanhVien.Location = new System.Drawing.Point(540, 109);
            this.cboHangThanhVien.Name = "cboHangThanhVien";
            this.cboHangThanhVien.Size = new System.Drawing.Size(290, 25);
            this.cboHangThanhVien.TabIndex = 6;

            // chkTrangThai
            this.chkTrangThai.AutoSize = true;
            this.chkTrangThai.Checked = true;
            this.chkTrangThai.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTrangThai.Location = new System.Drawing.Point(540, 145);
            this.chkTrangThai.Name = "chkTrangThai";
            this.chkTrangThai.Size = new System.Drawing.Size(120, 21);
            this.chkTrangThai.TabIndex = 7;
            this.chkTrangThai.Text = "Đang hoạt động";
            this.chkTrangThai.UseVisualStyleBackColor = true;

            // btnThem
            this.btnThem.Location = new System.Drawing.Point(440, 172);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(90, 30);
            this.btnThem.TabIndex = 8;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            // btnSua
            this.btnSua.Location = new System.Drawing.Point(540, 172);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(90, 30);
            this.btnSua.TabIndex = 9;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            // btnXoa
            this.btnXoa.Location = new System.Drawing.Point(640, 172);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(90, 30);
            this.btnXoa.TabIndex = 10;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            // btnLamMoi
            this.btnLamMoi.Location = new System.Drawing.Point(740, 172);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(90, 30);
            this.btnLamMoi.TabIndex = 11;
            this.btnLamMoi.Text = "Làm Mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            // 
            // gbTimKiem
            // 
            this.gbTimKiem.Controls.Add(this.lblTimKiemHoTen);
            this.gbTimKiem.Controls.Add(this.txtTimKiemHoTen);
            this.gbTimKiem.Controls.Add(this.lblTimKiemHang);
            this.gbTimKiem.Controls.Add(this.cboTimKiemHang);
            this.gbTimKiem.Controls.Add(this.btnTimKiem);
            this.gbTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbTimKiem.Location = new System.Drawing.Point(12, 230);
            this.gbTimKiem.Name = "gbTimKiem";
            this.gbTimKiem.Size = new System.Drawing.Size(860, 65);
            this.gbTimKiem.TabIndex = 1;
            this.gbTimKiem.TabStop = false;
            this.gbTimKiem.Text = "Bộ Lọc & Tìm Kiếm Đa Điều Kiện";

            // lblTimKiemHoTen
            this.lblTimKiemHoTen.AutoSize = true;
            this.lblTimKiemHoTen.Location = new System.Drawing.Point(20, 28);
            this.lblTimKiemHoTen.Name = "lblTimKiemHoTen";
            this.lblTimKiemHoTen.Size = new System.Drawing.Size(70, 17);
            this.lblTimKiemHoTen.Text = "Tìm họ tên:";

            // txtTimKiemHoTen
            this.txtTimKiemHoTen.Location = new System.Drawing.Point(100, 25);
            this.txtTimKiemHoTen.Name = "txtTimKiemHoTen";
            this.txtTimKiemHoTen.Size = new System.Drawing.Size(280, 25);
            this.txtTimKiemHoTen.TabIndex = 0;

            // lblTimKiemHang
            this.lblTimKiemHang.AutoSize = true;
            this.lblTimKiemHang.Location = new System.Drawing.Point(420, 28);
            this.lblTimKiemHang.Name = "lblTimKiemHang";
            this.lblTimKiemHang.Size = new System.Drawing.Size(65, 17);
            this.lblTimKiemHang.Text = "Lọc hạng:";

            // cboTimKiemHang
            this.cboTimKiemHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTimKiemHang.FormattingEnabled = true;
            this.cboTimKiemHang.Location = new System.Drawing.Point(490, 25);
            this.cboTimKiemHang.Name = "cboTimKiemHang";
            this.cboTimKiemHang.Size = new System.Drawing.Size(220, 25);
            this.cboTimKiemHang.TabIndex = 1;

            // btnTimKiem
            this.btnTimKiem.Location = new System.Drawing.Point(730, 22);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(100, 30);
            this.btnTimKiem.TabIndex = 2;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);

            // 
            // dgvHoiVien
            // 
            this.dgvHoiVien.AllowUserToAddRows = false;
            this.dgvHoiVien.AllowUserToDeleteRows = false;
            this.dgvHoiVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoiVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoiVien.Location = new System.Drawing.Point(12, 305);
            this.dgvHoiVien.MultiSelect = false;
            this.dgvHoiVien.Name = "dgvHoiVien";
            this.dgvHoiVien.ReadOnly = true;
            this.dgvHoiVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoiVien.Size = new System.Drawing.Size(860, 250);
            this.dgvHoiVien.TabIndex = 2;
            this.dgvHoiVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHoiVien_CellClick);

            // 
            // FormHoiVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 566);
            this.Controls.Add(this.dgvHoiVien);
            this.Controls.Add(this.gbTimKiem);
            this.Controls.Add(this.gbThongTin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormHoiVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Hội Viên - FitZone Gym";
            this.Load += new System.EventHandler(this.FormHoiVien_Load);

            this.gbThongTin.ResumeLayout(false);
            this.gbThongTin.PerformLayout();
            this.gbGioiTinh.ResumeLayout(false);
            this.gbGioiTinh.PerformLayout();
            this.gbTimKiem.ResumeLayout(false);
            this.gbTimKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoiVien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbThongTin;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.GroupBox gbGioiTinh;
        private System.Windows.Forms.RadioButton rdbNam;
        private System.Windows.Forms.RadioButton rdbNu;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblHangThanhVien;
        private System.Windows.Forms.ComboBox cboHangThanhVien;
        private System.Windows.Forms.CheckBox chkTrangThai;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;

        private System.Windows.Forms.GroupBox gbTimKiem;
        private System.Windows.Forms.Label lblTimKiemHoTen;
        private System.Windows.Forms.TextBox txtTimKiemHoTen;
        private System.Windows.Forms.Label lblTimKiemHang;
        private System.Windows.Forms.ComboBox cboTimKiemHang;
        private System.Windows.Forms.Button btnTimKiem;

        private System.Windows.Forms.DataGridView dgvHoiVien;
    }
}