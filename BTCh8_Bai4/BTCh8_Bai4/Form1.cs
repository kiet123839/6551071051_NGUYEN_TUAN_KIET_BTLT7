using Microsoft.EntityFrameworkCore;
using BTCh8_Bai4.Models;

namespace BTCh8_Bai4
{
    public partial class Form1 : Form
    {
        private int _maLichDangChon = 0;

        public Form1()
        {
            InitializeComponent();

            // Gắn sự kiện
            Load += Form1_Load;

            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;

            btnTimKiem.Click += btnTimKiem_Click;
            btnQuanLyBacSi.Click += btnQuanLyBacSi_Click;

            dgvLichKham.CellClick += dgvLichKham_CellClick;
        }

        // ==========================
        // LOAD FORM
        // ==========================
        private async void Form1_Load(object? sender, EventArgs e)
        {
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.AddRange(new object[]
            {
                "Chờ khám",
                "Đã khám",
                "Đã hủy"
            });

            cboTrangThai.SelectedIndex = 0;

            await LoadBacSiAsync();
            await LoadLichKhamAsync();

            LamMoi();
        }

        // ==========================
        // LOAD BÁC SĨ
        // ==========================
        private async Task LoadBacSiAsync()
        {
            using var db = new AnKhangClinicContext();

            var danhSach = await db.BacSis
                .AsNoTracking()
                .OrderBy(x => x.HoTen)
                .Select(x => new
                {
                    x.MaBs,

                    HienThi =
                        "BS. " + x.HoTen +
                        " - " + (x.ChuyenKhoa ?? "")
                })
                .ToListAsync();

            // ComboBox chọn bác sĩ khi đặt lịch
            cboBacSi.DataSource = danhSach.ToList();
            cboBacSi.DisplayMember = "HienThi";
            cboBacSi.ValueMember = "MaBs";
            cboBacSi.SelectedIndex = -1;

            // ComboBox tìm kiếm bác sĩ
            cboTimBacSi.DataSource = danhSach.ToList();
            cboTimBacSi.DisplayMember = "HienThi";
            cboTimBacSi.ValueMember = "MaBs";
            cboTimBacSi.SelectedIndex = -1;
        }

        // ==========================
        // LOAD LỊCH KHÁM
        // ==========================
        private async Task LoadLichKhamAsync()
        {
            using var db = new AnKhangClinicContext();

            var danhSach = await db.LichKhams

                // Yêu cầu quan trọng của đề
                .Include(x => x.MaBsNavigation)

                .AsNoTracking()

                .OrderByDescending(x => x.NgayKham)
                .ThenBy(x => x.GioKham)

                .Select(x => new
                {
                    x.MaLich,
                    x.TenBenhNhan,

                    SDT = x.Sdt,

                    x.NgayKham,
                    x.GioKham,

                    x.MaBs,

                    BacSi = x.MaBsNavigation != null
                        ? "BS. " + x.MaBsNavigation.HoTen
                        : "",

                    ChuyenKhoa = x.MaBsNavigation != null
                        ? x.MaBsNavigation.ChuyenKhoa
                        : "",

                    x.TrangThai
                })

                .ToListAsync();

            dgvLichKham.DataSource = danhSach;

            DinhDangDataGridView();
        }

        // ==========================
        // ĐỊNH DẠNG DATAGRIDVIEW
        // ==========================
        private void DinhDangDataGridView()
        {
            if (dgvLichKham.Columns["MaLich"] != null)
                dgvLichKham.Columns["MaLich"].HeaderText = "Mã lịch";

            if (dgvLichKham.Columns["TenBenhNhan"] != null)
                dgvLichKham.Columns["TenBenhNhan"].HeaderText = "Tên bệnh nhân";

            if (dgvLichKham.Columns["SDT"] != null)
                dgvLichKham.Columns["SDT"].HeaderText = "Số điện thoại";

            if (dgvLichKham.Columns["NgayKham"] != null)
                dgvLichKham.Columns["NgayKham"].HeaderText = "Ngày khám";

            if (dgvLichKham.Columns["GioKham"] != null)
                dgvLichKham.Columns["GioKham"].HeaderText = "Giờ khám";

            if (dgvLichKham.Columns["BacSi"] != null)
                dgvLichKham.Columns["BacSi"].HeaderText = "Bác sĩ";

            if (dgvLichKham.Columns["ChuyenKhoa"] != null)
                dgvLichKham.Columns["ChuyenKhoa"].HeaderText = "Chuyên khoa";

            if (dgvLichKham.Columns["TrangThai"] != null)
                dgvLichKham.Columns["TrangThai"].HeaderText = "Trạng thái";

            // Không cần hiển thị khóa ngoại
            if (dgvLichKham.Columns["MaBs"] != null)
                dgvLichKham.Columns["MaBs"].Visible = false;
        }

