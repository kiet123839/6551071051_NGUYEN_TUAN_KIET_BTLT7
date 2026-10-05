using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BTCh8_Bai2_.Models;

public partial class FitZoneDbContext : DbContext
{
    public FitZoneDbContext()
    {
    }

    public FitZoneDbContext(DbContextOptions<FitZoneDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<HoiVien> HoiViens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=FitZoneDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HoiVien>(entity =>
        {
            entity.HasKey(e => e.MaHv);

            entity.ToTable("HoiVien");

            entity.Property(e => e.MaHv).HasColumnName("MaHV");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.HangThanhVien)
                .HasMaxLength(20)
                .HasDefaultValue("Basic", "DF_HoiVien_HangThanhVien");
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.NgayDangKy)
                .HasDefaultValueSql("(getdate())", "DF_HoiVien_NgayDangKy")
                .HasColumnType("datetime");
            entity.Property(e => e.Sdt)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("SDT");
            entity.Property(e => e.TrangThai).HasDefaultValue(true, "DF_HoiVien_TrangThai");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
