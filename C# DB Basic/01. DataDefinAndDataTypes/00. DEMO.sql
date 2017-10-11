
-- TASK 1 Create Database
CREATE DATABASE Minions

-- TASK 2 Create Tables
GO
Drop Table Minions
GO
Drop Table Towns

CREATE TABLE Minions (
	Id INT NOT NULL,
	Name NVARCHAR(50) NOT NULL,
	Age INT 
    CONSTRAINT PK_Minions PRIMARY KEY (Id)	
)

CREATE TABLE Towns (
	Id INT NOT NULL,
	Name NVARCHAR(50) NOT NULL,
	CONSTRAINT PK_Towns PRIMARY KEY (Id)
)

-- TASK 3 Alter Minions Table


ALTER TABLE Minions
ADD TownId INT NOT NULL
FOREIGN KEY (TownId) REFERENCES Minions(Id);

-- TASK 4 Insert Records in Both Tables

INSERT INTO Towns VALUES 
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')

INSERT INTO Minions VALUES 
(1, 'Kevin', 22, 1),
(2, 'Bob', 15, 3),
(3, 'Steward', NULL, 2)

--TASK 5.Truncate Table Minions
USE Minions
GO
TRUNCATE TABLE Minions
SELECT * FROM Minions

-- TASK 6 Drop all tables

USE Minions
GO
DROP TABLE Minions
DROP TABLE Towns

-- TASK 7 Create Table People
GO
DROP TABLE People

CREATE TABLE People (
	Id INT IDENTITY NOT NULL,
	Name NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX),
	Height DECIMAL(15, 2),
	Weight DECIMAL(15, 2),
	Gender BIT NOT NULL, 
	Birthdate DATETIME NOT NULL,
	Biography NVARCHAR(MAX) 
	CONSTRAINT PK_People PRIMARY KEY (Id)
)

INSERT INTO People
VALUES 
('Ivan', NULL, NULL, NULL, 1, 1990-05-02, NULL),
('Pesho', NULL, NULL, NULL, 1, 1991/05/02, NULL),
('Ivanka', NULL, NULL, NULL, 0, 1992/05/02, NULL),
('Ivan40', NULL, NULL, NULL, 1, 1993/05/02, NULL),
('Gergan', NULL, NULL, NULL, 1, 1994/05/02, NULL)

SELECT * FROM People

--TASK 8 Create Table Users

CREATE TABLE Users (
	Id BIGINT IDENTITY NOT NULL,
	UserName VARCHAR(30) NOT NULL,
	Password VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX),
	LastLoginTime DATETIME NOT NULL,
	IsDeleted BIT
	CONSTRAINT PK_Users PRIMARY KEY (Id)
)


ALTER TABLE Users
ADD CONSTRAINT CHK_ProfilePictureLength 
CHECK (DATALENGTH(ProfilePicture) > 900 * 1024)

INSERT INTO Users (UserName, Password, ProfilePicture, IsDeleted) VALUES
('Pesho', '1235673', NULL, 0),
('Ivan', '123456', NULL, 0),
('Dragan', '123456', NULL, 0),
('Minka', '123456', NULL, 0),
('Ginka', '123456', NULL, 0)

SELECT * FROM Users

-- TASK 9 Change Primary Key

ALTER TABLE Users
DROP CONSTRAINT PK_Users 

ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY (Id, UserName)

--TASK 10 Add Check Constraint

ALTER TABLE Users
ADD CONSTRAINT CHK_PasswordLength CHECK (DATALENGTH(Password) >= 5)


--TASK 11 Set Default Value of the Field

ALTER TABLE Users
DROP COLUMN LastLoginTime

SELECT * FROM Users

GO 
ALTER TABLE Users
ADD LastLoginTime DATETIME DEFAULT GETDATE() NOT NULL

-- TASK 12 Set Unique Field
USE Minions
GO

ALTER TABLE Users
DROP CONSTRAINT PK_Users

ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY (Id)

ALTER TABLE Users
DROP COLUMN Username

ALTER TABLE Users
ADD Username VARCHAR(30) 

ALTER TABLE Users
ADD UNIQUE (Username) 

