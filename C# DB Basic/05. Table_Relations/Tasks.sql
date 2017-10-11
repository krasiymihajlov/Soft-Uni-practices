USE TableRelations
GO

--Problem 1.	One-To-One Relationship

CREATE TABLE Passports (
    PassportID INT IDENTITY (101, 1),
    PassportNumber NVARCHAR(8) NOT NULL,    

    CONSTRAINT PK_Passports 
    PRIMARY KEY (PassportID)   
)

CREATE TABLE Persons(
    PersonID INT IDENTITY NOT NULL,
    FirstName NVARCHAR(50) NOT NULL,
    Salary DECIMAL(15,2),
    PassportID INT UNIQUE ,

    CONSTRAINT PK_Persons 
    PRIMARY KEY (PersonID),

    CONSTRAINT FK_Persons_Passports 
    FOREIGN KEY (PassportID) 
    REFERENCES Passports(PassportID)
)

INSERT INTO Passports VALUES
('N34FG21B'),
('K65LO4R7'),
('ZE657QP2')

INSERT INTO Persons VALUES
('Roberto', 43300.00, 102),
('Tom', 56100.00, 103),
('Yana', 60200.00, 101)

--Problem 2.	One-To-Many Relationship

CREATE TABLE Manufacturers (
    ManufacturerID INT IDENTITY NOT NULL,
    Name NVARCHAR(50),
    EstablishedOn DATE NOT NULL,

    CONSTRAINT PK_Manufacturers 
    PRIMARY KEY (ManufacturerID)
)

