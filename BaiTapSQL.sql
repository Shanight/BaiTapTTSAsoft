create database test6
use test6
create table KhachHang(
	IDKH nvarchar(50) primary key,
	NameKH nvarchar(50),
	Tel nvarchar(50),
	Email nvarchar(50)
)

create table DonHang(
	IDDH nvarchar(50) primary key,
	IDKH nvarchar(50),
	IDMH nvarchar(50),
	NgayMua date,
	ThangMua nvarchar(10),
	DayMua nvarchar(10)
)

create table MatHang(
	IDMH nvarchar(50) primary key,
	NameMH nvarchar(50),
	SoLuong int,
	ThanhTien int
)
ALTER TABLE DonHang
ADD CONSTRAINT FK_DonHang_KhachHang FOREIGN KEY (IDKH) REFERENCES KhachHang(IDKH);

ALTER TABLE DonHang
ADD CONSTRAINT FK_DonHang_MatHang FOREIGN KEY (IDMH) REFERENCES MatHang(IDMH);

select * from DonHang
select * from KhachHang
select * from MatHang
-- Tạo 100 khách hàng ngẫu nhiên
DECLARE @i INT = 1;
WHILE @i <= 100
BEGIN
    DECLARE @NameKH VARCHAR(50) = N'Khách hàng ' + CAST(@i AS VARCHAR);
    DECLARE @Tel VARCHAR(50) = '012345678' + CAST(@i AS VARCHAR);
    DECLARE @Email VARCHAR(50) = @NameKH + '@example.com';
    INSERT INTO KhachHang (IDKH, NameKH, Tel, Email)
    VALUES ('KH' + CAST(@i AS VARCHAR), @NameKH, @Tel, @Email);
    SET @i = @i + 1;
END;

-- Tạo 100 sản phẩm ngẫu nhiên
DECLARE @j INT = 1;
WHILE @j <= 100
BEGIN
    DECLARE @NameMH VARCHAR(50) = N'Item ' + CAST(@j AS VARCHAR);
    DECLARE @SoLuong INT = RAND() * 100; -- Số lượng ngẫu nhiên từ 0 đến 100
    DECLARE @ThanhTien INT = RAND() * 1000; -- Thanh tiền ngẫu nhiên từ 0 đến 1000
    INSERT INTO MatHang (IDMH, NameMH, SoLuong, ThanhTien)
    VALUES ('MH' + CAST(@j AS VARCHAR), @NameMH, @SoLuong, @ThanhTien);
    SET @j = @j + 1;
END;

-- Tạo 1000000 đơn hàng ngẫu nhiên
DECLARE @k INT = 1;
WHILE @k <= 1000000
BEGIN
    -- Chọn ngẫu nhiên ID khách hàng
    DECLARE @RandomCustomerID VARCHAR(50);
    SELECT TOP 1 @RandomCustomerID = IDKH FROM KhachHang ORDER BY NEWID();

    -- Chọn ngẫu nhiên ID sản phẩm
    DECLARE @RandomProductID VARCHAR(50);
    SELECT TOP 1 @RandomProductID = IDMH FROM MatHang ORDER BY NEWID();

    -- Chọn ngẫu nhiên ngày đặt hàng
    DECLARE @OrderDate DATETIME = DATEADD(day, RAND() * 60, '2024/7/1');

    INSERT INTO DonHang (IDDH, IDKH, IDMH, NgayMua,ThangMua,DayMua)
    VALUES ('DH' + CAST(@k AS VARCHAR), @RandomCustomerID, @RandomProductID, @OrderDate, MONTH(@OrderDate),DAY(@OrderDate));

    SET @k = @k + 1;
END;

SELECT IDDH, IDKH,IDMH,NgayMua FROM DonHang WHERE ThangMua='7';

--Tạo Index truy xuất theo tháng, năm ở Đơn Hàng
CREATE INDEX TableTheoThangNam ON DonHang(ThangMua,DayMua);
drop INDEX TableTheoThangNam on DonHang

