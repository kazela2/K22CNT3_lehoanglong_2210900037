use WebWuwa

Create Table Users
(
user_id int identity(1,1) primary key not null,
taikhoan varchar(50) not null UNIQUE,
matkhau varchar(100) not null,
email varchar(100) not null UNIQUE,
)
INSERT INTO Users
VALUES ( 'ADMIN', 'ADMIN', 'admin@gmail.com'),
( 'KAZEL', 'longlong', 'kazel@gmail.com');
 select * from Users

 Create Table Sukien
 (
 ev_id int identity(1,1) primary key,
 tieude varchar(255) not null,
 noidung Text not null
 )

INSERT INTO Sukien (tieude, noidung)
VALUES ('Su kien mua dong', 'Su kien mua dong dang dien ra voi nhieu phan thuong hap dan cho nguoi choi.'),
       ('Ra mat nhan vat moi CAMEL', 'Nhan vat moi voi suc manh dac biet se ra mat vao cuoi thang.');
select * from Sukien

Create table thamgia
(
tg_id int identity(1,1) primary key,
user_id int not null, 
ev_id int not null,
ngaythamgia DATE,
FOREIGN KEY (user_id) REFERENCES Users(user_id),
FOREIGN KEY (ev_id) REFERENCES Sukien(ev_id)
)

INSERT INTO thamgia (user_id, ev_id, ngaythamgia)
VALUES (1, 1, '2024-11-02'),
       (2, 2, '2024-11-01');
	   select * from thamgia


Create Table thongtinUser
(
tt_id int identity(1,1) primary key,
user_id int not null,
fullname varchar(100),
avatar varchar(255),
tieusu text,
FOREIGN KEY (user_id) REFERENCES Users(user_id)
)

INSERT INTO thongtinUser(user_id, fullname, avatar, tieusu)
VALUES 
(1, 'KAZEL', 'https://pin.it/z2VDdArHs', 'Mot nguoi yeu thich su kien va kham pha.'), 
(2, 'SORA', 'https://pin.it/5Fto2d1z5', 'nguoi dam me nghe thuat va sang tao.');

select * from thongtinUser


CREATE TABLE danhgia (
    dg_id INT identity(1,1) PRIMARY KEY,
    user_id INT NOT NULL,
    dg_value INT CHECK (dg_value >= 1 AND dg_value <= 5),
    ngaydg DATE NOT NULL,
    FOREIGN KEY (user_id) REFERENCES Users(user_id)
);
INSERT INTO danhgia (user_id, dg_value, ngaydg)
VALUES 
(1, 5, '2024-11-01'), 
(2, 5, '2024-11-01');
select * from danhgia