USE Bank
GO
--Problem 1.	Create Table Logs

--CREATE TABLE Logs (
--    LogId INT IDENTITY NOT NULL ,
--    AccountId INT, 
--    OldSum DECIMAL(15, 2) , 
--    NewSum DECIMAL(15, 2)
--)

GO
CREATE TRIGGER tr_SumAccountChanges ON Accounts FOR UPDATE
AS
BEGIN
    DECLARE @AccountId INT
    SET @AccountId = (SELECT i.Id FROM inserted AS i)
    DECLARE @OldSum DECIMAL(15, 2)
    SET @OldSum = (SELECT i.Balance FROM deleted AS i)
    DECLARE @NewSum DECIMAL(15, 2)
    SET @NewSum = (SELECT i.Balance FROM inserted AS i) 

    IF(@OldSum != @NewSum)
    BEGIN
        INSERT INTO Logs VALUES
        (@AccountId, @OldSum, @NewSum)
    END
END   

--Problem 2.	Create Table Emails

--CREATE TABLE NotificationEmails(
--    Id INT IDENTITY,
--    Recipient INT, 
--    Subject NVARCHAR(100), 
--    Body NVARCHAR(MAX)
--)

GO
CREATE TRIGGER tr_CreateNewEmail ON Logs FOR INSERT
AS
BEGIN
    DECLARE @Recipient INT
    SET @Recipient = (SELECT i.AccountId FROM inserted AS i)

    DECLARE @Subject NVARCHAR(100)
    SET @Subject = CONCAT('Balance change for account: ', @Recipient)
    DECLARE @OldSum DECIMAL(15, 2)
    SET @OldSum = (SELECT d.OldSum FROM inserted AS d)
    DECLARE @NewSum DECIMAL(15, 2)
    SET @NewSum = (SELECT d.NewSum FROM inserted AS d)

    DECLARE @Body NVARCHAR(MAX)
    SET @Body = CONCAT('On ', 
                        GETDATE(),
                        ' your balance was changed from ',
                        @OldSum,
                         ' to ',
                         @NewSum,
                         '.')
    INSERT INTO NotificationEmails VALUES
           (@Recipient, @Subject, @Body)    
END
--TESTS
INSERT INTO Logs VALUES
(2, 100, 200)

SELECT * FROM Logs
SELECT * FROM NotificationEmails

--Problem 3.	Deposit Money
GO
CREATE PROCEDURE usp_DepositMoney (@AccountId INT, @MoneyAmount DECIMAL(15, 4))
AS
    BEGIN TRANSACTION

    UPDATE Accounts
    SET Balance += @MoneyAmount
    WHERE Id = @AccountId

    IF(@@ROWCOUNT <> 1)
    BEGIN 
        RAISERROR('Invalid Account', 16, 1)
        ROLLBACK
        RETURN
    END

    COMMIT

-- TESTS
EXECUTE usp_DepositMoney 1, 10
SELECT * FROM Accounts

--Problem 4.	Withdraw Money
GO
CREATE PROCEDURE usp_WithdrawMoney (@AccountId INT, @MoneyAmount DECIMAL(15, 4))
AS
    BEGIN TRANSACTION 

    IF(@MoneyAmount < 0)
    BEGIN 
        RAISERROR('Error Transaction', 16, 1)
        ROLLBACK
        RETURN
    END
    UPDATE Accounts
    SET Balance -= @MoneyAmount
    WHERE Id = @AccountId

    IF(@@ROWCOUNT <> 1)
    BEGIN 
        RAISERROR('Invalid Accaunt', 16, 1)
        ROLLBACK
        RETURN
    END
    
    DECLARE @Balance DECIMAL(15, 4)
    SET @Balance = (SELECT Balance FROM Accounts WHERE Id = @AccountId)

    IF(@Balance < 0)
    BEGIN
        RAISERROR('Negative Amount', 16, 1)
        ROLLBACK
        RETURN
    END

    COMMIT

--Problem 5.	Money Transfer

GO
CREATE PROC usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount DECIMAL(15, 4)) 
AS
    BEGIN TRANSACTION 

    EXEC usp_WithdrawMoney @SenderId, @Amount

    EXEC usp_DepositMoney @ReceiverId, @Amount

    COMMIT

-- Problem 6.	Trigger
GO
USE Diablo
GO

--Problem 8.	Employees with Three Projects

USE SoftUni
GO
CREATE PROC usp_AssignProject(@EmploeeId INT, @ProjectId INT)
AS
    BEGIN TRANSACTION

     INSERT INTO EmployeesProjects VALUES
    (@EmploeeId, @ProjectId)

    DECLARE @ProjectCount INT
    SET @ProjectCount = (SELECT COUNT(EmployeeID) FROM EmployeesProjects WHERE @EmploeeId = EmployeeID)
    IF(@ProjectCount > 3)
    BEGIN
        RAISERROR('The employee has too many projects!', 16, 1)
        ROLLBACK
        RETURN
    END

    COMMIT


--Problem 9.	Delete Employees

CREATE TABLE Deleted_Employees(
    EmployeeId INT IDENTITY PRIMARY KEY NOT NULL, 
    FirstName NVARCHAR(50) NOT NULL, 
    LastName NVARCHAR(50) NOT NULL, 
    MiddleName NVARCHAR(50), 
    JobTitle NVARCHAR(50) NOT NULL, 
    DeparmentId INT NOT NULL, 
    Salary MONEY NOT NULL
)
    
GO
CREATE TRIGGER tr_Deleted_Employees ON Employees FOR DELETE
AS
   INSERT INTO Deleted_Employees 
   SELECT FirstName, LastName, MiddleName, JobTitle, DepartmentID, Salary FROM deleted



