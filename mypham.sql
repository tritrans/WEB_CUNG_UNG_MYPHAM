CREATE DATABASE CosmeticsShop;
USE CosmeticsShop;

CREATE TABLE VAITRO ( --Roles
    MAVAITRO CHAR(10) PRIMARY KEY,
    TENVAITRO NVARCHAR(20) NOT NULL
);
INSERT INTO VAITRO (MAVAITRO, TENVAITRO) VALUES
('1', N'Admin'),
('2', N'Customer');

CREATE TABLE NGUOIDUNG (--Users
    MANGUOIDUNG CHAR(10) PRIMARY KEY,
    TENNGUOIDUNG NVARCHAR(30) NOT NULL,
    EMAIL NVARCHAR(50) NOT NULL,
    MATKHAU NVARCHAR(8) NOT NULL,
    DIACHI NVARCHAR(50),
    SDT NVARCHAR(MAX),
    HINHANH NVARCHAR(MAX)
);

INSERT INTO NGUOIDUNG (MANGUOIDUNG, EMAIL, MATKHAU, TENNGUOIDUNG, DIACHI, SDT, HINHANH) VALUES
('2', N'huynhthevinh1608@gmail.com', '12345678', N'Vinh Huỳnh', NULL, NULL, N'af69bbb3-f863-4766-a9f9-e13ae643058c.jpg'),
('3', N'vin@gmail.com', '1234566', N'MiChan', NULL, NULL, NULL),
('4', N'huynhthevinh.work@gmail.com', '123456', N'MiMi', NULL, NULL, NULL),
('5', N'huynhthevinh.work@gmail.com', '123456', N'MiMi', NULL, NULL, NULL),
('6', N'mai1121@gmail.com', '123', N'Mai', NULL, NULL, NULL),
('7', N'tritranminh484@gmail.com', '123456', N'Tri', NULL, NULL, N'AdminDefaultAvatar.png'),
('8', N'thunguyen@gmail.com', '12345678', N'ThuThu', NULL, NULL, NULL),
('9', N'thunguyen@gmail.com', '12345678', N'ThuThu', NULL, NULL, NULL),
('10', N'maianhdao@gmail.com', '12345678', N'MaiAnh', NULL, NULL, NULL),
('11', N'anhtuthu@gmail.com', '12345678', N'TuThu', NULL, NULL, NULL),
('12', N'vermon1608@gmail.com', '123456', N'Vermon', NULL, NULL, NULL);

CREATE TABLE DONHANG ( -- Orders
    MADONHANG CHAR(10) PRIMARY KEY,
    MANGUOIDUNG CHAR(10),
    TRANGTHAI NVARCHAR(30),
    TONGTHANHTOAN DECIMAL(10, 3),
    NGAYDATHANG DATE,
    NGAYNHANHANG DATE,
    GIONHANHANG NVARCHAR(20),
    GHICHU NVARCHAR(50),
    PHIVANCHUYEN DECIMAL(10, 3)
);
INSERT INTO DONHANG (MADONHANG, MANGUOIDUNG, TRANGTHAI, TONGTHANHTOAN, NGAYDATHANG, NGAYNHANHANG, GIONHANHANG, GHICHU, PHIVANCHUYEN) 
VALUES
('13', '2', N'Đã hủy', 359.000, '2023-10-27', '2023-10-28', N'9h - 10h', N'Giao đúng giờ giùm', 30.000),
('14', '2', N'Hoàn thành', 2237.000, '2023-10-29', '2023-10-31', N'10h - 12h', NULL, 0.000),
('17', '2', N'Đã hủy', 688.000, '2023-10-29', '2023-10-30', N'9h - 10h', NULL, 30.000),
('18', '2', N'Đang chờ', 2875.000, '2024-09-25', '2024-09-27', N'9h - 10h', NULL, 30.000),
('19', '2', N'Đang chờ', 2875.000, '2024-09-25', '2024-09-27', N'9h - 10h', NULL, 30.000),
('20', '2', N'Đang chờ', 2875.000, '2024-09-25', '2024-09-27', N'9h - 10h', NULL, 30.000),
('21', '2', N'Đang chờ', 2875.000, '2024-09-25', '2024-09-27', N'9h - 10h', NULL, 30.000),
('22', '2', N'Đang chờ', 2875.000, '2024-09-25', '2024-09-27', N'9h - 10h', NULL, 30.000),
('23', '2', N'Đã hủy', 2875.000, '2024-09-25', '2024-09-27', N'9h - 10h', NULL, 30.000);

