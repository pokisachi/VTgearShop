CREATE DATABASE VTshop;
GO
USE VTshop;
GO
--DROP TABLE [Category];
CREATE TABLE Category(
	[CategoryId] SMALLINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[CategoryName] [nvarchar](64) NOT NULL,
	[CategoryAlias] [nvarchar](64) NULL,
	[Description] [nvarchar](max) NULL,
	[ImageUrl] [nvarchar](32) NULL
);
GO
--DROP TABLE [Supplier];
CREATE TABLE [dbo].[Supplier](
	[SupplierId] [varchar](10) NOT NULL,
	[CompanyName] [nvarchar](64) NOT NULL,
	[Logo] [VARCHAR](32) NOT NULL,
	[ContactName] [nvarchar](64) NULL,
	[Email] [nvarchar](64) NOT NULL,
	[Phone] [nvarchar](16) NULL,
	[Address] [nvarchar](64) NULL,
	[Description] [nvarchar](max) NULL
);
--DROP TABLE [dbo].[Product];
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[ProductName] [nvarchar](64) NOT NULL,
	[ProductAlias] [nvarchar](64) NULL,
	[CategoryId] SMALLINT NOT NULL,
	[Unit] [nvarchar](50) NULL,
	[Price] [DECIMAL] NULL,
	[Image] [nvarchar](50) NULL,
	[ProductDate] [datetime] NOT NULL,
	[SaleOff] [DECIMAL] NOT NULL,
	[Viewed] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[SupplierId] [varchar](10) NOT NULL
);
GO
--insert Data Category--
INSERT INTO [dbo].[Category] ([CategoryName], [CategoryAlias], [Description], [ImageUrl]) VALUES
(N'CPU', 'cpu', N'Central Processing Unit - bộ xử lý trung tâm của máy tính.', 'cpu.jpg'),
(N'RAM', 'ram', N'Random Access Memory - bộ nhớ truy cập ngẫu nhiên.', 'ram.jpg'),
(N'Mainboard', 'mainboard', N'Bảng mạch chủ của máy tính, nơi lắp đặt các linh kiện.', 'mainboard.jpg'),
(N'GPU', 'gpu', N'Graphics Processing Unit - bộ xử lý đồ họa.', 'gpu.jpg'),
(N'Nguồn', 'power-supply', N'Bộ nguồn cung cấp điện cho máy tính.', 'power-supply.jpg'),
(N'Màn Hình', 'monitor', N'Màn hình hiển thị của máy tính.', 'monitor.jpg'),
(N'Bàn Phím', 'keyboard', N'Thiết bị nhập liệu của máy tính.', 'keyboard.jpg'),
(N'Card Màn Hình', 'expansion-card', N'Card mở rộng, như card mạng, card âm thanh.', 'card.jpg'),
(N'Chuột', 'mouse', N'Thiết bị điều khiển con trỏ trên màn hình.', 'mouse.jpg'),
(N'Tai Nghe', 'headphones', N'Thiết bị âm thanh cá nhân.', 'headphones.jpg'),
(N'Bàn', 'desk', N'Bàn để máy tính và làm việc.', 'desk.jpg'),
(N'Ghế', 'chair', N'Ghế để ngồi làm việc tại máy tính.', 'chair.jpg'),
(N'Laptop', 'laptop', N'Máy tính xách tay.', 'laptop.jpg');

--insert Data Supplier--
INSERT INTO [dbo].[Supplier] ([SupplierId], [CompanyName], [Logo], [ContactName], [Email], [Phone], [Address], [Description]) VALUES
(N'SP1', 'TechMart', 'techmart.jpg', 'Alice Nguyen', 'alice@techmart.com', '0901234567', N'123 Pham Van Dong, Ho Chi Minh City', N'Nhà cung cấp linh kiện máy tính và thiết bị công nghệ uy tín.'),
(N'SP2', 'Computer World', 'computerworld.jpg', 'Bob Tran', 'bob@computerworld.com', '0912345678', N'456 Le Loi, Hanoi', N'Nhà cung cấp các loại linh kiện và phụ kiện máy tính chất lượng cao.'),
(N'SP3', 'PC Components', 'pccomponents.jpg', 'Charlie Pham', 'charlie@pccomponents.vn', '0987654321', N'789 Tran Hung Dao, Da Nang', N'Chuyên cung cấp các sản phẩm máy tính và phụ kiện từ các thương hiệu nổi tiếng.');