-- Store procedure tìm danh sách đơn hàng theo điều kiện lọc
alter PROCEDURE locdanhsach
    @MaDonHang VARCHAR(50) = NULL,
    @MaKhachHang VARCHAR(50) = NULL,
    @TenKhachHang VARCHAR(50) = NULL,
    @MaMatHang VARCHAR(50) = NULL,
    @TenMatHang VARCHAR(50) = NULL,
    @TuNgay datetime = NULL,
    @DenNgay datetime = NULL
AS
BEGIN
    SELECT o.IDDH, c.IDKH, c.NameKH, p.IDMH, p.NameMH, o.NgayMua
    FROM DonHang o
    INNER JOIN KhachHang c ON o.IDKH = c.IDKH
    INNER JOIN MatHang p ON o.IDMH = p.IDMH
    WHERE (o.IDDH LIKE '%' + ISNULL(@MaDonHang, '') + '%')
	  AND (c.IDKH LIKE '%' + ISNULL(@MaKhachHang, '') + '%')
	  AND (c.NameKH LIKE '%' + ISNULL(@TenKhachHang, '') + '%')
	  AND (p.IDMH LIKE '%' + ISNULL(@MaMatHang, '') + '%')
	  AND (p.NameMH LIKE '%' + ISNULL(@TenMatHang, '') + '%')
      AND (@TuNgay IS NULL OR o.NgayMua >= @TuNgay)
      AND (@DenNgay IS NULL OR o.NgayMua <= @DenNgay)
END;

exec locdanhsach '038','KH37',null,null,null,'2024/7/10','2024/7/30'--truy vấn theo định dạng (Mã đơn hàng, mã khách hàng, tên khách hàng, mã đặt hàng, tên đặt hàng, từ ngày, đến ngày) CHÚ Ý: Nếu không có dữ liệu nào thì vui lòng nhập là null
--VD: EXEC locdanhsach null,null,null,null,null,'2024/7/10','2024/7/30'



--store procedure tìm top10 danh sách khách hàng mua hàng nhiều nhất
create procedure top10muahang
	@tungay int = NULL,
	@denngay int = Null,
	@tuthang int = null,
	@denthang int = null
as
begin
	set rowcount 10
	IF @tuthang IS NULL
		SET @tuthang = 1;
	IF @denthang IS NULL
		SET @denthang = 12;
	IF @tungay IS NULL
		SET @tungay = 1;
	IF @denngay IS NULL
		SET @denngay = 31;
	SELECT KhachHang.NameKH, KhachHang.Tel,DonHang.NgayMua, MatHang.NameMH,MatHang.SoLuong,MatHang.ThanhTien, (MatHang.SoLuong * MatHang.ThanhTien) as N'Tổng chi phí'
	FROM DonHang, KhachHang, MatHang
	WHERE MONTH(NgayMua) >= @tuthang AND MONTH(NgayMua) <= @denthang and 
		  DAY(NgayMua) >= @tungay and DAY(NgayMua) <= @denngay and
		  DonHang.IDKH = KhachHang.IDKH and MatHang.IDMH = DonHang.IDMH
	order by (MatHang.SoLuong * MatHang.ThanhTien) DESC
END;


exec top10muahang 12,null,1,10 -- truy vấn theo từ ngày, đến ngày, từ tháng, đến tháng LƯU Ý: nếu không nhập giá trị nào thì vui lòng nhập là null
--VD: exec top10muahang 2,null,3,10


--store procedure tìm top10 danh sách mặt hàng được mua nhiều nhất trong tháng
create procedure top10MatHangMuaNhieuNhatTrongThang
	@thang int = NULL
	as
	set rowcount 10
	SELECT  MatHang.NameMH,MatHang.SoLuong,MatHang.ThanhTien, (MatHang.SoLuong * count(NameMH)) as N'Tổng số lượng bán ra'
	FROM DonHang, KhachHang, MatHang
	WHERE MONTH(NgayMua) = @thang and
		  DonHang.IDKH = KhachHang.IDKH and MatHang.IDMH = DonHang.IDMH
	group by NameMH, SoLuong, ThanhTien
	order by MatHang.SoLuong DESC


exec top10MatHangMuaNhieuNhatTrongThang 7 -- truy vấn theo tháng
--VD: exec top10mathangtrongthang 12