CREATE TABLE CHITIETDONHANG (-- OrderDetails
    MA CHAR(10) PRIMARY KEY,
    MADONHANG CHAR(10),
    MASANPHAM CHAR(10),
    SOLUONG INT,
    DONGIA DECIMAL(10, 3)
);
INSERT INTO CHITIETDONHANG (MA, MADONHANG, MASANPHAM, SOLUONG, DONGIA) VALUES
('11', '13', '3', 1, 329.000),
('12', '14', '7', 2, 329.000),
('13', '14', '2', 1, 1579.000),
('18', '17', '3', 1, 329.000),
('19', '17', '7', 1, 329.000),
('20', '18', '30', 5, 569.000),
('21', '19', '30', 5, 569.000),
('22', '20', '30', 5, 569.000),
('23', '21', '30', 5, 569.000),
('24', '22', '30', 5, 569.000),
('25', '23', '30', 5, 569.000);

CREATE TABLE VANCHUYEN ( -- ShippingOrders
    MAVANCHUYEN CHAR(10) PRIMARY KEY,
    MADONHANG CHAR(10),
    SDT NVARCHAR(50),
    DIACHI NVARCHAR(50),
    THANHPHO NVARCHAR(50),
    QUANHUYEN NVARCHAR(50),
    PHUONGXA NVARCHAR(50),
    HOTENNGUOINHAN NVARCHAR(50)
);

INSERT INTO VANCHUYEN (MAVANCHUYEN, MADONHANG, SDT, DIACHI, THANHPHO, QUANHUYEN, PHUONGXA, HOTENNGUOINHAN) VALUES
('4', '13', N'0933693264', N'111/21/1D Lũy Bán Bích', N'Thành phố Hà Nội', N'Quận Hai Bà Trưng', N'Phường Quỳnh Mai', N'Vinh Huỳnh'),
('5', '14', N'0913121021', N'11 Lê Trọng Tấn', N'Thành phố Hồ Chí Minh', N'Quận Tân Phú', N'Phường Tây Thạnh', N'Huỳnh Mỹ Duyên'),
('8', '17', N'0933693264', N'10 Hai Bà Trưng', N'Thành phố Hà Nội', N'Huyện Thường Tín', N'Xã Nguyễn Trãi', N'Cao Xuân Thùy'),
('9', '18', N'02332947', N'140 Lê Trọng Tấn', N'Thành phố Hà Nội', N'Quận Thanh Xuân', N'Phường Thượng Đình', N'Trần Văn Anh'),
('10', '19', N'02332947', N'140 Lê Trọng Tấn', N'Thành phố Hà Nội', N'Quận Thanh Xuân', N'Phường Thượng Đình', N'Trần Văn Anh'),
('11', '20', N'02332947', N'140 Lê Trọng Tấn', N'Thành phố Hà Nội', N'Quận Thanh Xuân', N'Phường Thượng Đình', N'Trần Văn Anh'),
('12', '21', N'02332947', N'140 Lê Trọng Tấn', N'Thành phố Hà Nội', N'Quận Thanh Xuân', N'Phường Thượng Đình', N'Trần Văn Anh'),
('13', '22', N'02332947', N'140 Lê Trọng Tấn', N'Thành phố Hà Nội', N'Quận Thanh Xuân', N'Phường Thượng Đình', N'Trần Văn Anh'),
('14', '23', N'02332947', N'140 Lê Trọng Tấn', N'Thành phố Hà Nội', N'Quận Thanh Xuân', N'Phường Thượng Đình', N'Trần Văn Anh');