ALTER TABLE Users
ADD CONSTRAINT CHK_UsernameLength CHECK (DATALENGTH(Username) > 3) 

--TASK 13 Movies Database

CREATE DATABASE Movies 

USE Movies
GO
DROP TABLE Directors

CREATE TABLE Directors (
	Id INT IDENTITY NOT NULL,
	DirectorName NVARCHAR(100),
	Notes NVARCHAR(MAX) 
	CONSTRAINT PK_Directors PRIMARY KEY (Id)
)

GO
CREATE TABLE Genre (
	Id INT IDENTITY NOT NULL,
	GenreName NVARCHAR(100),
	Notes NVARCHAR(MAX) 
	CONSTRAINT PK_Genre PRIMARY KEY (Id)
)

GO
CREATE TABLE Categories (
	Id INT IDENTITY NOT NULL,
	CategoryName NVARCHAR(100),
	Notes NVARCHAR(MAX) 
	CONSTRAINT PK_Categories PRIMARY KEY (Id)
)

GO
CREATE TABLE Movies (
	Id INT IDENTITY NOT NULL,
	Title NVARCHAR(50),
	DirectorId INT NOT NULL,
	CopyrightYear DATE,
	Length DECIMAL(15, 2),
	GenreId INT NOT NULL,
	CategoryId INT NOT NULL,
	Rating INT,
	Notes NVARCHAR(MAX)
	CONSTRAINT PK_Movies PRIMARY KEY (Id)
	CONSTRAINT FK_DirectorId FOREIGN KEY (DirectorId) REFERENCES Directors(Id),
	CONSTRAINT FK_GenreId FOREIGN KEY (GenreId) REFERENCES Genre(Id),
	CONSTRAINT FK_CategoryId FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
)

INSERT INTO Directors VALUES
('Ivankata', NULL),
('Stamat', NULL),
('Penka', NULL),
('Ivan', NULL),
('Pesho', NULL)

INSERT INTO Genre VALUES
('Drama', NULL),
('Comic', NULL),
('Crime', NULL),
('Erotic', NULL),
('Fantasy', NULL)

INSERT INTO Categories VALUES
('Ede', NULL),
('da', NULL),
('of', NULL),
('Sex', NULL),
('nosex', NULL)

INSERT INTO Movies VALUES
(NULL, NULL, NULL, 5, NULL),
(NULL, NULL, NULL, 4, NULL),
(NULL, NULL, NULL, 3, NULL),
(NULL, NULL, NULL, 2, NULL),
(NULL, NULL, NULL, 1, NULL)

--TASK 14 Car Rental Database

CREATE DATABASE CarRental 

CREATE TABLE Categories (
	Id INT IDENTITY NOT NULL,
	CategoryName NVARCHAR(100) NOT NULL, 
	DailyRate INT,
	WeeklyRate INT,
	MonthlyRate INT,
	WeekendRate INT,
	CONSTRAINT PK_Categories PRIMARY KEY(Id)
)

INSERT INTO Categories (CategoryName) VALUES
('A'),
('B'),
('C')

CREATE TABLE Cars (
	Id INT IDENTITY NOT NULL,
	PlateNumber INT NOT NULL,
	Manufacturer NVARCHAR(50),
	Model NVARCHAR(50),
	CarYear NVARCHAR(50),
	CategoryId INT NOT NULL,
	Doors INT,
	Picture VARBINARY(MAX),
	Condition NVARCHAR(MAX),
	Available BIT DEFAULT 1
	CONSTRAINT PK_Cars PRIMARY KEY (Id)
	CONSTRAINT FK_CategoryId FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
)

INSERT INTO Cars (PlateNumber, CategoryId )VALUES
(1, 1),
(2, 2),
(3, 3)

CREATE TABLE Employees (
	Id INT IDENTITY NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Title NVARCHAR(50),
	Notes NVARCHAR(MAX),
	CONSTRAINT PK_Employees PRIMARY KEY (Id)
)

INSERT INTO Employees (FirstName, LastName) VALUES
('Ivan', 'Ivanov'),
('Pesho', 'Maikata'),
('Stamat', 'Georgiev')