CREATE TABLE Models (
    ModelID INT IDENTITY(101, 1) NOT NULL,
    Name NVARCHAR(50),
    ManufacturerID INT,

    CONSTRAINT PK_Models 
    PRIMARY KEY (ModelID),

    CONSTRAINT FK_Models_Manufacturers 
    FOREIGN KEY (ManufacturerID) 
    REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Manufacturers VALUES
('BMW', '07/03/1916'),
('Tesla', '01/01/2003'),
('Lada', '01/05/1966')

INSERT INTO Models VALUES
('X1', 1),
('i6', 1),
('Model S', 2),
('Model X', 2),
('Model 3', 2),
('Nova', 3)

--Problem 3.	Many-To-Many Relationship

CREATE TABLE Students (
    StudentID INT IDENTITY PRIMARY KEY NOT NULL,
    Name NVARCHAR(50) NOT NULL
)

CREATE TABLE Exams (
    ExamID INT IDENTITY(101, 1) PRIMARY KEY NOT NULL,
    Name NVARCHAR(50) NOT NULL
)

CREATE TABLE StudentsExams (
    StudentID INT NOT NULL, 
    ExamID INT NOT NULL,

    CONSTRAINT PK_StudentsExams 
    PRIMARY KEY (StudentID, ExamID),

    CONSTRAINT FK_StudentsExams_Students 
    FOREIGN KEY (StudentID) 
    REFERENCES Students(StudentID),

    CONSTRAINT FK_StudentsExams_Exams
    FOREIGN KEY (ExamID) 
    REFERENCES Exams(ExamID)
)

INSERT INTO Students VALUES
('Mila'),
('Toni'),
('Ron')

INSERT INTO Exams VALUES
('SpringMVC'),
('Neo4j'),
('Oracle 11g')

INSERT INTO StudentsExams VALUES 
(1, 101),
(1, 102),
(2, 101),
(3, 103),
(2, 102),
(2, 103)

--Problem 4.	Self-Referencing 

CREATE TABLE Teachers (
    TeacherID INT IDENTITY(101, 1) NOT NULL,
    Name NVARCHAR(50) NOT NULL,
    ManagerID INT,

    CONSTRAINT PK_Teachers 
    PRIMARY KEY (TeacherID),

    CONSTRAINT FK_ManagerID_TeacherID 
    FOREIGN KEY (ManagerID)
    REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers VALUES
('John', NULL),
('Maya', 106),
('Silvia', 106),
('Ted', 105),
('Mark', 101),
('Greta', 101)

-- Problem 5.	Online Store Database

CREATE DATABASE OnlineStore
USE OnlineStore

CREATE TABLE Cities (
    CityID INT IDENTITY PRIMARY KEY NOT NULL,
    Name VARCHAR(50) NOT NULL
)

CREATE TABLE Customers (
    CustomerID INT IDENTITY PRIMARY KEY NOT NULL,
    Name VARCHAR(50),
    Birthday DATE NOT NULL,
    CityID INT,

    CONSTRAINT FK_Customers_Cities 
    FOREIGN KEY (CityID)
    REFERENCES Cities(CityID)
)

CREATE TABLE Orders (
    OrderID INT IDENTITY PRIMARY KEY NOT NULL,
    CustomerID INT NOT NULL,

    CONSTRAINT FK_Orders_Customers 
    FOREIGN KEY (CustomerID)
    REFERENCES Customers(CustomerID)
)

CREATE TABLE ItemTypes (
    ItemTypeID INT IDENTITY PRIMARY KEY NOT NULL,
    Name VARCHAR(50) NOT NULL
)

CREATE TABLE Items(
    ItemID INT IDENTITY PRIMARY KEY NOT NULL,
    Name VARCHAR(50),
    ItemTypeID INT,

    CONSTRAINT FK_Items_ItemTypes
    FOREIGN KEY (ItemTypeID)
    REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE OrderItems (
    OrderID INT NOT NULL,
    ItemID INT NOT NULL,

    CONSTRAINT PK_OrderItems 
    PRIMARY KEY (OrderID, ItemID),

    CONSTRAINT FK_OrderItems_Orders
    FOREIGN KEY (OrderID)
    REFERENCES Orders(OrderID),

    CONSTRAINT FK_OrderItems_Items
    FOREIGN KEY (ItemID)
    REFERENCES Items(ItemID)
)

--Problem 6.	University Database

CREATE DATABASE University
USE University

CREATE TABLE Majors (
    MajorID INT IDENTITY PRIMARY KEY NOT NULL,
    Name NVARCHAR(50) NOT NULL
)

CREATE TABLE Students(
    StudentID INT IDENTITY PRIMARY KEY NOT NULL,
    StudentNumber NVARCHAR(10) NOT NULL,
    StudentName NVARCHAR(50),
    MajorID INT ,

    CONSTRAINT FK_Students_Majors
    FOREIGN KEY (MajorID)
    REFERENCES Majors(MajorID)
)

CREATE TABLE Payments (
    PaymentID INT IDENTITY PRIMARY KEY NOT NULL,
    PaymentDate DATE NOT NULL,
    PaymentAmount DECIMAL(15, 2),
    StudentID INT,

    CONSTRAINT FK_Payments_Students
    FOREIGN KEY (StudentID)
    REFERENCES Students(StudentID)
)

CREATE TABLE Subjects(
    SubjectID INT IDENTITY PRIMARY KEY NOT NULL,
    SubjectName NVARCHAR(50) NOT NULL
)

CREATE TABLE Agenda(
    StudentID INT  NOT NULL,
    SubjectID INT  NOT NULL,

    CONSTRAINT PK_Agenda
    PRIMARY KEY (StudentID, SubjectID),

    CONSTRAINT FK_Agenda_Subjects
    FOREIGN KEY (SubjectID)
    REFERENCES Subjects(SubjectID),

    CONSTRAINT FK_Agenda_Students
    FOREIGN KEY (StudentID)
    REFERENCES Students(StudentID)
)
GO
--Problem 9.	*Peaks in Rila

USE Geography
GO

SELECT m.MountainRange, p.PeakName, p.Elevation 
  FROM Mountains AS m
 JOIN Peaks AS p ON p.MountainId = m.Id
 WHERE m.MountainRange = 'Rila'
ORDER BY p.Elevation DESC