CREATE TABLE SANPHAM (--Products
    MASANPHAM CHAR(10) PRIMARY KEY,
    MANHACUNGCAP CHAR(10),
    TENSANPHAM NVARCHAR(50),
    GIA DECIMAL(10, 3),
    SOLUONG INT,
    TRANGTHAI NVARCHAR(50),
    MOTA NVARCHAR(MAX),
    HINHANH NVARCHAR(MAX)
);
insert into SANPHAM(MASANPHAM,MANHACUNGCAP,TENSANPHAM,GIA,SOLUONG,TRANGTHAI,MOTA,HINHANH) values
('2','1',N'Sữa Rửa Mặt Simple ',300000,100,N'Còn',N'Với công thức dịu nhẹ không chứa xà phòng cùng thành phần Pro-Vitamin B5 và Vitamin E, sản phẩm giúp làm sạch da hiệu quả, cuốn đi chất nhờn, bụi bẩn và các tạp chất khác mà không gây kích ứng, cho da mềm mịn, đồng thời mang lại cảm giác tươi mát và sạch thoáng cho da.',N'gel-rua-mat-danh-cho-da-nhay-cam-simple-150ml.png'),
('3','2',N'Sữa Rửa Mặt CeraVe ',350000,100,N'Còn',N'Với sự kết hợp của ba Ceramides thiết yếu, Hyaluronic Acid sản phẩm giúp làm sạch và giữ ẩm cho làn da mà không ảnh hưởng đến hàng rào bảo vệ da mặt và cơ thể.',N'sua-rua-mat-cerave-tao-bot-cho-da-thuong-den-da-dau-88ml.png'),
('7','1',N'Nước Tẩy Trang LOreal ',165000,100,N'Còn',N'được ứng dụng công nghệ Micellar dịu nhẹ giúp làm sạch da, lấy đi bụi bẩn, dầu thừa và cặn trang điểm chỉ trong một bước, mang lại làn da thông thoáng, mềm mượt mà không hề khô căng.',N'nuoc-tay-trang-400.png'),
('11','2',N'DUNG DỊCH DƯỠNG ẨM ',435000,100,N'Còn',N'Với công thức chuyên biệt 5% Vitamin B5,  serum B5 đến từ thương hiệu Acnes tăng cường dưỡng ẩm, dưỡng da trông căng mịn; làm dịu da khô ráp; giúp cải thiện hàng rào độ ẩm và độ đàn hồi của da; giúp ngăn ngừa các dấu hiệu lão hóa da, hỗ trợ làm mờ nếp nhăn và cải thiện vùng da kém mịn màng, xỉn màu.',N'ACNES-LAB-B5-RECOVER-25ML.png'),
('12','1',N'Tera20S Mặt Nạ Giấy Bạc ',50000,100,N'Còn',N'Mặt nạ dưỡng da đến từ thương hiệu Tera20S có chứa các thành phần như chiết xuất chanh, panthenol, giúp cung cấp độ ẩm và dưỡng chất phong phú cho làn da bị thô ráp, cho da ẩm và mịn màng','Tera20S-Mat-Na-Giay-BacB5.jpg'),
('13','2',N'Son Thỏi Lì 3CE Vỏ Trong Suốt ',254000,100,N'Còn',N'sản phẩm son môi đến từ thương hiệu mỹ phẩm 3CE của Hàn Quốc, kết cấu son mềm mại và nhẹ môi cùng sắc tố cao giúp lên màu chuẩn sắc ngay từ lần đầu tiên. Sản phẩm với thiết kế vỏ trong suốt độc đáo, lạ mắt và ấn tượng giúp bạn quan sát được màu son bên trong.',N'son-thoi-li-3ce-vo-trong-suot-focus-on-me-do-san-ho-3-5g.jpg'),
('14','1',N'Son Mịn Lì B.O.M ',279000,100,N'Còn',N'sản phẩm son thỏi đến từ thương hiệu B.O.M - Hàn Quốc. Sản phẩm là DÒNG SON THUẦN CHAY có chất son lì, mềm mịn và mượt, tạo cảm giác “NHẸ TÊNH” trên môi, đem đến sự thoải mái & tự tin cho nàng.',N'son-min-li-b-o-m-03-bright-rose-do-tuoi-3-3g.jpg'),
('15','2',N'Son Môi Naris Cosmetics ',735000,100,N'Còn',N'Naris Cosmetic Coeor phiên bản mới có thiết kế sang trọng với lớp vỏ bóng có tông màu tinh tế được làm từ nhựa cứng, bên trong là một chất son vô cùng mềm mại và mịn màng.',N'Coeor Lipstick B02.jpg'),
('16','1',N'Kem Nền B.O.M Che Phủ ',480000,100,N'Còn',N'sản phẩm trang điểm đến từ thương hiệu B.O.M - Hàn Quốc. Sản phẩm với kết cấu mỏng mịn cùng độ che phủ cao cho bạn một lớp nền trang điểm bền màu, lâu trôi lên đến 24h.',N'kem-nen-b-o-m-che-phu-cao-lau-troi-21-rosy-beige-30ml.png'),
('17','2',N'Kem Nền Silkygirl Skin Perfect ',178000,100,N'Còn',N'với công thức cải tiến và bao bì bắt mắt phù hợp xu hướng, hứa hẹn sẽ là sản phẩm trang điểm nền hoàn hảo đáp ứng nhu cầu của giới trẻ hiện đại.',N'kem-nen-silkygirl-skin-perfect-02-natural-mau-tu-nhien-25ml.png'),
('18','1',N'Kem Nền Estee Lauder ',1600000,100,N'Còn',N'Estee Lauder',N'kem-nen-estee-lauder-lau-troi-1w1-bone-30mlx2.jpg'),
('19','2',N'Kem Nền Australis ',300000,100,N'Còn',N' dòng kem nền đến từ thương hiệu mỹ phẩm Australis của Úc, với thành phần thuần thực vật chứa vitamin C, E hỗ trợ kiểm soát dầu thừa và hỗ trợ nuôi dưỡng và bảo vệ da với chỉ số chống nắng SPF 15, che phủ khuyết điểm tối ưu mang lại lớp nền như ý.',N'kem-nen-australis-sieu-nhe-tong-hong-kem-honeydew-30ml.jpg'),
('20','1',N'Phấn Phủ innisfree ',152000,100,N'Còn',N'sản phẩm phấn phủ đến từ thương hiệu mỹ phẩm innisfree của Hàn Quốc với chiết xuất từ bạc hà và khoáng chất tự nhiên Jeju, kiềm dầu đồng thời tạo độ che phủ tự nhiên cho lớp nền khô thoáng.',N'phan-phu-innisfree-kiem-dau-dang-bot-khoang-5g.png'),
('21','2',N'Phấn Phủ Maybelline ',150000,100,N'Còn',N'sản phẩm phấn phủ nổi tiếng của thương hiệu Maybelline New York, nay đã chính thức ra mắt công thức mới giúp kiềm dầu hiệu quả lên đến 16H và cho cảm giác mềm mượt hơn. Chất phấn mịn lì, dễ tán, tiệp hoàn toàn vào da, cùng chỉ số SPF 32 PA+++ giúp bảo vệ da tối ưu dưới ánh nắng.',N'phan-nen-kiem-dau-maybelline-spf28-pa.jpg'),
('22','1',N'Phấn Phủ Perfect Diary ',198000,100,N'Còn',N'sản phẩm phấn phủ dạng bột mịn, có công thức độc đáo của thương hiệu Perfect Diary - Trung Quốc. Phấn giúp kiềm dầu trên da, che phủ lỗ chân lông và sẹo rỗ, nâng tone nhẹ tự nhiên và bền màu suốt cả ngày. Sản phẩm này còn có thành phần an toàn cho da, không gây kích ứng hay bí da.',N'phan-phu-perfect-diary-kiem-dau-ngan-tham-nuoc-mau-01-7.jpg'),
('23','2',N'Phấn Phủ Carslan ',430000,100,N'Còn',N'sản phẩm phấn phủ đến từ thương hiệu Carslan - Trung Quốc. Sản phẩm với công thức đáng tin cây, tinh chất kiểm soát dầu thông minh EPS của Pháp có thể chống dầu và nước trong mồ hôi khóa lớp nền không bị dịch chuyển!',N'phan-phu-carslan-dang-bot-nap-xam-mau-trong-suot-8g.png'),
('24','1',N'Chì Kẻ Chân Mày ',87000,100,N'Còn',N'sản phẩm chì kẻ mày đến từ thương hiệu mỹ phẩm Innisfree của Hàn Quốc, với đầu oval dễ kẻ, tạo nên hàng lông mày sắc nét và tinh tế. Chì kẻ nổi tiếng với thiết kế thông minh và bảng màu tự nhiên, phù hợp cho cả người mới bắt đầu đến chuyên viên trang điểm.',N'chi-ke-chan-may-innisfree-mau-4-ash-brown-moi-03g.png'),
('25','2',N'Chì Kẻ Mày Xé Suri ',28000,100,N'Còn',N' sản phẩm kẻ chân mày đến từ thương hiệu mỹ phẩm Suri của Hàn Quốc, với chất chì mềm mại, dễ sử dụng cho bạn định hình đôi chân mày ấn tượng, quyến rũ nhưng vẫn không kém phần tự nhiên.',N'chi-ke-may-xe-suri-102-brown-mau-nau-e271.jpg'),
('26','1',N'Chì Kẻ Mày Cathy ',65000,100,N'Còn',N'dòng sản phẩm chì kẻ mày siêu mảnh đến từ thương hiệu mỹ phẩm CATHY DOLL của Thái Lan, với đầu chì siêu nhỏ, đặc biệt chỉ 1.5mm, chất chì chất lượng, kẻ siêu dễ, không lem không trôi bền màu cả ngày, có đầu cọ chải mày đi kèm cho hàng chân mày đẹp tự nhiên.',N'chi-ke-may-sieu-manh-cathy-doll-06-coffee-brown-0-05g.jpg'),
('27','2',N'Chì Kẻ Chân Mày Silkygirl ',120000,100,N'Còn',N'sản phẩm kẻ chân mày đến từ thương hiệu mỹ phẩm Silkygirl của Malaysia, đầu chì cứng cáp nhỏ nhọn, chất chì mềm mịn thỏa sức tán đều với đầu chổi đi kèm.',N'chi-ke-chan-may-silkygirl-kem-choi-mau-nau-02-dark-brown.png'),
('28','1',N'Mascara Maybelline ',182000,100,N'Còn',N' sản phẩm mascara đến từ thương hiệu mỹ phẩm Maybelline của Mỹ, với công thức không thấm nước và mang lại hàng mi cong vút từ mọi góc độ, tạo độ dài và dày mi vô cùng cuốn hút.',N'mascara-maybelline-lam-dai-va-day-mi-mau-very-black-6ml.png'),
('29','2',N'Chuốt Mi Browit ',99000,100,N'Còn',N' sản phẩm mascara đến từ thương hiệu mỹ phẩm Browit của Thái Lan, với thiết kế đặc biệt đầu chải lược giúp len lỏi và chải từng sợi mi giúp đôi mi dài và cong vút tự nhiên cả ngày.',N'chuot-mi-browit-keo-dai-va-cong-mi-dang-dau-luoc-5-5g.jpg'),
('30','1',N'Mascara Australis ',186000,100,N'Còn',N'sản phẩm mascara đến từ thương hiệu mỹ phẩm Australis của Úc. Đây là một sản phẩm 2 trong 1 có tác dụng định hình chân mày và kéo dài sợi mi, với dạng gel trong suốt không màu nhưng vẫn mang lại sự khác biệt cho hàng mi và dáng mày, giúp cho đôi mắt của bạn thêm sắc sảo, hút hồn người đối diện.',N'mascara-trong-suot-2-trong-1-australis.jpg'),
('31','2',N'Nước Hoa Nữ Armaf Club De Nuit Woman EDP 105ml',650000,100,N'Còn',N'Nước hoa với sự kết hợp của các thành phần tự nhiên từ trái cây, hoa và các nốt hương gỗ ấm áp, tạo nên một sự hòa quyện tinh tế và nữ tính lý tưởng cho phụ nữ tự tin và yêu thích sự tươi mới. Mùi hương này thích hợp cho cả ngày lẫn đêm, phù hợp với nhiều dịp khác nhau từ công sở đến những bữa tiệc trang trọng.',N'nuoc-hoa-nu-armaf-club-de-nuit-woman-105ml.jpg'),
('32','1',N'Nước Hoa Nữ De Memoria EDP #05 Montpellier 30ml',354000,100,N'Còn',N'dòng nước hoa nữ đến từ thương hiệu De Memoria của Hàn Quốc, nằm trong bộ sưu tập Ký Ức Đầu Tiên với mùi hương tinh tế, độc đáo lấy cảm hứng từ những thị trấn thơm hương tại Châu Âu. Thiết kế lọ thuỷ tinh sang trọng với đường nét bo tròn mềm mại, nhỏ nhắn tiện lợi mang theo bất cứ đâu.',N'Nước Hoa Nữ De Memoria EDP.png'),
('33','2',N'Nước Hoa Nữ Gennie Little',260000,100,N'Còn',N'sản phẩm nước hoa nữ đến từ thương hiệu nước hoa Gennie của Singapore, tuyệt phẩm hương thơm từ nhà chế tác hàng đầu thế giới Givaudan, Little Rose Dress mang lại hương thơm vô cùng nữ tính, ngọt ngào, điệu đà, nhưng cũng đầy phá cách, cá tính và thời thượng.',N'nuoc-hoa-nu-gennie-little-rose-dress-ban-gioi-han-50ml.png'),
('35','1',N'Nước Hoa Nữ Narciso Rodriguez ',1690000,100,N'Còn',N'Nước hoa mang phong cách nữ tính, thanh lịch và gợi cảm lý tưởng cho những phụ nữ yêu thích sự tối giản nhưng tinh tế. Mùi hương của Narciso Rodriguez For Her EDT là một sự kết hợp hoàn hảo giữa sự tươi mát, ngọt ngào và sự ấm áp, quyến rũ. Mở ra với hương hoa cam và hoa mộc tê nhẹ nhàng, thanh khiết.',N'nuoc-hoa-nu-narciso-rodriguez-for-her-edt-50ml.jpg'),
('36','2',N'Kem Chống Nắng La Roche-Posay',356000,100,N'Còn',N' kem chống nắng dành cho da dầu phiên bản công thức cải tiến mới đến từ thương hiệu dược mỹ phẩm La Roche-Posay, giúp kiểm soát bóng nhờn và bảo vệ da trước tác hại từ ánh nắng & ô nhiễm, ngăn chặn các tác nhân gây lão hóa sớm.',N'kem-chong-nang-la-roche-posay-kiem-soat-dau-spf50-50ml.png'),
('37','1',N'Kem Chống Nắng MartiDerm Phổ',550000,100,N'Còn',N' Sản phẩm cung cấp màng lọc chống nắng phổ rộng chống lại các tia UVA, UVB, IR (hồng ngoại), HEV (ánh sáng xanh).','kem-chong-nang-martiderm-pho-rong-toan-dien-spf50-40ml.jpg'),
('38','2',N'Son Dior 284',1699000,100,N'Còn',N'Với thiết kế vàng hồng sang trọng và chất son lì mịn, thỏi son này không chỉ là một món đồ trang điểm mà còn là một phụ kiện thời trang đẳng cấp.','dior_284_rose_bavarde_velvet_limited-edition_golden_case.jpg'),
('39',1,N'Mascara Silkygirl',99000,100,N'Còn',N'Đây là một trong 3 loại mascara được yêu thích nhất của hãng Silkygirl, với Collagen nuôi dưỡng mi và công thức đặc biệt chứa các loại thành phần tự nhiên cho màu lên cực thật','mascara-silkygirl-big-eye-lam-dai-va-cong-mi-18ml.jpg'),
('40',2,N'Mặt Nạ Đen Sexylook',140000,100,N'Còn',N'Collagen, 3 Peptide, ngọc trai đen thúc đẩy quá trình tạo da, sản sinh Collagen khiến làn da trở nên săn chắc, tăng cường độ đàn hồi, phục hồi da khỏe mạnh.','mat-na-den-sexylook-kiem-soat-dau-ngua-mun-28ml.jpg'),
('41',1,N'Mặt Nạ Sur.Medic+',25000,100,N'Còn',N'dòng mặt nạ tinh chất Glutathione dưỡng sáng da từ thương hiệu mỹ phẩm Sur.Medic+ của Hàn Quốc, nay chính thức ra mắt phiên bản nâng cấp hoàn toàn mới','SurMedic.jpg'),
('42',2,N'Mặt Nạ Wonjin',22000,100,N'Còn',N'sản phẩm mặt nạ đến từ thương hiệu Wonjin - Hàn Quốc. Sản phẩm là dòng mặt nạ cao cấp đến từ thẩm mỹ viện Wonjin nổi tiếng của Hàn Quốc nghiên cứu và phát triển.','Wonjin.jpg');