--insert Data product--
INSERT INTO [dbo].[Product] ([ProductName], [ProductAlias], [CategoryId], [Unit], [Price], [Image], [ProductDate], [SaleOff], [Viewed], [Description], [SupplierId]) VALUES
(N'Intel Core i7-12700K', 'intel-i7', 1, 'Unit', 320.5, 'intel-i7.jpg', '2024-01-10', 0.05, 150, N'CPU mạnh mẽ cho các tác vụ đa nhiệm và chơi game.', 'SP1'),
(N'Corsair Vengeance LPX 16GB', 'corsair-ram-16gb', 2, 'Unit', 75.0, 'corsair-ram.jpg', '2024-02-15', 0.1, 120, N'RAM DDR4 dung lượng 16GB, tốc độ cao.', 'SP2'),
(N'ASUS TUF Gaming B560M', 'asus-mainboard', 3, 'Unit', 145.0, 'asus-mainboard.jpg', '2024-03-05', 0.08, 200, N'Mainboard ASUS hỗ trợ CPU Intel thế hệ thứ 11.', 'SP3'),
(N'NVIDIA GeForce RTX 3060', 'nvidia-rtx-3060', 4, 'Unit', 499.99, 'rtx-3060.jpg', '2024-04-20', 0.1, 300, N'Card đồ họa với hiệu năng mạnh mẽ cho chơi game và đồ họa.', 'SP1'),
(N'Corsair CX550M', 'corsair-cx550m', 5, 'Unit', 70.0, 'corsair-psu.jpg', '2024-05-18', 0.05, 90, N'Nguồn máy tính 550W, hiệu suất cao.', 'SP2'),
(N'Dell UltraSharp U2722D', 'dell-monitor', 6, 'Unit', 379.0, 'dell-monitor.jpg', '2024-06-10', 0.12, 175, N'Màn hình Dell 27 inch, độ phân giải 2K.', 'SP3'),
(N'Logitech MX Keys', 'logitech-mx-keys', 7, 'Unit', 99.0, 'logitech-keyboard.jpg', '2024-07-01', 0.07, 65, N'Bàn phím không dây cao cấp từ Logitech.', 'SP1'),
(N'Sound BlasterX AE-5', 'sound-blasterx-ae5', 8, 'Unit', 129.99, 'sound-card.jpg', '2024-08-25', 0.1, 80, N'Card âm thanh cao cấp cho trải nghiệm âm thanh tuyệt vời.', 'SP2'),
(N'Logitech G Pro X Superlight', 'logitech-mouse', 9, 'Unit', 130.0, 'logitech-mouse.jpg', '2024-09-05', 0.08, 230, N'Chuột chơi game siêu nhẹ với độ chính xác cao.', 'SP3'),
(N'HyperX Cloud II', 'hyperx-cloud-ii', 10, 'Unit', 85.0, 'hyperx-headphones.jpg', '2024-10-15', 0.09, 95, N'Tai nghe chơi game với âm thanh vòm 7.1.', 'SP1'),
(N'Gaming Desk', 'gaming-desk', 11, 'Unit', 150.0, 'gaming-desk.jpg', '2024-11-01', 0.15, 45, N'Bàn chơi game thiết kế tối ưu cho game thủ.', 'SP2'),
(N'Gaming Chair', 'gaming-chair', 12, 'Unit', 220.0, 'gaming-chair.jpg', '2024-11-10', 0.2, 50, N'Ghế chơi game thoải mái và chắc chắn.', 'SP3'),
(N'HP Pavilion 15', 'hp-pavilion-15', 13, 'Unit', 650.0, 'hp-laptop.jpg', '2024-12-01', 0.1, 150, N'Laptop HP với hiệu suất tốt cho công việc và giải trí.', 'SP1');


