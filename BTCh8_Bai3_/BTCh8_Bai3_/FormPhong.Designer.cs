namespace BTCh8_Bai3_
{
    partial class FormPhong
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
            txtSoPhong = new TextBox();
            lblSoPhong = new Label();
            lblTangSo = new Label();
            nudTangSo = new NumericUpDown();
            lblLoaiPhong = new Label();
            cboLoaiPhong = new ComboBox();
            lblTinhTrang = new Label();
            cboTinhTrang = new ComboBox();
            picHinhAnh = new PictureBox();
            btnChonAnh = new Button();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            cboLocLoaiPhong = new ComboBox();
            cboLocTinhTrang = new ComboBox();
            btnTimKiem = new Button();
            dgvPhong = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)nudTangSo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPhong).BeginInit();
            SuspendLayout();
            // 
            // txtSoPhong
            // 
            txtSoPhong.Location = new Point(12, 57);
            txtSoPhong.Name = "txtSoPhong";
            txtSoPhong.Size = new Size(73, 27);
            txtSoPhong.TabIndex = 0;
            // 
            // lblSoPhong
            // 
            lblSoPhong.AutoSize = true;
            lblSoPhong.Location = new Point(12, 18);
            lblSoPhong.Name = "lblSoPhong";
            lblSoPhong.Size = new Size(73, 20);
            lblSoPhong.TabIndex = 1;
            lblSoPhong.Text = "Số phòng";
            // 
            // lblTangSo
            // 
            lblTangSo.AutoSize = true;
            lblTangSo.Location = new Point(110, 18);
            lblTangSo.Name = "lblTangSo";
            lblTangSo.Size = new Size(61, 20);
            lblTangSo.TabIndex = 2;
            lblTangSo.Text = "Tầng số";
            // 
            // nudTangSo
            // 
            nudTangSo.Location = new Point(110, 56);
            nudTangSo.Name = "nudTangSo";
            nudTangSo.Size = new Size(85, 27);
            nudTangSo.TabIndex = 3;
            // 
            // lblLoaiPhong
            // 
            lblLoaiPhong.AutoSize = true;
            lblLoaiPhong.Location = new Point(227, 18);
            lblLoaiPhong.Name = "lblLoaiPhong";
            lblLoaiPhong.Size = new Size(84, 20);
            lblLoaiPhong.TabIndex = 4;
            lblLoaiPhong.Text = "Loại phòng";
            // 
            // cboLoaiPhong
            // 
            cboLoaiPhong.FormattingEnabled = true;
            cboLoaiPhong.Location = new Point(227, 55);
            cboLoaiPhong.Name = "cboLoaiPhong";
            cboLoaiPhong.Size = new Size(114, 28);
            cboLoaiPhong.TabIndex = 5;
            // 
            // lblTinhTrang
            // 
            lblTinhTrang.AutoSize = true;
            lblTinhTrang.Location = new Point(367, 18);
            lblTinhTrang.Name = "lblTinhTrang";
            lblTinhTrang.Size = new Size(76, 20);
            lblTinhTrang.TabIndex = 6;
            lblTinhTrang.Text = "Tình trạng";
            // 
            // cboTinhTrang
            // 
            cboTinhTrang.FormattingEnabled = true;
            cboTinhTrang.Location = new Point(367, 55);
            cboTinhTrang.Name = "cboTinhTrang";
            cboTinhTrang.Size = new Size(97, 28);
            cboTinhTrang.TabIndex = 7;
            // 
            // picHinhAnh
            // 
            picHinhAnh.Location = new Point(485, 18);
            picHinhAnh.Name = "picHinhAnh";
            picHinhAnh.Size = new Size(132, 120);
            picHinhAnh.TabIndex = 8;
            picHinhAnh.TabStop = false;
            // 
            // btnChonAnh
            // 
            btnChonAnh.Location = new Point(500, 144);
            btnChonAnh.Name = "btnChonAnh";
            btnChonAnh.Size = new Size(94, 29);
            btnChonAnh.TabIndex = 9;
            btnChonAnh.Text = "Chọn ảnh...";
            btnChonAnh.UseVisualStyleBackColor = true;
            btnChonAnh.Click += btnChonAnh_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(642, 18);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(99, 44);
            btnThem.TabIndex = 10;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(747, 18);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(99, 44);
            btnSua.TabIndex = 11;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(642, 91);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(99, 47);
            btnXoa.TabIndex = 12;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(747, 91);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(99, 47);
            btnLamMoi.TabIndex = 13;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // cboLocLoaiPhong
            // 
            cboLocLoaiPhong.FormattingEnabled = true;
            cboLocLoaiPhong.Location = new Point(12, 207);
            cboLocLoaiPhong.Name = "cboLocLoaiPhong";
            cboLocLoaiPhong.Size = new Size(200, 28);
            cboLocLoaiPhong.TabIndex = 14;
            cboLocLoaiPhong.Text = "lọc theo loại phòng";
            // 
            // cboLocTinhTrang
            // 
            cboLocTinhTrang.FormattingEnabled = true;
            cboLocTinhTrang.Location = new Point(242, 207);
            cboLocTinhTrang.Name = "cboLocTinhTrang";
            cboLocTinhTrang.Size = new Size(201, 28);
            cboLocTinhTrang.TabIndex = 15;
            cboLocTinhTrang.Text = "lọc theo tình trạng";
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(485, 200);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(94, 40);
            btnTimKiem.TabIndex = 16;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // dgvPhong
            // 
            dgvPhong.AllowUserToAddRows = false;
            dgvPhong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPhong.Location = new Point(0, 273);
            dgvPhong.MultiSelect = false;
            dgvPhong.Name = "dgvPhong";
            dgvPhong.ReadOnly = true;
            dgvPhong.RowHeadersWidth = 51;
            dgvPhong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPhong.Size = new Size(885, 284);
            dgvPhong.TabIndex = 17;
            dgvPhong.CellClick += dgvPhong_CellClick;
            // 
            // FormPhong
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 553);
            Controls.Add(dgvPhong);
            Controls.Add(btnTimKiem);
            Controls.Add(cboLocTinhTrang);
            Controls.Add(cboLocLoaiPhong);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(btnChonAnh);
            Controls.Add(picHinhAnh);
            Controls.Add(cboTinhTrang);
            Controls.Add(lblTinhTrang);
            Controls.Add(cboLoaiPhong);
            Controls.Add(lblLoaiPhong);
            Controls.Add(nudTangSo);
            Controls.Add(lblTangSo);
            Controls.Add(lblSoPhong);
            Controls.Add(txtSoPhong);
            Name = "FormPhong";
            Text = "Quản Lý Phòng - Sunrise Homestay";
            Load += FormPhong_Load;
            ((System.ComponentModel.ISupportInitialize)nudTangSo).EndInit();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPhong).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSoPhong;
        private Label lblSoPhong;
        private Label lblTangSo;
        private NumericUpDown nudTangSo;
        private Label lblLoaiPhong;
        private ComboBox cboLoaiPhong;
        private Label lblTinhTrang;
        private ComboBox cboTinhTrang;
        private PictureBox picHinhAnh;
        private Button btnChonAnh;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private ComboBox cboLocLoaiPhong;
        private ComboBox cboLocTinhTrang;
        private Button btnTimKiem;
        private DataGridView dgvPhong;
    }
}