CREATE TABLE GIOHANG ( --CartItems
    MA CHAR(10) PRIMARY KEY,
    MANGUOIDUNG CHAR(10),
    MASANPHAM CHAR(10),
    SOLUONG INT
);

CREATE TABLE DANHMUCSANPHAM ( --ProductCategories
    MADANHMUC CHAR(10) NOT NULL,
    MASANPHAM CHAR(10) NOT NULL,
    PRIMARY KEY (MADANHMUC, MASANPHAM)
);
INSERT INTO DANHMUCSANPHAM (MADANHMUC, MASANPHAM) VALUES
('8', '2'),
('8', '3'),
('10', '7'),
('6', '11'),
('11', '12'),
('1', '13'),
('1', '14'),
('1', '15'),
('2', '16'),
('2', '17'),
('2', '18'),
('2', '19'),
('3', '20'),
('3', '21'),
('3', '22'),
('3', '23'),
('4', '24'),
('4', '25'),
('4', '26'),
('4', '27'),
('5', '28'),
('5', '29'),
('5', '30'),
('7', '31'),
('7', '32'),
('7', '33'),
('7', '35'),
('9', '36'),
('9', '37'),
('1','38'),
('5','39'),
('11','40'),
('11','41'),
('11','42');
CREATE TABLE DANHMUC (--Categories
    MADANHMUC CHAR(10) PRIMARY KEY,
    TENDANHMUC NVARCHAR(50)
);
INSERT INTO DANHMUC (MADANHMUC, TENDANHMUC) VALUES
('1', N'Son môi'),
('2', N'Kem nền'),
('3', N'Phấn phủ'),
('4', N'Chì kẻ mày'),
('5', N'Mascara'),
('6', N'Kem dưỡng da'),
('7', N'Nước hoa'),
('8', N'Sữa rửa mặt'),
('9', N'Kem chống nắng'),
('10', N'Nước tẩy trang'),
('11', N'Mặt nạ');