-----------CART-------------
--Drop TABLE Cart
CREATE TABLE Cart(
	CartCode char(32) NOT NULL ,
	ProductId INT NOT NULL REFERENCES Product(ProductId),
	Quantity SMALLINT NOT NULL,
	CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
	UpdatedDate DATETIME NOT NULL DEFAULT GETDATE(),
	PRIMARY KEY(CartCode, ProductId)
	);
GO
--DROP PROC AddCart;
CREATE PROC AddCart
(
	@CartCode CHAR(32),
	@ProductId INT,
	@Quantity SMALLINT
)
AS
	IF EXISTS(SELECT * FROM Cart WHERE CartCode = @CartCode AND ProductId = @ProductId)
		UPDATE Cart SET Quantity += @Quantity, UpdatedDate = GETDATE() WHERE CartCode = @CartCode AND ProductId = @ProductId;
	ELSE
		INSERT INTO Cart (CartCode, ProductId, Quantity) VALUES (@CartCode, @ProductId, @Quantity);
GO
--Drop PROC GetCategoryAndProducts
CREATE PROC GetCategoryAndProducts
AS
SELECT Category.CategoryId, CategoryName, COUNT(*) AS Total FROM Category
	JOIN Product ON Category.CategoryId = Product.CategoryId
	GROUP BY Category.CategoryId, CategoryName;
	GO



--DROP TABLE Customer
CREATE TABLE Customer(
	CustomerId INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	CustomerName NVARCHAR(64) NOT NULL,
	Email VARCHAR(64) NOT NULL,
	DateOfBirth DATE NOT NULL,
	Address NVARCHAR(128) NOT NULL
);
GO

SET IDENTITY_INSERT Customer ON;

INSERT INTO Customer (CustomerId, CustomerName, Email, DateOfBirth, Address)
VALUES 
(1, 'Nguyen Van A', 'nguyenvana@example.com', '1990-05-12', '123 Le Loi, Ho Chi Minh City'),
(2, 'Tran Thi B', 'tranthib@example.com', '1985-08-24', '456 Nguyen Hue, Ho Chi Minh City'),
(3, 'Le Van C', 'levanc@example.com', '1992-11-15', '789 Tran Hung Dao, Ho Chi Minh City'),
(4, 'Pham Thi D', 'phamthid@example.com', '1995-01-30', '101 Nguyen Van Linh, Da Nang'),
(5, 'Do Van E', 'dovane@example.com', '1988-07-08', '202 Le Duan, Ha Noi');

SET IDENTITY_INSERT Customer OFF;
GO

---DROP TABLE Invoice --
CREATE TABLE Invoice(
	InvoiceId INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	InvoiceDate DATETIME NOT NULL DEFAULT GETDATE(),
	CustomerId INT NOT NULL REFERENCES Customer(CustomerId)
);
GO
SET IDENTITY_INSERT Invoice ON;
INSERT INTO Invoice (InvoiceId, InvoiceDate, CustomerId) VALUES
	(1, '2024/1/1', 1),
	(2, '2023/1/1', 3),
	(3, '2022/1/1', 4),
	(4, '2024/1/1', 5),
	(5, '2023/1/1', 3),
	(6, '2022/1/1', 2),
	(7, '2021/1/1', 1),
	(8, '2020/1/1', 3),
	(9, '2022/1/1', 2),
	(10, '2023/1/1', 5),
	(11, '2024/3/1', 4)
	