CREATE TABLE Customers (
	Id INT IDENTITY NOT NULL,
	DriverLicenceNumber INT NOT NULL,
	FullName NVARCHAR(100) NOT NULL,
	Address NVARCHAR(200),
	City NVARCHAR(50),
	ZIPCode NVARCHAR(50),
	Notes NVARCHAR(MAX),
	CONSTRAINT PK_Customers PRIMARY KEY (Id)
)

INSERT INTO Customers(DriverLicenceNumber, FullName) VALUES
(1, 'kolio mamata'),
(2, 'Bat Pesho'),
(3, 'Inka')

CREATE TABLE RentalOrders (
	Id INT IDENTITY NOT NULL,
	EmployeeId INT NOT NULL,
	CustomerId INT NOT NULL,
	CarId INT NOT NULL,
	TankLevel INT,
	KilometrageStart INT,
	KilometrageEnd INT,
	TotalKilometrage INT,
	StartDate DATETIME NOT NULL,
	EndDate DATETIME NOT NULL,
	TotalDays INT NOT NULL,
	RateApplied INT,
	TaxRate DECIMAL(15, 2) NOT NULL,
	OrderStatus BIT,
	Notes NVARCHAR(MAX),
	CONSTRAINT FK_EmployeeId FOREIGN KEY (EmployeeId) REFERENCES Employees(Id),
	CONSTRAINT FK_CustomerId FOREIGN KEY (CustomerId) REFERENCES Customers(Id),
	CONSTRAINT FK_CarId FOREIGN KEY (CarId) REFERENCES Cars(Id)
)

INSERT INTO RentalOrders(EmployeeId, CustomerId, CarId, StartDate, EndDate, TotalDays, TaxRate) VALUES
(1, 1, 1, GETDATE(), GETDATE(), 4, 10.22),
(2, 2, 2, GETDATE(), GETDATE(), 4, 10.22),
(3, 3, 3, GETDATE(), GETDATE(), 4, 10.22)

--TASK 15 Hotel Database

CREATE TABLE Employees (
	Id INT IDENTITY NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Title NVARCHAR(50),
	Notes NVARCHAR(MAX)
	CONSTRAINT PK_Employees PRIMARY KEY (Id)
)

INSERT INTO Employees (FirstName, LastName) VALUES
('Genadi', 'Trifonov'),
('Pecata', 'Stoqnov'),
('Gringo', 'Dinkov')

CREATE TABLE Customers (
	Id INT IDENTITY NOT NULL,
	AccountNumber INT NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	PhoneNumber INT,
	EmergencyName NVARCHAR(50),
	EmergencyNumber INT,
	Notes NVARCHAR(MAX)
	CONSTRAINT PK_Customers PRIMARY KEY (Id)
)

INSERT INTO Customers (AccountNumber, FirstName, LastName) VALUES
(2, 'Genadi', 'Trifonov'),
(3, 'Pecata', 'Stoqnov'),
(4, 'Gringo', 'Dinkov')

