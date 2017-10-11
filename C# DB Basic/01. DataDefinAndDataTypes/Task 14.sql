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