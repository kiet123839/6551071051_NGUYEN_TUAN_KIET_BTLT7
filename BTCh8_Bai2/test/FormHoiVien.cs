using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTCh8_Bai2_.Models;

namespace BTCh8_Bai2_
{
    public partial class FormHoiVien : Form
    {
        private readonly FitZoneDbContext _context;
        private int _selectedMaHV = -1;

        public FormHoiVien()
        {
            InitializeComponent();
            _context = new FitZoneDbContext();
        }

        private async void FormHoiVien_Load(object sender, EventArgs e)
        {
            InitControlData();
            await LoadDataAsync();
        }

        private void InitControlData()
        {
            cboHangThanhVien.Items.Clear();
            cboHangThanhVien.Items.AddRange(new string[] { "Basic", "VIP", "Premium" });
            cboHangThanhVien.SelectedIndex = 0;

            cboTimKiemHang.Items.Clear();
            cboTimKiemHang.Items.AddRange(new string[] { "-- Tất cả --", "Basic", "VIP", "Premium" });
            cboTimKiemHang.SelectedIndex = 0;

            dtpNgaySinh.Format = DateTimePickerFormat.Short;
            rdbNam.Checked = true;
            chkTrangThai.Checked = true;
        }

        private async Task LoadDataAsync()
        {
            var query = _context.HoiViens.AsQueryable();

            string keyword = txtTimKiemHoTen.Text.Trim();
            string? hangSelected = cboTimKiemHang.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(keyword) && !string.IsNullOrEmpty(hangSelected) && hangSelected != "-- Tất cả --")
            {
                query = query.Where(hv => hv.HoTen.Contains(keyword) && hv.HangThanhVien == hangSelected);
            }
            else
            {
                if (!string.IsNullOrEmpty(keyword))
                    query = query.Where(hv => hv.HoTen.Contains(keyword));

                if (!string.IsNullOrEmpty(hangSelected) && hangSelected != "-- Tất cả --")
                    query = query.Where(hv => hv.HangThanhVien == hangSelected);
            }

            var rawList = await query.ToListAsync();

            var listHV = rawList.Select(hv => {
                int maHV = GetPropertyValue<int>(hv, "MaHV", "MaHoiVien", "Id");
                string sdt = GetPropertyValue<string>(hv, "SDT", "Sdt", "SoDienThoai", "DienThoai") ?? string.Empty;

                return new
                {
                    MaHV = maHV,
                    HoTen = hv.HoTen ?? string.Empty,
                    GioiTinhText = hv.GioiTinh ? "Nam" : "Nữ",
                    GioiTinh = hv.GioiTinh,
                    NgaySinh = hv.NgaySinh,
                    SDT = sdt,
                    Email = hv.Email ?? string.Empty,
                    HangThanhVien = hv.HangThanhVien ?? string.Empty,
                    NgayDangKy = hv.NgayDangKy,
                    TrangThaiText = hv.TrangThai ? "Đang hoạt động" : "Tạm ngưng",
                    TrangThai = hv.TrangThai
                };
            }).ToList();

            dgvHoiVien.DataSource = listHV;
            CustomDataGridView();
            ClearInputForm();
        }

        private void CustomDataGridView()
        {
            if (dgvHoiVien.Columns["GioiTinh"] != null) dgvHoiVien.Columns["GioiTinh"]!.Visible = false;
            if (dgvHoiVien.Columns["TrangThai"] != null) dgvHoiVien.Columns["TrangThai"]!.Visible = false;

            if (dgvHoiVien.Columns["MaHV"] != null) dgvHoiVien.Columns["MaHV"]!.HeaderText = "Mã HV";
            if (dgvHoiVien.Columns["HoTen"] != null) dgvHoiVien.Columns["HoTen"]!.HeaderText = "Họ và Tên";
            if (dgvHoiVien.Columns["GioiTinhText"] != null) dgvHoiVien.Columns["GioiTinhText"]!.HeaderText = "Giới Tính";
            if (dgvHoiVien.Columns["NgaySinh"] != null) dgvHoiVien.Columns["NgaySinh"]!.HeaderText = "Ngày Sinh";
            if (dgvHoiVien.Columns["SDT"] != null) dgvHoiVien.Columns["SDT"]!.HeaderText = "Số ĐT";
            if (dgvHoiVien.Columns["Email"] != null) dgvHoiVien.Columns["Email"]!.HeaderText = "Email";
            if (dgvHoiVien.Columns["HangThanhVien"] != null) dgvHoiVien.Columns["HangThanhVien"]!.HeaderText = "Hạng TV";
            if (dgvHoiVien.Columns["NgayDangKy"] != null) dgvHoiVien.Columns["NgayDangKy"]!.HeaderText = "Ngày Đăng Ký";
            if (dgvHoiVien.Columns["TrangThaiText"] != null) dgvHoiVien.Columns["TrangThaiText"]!.HeaderText = "Trạng Thái";
        }

