Use master
GO

CREATE DATABASE CarRental;
GO
USE CarRental;
GO

---------------------MEMBER------------------------
CREATE TABLE Role(
	RoleId TINYINT NOT NULL PRIMARY KEY IDENTITY(1,1),
	RoleName NVARCHAR(16) NOT NULL
);
GO
INSERT INTO Role VALUES
	(N'Admin'),
	(N'Chủ xe'),
	(N'Khách thuê')
	GO
--DROP DATABASE Member
GO
CREATE TABLE Member(
	MemberId VARCHAR(32) NOT NULL PRIMARY KEY,	
	Email VARCHAR(128) NOT NULL,
	Phone VARCHAR(16) NOT NULL,
	Password VARCHAR(128) NOT NULL,
	FullName NVARCHAR(256) NOT NULL,
	Gender NVARCHAR(16) NOT NULL,
	RoleId TINYINT NOT NULL REFERENCES Role(RoleId)
);
GO

------------------------CAR-------------------------
CREATE TABLE Manufacturer(
	ManufacturerId TINYINT NOT NULL PRIMARY KEY IDENTITY(1,1),
	ManufacturerName NVARCHAR(32) NOT NULL
);
INSERT INTO Manufacturer VALUES
	(N'Chevrolet'),
	(N'Ford'),
	(N'Honda'),
	(N'Hyundai'),
	(N'Mazda'),
	(N'Mitsubishi'),
	(N'Nissan')	
GO
CREATE TABLE Category(
	CategoryId TINYINT NOT NULL PRIMARY KEY IDENTITY(1,1),
	CategoryName NVARCHAR(64) NOT NULL
);
GO
--DROP TABLE Category
INSERT INTO Category VALUES
	(N'Sedan'),
	(N'5 chỗ'),
	(N'7 chỗ'),
	(N'Mini'),
	(N'Bán tải')
GO
CREATE TABLE Fuel(
	FuelId TINYINT NOT NULL PRIMARY KEY IDENTITY(1,1),
	FuelName NVARCHAR(64) NOT NULL
);
GO
INSERT INTO Fuel VALUES
	(N'Xăng'),
	(N'Dầu'),
	(N'Điện')
	GO
CREATE TABLE GearBox(
	GearboxId TINYINT NOT NULL PRIMARY KEY IDENTITY(1,1),
	GearboxName NVARCHAR(64) NOT NULL
);
GO
INSERT INTO GearBox VALUES
	(N'Số sàn'),
	(N'Số tự động')
	GO
	--DROP DATABASE Car
CREATE TABLE Car(
	CarId VARCHAR(16) NOT NULL PRIMARY KEY,
	MemberId VARCHAR(32) REFERENCES Member(MemberId),
	ManufacturerId TINYINT NOT NULL REFERENCES Manufacturer(ManufacturerId),
	CategoryId TINYINT NOT NULL REFERENCES Category(CategoryId),
	CarName NVARCHAR(128) NOT NULL,
	ProducedYear SMALLINT NOT NULL,
	Color NVARCHAR(64) NOT NULL,
	NumberPlate NVARCHAR(64),
	PricePerDay INT NOT NULL,
	Location NVARCHAR(512) NOT NULL,
	FuelId TINYINT NOT NULL REFERENCES Fuel(FuelId),
	GearboxId TINYINT NOT NULL REFERENCES GearBox(GearboxId),
	CarStatus BIT NOT NULL DEFAULT 0
);
GO


CREATE TABLE CarImage(
	CarId VARCHAR(16) NOT NULL REFERENCES Car(CarId),
	ImageUrl VARCHAR(32) NOT NULL,
	PRIMARY KEY(CarId, ImageUrl)
);
GO

---------------------BOOKING----------------------
--DROP DATABASE Booking
CREATE TABLE BookingStatus(
	BookingStatusId TINYINT NOT NULL PRIMARY KEY IDENTITY(1,1),
	BookingStatusDescription NVARCHAR(64) NOT NULL
);
GO
--DROP DATABASE Booking
GO
CREATE TABLE Booking(
	BookingId VARCHAR(32) NOT NULL PRIMARY KEY,
	CarId VARCHAR(16) NOT NULL REFERENCES Car(CarId),
	MemberId VARCHAR(32) NOT NULL REFERENCES Member(MemberId),
	BookingDate DATETIME NOT NULL,
	StartDate DATETIME NOT NULL,
	EndDate DATETIME NOT NULL,
	Deposit DECIMAL NOT NULL,
	BookingStatusId TINYINT REFERENCES BookingStatus(BookingStatusId)
);
GO
------------------------TRIP----------------------------------
--DROP DATABASE TripStatus
GO
CREATE TABLE TripStatus(
	TripStatusId TINYINT NOT NULL PRIMARY KEY IDENTITY(1,1),
	TripStatusDescription NVARCHAR(32) NOT NULL
);
GO
--DROP DATABASE Trip
GO
CREATE TABLE Trip(	
	TripId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	BookingId VARCHAR(32) NOT NULL REFERENCES Booking(BookingId),
	TripStatusId TINYINT REFERENCES TripStatus(TripStatusId)
);
GO
--DROP TABLE TripRating
CREATE TABLE TripRating(
	TripId INT REFERENCES Trip(TripId) PRIMARY KEY,
	Rating TINYINT NOT NULL,
	Comment NVARCHAR(1024) NOT NULL,
	MemberId VARCHAR(32) REFERENCES Member(MemberId)
);
GO

--Select * from Category
--DROP DATABASE booking
--SELECT * from Manufacturer
--SELECT * FROM Role
--SELECT * FROM Member
--SELECT * FROM Car
