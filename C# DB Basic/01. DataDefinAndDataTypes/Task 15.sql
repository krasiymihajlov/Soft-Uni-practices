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