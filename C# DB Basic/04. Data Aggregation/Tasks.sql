USE Gringotts
GO

--Problem 1.	Records’ Count

SELECT COUNT(Id) AS Count
  FROM WizzardDeposits

--Problem 2.	Longest Magic Wand

SELECT MAX(MagicWandSize) AS [LongestMagicWand]
  FROM WizzardDeposits

--Problem 3.	Longest Magic Wand per Deposit Groups

  SELECT w.DepositGroup, MAX(w.MagicWandSize) AS [LongestMagicWand]
    FROM WizzardDeposits AS w
GROUP BY w.DepositGroup

--Problem 4.	* Smallest Deposit Group per Magic Wand Size

  SELECT TOP 2 w.DepositGroup
    FROM WizzardDeposits AS w
GROUP BY w.DepositGroup
ORDER BY AVG(w.MagicWandSize)

SELECT * FROM WizzardDeposits

--Problem 5.	Deposits Sum

  SELECT w.DepositGroup, SUM(w.DepositAmount) AS [TotalSum]
    FROM WizzardDeposits AS w
GROUP BY w.DepositGroup

--Problem 6.	Deposits Sum for Ollivander Family

SELECT w.DepositGroup, SUM(w.DepositAmount) AS [TotalSum]
  FROM WizzardDeposits AS w
 WHERE w.MagicWandCreator = 'Ollivander family'
 GROUP BY w.DepositGroup

 --Problem 7.	Deposits Filter

  SELECT w.DepositGroup, SUM(w.DepositAmount) AS [TotalSum]
  FROM WizzardDeposits AS w
 WHERE w.MagicWandCreator = 'Ollivander family'
 GROUP BY w.DepositGroup
 HAVING SUM(w.DepositAmount) < 150000 
 ORDER BY SUM(w.DepositAmount) DESC

 --Problem 8.	 Deposit Charge

  SELECT w.DepositGroup, w.MagicWandCreator, MIN(w.DepositCharge) AS [MinDepositCharge]
    FROM WizzardDeposits AS w
GROUP BY w.DepositGroup , w.MagicWandCreator
ORDER BY w.MagicWandCreator, w.DepositGroup

--Problem 9.	Age Groups

SELECT w.AgeGroup, 
	COUNT(*) 
	FROM 
	(SELECT
		CASE 
			WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
			WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
			WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
			WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
			WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
			WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
			WHEN Age >= 61 THEN '[61+]'
		END AS AgeGroup
  FROM WizzardDeposits ) AS w  
GROUP BY w.AgeGroup

--Problem 10.	First Letter

SELECT SUBSTRING(w.FirstName, 1, 1) AS [FirstLetter]
 FROM WizzardDeposits AS w
 WHERE w.DepositGroup = 'Troll Chest'
 GROUP BY  SUBSTRING(w.FirstName, 1, 1)
 ORDER BY  FirstLetter

 --Problem 11.	Average Interest 

 SELECT w.DepositGroup, w.IsDepositExpired ,AVG(w.DepositInterest) 
 FROM WizzardDeposits AS w
 WHERE  w.DepositStartDate > '1985-01-01'
 GROUP BY w.DepositGroup, w.IsDepositExpired
 ORDER BY w.DepositGroup DESC, w.IsDepositExpired

 --Problem 12.	* Rich Wizard, Poor Wizard

 USE Gringotts

 SELECT SUM(w.[Difference]) AS [SumDifference]
 FROM (
     SELECT FirstName, DepositAmount,
     LEAD(FirstName, 1) OVER (ORDER BY Id) AS [Guest Wizzard],
     LEAD(DepositAmount, 1) OVER (ORDER BY Id) AS [Guest Wizard Deposit],
     DepositAmount - LEAD(DepositAmount, 1) OVER (ORDER BY Id) AS [Difference]
     FROM WizzardDeposits ) AS w

--Problem 13.	Departments Total Salaries

USE SoftUni
GO

   SELECT DepartmentID, SUM(Salary) AS TotalSalary
    FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID

--Problem 14.	Employees Minimum Salaries

SELECT DepartmentID, MIN(Salary) AS MinimumSalary 
  FROM Employees
 WHERE HireDate > '2000-01-01'
 GROUP BY DepartmentID
 HAVING DepartmentID IN (2, 5, 7)

 --Problem 15.	Employees Average Salaries

 USE SoftUni
 GO

 SELECT *
   INTO MoreThanSalary
   FROM Employees
  WHERE Salary > 30000

DELETE FROM MoreThanSalary
 WHERE ManagerID = 42

UPDATE MoreThanSalary
   SET Salary += 5000
 WHERE DepartmentID = 1

  SELECT DepartmentID, AVG(Salary) AS AverageSalary
    FROM MoreThanSalary
GROUP BY DepartmentID

--Problem 16.	Employees Maximum Salaries

SELECT DepartmentID, MAX(Salary) AS [MaxSalary]
FROM Employees
GROUP BY DepartmentID
HAVING Salary NOT BETWEEN 30000 AND 70000

--Problem 17.	Employees Count Salaries

SELECT COUNT(Salary) AS [Count]
FROM Employees
WHERE ManagerID IS NULL
GROUP BY ManagerID

--3rd Highest Salary
USE SoftUni

  SELECT HS.DepartmentID, HS.Salary
   FROM(
  SELECT DepartmentID, Salary,
           DENSE_RANK()
           OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS [Rank]
    FROM Employees    
GROUP BY DepartmentID, Salary) AS HS
WHERE [Rank] = 3

--Problem 19.	**Salary Challenge

SELECT TOP(10) Employees.FirstName, Employees.LastName, Employees.DepartmentID
FROM (
 SELECT DepartmentID, AVG(Salary) AS [AvgSalary]
 FROM Employees 
 GROUP BY DepartmentID
) AS DS
INNER JOIN Employees ON Employees.DepartmentID = DS.DepartmentID AND Employees.Salary > DS.AvgSalary
