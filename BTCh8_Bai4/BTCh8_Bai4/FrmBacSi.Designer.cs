namespace BTCh8_Bai4
{
    partial class FrmBacSi
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTieuDe = new Label();

            lblHoTen = new Label();
            txtHoTen = new TextBox();

            lblChuyenKhoa = new Label();
            txtChuyenKhoa = new TextBox();

            lblSDT = new Label();
            txtSDT = new TextBox();

            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();

            dgvBacSi = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)dgvBacSi)
                .BeginInit();

            SuspendLayout();

            // ===========================
            // TIÊU ĐỀ
            // ===========================
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font =
                new Font(
                    "Segoe UI",
                    16F,
                    FontStyle.Bold);

            lblTieuDe.Location =
                new Point(280, 20);

            lblTieuDe.Name =
                "lblTieuDe";

            lblTieuDe.Size =
                new Size(228, 30);

            lblTieuDe.Text =
                "QUẢN LÝ BÁC SĨ";

            // ===========================
            // HỌ TÊN
            // ===========================
            lblHoTen.AutoSize = true;

            lblHoTen.Location =
                new Point(35, 85);

            lblHoTen.Name =
                "lblHoTen";

            lblHoTen.Size =
                new Size(45, 15);

            lblHoTen.Text =
                "Họ tên:";

            txtHoTen.Location =
                new Point(130, 81);

            txtHoTen.Name =
                "txtHoTen";

            txtHoTen.Size =
                new Size(260, 23);

            // ===========================
            // CHUYÊN KHOA
            // ===========================
            lblChuyenKhoa.AutoSize = true;

            lblChuyenKhoa.Location =
                new Point(35, 125);

            lblChuyenKhoa.Name =
                "lblChuyenKhoa";

            lblChuyenKhoa.Size =
                new Size(79, 15);

            lblChuyenKhoa.Text =
                "Chuyên khoa:";

            txtChuyenKhoa.Location =
                new Point(130, 121);

            txtChuyenKhoa.Name =
                "txtChuyenKhoa";

            txtChuyenKhoa.Size =
                new Size(260, 23);

            // ===========================
            // SỐ ĐIỆN THOẠI
            // ===========================
            lblSDT.AutoSize = true;

            lblSDT.Location =
                new Point(35, 165);

            lblSDT.Name =
                "lblSDT";

            lblSDT.Size =
                new Size(79, 15);

            lblSDT.Text =
                "Số điện thoại:";

            txtSDT.Location =
                new Point(130, 161);

            txtSDT.Name =
                "txtSDT";

            txtSDT.Size =
                new Size(260, 23);

            // ===========================
            // BUTTON THÊM
            // ===========================
            btnThem.Location =
                new Point(440, 80);

            btnThem.Name =
                "btnThem";

            btnThem.Size =
                new Size(85, 32);

            btnThem.Text =
                "Thêm";

            btnThem.UseVisualStyleBackColor =
                true;

            // ===========================
            // BUTTON SỬA
            // ===========================
            btnSua.Location =
                new Point(540, 80);

            btnSua.Name =
                "btnSua";

            btnSua.Size =
                new Size(85, 32);

            btnSua.Text =
                "Sửa";

            btnSua.UseVisualStyleBackColor =
                true;

            // ===========================
            // BUTTON XÓA
            // ===========================
            btnXoa.Location =
                new Point(440, 130);

            btnXoa.Name =
                "btnXoa";

            btnXoa.Size =
                new Size(85, 32);

            btnXoa.Text =
                "Xóa";

            btnXoa.UseVisualStyleBackColor =
                true;

            // ===========================
            // BUTTON LÀM MỚI
            // ===========================
            btnLamMoi.Location =
                new Point(540, 130);

            btnLamMoi.Name =
                "btnLamMoi";

            btnLamMoi.Size =
                new Size(85, 32);

            btnLamMoi.Text =
                "Làm mới";

            btnLamMoi.UseVisualStyleBackColor =
                true;

            // ===========================
            // DATAGRIDVIEW
            // ===========================
            dgvBacSi.AllowUserToAddRows =
                false;

            dgvBacSi.AllowUserToDeleteRows =
                false;

            dgvBacSi.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvBacSi.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            dgvBacSi.Location =
                new Point(35, 220);

            dgvBacSi.MultiSelect =
                false;

            dgvBacSi.Name =
                "dgvBacSi";

            dgvBacSi.ReadOnly =
                true;

            dgvBacSi.RowHeadersWidth =
                51;

            dgvBacSi.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvBacSi.Size =
                new Size(700, 310);

            // ===========================
            // FORM
            // ===========================
            AutoScaleDimensions =
                new SizeF(7F, 15F);

            AutoScaleMode =
                AutoScaleMode.Font;

            ClientSize =
                new Size(775, 565);

            Controls.Add(lblTieuDe);

            Controls.Add(lblHoTen);
            Controls.Add(txtHoTen);

            Controls.Add(lblChuyenKhoa);
            Controls.Add(txtChuyenKhoa);

            Controls.Add(lblSDT);
            Controls.Add(txtSDT);

            Controls.Add(btnThem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnLamMoi);

            Controls.Add(dgvBacSi);

            Name =
                "FrmBacSi";

            StartPosition =
                FormStartPosition.CenterParent;

            Text =
                "Quản lý Bác sĩ - An Khang Clinic";

            ((System.ComponentModel.ISupportInitialize)dgvBacSi)
                .EndInit();

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTieuDe;

        private Label lblHoTen;
        private TextBox txtHoTen;

        private Label lblChuyenKhoa;
        private TextBox txtChuyenKhoa;

        private Label lblSDT;
        private TextBox txtSDT;

        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;

        private DataGridView dgvBacSi;
    }
}