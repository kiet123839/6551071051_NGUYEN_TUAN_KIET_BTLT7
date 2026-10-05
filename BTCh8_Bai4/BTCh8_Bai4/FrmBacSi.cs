using Microsoft.EntityFrameworkCore;
using BTCh8_Bai4.Models;

namespace BTCh8_Bai4
{
    public partial class FrmBacSi : Form
    {
        private int _maBsDangChon = 0;

        public FrmBacSi()
        {
            InitializeComponent();

            Load += FrmBacSi_Load;

            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;

            dgvBacSi.CellClick += dgvBacSi_CellClick;
        }

        // ========================================
        // LOAD FORM
        // ========================================
        private async void FrmBacSi_Load(object? sender, EventArgs e)
        {
            await LoadBacSiAsync();
            LamMoi();
        }

        // ========================================
        // LOAD DANH SÁCH BÁC SĨ
        // ========================================
        private async Task LoadBacSiAsync()
        {
            try
            {
                using var db = new AnKhangClinicContext();

                var danhSach = await db.BacSis
                    .AsNoTracking()
                    .OrderBy(x => x.HoTen)
                    .Select(x => new
                    {
                        x.MaBs,
                        x.HoTen,
                        x.ChuyenKhoa,
                        SDT = x.Sdt
                    })
                    .ToListAsync();

                dgvBacSi.DataSource = danhSach;

                DinhDangDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải danh sách bác sĩ.\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ========================================
        // ĐỊNH DẠNG DATAGRIDVIEW
        // ========================================
        private void DinhDangDataGridView()
        {
            if (dgvBacSi.Columns["MaBs"] != null)
                dgvBacSi.Columns["MaBs"].HeaderText = "Mã BS";

            if (dgvBacSi.Columns["HoTen"] != null)
                dgvBacSi.Columns["HoTen"].HeaderText = "Họ tên";

            if (dgvBacSi.Columns["ChuyenKhoa"] != null)
                dgvBacSi.Columns["ChuyenKhoa"].HeaderText = "Chuyên khoa";

            if (dgvBacSi.Columns["SDT"] != null)
                dgvBacSi.Columns["SDT"].HeaderText = "Số điện thoại";
        }

        // ========================================
        // VALIDATE
        // ========================================
        private bool KiemTraDuLieu()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show(
                    "Không được bỏ trống họ tên bác sĩ.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtHoTen.Focus();

                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                string sdt = txtSDT.Text.Trim();

                if (!sdt.All(char.IsDigit))
                {
                    MessageBox.Show(
                        "Số điện thoại chỉ được chứa chữ số.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtSDT.Focus();

                    return false;
                }

                if (sdt.Length < 9 || sdt.Length > 15)
                {
                    MessageBox.Show(
                        "Số điện thoại phải từ 9 đến 15 chữ số.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtSDT.Focus();

                    return false;
                }
            }

            return true;
        }

        // ========================================
        // THÊM BÁC SĨ
        // ========================================
        private async void btnThem_Click(object? sender, EventArgs e)
        {
            if (!KiemTraDuLieu())
                return;

            try
            {
                using var db = new AnKhangClinicContext();

                var bacSi = new BacSi
                {
                    HoTen = txtHoTen.Text.Trim(),

                    ChuyenKhoa = string.IsNullOrWhiteSpace(
                        txtChuyenKhoa.Text)
                        ? null
                        : txtChuyenKhoa.Text.Trim(),

                    Sdt = string.IsNullOrWhiteSpace(
                        txtSDT.Text)
                        ? null
                        : txtSDT.Text.Trim()
                };

                db.BacSis.Add(bacSi);

                await db.SaveChangesAsync();

                MessageBox.Show(
                    "Thêm bác sĩ thành công.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                await LoadBacSiAsync();

                LamMoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Có lỗi khi thêm bác sĩ.\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ========================================
        // CLICK DÒNG DATAGRIDVIEW
        // ========================================
        private void dgvBacSi_CellClick(
            object? sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row =
                dgvBacSi.Rows[e.RowIndex];

            if (row.Cells["MaBs"].Value == null)
                return;

            _maBsDangChon =
                Convert.ToInt32(
                    row.Cells["MaBs"].Value);

            txtHoTen.Text =
                row.Cells["HoTen"].Value?.ToString() ?? "";

            txtChuyenKhoa.Text =
                row.Cells["ChuyenKhoa"].Value?.ToString() ?? "";

            txtSDT.Text =
                row.Cells["SDT"].Value?.ToString() ?? "";
        }

        // ========================================
        // SỬA BÁC SĨ
        // ========================================
        private async void btnSua_Click(object? sender, EventArgs e)
        {
            if (_maBsDangChon == 0)
            {
                MessageBox.Show(
                    "Vui lòng chọn bác sĩ cần sửa.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (!KiemTraDuLieu())
                return;

            try
            {
                using var db = new AnKhangClinicContext();

                var bacSi =
                    await db.BacSis.FindAsync(
                        _maBsDangChon);

                if (bacSi == null)
                {
                    MessageBox.Show(
                        "Không tìm thấy bác sĩ.");

                    return;
                }

                bacSi.HoTen =
                    txtHoTen.Text.Trim();

                bacSi.ChuyenKhoa =
                    string.IsNullOrWhiteSpace(
                        txtChuyenKhoa.Text)
                    ? null
                    : txtChuyenKhoa.Text.Trim();

                bacSi.Sdt =
                    string.IsNullOrWhiteSpace(
                        txtSDT.Text)
                    ? null
                    : txtSDT.Text.Trim();

                await db.SaveChangesAsync();

                MessageBox.Show(
                    "Cập nhật bác sĩ thành công.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                await LoadBacSiAsync();

                LamMoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Có lỗi khi cập nhật bác sĩ.\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ========================================
        // XÓA BÁC SĨ
        // ========================================
        private async void btnXoa_Click(object? sender, EventArgs e)
        {
            if (_maBsDangChon == 0)
            {
                MessageBox.Show(
                    "Vui lòng chọn bác sĩ cần xóa.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                using var db = new AnKhangClinicContext();

                // Kiểm tra bác sĩ đã có lịch khám chưa
                bool coLichKham =
                    await db.LichKhams.AnyAsync(
                        x => x.MaBs == _maBsDangChon);

                if (coLichKham)
                {
                    MessageBox.Show(
                        "Không thể xóa bác sĩ này vì đang có lịch khám liên quan.",
                        "Không thể xóa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                DialogResult ketQua =
                    MessageBox.Show(
                        "Bạn có chắc chắn muốn xóa bác sĩ này không?",
                        "Xác nhận xóa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                if (ketQua != DialogResult.Yes)
                    return;

                var bacSi =
                    await db.BacSis.FindAsync(
                        _maBsDangChon);

                if (bacSi == null)
                {
                    MessageBox.Show(
                        "Không tìm thấy bác sĩ.");

                    return;
                }

                db.BacSis.Remove(bacSi);

                await db.SaveChangesAsync();

                MessageBox.Show(
                    "Xóa bác sĩ thành công.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                await LoadBacSiAsync();

                LamMoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Có lỗi khi xóa bác sĩ.\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ========================================
        // LÀM MỚI
        // ========================================
        private void btnLamMoi_Click(object? sender, EventArgs e)
        {
            LamMoi();
        }

        private void LamMoi()
        {
            _maBsDangChon = 0;

            txtHoTen.Clear();
            txtChuyenKhoa.Clear();
            txtSDT.Clear();

            dgvBacSi.ClearSelection();

            txtHoTen.Focus();
        }
    }
}