CREATE TABLE RoomStatus (
	RoomStatus BIT DEFAULT 0 NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO RoomStatus (RoomStatus) VALUES
(1),
(0),
(1)

CREATE TABLE RoomTypes (
	RoomType INT NOT NULL,
	Notes NVARCHAR(MAX)
	CONSTRAINT PK_RoomType PRIMARY KEY (RoomType)
)

INSERT INTO RoomTypes (RoomType) VALUES
(2),
(4),
(3)

CREATE TABLE BedTypes (
	BedType INT NOT NULL,
	Notes NVARCHAR(MAX),
	CONSTRAINT PK_BedType PRIMARY KEY(BedType)
)

INSERT INTO BedTypes (BedType) VALUES
(2),
(4),
(1)

CREATE TABLE Rooms (
	RoomNumber INT NOT NULL UNIQUE,
	RoomType INT NOT NULL,
	BedType INT NOT NULL,
	Rate INT,
	RoomStatus BIT DEFAULT 0,
	Notes NVARCHAR(MAX),
	CONSTRAINT FK_RoomType FOREIGN KEY (RoomType) REFERENCES RoomTypes(RoomType),
	CONSTRAINT FK_BedType FOREIGN KEY (BedType) REFERENCES BedTypes(BedType)
)

INSERT INTO Rooms (RoomNumber, RoomType, BedType) VALUES 
(2, 2, 4),
(3, 2, 4),
(4, 3, 4)

CREATE TABLE Payments (
	Id INT IDENTITY NOT NULL,
	EmployeeId INT NOT NULL,
	PaymentDate DATETIME,
	AccountNumber INT NOT NULL,
	FirstDateOccupied DATETIME DEFAULT GETDATE(),
	LastDateOccupied DATETIME DEFAULT GETDATE(),
	TotalDays INT NOT NULL,
	AmountCharged DECIMAL(15, 2) NOT NULL,
	TaxRate DECIMAL(15, 2),
	TaxAmount DECIMAL(15, 2),
	PaymentTotal DECIMAL(15, 2) NOT NULL,
	Notes NVARCHAR(MAX),
	CONSTRAINT FK_EmployeeId FOREIGN KEY (EmployeeId) REFERENCES Employees(Id)
)

INSERT INTO Payments (EmployeeId, AccountNumber, TotalDays, AmountCharged, PaymentTotal)
VALUES
(1, 2, 3, 23.4, 299),
(2, 2, 3, 23.4, 299),
(3, 2, 3, 23.4, 299)

CREATE TABLE Occupancies (
	Id INT IDENTITY NOT NULL,
	EmployeeId INT NOT NULL,
	DateOccupied DATETIME,
	AccountNumber INT NOT NULL,
	RoomNumber INT NOT NULL,
	RateApplied INT,
	PhoneCharge INT,
	Notes NVARCHAR(MAX),
	CONSTRAINT FK_EmployeeIdOccupancies FOREIGN KEY (EmployeeId) REFERENCES Employees(Id),
	CONSTRAINT FK_RoomNumber FOREIGN KEY (RoomNumber) REFERENCES Rooms(RoomNumber)
)

INSERT INTO Occupancies (EmployeeId, AccountNumber, RoomNumber) VALUES
(1, 23, 2),
(2, 24, 3),
(3, 25, 4)


--TASK 16 Create SoftUni Database

CREATE DATABASE SoftUni

CREATE TABLE Towns (
	Id INT IDENTITY NOT NULL,
	Name NVARCHAR(50) NOT NULL,
	CONSTRAINT PK_Towns PRIMARY KEY (Id)
)

CREATE TABLE Addresses (
	Id INT IDENTITY NOT NULL,
	AddressText NVARCHAR(100) NOT NULL,
	TownId INT NOT NULL,
	CONSTRAINT PK_Addresses PRIMARY KEY (Id),
	CONSTRAINT FK_TownId FOREIGN KEY (TownId) REFERENCES Towns(Id)
)

CREATE TABLE Departments (
	Id INT IDENTITY NOT NULL,
	Name NVARCHAR(50)
	CONSTRAINT PK_Departments PRIMARY KEY (Id)
)

DROP TABLE Employees

CREATE TABLE Employees (
	Id INT IDENTITY NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(50) NOT NULL,
	JobTitle NVARCHAR(50) NOT NULL,
	DepartmentId INT NOT NULL,
	HireDate DATE DEFAULT GETDATE(),
	Salary DECIMAL(15, 2) NOT NULL,
	AddressId INT,
	CONSTRAINT PK_Employees PRIMARY KEY (Id),
	CONSTRAINT FK_DepartmentId FOREIGN KEY (DepartmentId) REFERENCES Departments(Id)
)

--TASK 18 Basic Insert

INSERT INTO Towns VALUES
('Sofia'),
('Plovdiv'), 
('Varna'), 
('Burgas')

INSERT INTO Departments VALUES
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance')

Select * FROM Departments

INSERT INTO Employees (FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary) VALUES
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013/02/01', 3500.00),
('Petar ', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004/03/02', 4000.00),
('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016/08/28', 525.25),
('Georgi', 'Terziev', 'Ivanov', 'CEO', 2, '2007/12/09', 3000.00),
('Peter', 'Pan', 'Pan', 'Intern', 3, '2016/08/28', 599.88)

SELECT * FROM Employees

--TASK 20 