CREATE TABLE GIAMGIASANPHAM (--DiscountProducts
    MASANPHAM CHAR(10) PRIMARY KEY,
    GiaGiam DECIMAL(10, 3)
);
INSERT INTO GIAMGIASANPHAM VALUES
('3', 329.000),
('7', 329.000),
('11', 329.000);
CREATE TABLE NHACUNGCAP (--Suppliers
    MANHACUNGCAP CHAR(10) PRIMARY KEY,
    TENNHACUNGCAP NVARCHAR(MAX),
    SDT VARCHAR(11),
    DIACHI NVARCHAR(60)
);
INSERT INTO NHACUNGCAP VALUES
('1', N'Nhà Cung Cấp A', '0931234567', N'123 Đường ABC, Quận 1, TP.HCM'),
('2', N'Nhà Cung Cấp B', '0912345678', N'456 Đường DEF, Quận 2, TP.HCM');



CREATE TABLE VAITRO_NGUOIDUNG (--UserRoles
    MANGUOIDUNG CHAR(10) NOT NULL,
    MAVAITRO CHAR(10) NOT NULL,
    PRIMARY KEY (MANGUOIDUNG, MAVAITRO)
);
INSERT INTO VAITRO_NGUOIDUNG VALUES
('2', '2'),
('3', '2'),
('7', '1'),
('11', '2'),
('12', '2');