        private void dgvHoiVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvHoiVien.Rows.Count) return;

            var row = dgvHoiVien.Rows[e.RowIndex];
            if (row.Cells["MaHV"].Value == null) return;

            _selectedMaHV = Convert.ToInt32(row.Cells["MaHV"].Value);

            txtHoTen.Text = row.Cells["HoTen"].Value?.ToString() ?? string.Empty;
            txtSDT.Text = row.Cells["SDT"].Value?.ToString() ?? string.Empty;
            txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? string.Empty;

            bool gioiTinh = Convert.ToBoolean(row.Cells["GioiTinh"].Value ?? false);
            if (gioiTinh) rdbNam.Checked = true;
            else rdbNu.Checked = true;

            if (row.Cells["NgaySinh"].Value != null)
            {
                var val = row.Cells["NgaySinh"].Value;
                if (val is DateOnly dOnly)
                    dtpNgaySinh.Value = dOnly.ToDateTime(TimeOnly.MinValue);
                else if (val != null)
                    dtpNgaySinh.Value = Convert.ToDateTime(val);
            }

            string hang = row.Cells["HangThanhVien"].Value?.ToString() ?? string.Empty;
            cboHangThanhVien.SelectedItem = hang;

            bool trangThai = Convert.ToBoolean(row.Cells["TrangThai"].Value ?? true);
            chkTrangThai.Checked = trangThai;
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập Họ và Tên hội viên!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }

            string sdt = txtSDT.Text.Trim();
            if (!string.IsNullOrEmpty(sdt))
            {
                if (!Regex.IsMatch(sdt, @"^\d{9,11}$"))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ! SĐT phải từ 9 đến 11 chữ số.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSDT.Focus();
                    return false;
                }
            }

            string email = txtEmail.Text.Trim();
            if (!string.IsNullOrEmpty(email))
            {
                if (!email.Contains("@"))
                {
                    MessageBox.Show("Email không hợp lệ! Email phải chứa ký tự '@'.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return false;
                }
            }

            DateTime ngaySinh = dtpNgaySinh.Value;
            DateTime ngayHienTai = DateTime.Now;
            int tuoi = ngayHienTai.Year - ngaySinh.Year;
            if (ngaySinh.Date > ngayHienTai.AddYears(-tuoi)) tuoi--;

            if (tuoi < 15)
            {
                MessageBox.Show($"Hội viên chưa đủ tuổi đăng ký! Tuổi hiện tại là {tuoi} (yêu cầu từ 15 tuổi trở lên).", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgaySinh.Focus();
                return false;
            }

            return true;
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            try
            {
                string hangTV = cboHangThanhVien.SelectedItem?.ToString() ?? "Basic";

                var newHV = new HoiVien
                {
                    HoTen = txtHoTen.Text.Trim(),
                    GioiTinh = rdbNam.Checked,
                    NgaySinh = DateOnly.FromDateTime(dtpNgaySinh.Value),
                    Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                    HangThanhVien = hangTV,
                    NgayDangKy = DateTime.Now,
                    TrangThai = chkTrangThai.Checked
                };

                SetPropertyValue(newHV, txtSDT.Text.Trim(), "SDT", "Sdt", "SoDienThoai", "DienThoai");

                _context.HoiViens.Add(newHV);
                await _context.SaveChangesAsync();

                MessageBox.Show("Thêm hội viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thêm dữ liệu: {ex.Message}", "Lỗi System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (_selectedMaHV == -1)
            {
                MessageBox.Show("Vui lòng chọn hội viên cần sửa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateForm()) return;

            try
            {
                var hvList = await _context.HoiViens.ToListAsync();
                var hv = hvList.FirstOrDefault(item => GetPropertyValue<int>(item, "MaHV", "MaHoiVien", "Id") == _selectedMaHV);

                if (hv != null)
                {
                    hv.HoTen = txtHoTen.Text.Trim();
                    hv.GioiTinh = rdbNam.Checked;
                    hv.NgaySinh = DateOnly.FromDateTime(dtpNgaySinh.Value);
                    hv.Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim();
                    hv.HangThanhVien = cboHangThanhVien.SelectedItem?.ToString() ?? "Basic";
                    hv.TrangThai = chkTrangThai.Checked;

                    SetPropertyValue(hv, txtSDT.Text.Trim(), "SDT", "Sdt", "SoDienThoai", "DienThoai");

                    await _context.SaveChangesAsync();

                    MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDataAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi cập nhật: {ex.Message}", "Lỗi System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (_selectedMaHV == -1)
            {
                MessageBox.Show("Vui lòng chọn hội viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa hội viên này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    var hvList = await _context.HoiViens.ToListAsync();
                    var hv = hvList.FirstOrDefault(item => GetPropertyValue<int>(item, "MaHV", "MaHoiVien", "Id") == _selectedMaHV);

                    if (hv != null)
                    {
                        _context.HoiViens.Remove(hv);
                        await _context.SaveChangesAsync();

                        MessageBox.Show("Xóa hội viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadDataAsync();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi xóa dữ liệu: {ex.Message}", "Lỗi System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnTimKiem_Click(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInputForm();
        }

        private void ClearInputForm()
        {
            _selectedMaHV = -1;
            txtHoTen.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            rdbNam.Checked = true;
            dtpNgaySinh.Value = DateTime.Now.AddYears(-18);
            if (cboHangThanhVien.Items.Count > 0) cboHangThanhVien.SelectedIndex = 0;
            chkTrangThai.Checked = true;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _context?.Dispose();
        }

        // Helper Reflection hỗ trợ đọc/ghi thuộc tính linh hoạt theo tên cột Database (kèm kiểm tra Null-safety)
        private T? GetPropertyValue<T>(object obj, params string[] propertyNames)
        {
            var type = obj.GetType();
            foreach (var name in propertyNames)
            {
                var prop = type.GetProperty(name);
                if (prop != null)
                {
                    var val = prop.GetValue(obj);
                    if (val != null)
                    {
                        return (T)Convert.ChangeType(val, typeof(T));
                    }
                }
            }
            return default;
        }

        private void SetPropertyValue(object obj, string value, params string[] propertyNames)
        {
            var type = obj.GetType();
            foreach (var name in propertyNames)
            {
                var prop = type.GetProperty(name);
                if (prop != null && prop.CanWrite)
                {
                    prop.SetValue(obj, string.IsNullOrWhiteSpace(value) ? null : value);
                    break;
                }
            }
        }
    }
}