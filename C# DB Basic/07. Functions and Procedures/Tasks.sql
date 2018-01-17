-- Problem 1.	Employees with Salary Above 35000

SELECT * FROM Employees
GO

CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000 
AS
  SELECT FirstName AS [First Name],
         LastName  AS [Last Name]
    FROM Employees
    WHERE Salary > 35000

GO

EXEC usp_GetEmployeesSalaryAbove35000

--02. Employees with Salary Above Number

GO 
CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber @Number DECIMAL(18, 4)
AS
  SELECT FirstName AS [First Name],
         LastName  AS [Last Name]
    FROM Employees
   WHERE Salary >= @Number

EXEC usp_GetEmployeesSalaryAboveNumber 48100

--Problem 3.	Town Names Starting With

GO
CREATE PROCEDURE usp_GetTownsStartingWith @String NVARCHAR(50)
AS
    SELECT Name AS Town FROM Towns
    WHERE Name LIKE CONCAT(@String, '%')

EXEC usp_GetTownsStartingWith b

--Problem 4.	Employees from Town
GO
CREATE PROCEDURE usp_GetEmployeesFromTown (@TownName NVARCHAR(50))
AS
    SELECT FirstName, LastName FROM Employees AS e
    JOIN Addresses AS a ON a.AddressID = e.AddressID
    JOIN Towns AS t ON t.TownID = a.TownID
    WHERE t.Name = @TownName

    EXEC usp_GetEmployeesFromTown Sofia

-- Problem 5.	Salary Level Function
GO
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4)) 
RETURNS NVARCHAR(10)
AS
BEGIN
    DECLARE @Result NVARCHAR(10)

    IF(@salary < 30000)
    BEGIN
        SET @Result = 'Low';
    END
    ELSE IF(@salary BETWEEN 30000 AND 50000)
    BEGIN
        SET @Result = 'Average'
    END
    ELSE
    BEGIN 
        SET @Result = 'High';
    END

    RETURN @Result
END

GO
SELECT Salary, 
       dbo.ufn_GetSalaryLevel(20000) AS SOMEt 
  FROM Employees

 --06. Employees by Salary Level
 GO
 CREATE PROCEDURE usp_EmployeesBySalaryLevel (@Salary NVARCHAR(50))
 AS
    SELECT FirstName, LastName FROM Employees
    WHERE @Salary = dbo.ufn_GetSalaryLevel(Salary)
GO
EXEC usp_EmployeesBySalaryLevel 'Average'

--07. Define Function
GO
CREATE FUNCTION ufn_IsWordComprised(@SetOfLetters NVARCHAR(MAX), @Word NVARCHAR(MAX))
RETURNS BIT
AS
BEGIN
    DECLARE @Result BIT = 1;

    DECLARE @count INT = 1;

    WHILE @count <= LEN(@Word)
    BEGIN

       DECLARE @Symbol CHAR
       SET @Symbol = SUBSTRING(@Word, @count, 1);

       IF(CHARINDEX(@Symbol, @SetOfLetters, 1) = 0)
       BEGIN
          SET @Result = 0;
          BREAK;
       END      
       SET @count += 1;
    END;

    RETURN @Result
END 

GO

CREATE TABLE Test(
    SetOfLetters NVARCHAR(MAX) NOT NULL,
    Word NVARCHAR(MAX) NOT NULL
)

INSERT INTO Test VALUES
('oistmiahf', 'Sofia'),
('oistmiahf', 'halves'),
('bobr', 'Rob'),
('pppp', 'Guy')

SELECT dbo.ufn_IsWordComprised (SetOfLetters, Word) AS Result FROM Test

--Problem 8.	* Delete Employees and Departments
GO
CREATE PROCEDURE usp_DeleteEmployeesFromDepartment (@departmentId INT) 
AS
    ALTER TABLE Departments
    ALTER COLUMN ManagerID INT NULL

    DELETE FROM EmployeesProjects
    WHERE EmployeeID IN    
            (
                SELECT EmployeeID FROM Employees
                WHERE DepartmentID = @departmentId
            )

    UPDATE Employees
    SET ManagerID = NULL
    WHERE ManagerID IN (
                            SELECT EmployeeID FROM Employees
                            WHERE DepartmentID = @departmentId
                        )

    UPDATE Departments
    SET ManagerID = NULL
    WHERE ManagerID IN (
                            SELECT EmployeeID FROM Employees
                            WHERE DepartmentID = @departmentId
                        )

    DELETE FROM Employees
    WHERE DepartmentID = @departmentId

    DELETE FROM Departments
    WHERE DepartmentID = @departmentId

    SELECT COUNT(*) AS CountDeletedEmployee FROM Employees
    WHERE DepartmentID = @departmentId

--Problem 9.	Find Full Name
GO
USE Bank

GO
CREATE PROC usp_GetHoldersFullName 
AS
    SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name] FROM AccountHolders

EXEC usp_GetHoldersFullName

--Problem 10.	People with Balance Higher Than
GO
CREATE PROC usp_GetHoldersWithBalanceHigherThan(@Number DECIMAL(15, 2))
AS
       SELECT FirstName, LastName FROM AccountHolders AS ah
       JOIN 
      ( SELECT a.AccountHolderId
         FROM Accounts AS a
     GROUP BY a.AccountHolderId
       HAVING SUM(Balance) > @Number) AS acc
       ON ah.Id = acc.AccountHolderId
       ORDER BY LastName, FirstName

GO
EXECUTE usp_GetHoldersWithBalanceHigherThan 100
GO
--Problem 11.	Future Value Function
GO
CREATE FUNCTION ufn_CalculateFutureValue (@Sum DECIMAL(15,4), @YearlyInterestRate FLOAT, @NumberOfYear INT)
RETURNS DECIMAL(15, 4)
AS
BEGIN 
     RETURN @Sum * POWER(1 + @YearlyInterestRate, @NumberOfYear);   
END

    

--Problem 12.	Calculating Interest
GO
CREATE PROCEDURE usp_CalculateFutureValueForAccount (@AccountID INT, @Interest FLOAT)
AS 
        SELECT ah.Id,
               ah.FirstName, 
               ah.LastName, 
               a.Balance AS [Current Balance],
               dbo.ufn_CalculateFutureValue (Balance, @Interest, 5) AS [Balance in 5 years]
          FROM AccountHolders AS ah
          JOIN Accounts AS a 
            ON a.AccountHolderId = ah.Id
            WHERE a.Id = @AccountID

EXECUTE usp_CalculateFutureValueForAccount 1, 0.1
GO
--Problem 13.	*Scalar Function: Cash in User Games Odd Rows

GO
CREATE FUNCTION ufn_CashInUsersGames (@GameName NVARCHAR(MAX))
RETURNS TABLE
AS
    RETURN (
           WITH CTE_CashInRows (Cash, RowNumber)
            AS
            (SELECT ug.Cash,
                    ROW_NUMBER() OVER(ORDER BY ug.Cash DESC)
              FROM UsersGames AS ug
              JOIN Games AS g ON g.Id = ug.GameId 
             WHERE g.Name = @GameName)

             SELECT SUM(Cash) AS [SumCash]
             FROM CTE_CashInRows
             WHERE RowNumber % 2 = 1
     )

GO

SELECT * FROM dbo.ufn_CashInUsersGames ('Lily Stargazer');
SELECT * FROM dbo.ufn_CashInUsersGames ('Love in a mist');


