CREATE DATABASE TriThucBooks;
GO

USE TriThucBooks;
GO

CREATE TABLE TheLoaiSach
(
    MaTL INT IDENTITY(1,1) PRIMARY KEY,
    TenTheLoai NVARCHAR(100) NOT NULL,
    MoTa NVARCHAR(255) NULL,
    SoLuongSach INT NOT NULL DEFAULT 0,
    NgayTao DATETIME NOT NULL DEFAULT GETDATE(),

    CONSTRAINT UQ_TheLoaiSach_TenTheLoai UNIQUE (TenTheLoai),
    CONSTRAINT CK_TheLoaiSach_SoLuongSach CHECK (SoLuongSach >= 0)
);
GO

INSERT INTO TheLoaiSach (TenTheLoai, MoTa, SoLuongSach)
VALUES
(N'Tiểu thuyết', N'Thể loại tiểu thuyết', 1),
(N'Kỹ năng sống', N'Kỹ năng sống nâng sống', 15),
(N'Thiếu nhi', N'Thiếu nhi cuốn', 2),
(N'Sách giáo khoa', N'Sách giáo khoa chỉ đường phổ hội vào tạo', 2),
(N'Truyện tranh', N'Truyện tranh', 1);
GO

SELECT * FROM TheLoaiSach;