ALTER TABLE VAITRO_NGUOIDUNG
ADD CONSTRAINT FK_VAITRO_NGUOIDUNG_NGUOIDUNG
FOREIGN KEY (MANGUOIDUNG) REFERENCES NGUOIDUNG(MANGUOIDUNG);

ALTER TABLE VAITRO_NGUOIDUNG
ADD CONSTRAINT FK_VAITRO_NGUOIDUNG_VAITRO
FOREIGN KEY (MAVAITRO) REFERENCES VAITRO(MAVAITRO);

ALTER TABLE DONHANG
ADD CONSTRAINT FK_DONHANG_NGUOIDUNG
FOREIGN KEY (MANGUOIDUNG) REFERENCES NGUOIDUNG(MANGUOIDUNG);

ALTER TABLE CHITIETDONHANG
ADD CONSTRAINT FK_CHITIETDONHANG_DONHANG
FOREIGN KEY (MADONHANG) REFERENCES DONHANG(MADONHANG);

ALTER TABLE CHITIETDONHANG
ADD CONSTRAINT FK_CHITIETDONHANG_SANPHAM
FOREIGN KEY (MASANPHAM) REFERENCES SANPHAM(MASANPHAM);

ALTER TABLE VANCHUYEN
ADD CONSTRAINT FK_VANCHUYEN_DONHANG
FOREIGN KEY (MADONHANG) REFERENCES DONHANG(MADONHANG);

