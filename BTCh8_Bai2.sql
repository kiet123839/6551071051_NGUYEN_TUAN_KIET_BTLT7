-- Create Database FitZone (nếu chưa có)
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'FitZoneDB')
BEGIN
    CREATE DATABASE FitZoneDB;
END
GO

USE FitZoneDB;
GO

-- Create Table HoiVien
IF OBJECT_ID('dbo.HoiVien', 'U') IS NOT NULL
    DROP TABLE dbo.HoiVien;
GO

CREATE TABLE HoiVien (
    MaHV INT IDENTITY(1,1) CONSTRAINT PK_HoiVien PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    GioiTinh BIT NOT NULL, -- 1: Nam, 0: Nữ
    NgaySinh DATE NOT NULL,
    SDT VARCHAR(15) NULL,
    Email VARCHAR(100) NULL,
    HangThanhVien NVARCHAR(20) NOT NULL CONSTRAINT DF_HoiVien_HangThanhVien DEFAULT (N'Basic'), -- Basic / VIP / Premium
    NgayDangKy DATETIME NOT NULL CONSTRAINT DF_HoiVien_NgayDangKy DEFAULT (GETDATE()),
    TrangThai BIT NOT NULL CONSTRAINT DF_HoiVien_TrangThai DEFAULT (1) -- 1: Đang hoạt động, 0: Tạm ngưng
);
GO

-- Thêm một số dữ liệu mẫu (Seed Data) để kiểm thử
INSERT INTO HoiVien (HoTen, GioiTinh, NgaySinh, SDT, Email, HangThanhVien, TrangThai)
VALUES 
(N'Nguyễn Văn A', 1, '2000-05-15', '0901234567', 'nguyenvana@gmail.com', N'VIP', 1),
(N'Trần Thị B', 0, '1998-10-20', '0912345678', 'tranthib@gmail.com', N'Basic', 1),
(N'Lê Văn C', 1, '2005-01-10', '0987654321', 'levanc@gmail.com', N'Premium', 0);
GO
