
USE SoftUni;
GO
-- Problem 1.	Find Names of All Employees by First Name

SELECT FirstName, LastName
FROM Employees
WHERE FirstName LIKE 'SA%';		

--Problem 2.	  Find Names of All employees by Last Name 

SELECT FirstName, LastName
FROM Employees
WHERE LastName LIKE '%ei%';		

--Problem 3.	Find First Names of All Employees                  <<<<< !!!!! HireDate

SELECT FirstName
FROM Employees
WHERE DepartmentID IN( 3, 10 );

--Problem 4.	Find All Employees Except Engineers

SELECT FirstName, LastName
FROM Employees
WHERE NOT JobTitle LIKE '%engineer%';

--Problem 5.	Find Towns with Name Length                                  <<<<<!!!!!

SELECT Name
FROM Towns
WHERE LEN(Name) IN( 5, 6 )
ORDER BY Name;

--Problem 6.	 Find Towns Starting With

SELECT *
FROM Towns
WHERE Name LIKE 'M%' OR 
	  Name LIKE 'K%' OR 
	  Name LIKE 'B%' OR 
	  Name LIKE 'E%'
ORDER BY Name;

 -- Problem 7.	 Find Towns Not Starting With

SELECT *
FROM Towns
WHERE Name NOT LIKE 'B%' AND 
	  Name NOT LIKE 'R%' AND 
	  Name NOT LIKE 'D%'
ORDER BY Name;

 --Problem 8.	Create View Employees Hired After 2000 Year
GO

CREATE VIEW V_EmployeesHiredAfter2000
AS
SELECT FirstName, LastName
FROM Employees
WHERE DATEPART(YEAR, HireDate) > 2000;

GO

SELECT *
FROM V_EmployeesHiredAfter2000;

--Problem 9.	Length of Last Name

SELECT FirstName, LastName
FROM Employees
WHERE LEN(LastName) = 5;

--Problem 10.	Countries Holding ‘A’ 3 or More Times                       <<<<<<<!!!!!!

USE Geography;
GO

SELECT CountryName, IsoCode
FROM Countries
WHERE CountryName LIKE '%A%A%A%'
ORDER BY IsoCode;

 --Problem 11.	 Mix of Peak and River Names

SELECT PeakName, RiverName, CONCAT(LOWER(SUBSTRING(PeakName, 1, LEN(PeakName)-1)), LOWER(RiverName)) AS Mix
FROM Peaks, Rivers
WHERE SUBSTRING(PeakName, LEN(PeakName), 1) = SUBSTRING(RiverName, 1, 1)
ORDER BY Mix;

--Problem 12.	Games from 2011 and 2012 year

USE Diablo;
GO

SELECT TOP 50 Name, FORMAT(Start, 'yyyy-MM-dd') AS [Start date]
FROM Games
WHERE DATEPART(YEAR, Start) BETWEEN 2011 AND 2012
ORDER BY [Start date] ASC, Name ASC;

SELECT *
FROM Games;

--Problem 13.	 User Email Providers

SELECT Username, SUBSTRING(Email, CHARINDEX('@', Email)+1, LEN(Email)-CHARINDEX('@', Email)) AS [Email Provider]
FROM Users
ORDER BY [Email Provider], Username; 

--Problem 14.	 Get Users with IPAdress Like Pattern

SELECT Username, IpAddress
FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username;

--Problem 15.	 Show All Games with Duration and Part of the Day

SELECT Name AS [Game],
			   CASE
			   WHEN DATEPART(HOUR, Start) BETWEEN 0 AND 11 THEN 'Morning'
			   WHEN DATEPART(HOUR, Start) BETWEEN 12 AND 17 THEN 'Afternoon'
			   WHEN DATEPART(HOUR, Start) BETWEEN 18 AND 23 THEN 'Evening'
			   ELSE NULL
			   END AS [Part of the Day],
					  CASE
					  WHEN Duration <= 3 THEN 'Extra Short'
					  WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
					  WHEN Duration > 6 THEN 'Long'
					  ELSE 'Extra Long'
					  END AS [Duration]
FROM Games
ORDER BY [Game], [Duration], [Part of the Day];

-- Problem 16.	 Orders Table

USE Orders;
GO

SELECT *
FROM Orders;

SELECT ProductName, OrderDate, DATEADD(DAY, 3, OrderDate) AS [Pay Due], DATEADD(MONTH, 1, OrderDate) AS [Deliver Due]
FROM Orders;

--Problem 17.	 People Table

CREATE TABLE People
( 
			 Id int IDENTITY NOT NULL, Name nvarchar(50) NOT NULL, Birthdate datetime NOT NULL CONSTRAINT PK_People PRIMARY KEY(Id)
);

INSERT INTO People( Name, Birthdate )
VALUES( 'Viktor', '2000-12-07 00:00:00.000' ), ( 'Stefan', '1992-09-10 00:00:00.000' ), ( 'Ivan', '1910-09-19 00:00:00.000' ), ( 'Stamat', '2010-01-06 00:00:00.000' );

SELECT Name, DATEDIFF(YEAR, Birthdate, GETDATE()) AS [Age in Years], DATEDIFF(MONTH, Birthdate, GETDATE()) AS [Age in Months], DATEDIFF(DAY, Birthdate, GETDATE()) AS [Age in Days], DATEDIFF(MINUTE, Birthdate, GETDATE()) AS [Age in Minutes]
FROM People;



