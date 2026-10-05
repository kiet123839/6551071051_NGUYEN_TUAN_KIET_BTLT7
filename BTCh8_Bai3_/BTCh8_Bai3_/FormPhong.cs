using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using BTCh8_Bai3_.Models;

namespace BTCh8_Bai3_
{
    public partial class FormPhong : Form
    {
        // Khởi tạo DbContext scaffold từ EF Core Power Tools
        private SunriseHomestayDBContext db = new SunriseHomestayDBContext();
        private string tenFileAnhChon = "";
        private string thuMucAnh = Path.Combine(Application.StartupPath, "Images");

        public FormPhong()
        {
            InitializeComponent();
        }

        // 1. Khi Form vừa mở lên
        private void FormPhong_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(thuMucAnh))
            {
                Directory.CreateDirectory(thuMucAnh);
            }

            // Sao chép sẵn các file ảnh từ thư mục dự án vào thư mục chạy nếu chưa có
            CopyAnhMauVaoThuMucChay();

            LoadComboBoxLoaiPhong();
            LoadComboBoxTinhTrang();
            LoadDanhSachPhong();
        }

        private void CopyAnhMauVaoThuMucChay()
        {
            try
            {
                string projectDir = Directory.GetParent(Application.StartupPath).Parent.Parent.FullName;
                string srcImgDir = Path.Combine(projectDir, "Images");
                if (Directory.Exists(srcImgDir))
                {
                    foreach (var file in Directory.GetFiles(srcImgDir))
                    {
                        string destFile = Path.Combine(thuMucAnh, Path.GetFileName(file));
                        if (!File.Exists(destFile))
                        {
                            File.Copy(file, destFile, true);
                        }
                    }
                }
            }
            catch { }
        }

        // 2. Nạp dữ liệu vào các ComboBox Loại phòng qua LINQ
        private void LoadComboBoxLoaiPhong()
        {
            var dsLoai = db.LoaiPhongs.ToList();

            // ComboBox nhập liệu ở trên
            cboLoaiPhong.DataSource = dsLoai.ToList();
            cboLoaiPhong.DisplayMember = "TenLoai";
            cboLoaiPhong.ValueMember = "MaLoai";

            // ComboBox lọc tìm kiếm ở dưới (thêm mục Tất cả)
            var dsLoc = dsLoai.Select(x => new { x.MaLoai, x.TenLoai }).ToList();
            dsLoc.Insert(0, new { MaLoai = 0, TenLoai = "-- Lọc theo loại phòng --" });
            cboLocLoaiPhong.DataSource = dsLoc;
            cboLocLoaiPhong.DisplayMember = "TenLoai";
            cboLocLoaiPhong.ValueMember = "MaLoai";
        }

        // 3. Nạp dữ liệu vào ComboBox Tình trạng
        private void LoadComboBoxTinhTrang()
        {
            string[] items = new string[] { "Trống", "Đang ở", "Đang dọn" };

            cboTinhTrang.Items.Clear();
            cboTinhTrang.Items.AddRange(items);
            if (cboTinhTrang.Items.Count > 0) cboTinhTrang.SelectedIndex = 0;

            cboLocTinhTrang.Items.Clear();
            cboLocTinhTrang.Items.Add("-- Lọc theo tình trạng --");
            cboLocTinhTrang.Items.AddRange(items);
            cboLocTinhTrang.SelectedIndex = 0;
        }

        // 4. Load danh sách phòng kèm ảnh Thumbnail và Eager Loading (Include)
        private void LoadDanhSachPhong()
        {
            // Yêu cầu 5: Eager Loading qua Include(x => x.MaLoaiNavigation)
            var ds = db.Phongs.Include(p => p.MaLoaiNavigation).ToList();
            HienThiLenDataGridView(ds);
        }

        private void HienThiLenDataGridView(System.Collections.Generic.List<Phong> list)
        {
            dgvPhong.Rows.Clear();
            dgvPhong.Columns.Clear();

            dgvPhong.Columns.Add("MaPhong", "Mã phòng");

            // Cột DataGridViewImageColumn hiển thị thumbnail ảnh
            DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
            imgCol.Name = "ColHinhAnh";
            imgCol.HeaderText = "Ảnh";
            imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dgvPhong.Columns.Add(imgCol);

            dgvPhong.Columns.Add("SoPhong", "Số phòng");
            dgvPhong.Columns.Add("TangSo", "Tầng");
            dgvPhong.Columns.Add("TenLoai", "Loại phòng");
            dgvPhong.Columns.Add("GiaMoiDem", "Giá/đêm");
            dgvPhong.Columns.Add("TinhTrang", "Tình trạng");

            dgvPhong.RowTemplate.Height = 65; // Đảm bảo chiều cao hàng vừa vặn ảnh

            foreach (var item in list)
            {
                Image anhHienThi = null;
                string duongDan = Path.Combine(thuMucAnh, item.HinhAnh ?? "");
                if (!string.IsNullOrEmpty(item.HinhAnh) && File.Exists(duongDan))
                {
                    using (var fs = new FileStream(duongDan, FileMode.Open, FileAccess.Read))
                    {
                        anhHienThi = Image.FromStream(fs);
                    }
                }

                dgvPhong.Rows.Add(
                    item.MaPhong,
                    anhHienThi,
                    item.SoPhong,
                    item.TangSo,
                    item.MaLoaiNavigation?.TenLoai,
                    item.MaLoaiNavigation?.GiaMoiDem?.ToString("N0"),
                    item.TinhTrang
                );
            }
        }

        // 5. Chọn ảnh: sao chép vào thư mục Images của ứng dụng và chỉ lưu TÊN FILE
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string ext = Path.GetExtension(ofd.FileName);
                    tenFileAnhChon = Guid.NewGuid().ToString() + ext; // Đặt tên ngẫu nhiên tránh trùng
                    string fileDich = Path.Combine(thuMucAnh, tenFileAnhChon);

                    File.Copy(ofd.FileName, fileDich, true);

                    if (picHinhAnh.Image != null) picHinhAnh.Image.Dispose();
                    using (var fs = new FileStream(fileDich, FileMode.Open, FileAccess.Read))
                    {
                        picHinhAnh.Image = Image.FromStream(fs);
                    }
                }
            }
        }

        // 6. Thêm phòng mới
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSoPhong.Text))
            {
                MessageBox.Show("Vui lòng nhập số phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Phong p = new Phong
            {
                SoPhong = txtSoPhong.Text.Trim(),
                TangSo = (int)nudTangSo.Value,
                TinhTrang = cboTinhTrang.SelectedItem?.ToString(),
                MaLoai = (int)cboLoaiPhong.SelectedValue,
                HinhAnh = tenFileAnhChon
            };

            db.Phongs.Add(p);
            db.SaveChanges();
            MessageBox.Show("Thêm phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadDanhSachPhong();
            LamMoiForm();
        }

        // 7. Sửa thông tin phòng
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvPhong.CurrentRow == null) return;
            int maPhong = Convert.ToInt32(dgvPhong.CurrentRow.Cells["MaPhong"].Value);

            var p = db.Phongs.Find(maPhong);
            if (p != null)
            {
                p.SoPhong = txtSoPhong.Text.Trim();
                p.TangSo = (int)nudTangSo.Value;
                p.TinhTrang = cboTinhTrang.SelectedItem?.ToString();
                p.MaLoai = (int)cboLoaiPhong.SelectedValue;
                if (!string.IsNullOrEmpty(tenFileAnhChon))
                {
                    p.HinhAnh = tenFileAnhChon;
                }

                db.SaveChanges();
                MessageBox.Show("Cập nhật thông tin phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachPhong();
                LamMoiForm();
            }
        }

        // 8. Xóa phòng
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvPhong.CurrentRow == null) return;
            int maPhong = Convert.ToInt32(dgvPhong.CurrentRow.Cells["MaPhong"].Value);

            var dialog = MessageBox.Show("Bạn có chắc chắn muốn xóa phòng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                var p = db.Phongs.Find(maPhong);
                if (p != null)
                {
                    db.Phongs.Remove(p);
                    db.SaveChanges();
                    MessageBox.Show("Đã xóa phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachPhong();
                    LamMoiForm();
                }
            }
        }

        // 9. Tích chọn dòng DataGridView để hiển thị dữ liệu và ảnh lên PictureBox
        private void dgvPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvPhong.Rows.Count) return;

            DataGridViewRow row = dgvPhong.Rows[e.RowIndex];
            int maPhong = Convert.ToInt32(row.Cells["MaPhong"].Value);

            var p = db.Phongs.Find(maPhong);
            if (p != null)
            {
                txtSoPhong.Text = p.SoPhong;
                nudTangSo.Value = p.TangSo ?? 1;
                cboLoaiPhong.SelectedValue = p.MaLoai;
                cboTinhTrang.SelectedItem = p.TinhTrang;
                tenFileAnhChon = p.HinhAnh;

                string path = Path.Combine(thuMucAnh, p.HinhAnh ?? "");
                if (picHinhAnh.Image != null) picHinhAnh.Image.Dispose();

                if (!string.IsNullOrEmpty(p.HinhAnh) && File.Exists(path))
                {
                    using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        picHinhAnh.Image = Image.FromStream(fs);
                    }
                }
                else
                {
                    picHinhAnh.Image = null;
                }
            }
        }

        // 10. Tìm kiếm / Lọc kết hợp Loại phòng VÀ Tình trạng (LINQ Where + Include)
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            int maLoaiLoc = Convert.ToInt32(cboLocLoaiPhong.SelectedValue);
            string tinhTrangLoc = cboLocTinhTrang.SelectedItem?.ToString();

            var query = db.Phongs.Include(p => p.MaLoaiNavigation).AsQueryable();

            if (maLoaiLoc > 0)
            {
                query = query.Where(p => p.MaLoai == maLoaiLoc);
            }

            if (cboLocTinhTrang.SelectedIndex > 0 && tinhTrangLoc != "-- Lọc theo tình trạng --")
            {
                query = query.Where(p => p.TinhTrang == tinhTrangLoc);
            }

            HienThiLenDataGridView(query.ToList());
        }

        // 11. Làm mới Form
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoiForm();
            LoadDanhSachPhong();
        }

        private void LamMoiForm()
        {
            txtSoPhong.Clear();
            nudTangSo.Value = 1;
            if (cboTinhTrang.Items.Count > 0) cboTinhTrang.SelectedIndex = 0;
            if (cboLoaiPhong.Items.Count > 0) cboLoaiPhong.SelectedIndex = 0;
            if (picHinhAnh.Image != null) picHinhAnh.Image.Dispose();
            picHinhAnh.Image = null;
            tenFileAnhChon = "";
        }
    }
}