--store procedure tìm top10 danh sách mặt hàng được mua ít nhất trong tháng
create procedure top10MatHangMuaItNhatTrongThang
	@thang int = NULL
	as
	set rowcount 10
	SELECT  MatHang.NameMH,MatHang.SoLuong,MatHang.ThanhTien, (MatHang.SoLuong * count(NameMH)) as N'Tổng số lượng bán ra'
	FROM DonHang, KhachHang, MatHang
	WHERE MONTH(NgayMua) = @thang and
		  DonHang.IDKH = KhachHang.IDKH and MatHang.IDMH = DonHang.IDMH
	group by NameMH, SoLuong, ThanhTien
	order by MatHang.SoLuong ASC


exec top10MatHangMuaItNhatTrongThang 7 -- truy vấn theo tháng
--VD: exec top10mathangtrongthang 12







create PROCEDURE sp_TimDonHang
    @MaDonHang VARCHAR(50) = NULL,
    @MaKhachHang VARCHAR(50) = NULL,
    @TenKhachHang VARCHAR(50) = NULL,
    @MaMatHang VARCHAR(50) = NULL,
    @TenMatHang VARCHAR(50) = NULL,
    @TuNgay datetime = NULL,
    @DenNgay datetime = NULL
AS
BEGIN
    -- Tạo câu lệnh SELECT cơ bản
    DECLARE @Sql NVARCHAR(MAX) = 'SELECT * FROM DonHang';

    -- Thêm điều kiện lọc Mã đơn hàng
    IF @MaDonHang IS NOT NULL
        SET @Sql = @Sql + ' WHERE IDDH = @MaDonHang';

    -- Thêm điều kiện lọc Mã/Tên khách hàng
    IF @MaKhachHang IS NOT NULL
        SET @Sql = @Sql + (CASE WHEN @Sql LIKE '%WHERE%' THEN ' AND' ELSE ' WHERE' END) + ' IDKH = @MaKhachHang';
    IF @TenKhachHang IS NOT NULL
        SET @Sql = @Sql + (CASE WHEN @Sql LIKE '%WHERE%' THEN ' AND' ELSE ' WHERE' END) + ' IDKH IN (SELECT IDKH FROM KhachHang WHERE NameKH = @TenKhachHang)';

    -- Thêm điều kiện lọc Mã/Tên mặt hàng
    IF @MaMatHang IS NOT NULL
        SET @Sql = @Sql + (CASE WHEN @Sql LIKE '%WHERE%' THEN ' AND' ELSE ' WHERE' END) + ' IDMH = @MaMatHang';
    IF @TenMatHang IS NOT NULL
        SET @Sql = @Sql + (CASE WHEN @Sql LIKE '%WHERE%' THEN ' AND' ELSE ' WHERE' END) + ' IDMH IN (SELECT IDMH FROM MatHang WHERE NameMH = @TenMatHang)';

    -- Thêm điều kiện lọc Ngày tạo đơn hàng
    IF @TuNgay IS NOT NULL AND @DenNgay IS NOT NULL
        SET @Sql = @Sql + (CASE WHEN @Sql LIKE '%WHERE%' THEN ' AND' ELSE ' WHERE' END) + ' NgayMua BETWEEN @TuNgay AND @DenNgay';

    -- Thực thi câu lệnh SELECT
    EXEC sp_executesql @Sql,
                       N'@MaDonHang VARCHAR(50), @MaKhachHang VARCHAR(50), @TenKhachHang VARCHAR(50), @MaMatHang VARCHAR(50), @TenMatHang VARCHAR(50), @TuNgay DATETIME, @DenNgay DATETIME',
                       @MaDonHang, @MaKhachHang, @TenKhachHang, @MaMatHang, @TenMatHang, @TuNgay, @DenNgay;
END;

EXEC sp_TimDonHang null,'KH32',null,null,null,'2024/7/10','2024/7/30' --truy vấn theo định dạng (Mã đơn hàng, mã khách hàng, tên khách hàng, mã đặt hàng, tên đặt hàng, từ ngày, đến ngày) CHÚ Ý: Nếu không có dữ liệu nào thì vui lòng nhập là null
--VD: EXEC sp_TimDonHang null,null,null,null,null,'2024/7/10','2024/7/30'