CREATE DATABASE SunriseHomestayDB;
GO

USE SunriseHomestayDB;
GO

CREATE TABLE LoaiPhong (
    MaLoai INT IDENTITY(1,1) PRIMARY KEY,
    TenLoai NVARCHAR(100) NOT NULL,
    GiaMoiDem DECIMAL(18,2) NULL,
    MoTa NVARCHAR(255) NULL
);
GO

CREATE TABLE Phong (
    MaPhong INT IDENTITY(1,1) PRIMARY KEY,
    SoPhong VARCHAR(10) NOT NULL,
    TangSo INT NULL,
    TinhTrang NVARCHAR(20) NULL,
    HinhAnh NVARCHAR(255) NULL,
    MaLoai INT NOT NULL,
    CONSTRAINT FK_Phong_LoaiPhong FOREIGN KEY (MaLoai) REFERENCES LoaiPhong(MaLoai) ON DELETE CASCADE
);
GO

INSERT INTO LoaiPhong (TenLoai, GiaMoiDem, MoTa) VALUES
(N'Phòng Đơn', 350000, N'1 giường đơn, tiện nghi cơ bản'),
(N'Phòng Đôi', 500000, N'1 giường đôi lớn, ban công'),
(N'Phòng VIP', 900000, N'Phòng khách riêng, view biển');

INSERT INTO Phong (SoPhong, TangSo, TinhTrang, HinhAnh, MaLoai) VALUES
('101', 1, N'Trống', '', 1),
('102', 1, N'Đang ở', '', 2),
('201', 2, N'Đang dọn', '', 3);
GO