GO
SET IDENTITY_INSERT Invoice OFF;
GO
--DROP TABLE InvoiceDetail
CREATE TABLE InvoiceDetail(
	InvoiceId INT NOT NULL,
	ProductId INT NOT NULL,
	Quantity SMALLINT NOT NULL,
	Price DECIMAL(10, 2) NOT NULL
);
GO
INSERT INTO InvoiceDetail (InvoiceId, ProductId, Quantity, Price) VALUES
	(1, 1, 2, 9.3),
	(1, 2, 1, 8.4),
	(1, 3, 2, 2.7),
	(2, 1, 2, 9.3),
	(2, 3, 2, 9.3),
	(2, 5, 2, 9.3),
	(3, 1, 2, 9.3),
	(3, 2, 2, 2.9),
	(3, 4, 2, 9.3),
	(4, 2, 1, 7.2),
	(4, 1, 3, 9.3),
	(4, 4, 2, 8.5),
	(5, 1, 3, 6.9),
	(5, 3, 2, 9.3),
	(6, 5, 4, 8.3),
	(7, 4, 2, 9.3),
	(8, 3, 2, 2.3),
	(9, 2, 2, 9.3),
	(10, 4, 2, 7.2),
	(11, 7, 2, 3.3),
	(12, 2, 2, 8.3),
	(13, 5, 2, 9.3),
	(14, 3, 2, 9.3),
	(14, 4, 2, 9.3);
GO

	CREATE PROC GetSalesByAge
as
SELECT YEAR(GETDATE()) -YEAR(InvoiceDate) AS Age, SUM(Price * Quantity) AS Sales
	FROM Invoice JOIN InvoiceDetail ON Invoice.InvoiceId = InvoiceDetail.InvoiceId
	GROUP BY YEAR(InvoiceDate);
Go

CREATE TABLE Employee(
	EmployeeId INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	EmployeeName NVARCHAR(64) NOT NULL,
	ParentId INT REFERENCES Employee(EmployeeId)
);
GO

CREATE PROC GetEmployeesAndParent
AS
SELECT C.EmployeeId, C.EmployeeName, C.ParentId,  P.EmployeeName AS ParentName
	FROM Employee AS P RIGHT JOIN Employee AS C ON C.ParentId = P.EmployeeId;
	GO

--Invoice New--
--DROP TABLE Invoice
GO
CREATE TABLE Invoice(
	InvoiceId BIGINT NOT NULL PRIMARY KEY,
	InvoiceDate DATETIME NOT NULL DEFAULT GETDATE(),
	Fullname NVARCHAR(64) NOT NULL,
	Email VARCHAR(64) NOT NULL,
	Phone VARCHAR(16) NOT NULL,
	Address NVARCHAR(128) NOT NULL
);
GO
--DROP  TABLE InvoiceDetail
CREATE TABLE InvoiceDetail(
	InvoiceId BIGINT NOT NULL,
	ProductId INT NOT NULL,
	Quantity SMALLINT NOT NULL,
	Price DECIMAL(10, 2) NOT NULL
);
GO
--DROP TABLE InvoiceDetail
--DROP PROC AddInvoice

CREATE PROC AddInvoice(
	@CartCode CHAR(32),
	@InvoiceId BIGINT,
	@InvoiceDate DATETIME,
	@FullName NVARCHAR(64),
	@Email VARCHAR(64),
	@Phone VARCHAR(16),
	@Address NVARCHAR(128)
)
AS
BEGIN
	INSERT INTO Invoice(InvoiceId, InvoiceDate, FullName, Email, Phone, Address) VALUES
		(@InvoiceId, @InvoiceDate, @FullName, @Email, @Phone, @Address);
	INSERT INTO InvoiceDetail(InvoiceId, ProductId, Quantity, Product.Price)
		SELECT @InvoiceId, Cart.ProductId, Cart.Quantity, Product.Price
		FROM Cart JOIN Product ON Cart.ProductID = Product.ProductId AND CartCode = @CartCode;
	--DELETE FROM Cart WHERE CartCode = @CartCode;
End
Go

select * from InvoiceDetail
select * from Invoice


------
CREATE PROC GetAmountInvoice
(
	@InvoiceId BIGINT
)
AS
	SELECT Price * Quantity FROM InvoiceDetail WHERE InvoiceId = @InvoiceId;
