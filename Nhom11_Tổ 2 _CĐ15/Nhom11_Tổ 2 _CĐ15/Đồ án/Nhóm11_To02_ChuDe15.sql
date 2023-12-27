CREATE DATABASE QLKTX--Tạo CSDL --chạy rồi

USE QLKTX -- Sử dụng -- chạy rồi

CREATE TABLE SinhVien
(
    MaSV CHAR(9) PRIMARY KEY,
    MaNguoiThan INT,
    MaPhong CHAR(4),
    HoTen NVARCHAR(50),
    GioiTinh NVARCHAR(3) CHECK (GioiTinh IN (N'Nam', N'Nữ')),
    NgaySinh DATE,
    SoDienThoai VARCHAR(12), 
    Email VARCHAR(100) CHECK (Email LIKE '%_@__%.__%') UNIQUE NOT NULL,
    DiaChi NVARCHAR(100) 
);

-- Thêm khoá ngoại
ALTER TABLE SinhVien ADD CONSTRAINT fk_SinhVien_NguoiThan FOREIGN KEY (MaNguoiThan) REFERENCES NguoiThan(MaNguoiThan);
ALTER TABLE SinhVien ADD CONSTRAINT fk_SinhVien_Phong FOREIGN KEY (MaPhong) REFERENCES Phong(MaPhong);
-- Xoá khoá ngoại
ALTER TABLE SinhVien DROP CONSTRAINT fk_SinhVien_Phong 
-- Xoá cột
ALTER TABLE SinhVien DROP COLUMN SoDienThoai 

-- Thêm cột
ALTER TABLE SinhVien ADD SoDienThoai CHAR(11)
ALTER TABLE SinhVien ADD MaPhong CHAR(4)

CREATE TABLE NguoiThan
(
    MaNguoiThan INT PRIMARY KEY,
    MaSV CHAR(9),
    HoTenNguoiThan NVARCHAR(50),
    GioiTinh NVARCHAR(3) CHECK (GioiTinh IN (N'Nam', N'Nữ')),
    NgaySinh DATE,
    DiaChi NVARCHAR(100),
    SoDienThoai CHAR(11), -- Kiểu dữ liệu đã được thay đổi
    Email VARCHAR(100) CHECK (Email LIKE '%_@__%.__%') UNIQUE NOT NULL
);

-- Thêm khoá ngoại
ALTER TABLE NguoiThan ADD CONSTRAINT fk_NguoiThan_SinhVien FOREIGN KEY (MaSV) REFERENCES SinhVien(MaSV);
-- Xoá khoá ngoại
ALTER TABLE NguoiThan DROP CONSTRAINT fk_NguoiThan_SinhVien
-- Xoá cột
ALTER TABLE NguoiThan DROP COLUMN NgaySinh 
ALTER TABLE NguoiThan DROP COLUMN MaSV
-- Thêm cột
ALTER TABLE NguoiThan ADD NgaySinh DATE 
ALTER TABLE NguoiThan ADD MaSV CHAR(9)

CREATE TABLE NhanVien
(
    MaNV CHAR(5) PRIMARY KEY,
    HoTen NVARCHAR(50),
    GioiTinh NVARCHAR(3) CHECK (GioiTinh IN (N'Nam', N'Nữ')),
    QueQuan NVARCHAR(50),
    SDT VARCHAR(12), -- Kiểu dữ liệu đã được thay đổi
    Email VARCHAR(100) CHECK (Email LIKE '%_@__%.__%') UNIQUE NOT NULL,
    ChucVu NVARCHAR(50)
);
-- Xoá cột
ALTER TABLE NhanVien DROP COLUMN SDT
ALTER TABLE NhanVien DROP COLUMN TrangThai
-- Thêm cột
ALTER TABLE NhanVien ADD SDT CHAR(11)
ALTER TABLE NhanVien ADD NgaySinh Date
ALTER TABLE NHANVIEN ADD TrangThai NVARCHAR(7)
CREATE TABLE Phong
(
    MaPhong CHAR(4) PRIMARY KEY,
    Tang INT,
    SucChua INT CHECK (SucChua IN(4, 6)), -- Sức chứa 4/6
    LoaiPhong NVARCHAR(10) CHECK (LoaiPhong IN (N'Máy lạnh', N'Quạt')), 
    TrangThaiPhong NVARCHAR (10) CHECK (TrangThaiPhong IN (N'Đầy', N'Chưa Đầy'))
);

CREATE TABLE HopDong
(
    MaHopDong CHAR(6) PRIMARY KEY,
    MaNV CHAR(5),
    MaSV CHAR(9),
    MaPhong CHAR(4),
    NgayNhanPhong DATE,
    NgayTraPhong DATE,
);
--Thêm khoá ngoại
ALTER TABLE HopDong ADD CONSTRAINT fk_HopDong_NhanVien FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
ALTER TABLE HopDong ADD CONSTRAINT fk_HopDong_SinhVien FOREIGN KEY (MaSV) REFERENCES SinhVien(MaSV)
ALTER TABLE HopDong ADD CONSTRAINT fk_HopDong_Phong FOREIGN KEY (MaPhong) REFERENCES Phong(MaPhong)

CREATE TABLE DienNuoc
(
    MaDienNuoc INT PRIMARY KEY NOT NULL,
    TenDichVu VARCHAR(10),
    ChiSoDau_Dien INT,
    ChiSoDau_Nuoc INT,
    ChiSoCuoi_Dien INT,
    ChiSoCuoi_Nuoc INT,
    NgayBatDau DATE,
    NgayKetThuc DATE,
);
-- Xoá cột
ALTER TABLE DienNuoc DROP COLUMN TenDichVu 

CREATE TABLE HoaDon
(
    MaHoaDon INT PRIMARY KEY,
    MaHopDong CHAR(6),
    MaDienNuoc INT NOT NULL,
    TongTienDien DECIMAL(10, 2),
    TongTienNuoc DECIMAL(10, 2)
);
ALTER TABLE HoaDon ADD CONSTRAINT fk_HoaDon_DienNuoc FOREIGN KEY (MaDienNuoc) REFERENCES DienNuoc(MaDienNuoc)
ALTER TABLE HoaDon ADD CONSTRAINT fk_HoaDon_HopDong FOREIGN KEY (MaHopDong) REFERENCES HopDong(MaHopDong)
-- Thêm cột
ALTER TABLE HoaDon ADD ThangNamTToan DATE
select * from sinhvien
delete from sinhvien where masv = 'DTH215001'
SELECT * FROM HopDong
select * from nhanvien
update SinhVien
set MaNguoiThan = , HoTen = N'Nguyễn Văn Anh', GioiTinh = N'Nam', Email = 'A001@gmail.com', DiaChi = N'Long Xuyên', SoDienThoai = '0123456789', MaPhong = 'P001'
where MaSV='dth215001'

select * from NhanVien