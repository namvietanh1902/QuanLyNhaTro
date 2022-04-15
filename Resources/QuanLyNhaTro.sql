create database QuanLyNhaTro;
use QuanLyNhaTro
create table KhachTro(
MaKhach char(5) primary key,
TenKhach nvarchar(40),
NgaySinh Date,
GioiTinh bit,
CMND char(10),
SDT char(10),
NgheNghiep nvarchar(30)
)
create table Account(
UserID int identity,
Username varchar(30) primary key,
Pass varchar(20),
PhanQuyen bit,
)
drop table Account
create table PhongTro(
MaPhong char(5) primary key,
SoNguoi int,
GiaPhong money
)
create table HopDongThuePhong(
MaKhach char(5) foreign key references KhachTro(MaKhach)
on delete cascade
on update cascade,
MaPhong char(5) foreign key references PhongTro(MaPhong)
on delete cascade
on update cascade,
TenKhach nvarchar(40),
NgayThue date,
constraint pk_thue_phong primary key(MaKhach,MaPhong)

)
drop table ThuePhong
create table HoaDon(
MaHD char(6) primary key,

MaPhong CHAR(5) foreign key references PhongTro(MaPhong) 
on delete cascade
on update cascade,
TienPhong money,
TienDichVu money
)
create table DichVu(
MaDV char(5) primary key,
TenDichVu nvarchar(20),
GiaTien Money,
)
drop table DichVu
create table ChiTietHoaDon(
MaHD char(6) foreign key references HoaDon(MaHD)
on delete cascade
on update cascade,
MaDV char(5) foreign key references DichVu(MaDV)
on delete cascade
on update cascade,
SoLuong int ,
constraint pk_ChiTiet primary key(MaHD,MaDV)
)