        // ==========================
        // VALIDATE
        // ==========================
        private bool KiemTraDuLieu(out int maBs)
        {
            maBs = 0;

            if (string.IsNullOrWhiteSpace(txtTenBenhNhan.Text))
            {
                MessageBox.Show(
                    "Không được bỏ trống tên bệnh nhân.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTenBenhNhan.Focus();

                return false;
            }

            // Không cho đặt lịch ngày quá khứ
            if (dtpNgayKham.Value.Date < DateTime.Today)
            {
                MessageBox.Show(
                    "Không được đặt lịch khám vào ngày trong quá khứ.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (cboBacSi.SelectedValue == null ||
                !int.TryParse(
                    cboBacSi.SelectedValue.ToString(),
                    out maBs))
            {
                MessageBox.Show(
                    "Vui lòng chọn bác sĩ.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

        // ==========================
        // THÊM
        // ==========================
        private async void btnThem_Click(object? sender, EventArgs e)
        {
            if (!KiemTraDuLieu(out int maBs))
                return;

            try
            {
                using var db = new AnKhangClinicContext();

                var lich = new LichKham
                {
                    TenBenhNhan = txtTenBenhNhan.Text.Trim(),

                    Sdt = txtSDT.Text.Trim(),

                    NgayKham = DateOnly.FromDateTime(
                        dtpNgayKham.Value),

                    GioKham = TimeOnly.FromDateTime(
                        dtpGioKham.Value),

                    MaBs = maBs,

                    TrangThai = cboTrangThai.Text
                };

                db.LichKhams.Add(lich);

                await db.SaveChangesAsync();

                MessageBox.Show(
                    "Thêm lịch khám thành công.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                await LoadLichKhamAsync();

                LamMoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ==========================
        // CLICK DÒNG DATAGRIDVIEW
        // ==========================
        private void dgvLichKham_CellClick(
            object? sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var row = dgvLichKham.Rows[e.RowIndex];

            _maLichDangChon =
                Convert.ToInt32(
                    row.Cells["MaLich"].Value);

            txtTenBenhNhan.Text =
                row.Cells["TenBenhNhan"].Value?.ToString() ?? "";

            txtSDT.Text =
                row.Cells["SDT"].Value?.ToString() ?? "";

            // Ngày khám
            if (row.Cells["NgayKham"].Value is DateOnly ngay)
            {
                dtpNgayKham.Value =
                    ngay.ToDateTime(TimeOnly.MinValue);
            }

            // Giờ khám
            if (row.Cells["GioKham"].Value is TimeOnly gio)
            {
                dtpGioKham.Value =
                    DateTime.Today.Add(gio.ToTimeSpan());
            }

            // Bác sĩ
            if (row.Cells["MaBs"].Value != null)
            {
                cboBacSi.SelectedValue =
                    Convert.ToInt32(
                        row.Cells["MaBs"].Value);
            }

            // Trạng thái
            string trangThai =
                row.Cells["TrangThai"].Value?.ToString() ?? "";

            if (!string.IsNullOrWhiteSpace(trangThai))
            {
                cboTrangThai.SelectedItem = trangThai;
            }
        }

        // ==========================
        // SỬA
        // ==========================
        private async void btnSua_Click(object? sender, EventArgs e)
        {
            if (_maLichDangChon == 0)
            {
                MessageBox.Show(
                    "Vui lòng chọn lịch khám cần sửa.");

                return;
            }

            if (!KiemTraDuLieu(out int maBs))
                return;

            try
            {
                using var db = new AnKhangClinicContext();

                var lich =
                    await db.LichKhams.FindAsync(
                        _maLichDangChon);

                if (lich == null)
                {
                    MessageBox.Show(
                        "Không tìm thấy lịch khám.");

                    return;
                }

                lich.TenBenhNhan =
                    txtTenBenhNhan.Text.Trim();

                lich.Sdt =
                    txtSDT.Text.Trim();

                lich.NgayKham =
                    DateOnly.FromDateTime(
                        dtpNgayKham.Value);

                lich.GioKham =
                    TimeOnly.FromDateTime(
                        dtpGioKham.Value);

                lich.MaBs = maBs;

                lich.TrangThai =
                    cboTrangThai.Text;

                await db.SaveChangesAsync();

                MessageBox.Show(
                    "Cập nhật lịch khám thành công.");

                await LoadLichKhamAsync();

                LamMoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi: " + ex.Message);
            }
        }

        // ==========================
        // XÓA
        // ==========================
        private async void btnXoa_Click(object? sender, EventArgs e)
        {
            if (_maLichDangChon == 0)
            {
                MessageBox.Show(
                    "Vui lòng chọn lịch khám cần xóa.");

                return;
            }

            DialogResult ketQua =
                MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa lịch khám này không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (ketQua != DialogResult.Yes)
                return;

            try
            {
                using var db = new AnKhangClinicContext();

                var lich =
                    await db.LichKhams.FindAsync(
                        _maLichDangChon);

                if (lich == null)
                {
                    MessageBox.Show(
                        "Không tìm thấy lịch khám.");

                    return;
                }

                db.LichKhams.Remove(lich);

                // SaveChangesAsync chỉ được gọi
                // sau khi xác nhận Yes
                await db.SaveChangesAsync();

                MessageBox.Show(
                    "Xóa lịch khám thành công.");

                await LoadLichKhamAsync();

                LamMoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi: " + ex.Message);
            }
        }

        // ==========================
        // TÌM KIẾM
        // ==========================
        private async void btnTimKiem_Click(
            object? sender,
            EventArgs e)
        {
            DateOnly tuNgay =
                DateOnly.FromDateTime(
                    dtpTuNgay.Value.Date);

            DateOnly denNgay =
                DateOnly.FromDateTime(
                    dtpDenNgay.Value.Date);

            if (tuNgay > denNgay)
            {
                MessageBox.Show(
                    "Từ ngày không được lớn hơn đến ngày.");

                return;
            }

            if (cboTimBacSi.SelectedValue == null ||
                !int.TryParse(
                    cboTimBacSi.SelectedValue.ToString(),
                    out int maBs))
            {
                MessageBox.Show(
                    "Vui lòng chọn bác sĩ cần tìm.");

                return;
            }

            using var db = new AnKhangClinicContext();

            var danhSach = await db.LichKhams

                .Include(x => x.MaBsNavigation)

                .AsNoTracking()

                // Yêu cầu của đề:
                // >=, <= và ==
                .Where(x =>
                    x.NgayKham.HasValue &&
                    x.NgayKham.Value >= tuNgay &&
                    x.NgayKham.Value <= denNgay &&
                    x.MaBs == maBs)

                .OrderBy(x => x.NgayKham)

                .ThenBy(x => x.GioKham)

                .Select(x => new
                {
                    x.MaLich,
                    x.TenBenhNhan,

                    SDT = x.Sdt,

                    x.NgayKham,
                    x.GioKham,

                    x.MaBs,

                    BacSi = x.MaBsNavigation != null
                        ? "BS. " + x.MaBsNavigation.HoTen
                        : "",

                    ChuyenKhoa = x.MaBsNavigation != null
                        ? x.MaBsNavigation.ChuyenKhoa
                        : "",

                    x.TrangThai
                })

                .ToListAsync();

            dgvLichKham.DataSource = danhSach;

            DinhDangDataGridView();
        }

        // ==========================
        // LÀM MỚI
        // ==========================
        private async void btnLamMoi_Click(
            object? sender,
            EventArgs e)
        {
            LamMoi();

            await LoadLichKhamAsync();
        }

        private void LamMoi()
        {
            _maLichDangChon = 0;

            txtTenBenhNhan.Clear();

            txtSDT.Clear();

            dtpNgayKham.Value = DateTime.Today;

            dtpGioKham.Value = DateTime.Now;

            cboBacSi.SelectedIndex = -1;

            if (cboTrangThai.Items.Count > 0)
            {
                cboTrangThai.SelectedIndex = 0;
            }

            txtTenBenhNhan.Focus();
        }

        // ==========================
        // FORM QUẢN LÝ BÁC SĨ
        // ==========================
        private async void btnQuanLyBacSi_Click(
            object? sender,
            EventArgs e)
        {
            using var frm = new FrmBacSi();

            frm.ShowDialog();

            // Khi đóng form bác sĩ,
            // load lại ComboBox bác sĩ
            await LoadBacSiAsync();

            await LoadLichKhamAsync();
        }
    }
}