--drop table vnpayment;
go
	CREATE TABLE VnPayment(
		Amount BIGINT NOT NULL,
		BankCode VARCHAR(8) NOT NULL,
		BankTranNo VARCHAR(32) NOT NULL,
		CardType VARCHAR(16) NOT NULL,
		OrderInfo NVARCHAR(64) NOT NULL,
		PayDate VARCHAR(16) NOT NULL,
		ResponseCode VARCHAR(4) NOT NULL,
		TmnCode VARCHAR(16) NOT NULL,
		TransactionNo VARCHAR(16) NOT NULL,
		TransactionStatus VARCHAR(4) NOT NULL,
		TxnRef BIGINT NOT NULL,
		SecureHash VARCHAR(MAX) NOT NULL
);
GO



--drop proc addvnpayment;
go

CREATE PROC AddVnPayment(
		@Amount BIGINT,
		@BankCode VARCHAR(8) ,
		@BankTranNo VARCHAR(32) ,
		@CardType VARCHAR(16) ,
		@OrderInfo NVARCHAR(64),
		@PayDate VARCHAR(16),
		@ResponseCode VARCHAR(4),
		@TmnCode VARCHAR(16) ,
		@TransactionNo VARCHAR(16) ,
		@TransactionStatus VARCHAR(4) ,
		@TxnRef BIGINT ,
		@SecureHash VARCHAR(MAX) 
)
AS
INSERT INTO VnPayment VALUES(@Amount, @BankCode, @BankTranNo, @CardType, @OrderInfo,
	@PayDate, @ResponseCode, @TmnCode, @TransactionNo, @TransactionStatus, @TxnRef, @SecureHash);
Go

--select * from vnpayment;

--DROP table Member
create table Member(
	MemberId varchar(32) not null primary key,
	Email varchar(64) not null,
	Password varchar(128) not null,
	Name nvarchar(64) not null,
	GivenName nvarchar(16) not null,
	Surname nvarchar(32),
	LoginDate DATETIME NOT NULL DEFAULT GETDATE(),
	CreatedDate datetime not null default getdate()
);
Go
ALTER TABLE Member ADD Role VARCHAR(8) NOT NULL DEFAULT 'Customer';
GO
--DROP PROC AddMember
create PROC AddMember(
	@MemberId varchar(32),
	@Email varchar(64),
	@Password varchar(128),
	@Name nvarchar(64),
	@Givenname nvarchar(16),
	@Surname nvarchar(32) = null,
	@Role VARCHAR(8) ='Customer'
)
as 
	if not exists(select * from Member where MemberId = @MemberId)
		insert into Member (MemberId, Email, Password, Name, GivenName, Surname, Role) values
		(@MemberId, @Email, @Password, @Name, @GivenName, @Surname, @Role)
Go

SELECT * FROM Member

UPDATE Member
SET Role = 'Admin'
WHERE MemberId ='1063feb9f87c4ebea47e90d3f0ec5d6e'

--DROP PROC GetSalesByAge;
GO
CREATE PROC GetSalesByAge
AS
SELECT YEAR(GETDATE()) - YEAR(InvoiceDate) AS Age, SUM(Price * Quantity) AS Sales
	FROM Invoice JOIN InvoiceDetail ON Invoice.InvoiceId = InvoiceDetail.InvoiceId
	GROUP BY YEAR(InvoiceDate);
GO


ALTER TABLE Member ADD Token Char(32);
GO

CREATE PROCEDURE AddProduct
    @ProductName NVARCHAR(255),
    @ProductAlias NVARCHAR(255),
    @CategoryId INT,
    @Unit NVARCHAR(50),
    @Price DECIMAL(18, 2),
    @Image NVARCHAR(255),
    @ProductDate DATE,
    @SaleOff DECIMAL(18, 2),
    @Viewed INT,
    @Description NVARCHAR(MAX),
    @SupplierId NVARCHAR(50)
AS
BEGIN
    INSERT INTO [VTshop].[dbo].[Product]
        ([ProductName], [ProductAlias], [CategoryId], [Unit], [Price], [Image], 
         [ProductDate], [SaleOff], [Viewed], [Description], [SupplierId])
    VALUES
        (@ProductName, @ProductAlias, @CategoryId, @Unit, @Price, @Image, 
         @ProductDate, @SaleOff, @Viewed, @Description, @SupplierId)
END
GO
