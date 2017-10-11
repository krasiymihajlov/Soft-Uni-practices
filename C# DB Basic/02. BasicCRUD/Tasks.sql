--TASK 2 Find All Information About Departments
SELECT * FROM Departments

--TASK 3. Find all Department Names

SELECT Name 
  FROM Departments

--TASK 4. Find Salary of Each Employee

SELECT FirstName, LastName, Salary FROM Employees

--TASK 5. Find Full Name of Each Employee

SELECT FirstName, MiddleName, LastName FROM Employees

--TASK 6. Find Email Address of Each Employee

SELECT CONCAT(FirstName, '.', LastName, '@softuni.bg') AS [Full Email Address] 
  FROM Employees

--TASK 7. Find All Different Employee’s Salaries

SELECT DISTINCT Salary 
  FROM Employees

--TASK 8. Find all Information About Employees

SELECT * FROM Employees
 WHERE JobTitle = 'Sales Representative'

-- TASK 9. Find Names of All Employees by Salary in Range

SELECT FirstName, LastName, JobTitle 
  FROM Employees
 WHERE Salary BETWEEN 20000 AND 30000

 --TASK 10. Find Names of All Employees 

 SELECT CONCAT(FirstName, ' ', MiddleName, ' ', LastName) AS [Full Name]
   FROM Employees
  WHERE Salary = 25000 OR Salary = 14000 OR Salary = 12500 OR Salary = 23600  

--TASK 11. Find All Employees Without Manager

SELECT FirstName, LastName
  FROM Employees
 WHERE ManagerID IS NULL

 --TASK 12. Find All Employees with Salary More Than 50000

  SELECT FirstName, LastName, Salary
    FROM Employees
   WHERE Salary > 50000
ORDER BY Salary DESC

--TASK 13. Find 5 Best Paid Employees.

SELECT TOP 5 FirstName, LastName 
      FROM Employees
  ORDER BY Salary DESC

--TASK 14. Find All Employees Except Marketing

SELECT FirstName, LastName
  FROM Employees
 WHERE DepartmentID <> 4

 --TASK 15. Sort Employees Table

 SELECT * FROM Employees
 ORDER BY Salary DESC, FirstName ASC, LastName DESC, MiddleName ASC 

 --TASK 16.	Create View Employees with Salaries
 GO

 CREATE VIEW V_EmployeesSalaries AS
 SELECT FirstName, LastName, Salary
   FROM Employees 

GO

--TASK 17.	Create View Employees with Job Titles

CREATE VIEW V_EmployeeNameJobTitle AS
SELECT CONCAT(FirstName, ' ', MiddleName, ' ', LastName) AS [Full Name], JobTitle AS [Job Title]
  FROM Employees

GO
SELECT * FROM V_EmployeeNameJobTitle

--TASK 18.	 Distinct Job Titles

SELECT DISTINCT JobTitle
  FROM Employees

--TASK 19.	Find First 10 Started Projects

SELECT TOP 10 * FROM Projects
ORDER BY StartDate , Name

--TASK 20.	 Last 7 Hired Employees

SELECT TOP 7 FirstName, LastName, HireDate
		FROM Employees
	ORDER BY HireDate DESC

--TASK 21.	Increase Salaries

UPDATE Employees
   SET Salary = Salary + Salary * 0.12
 WHERE DepartmentID = 1 OR DepartmentID = 2 OR DepartmentID = 4 OR DepartmentID = 11

SELECT Salary FROM Employees
SELECT * FROM Departments

--TASK 22. All Mountain Peaks

USE Geography
GO

  SELECT PeakName
    FROM Peaks
ORDER BY PeakName

--TASK 23. Biggest Countries by Population

SELECT TOP 30 CountryName, Population
      FROM Countries
     WHERE ContinentCode = 'EU'
  ORDER BY Population DESC, CountryName ASC

--TASK 24. *Countries and Currency (Euro / Not Euro)

SELECT CountryName, CountryCode, Currency = 
	CASE
		WHEN CurrencyCode = 'EUR' THEN 'Euro'
		ELSE 'Not Euro'
	END
  FROM Countries
ORDER BY CountryName

--TASK 25. All Diablo Characters

USE Diablo
GO

  SELECT Name 
    FROM Characters
ORDER BY Name