ALTER TABLE SANPHAM
ADD CONSTRAINT FK_SANPHAM_NHACUNGCAP
FOREIGN KEY (MANHACUNGCAP) REFERENCES NHACUNGCAP(MANHACUNGCAP);

ALTER TABLE GIOHANG
ADD CONSTRAINT FK_GIOHANG_NGUOIDUNG
FOREIGN KEY (MANGUOIDUNG) REFERENCES NGUOIDUNG(MANGUOIDUNG);

ALTER TABLE GIOHANG
ADD CONSTRAINT FK_GIOHANG_SANPHAM
FOREIGN KEY (MASANPHAM) REFERENCES SANPHAM(MASANPHAM);

ALTER TABLE DANHMUCSANPHAM
ADD CONSTRAINT FK_DANHMUCSANPHAM_SANPHAM
FOREIGN KEY (MASANPHAM) REFERENCES SANPHAM(MASANPHAM);

ALTER TABLE DANHMUCSANPHAM
ADD CONSTRAINT FK_DANHMUCSANPHAM_DANHMUC
FOREIGN KEY (MADANHMUC) REFERENCES DANHMUC(MADANHMUC);

ALTER TABLE GIAMGIASANPHAM
ADD CONSTRAINT FK_GIAMGIASANPHAM_SANPHAM
FOREIGN KEY (MASANPHAM) REFERENCES SANPHAM(MASANPHAM);

