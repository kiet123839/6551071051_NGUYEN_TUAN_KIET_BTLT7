CREATE DATABASE AnKhangClinic;
GO

USE AnKhangClinic;
GO

CREATE TABLE BacSi
(
    MaBS INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    ChuyenKhoa NVARCHAR(100),
    SDT VARCHAR(15)
);
GO

CREATE TABLE LichKham
(
    MaLich INT IDENTITY(1,1) PRIMARY KEY,
    TenBenhNhan NVARCHAR(100) NOT NULL,
    SDT VARCHAR(15),
    NgayKham DATE,
    GioKham TIME,
    MaBS INT NOT NULL,
    TrangThai NVARCHAR(20),

    CONSTRAINT FK_LichKham_BacSi
        FOREIGN KEY (MaBS)
        REFERENCES BacSi(MaBS)
);
GO


INSERT INTO BacSi(HoTen, ChuyenKhoa, SDT)
VALUES
(N'Nguyễn Văn A', N'Nội tổng quát', '0901234567'),
(N'Nguyễn Văn B', N'Nội tổng quát', '0912345678'),
(N'Nguyễn Văn C', N'Nội tổng quát', '0923456789'),
(N'Nguyễn Văn D', N'Nội tổng quát', '0934567890');