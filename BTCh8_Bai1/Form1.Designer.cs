namespace BTCh8_Bai1
{
    partial class frmTheLoaiSach
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblMaTL = new Label();
            lblTenTheLoai = new Label();
            lblMoTa = new Label();
            btnTimKiem = new Button();
            txtMaTL = new TextBox();
            txtTenTheLoai = new TextBox();
            txtMoTa = new TextBox();
            txtTimKiem = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            dgvTheLoaiSach = new DataGridView();
            lblNgayTao = new Label();
            label5 = new Label();
            lblGiaTriNgayTao = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvTheLoaiSach).BeginInit();
            SuspendLayout();
            // 
            // lblMaTL
            // 
            lblMaTL.AutoSize = true;
            lblMaTL.Font = new Font("Segoe UI", 10F);
            lblMaTL.Location = new Point(13, 40);
            lblMaTL.Name = "lblMaTL";
            lblMaTL.Size = new Size(96, 23);
            lblMaTL.TabIndex = 0;
            lblMaTL.Text = "Mã thể loại";
            // 
            // lblTenTheLoai
            // 
            lblTenTheLoai.AutoSize = true;
            lblTenTheLoai.Font = new Font("Segoe UI", 10F);
            lblTenTheLoai.Location = new Point(12, 82);
            lblTenTheLoai.Name = "lblTenTheLoai";
            lblTenTheLoai.Size = new Size(98, 23);
            lblTenTheLoai.TabIndex = 1;
            lblTenTheLoai.Text = "Tên thể loại";
            // 
            // lblMoTa
            // 
            lblMoTa.AutoSize = true;
            lblMoTa.Font = new Font("Segoe UI", 10F);
            lblMoTa.Location = new Point(13, 128);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new Size(60, 23);
            lblMoTa.TabIndex = 2;
            lblMoTa.Text = "Mô tả ";
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(404, 268);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(94, 29);
            btnTimKiem.TabIndex = 3;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // txtMaTL
            // 
            txtMaTL.Location = new Point(133, 42);
            txtMaTL.Name = "txtMaTL";
            txtMaTL.ReadOnly = true;
            txtMaTL.Size = new Size(263, 27);
            txtMaTL.TabIndex = 4;
            // 
            // txtTenTheLoai
            // 
            txtTenTheLoai.Location = new Point(133, 81);
            txtTenTheLoai.Name = "txtTenTheLoai";
            txtTenTheLoai.Size = new Size(263, 27);
            txtTenTheLoai.TabIndex = 5;
        //txtTenTheLoai.TextChanged += txtTenTheLoai_TextChanged;
            // 
            // txtMoTa
            // 
            txtMoTa.Location = new Point(133, 128);
            txtMoTa.Multiline = true;
            txtMoTa.Name = "txtMoTa";
            txtMoTa.ScrollBars = ScrollBars.Vertical;
            txtMoTa.Size = new Size(263, 90);
            txtMoTa.TabIndex = 6;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(15, 269);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(383, 27);
            txtTimKiem.TabIndex = 7;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(493, 42);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 8;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(616, 42);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 9;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(738, 42);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 10;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(858, 42);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(94, 29);
            btnLamMoi.TabIndex = 11;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // dgvTheLoaiSach
            // 
            dgvTheLoaiSach.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTheLoaiSach.Location = new Point(0, 319);
            dgvTheLoaiSach.Name = "dgvTheLoaiSach";
            dgvTheLoaiSach.RowHeadersWidth = 51;
            dgvTheLoaiSach.Size = new Size(993, 205);
            dgvTheLoaiSach.TabIndex = 12;
        //  dgvTheLoaiSach.CellContentClick += dgvTheLoaiSach_CellContentClick;
            // 
            // lblNgayTao
            // 
            lblNgayTao.AutoSize = true;
            lblNgayTao.Location = new Point(15, 235);
            lblNgayTao.Name = "lblNgayTao";
            lblNgayTao.Size = new Size(70, 20);
            lblNgayTao.TabIndex = 13;
            lblNgayTao.Text = "Ngày tạo";
            // 
            // label5
            // 
            label5.Location = new Point(133, 235);
            label5.Name = "label5";
            label5.Size = new Size(62, 25);
            label5.TabIndex = 14;
            label5.Text = "label5";
            // 
            // lblGiaTriNgayTao
            // 
            lblGiaTriNgayTao.Location = new Point(133, 235);
            lblGiaTriNgayTao.Name = "lblGiaTriNgayTao";
            lblGiaTriNgayTao.Size = new Size(263, 25);
            lblGiaTriNgayTao.TabIndex = 14;
            lblGiaTriNgayTao.Text = "label5";
            // 
            // frmTheLoaiSach
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(991, 521);
            Controls.Add(lblGiaTriNgayTao);
            Controls.Add(label5);
            Controls.Add(lblNgayTao);
            Controls.Add(dgvTheLoaiSach);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(txtTimKiem);
            Controls.Add(txtMoTa);
            Controls.Add(txtTenTheLoai);
            Controls.Add(txtMaTL);
            Controls.Add(btnTimKiem);
            Controls.Add(lblMoTa);
            Controls.Add(lblTenTheLoai);
            Controls.Add(lblMaTL);
            Name = "frmTheLoaiSach";
            Text = "Quản Lý Thể Loại Sách - Tri Thức Books";
            ((System.ComponentModel.ISupportInitialize)dgvTheLoaiSach).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMaTL;
        private Label lblTenTheLoai;
        private Label lblMoTa;
        private Button btnTimKiem;
        private TextBox txtMaTL;
        private TextBox txtTenTheLoai;
        private TextBox txtMoTa;
        private TextBox txtTimKiem;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private DataGridView dgvTheLoaiSach;
        private Label lblNgayTao;
        private Label label5;
        private Label lblGiaTriNgayTao;
    }
}
