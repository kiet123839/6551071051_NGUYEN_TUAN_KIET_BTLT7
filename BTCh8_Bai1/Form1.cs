using BTCh8_Bai1.Models;
using Microsoft.EntityFrameworkCore;

namespace BTCh8_Bai1
{
    public partial class frmTheLoaiSach : Form
    {
        private TriThucBooksContext context;
        public frmTheLoaiSach()
        {
            InitializeComponent();

            var options = new DbContextOptionsBuilder<TriThucBooksContext>()
    .UseSqlServer(
        "Server=LAPTOP-APPVC4J1\\SQLEXPRESS;Database=TriThucBooks;Trusted_Connection=True;TrustServerCertificate=True;")
    .Options;

            context = new TriThucBooksContext(options);

            Load += frmTheLoaiSach_Load;
            dgvTheLoaiSach.SelectionChanged += dgvTheLoaiSach_SelectionChanged;
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            btnTimKiem.Click += btnTimKiem_Click;
        }

        private async void frmTheLoaiSach_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            var data = await context.TheLoaiSaches
                .AsNoTracking()
                .OrderBy(x => x.MaTl)
                .ToListAsync();

            dgvTheLoaiSach.DataSource = data;
        }

        private void dgvTheLoaiSach_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTheLoaiSach.CurrentRow == null)
                return;

            if (dgvTheLoaiSach.CurrentRow.DataBoundItem is TheLoaiSach item)
            {
                txtMaTL.Text = item.MaTl.ToString();
                txtTenTheLoai.Text = item.TenTheLoai;
                txtMoTa.Text = item.MoTa;

                lblGiaTriNgayTao.Text =
                    item.NgayTao.ToString("dd/MM/yyyy HH:mm:ss");
            }
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            string tenTheLoai = txtTenTheLoai.Text.Trim();
            string moTa = txtMoTa.Text.Trim();

            // Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(tenTheLoai))
            {
                MessageBox.Show(
                    "Vui lòng nhập tên thể loại!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTenTheLoai.Focus();
                return;
            }

            // Kiểm tra trùng
            bool trung = await context.TheLoaiSaches
                .AnyAsync(x => x.TenTheLoai == tenTheLoai);

            if (trung)
            {
                MessageBox.Show(
                    "Tên thể loại đã tồn tại!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTenTheLoai.Focus();
                return;
            }

            var theLoai = new TheLoaiSach
            {
                TenTheLoai = tenTheLoai,
                MoTa = string.IsNullOrWhiteSpace(moTa) ? null : moTa,
                SoLuongSach = 0,
                NgayTao = DateTime.Now
            };

            context.TheLoaiSaches.Add(theLoai);

            await context.SaveChangesAsync();

            MessageBox.Show(
                "Thêm thể loại thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            await LoadData();
            ClearInput();
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMaTL.Text, out int maTL))
            {
                MessageBox.Show(
                    "Vui lòng chọn thể loại cần sửa!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            string tenTheLoai = txtTenTheLoai.Text.Trim();
            string moTa = txtMoTa.Text.Trim();

            if (string.IsNullOrWhiteSpace(tenTheLoai))
            {
                MessageBox.Show(
                    "Tên thể loại không được để trống!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTenTheLoai.Focus();
                return;
            }

            // Kiểm tra trùng với thể loại khác
            bool trung = await context.TheLoaiSaches
                .AnyAsync(x =>
                    x.TenTheLoai == tenTheLoai &&
                    x.MaTl != maTL);

            if (trung)
            {
                MessageBox.Show(
                    "Tên thể loại đã tồn tại!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var theLoai = await context.TheLoaiSaches
                .FirstOrDefaultAsync(x => x.MaTl == maTL);

            if (theLoai == null)
            {
                MessageBox.Show("Không tìm thấy thể loại!");
                return;
            }

            theLoai.TenTheLoai = tenTheLoai;
            theLoai.MoTa = string.IsNullOrWhiteSpace(moTa) ? null : moTa;

            await context.SaveChangesAsync();

            MessageBox.Show(
                "Cập nhật thể loại thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            await LoadData();
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMaTL.Text, out int maTL))
            {
                MessageBox.Show(
                    "Vui lòng chọn thể loại cần xóa!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            string tenTheLoai = txtTenTheLoai.Text;

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc muốn xóa thể loại \"{tenTheLoai}\" không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                var theLoai = await context.TheLoaiSaches
                    .FirstOrDefaultAsync(x => x.MaTl == maTL);

                if (theLoai == null)
                {
                    MessageBox.Show("Không tìm thấy thể loại!");
                    return;
                }

                context.TheLoaiSaches.Remove(theLoai);

                await context.SaveChangesAsync();

                MessageBox.Show(
                    "Xóa thể loại thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                await LoadData();
                ClearInput();
            }
            catch (DbUpdateException)
            {
                MessageBox.Show(
                    "Không thể xóa thể loại này vì đang có sách tham chiếu đến thể loại!",
                    "Lỗi ràng buộc dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInput();

            txtTimKiem.Clear();

            await LoadData();
        }

        private void ClearInput()
        {
            txtMaTL.Clear();
            txtTenTheLoai.Clear();
            txtMoTa.Clear();

            lblGiaTriNgayTao.Text = "";

            txtTenTheLoai.Focus();
        }

        private async void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            var data = await context.TheLoaiSaches
                .AsNoTracking()
                .Where(x => x.TenTheLoai.Contains(keyword))
                .OrderBy(x => x.MaTl)
                .ToListAsync();

            dgvTheLoaiSach.DataSource = data;
        }
    }
}
