USE SoftUni

-- Problem 1.	Employee Address

SELECT TOP(5)e.EmployeeID, e.JobTitle, e.AddressID, a.AddressText
  FROM Employees AS e
JOIN Addresses AS a ON a.AddressID = e.AddressID
ORDER BY a.AddressID

--Problem 2.	Addresses with Towns

SELECT TOP(50) e.FirstName, e.LastName, t.Name, a.AddressText
  FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
JOIN Towns AS T ON a.TownID = t.TownID
ORDER BY e.FirstName, e.LastName 

--Problem 3.	Sales Employee

SELECT e.EmployeeID, e.FirstName, e.LastName, d.Name FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
ORDER BY e.EmployeeID

--Problem 4.	Employee Departments

SELECT TOP(5)e.EmployeeID, e.FirstName, e.Salary, d.Name FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.Salary > 15000
ORDER BY d.DepartmentID

--Problem 5.	Employees Without Project

SELECT TOP(3) e.EmployeeID, 
              e.FirstName
         FROM Employees AS e
    LEFT JOIN EmployeesProjects AS ep 
           ON e.EmployeeID = ep.EmployeeID
        WHERE ep.EmployeeID IS NULL
     ORDER BY e.EmployeeID 

-- Problem 6.	Employees Hired After

SELECT e.FirstName,
       e.LastName,
       e.HireDate,
       d.Name AS DeptName
  FROM Employees AS e
  JOIN 
(
SELECT DepartmentID, Name FROM Departments
 WHERE Name IN ('Sales', 'Finance')
) AS d
    ON d.DepartmentID = e.DepartmentID
 WHERE e.HireDate > '1.1.1999'
ORDER BY e.HireDate

--Problem 7.	Employees with Project
SELECT TOP(5) e.EmployeeID,
       e.FirstName,
       p.Name AS ProjectName
  FROM Employees AS e
  JOIN EmployeesProjects AS ep 
  ON   e.EmployeeID = ep.EmployeeID

  JOIN Projects AS p 
  ON p.ProjectID = ep.ProjectID

  WHERE p.StartDate > '2002.08.13' AND p.EndDate IS NULL 
  ORDER BY e.EmployeeID

-- Problem 8.	Employee 24

SELECT e.EmployeeID,
       e.FirstName, 
       CASE 
           WHEN p.StartDate > '2005'THEN NULL
           ELSE p.Name 
       END AS ProjectName 
  FROM Employees AS e
JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p ON p.ProjectID = ep.ProjectID
WHERE e.EmployeeID = 24

--Problem 9.	Employee Manager

  SELECT e.EmployeeID,
         e.FirstName, 
         e.ManagerID, 
         m.FirstName AS ManagerName 
    FROM Employees AS e
    JOIN Employees AS m ON m.EmployeeID = e.ManagerID
   WHERE e.ManagerID IN (3, 7)
ORDER BY e.EmployeeID

--Problem 10.	Employee Summary

SELECT TOP(50) e.EmployeeID,
               CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName,
               CONCAT(m.FirstName, ' ', m.LastName) AS ManagerName,
               d.Name AS DepartmentName
          FROM Employees AS e
          JOIN Employees AS m ON m.EmployeeID = e.ManagerID
          JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
      ORDER BY e.EmployeeID

--Problem 11.	Min Average Salary

SELECT TOP(1) AVG(Salary) FROM Employees
GROUP BY DepartmentID
ORDER BY AVG(Salary) ASC
SELECT * FROM Employees


--Problem 12.	Highest Peaks in Bulgaria

USE Geography

SELECT c.CountryCode, m.MountainRange, p.PeakName, p.Elevation
  FROM Countries AS c
JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
JOIN Mountains AS m ON m.Id = mc.MountainId
JOIN Peaks AS p ON p.MountainId = m.Id
WHERE c.CountryCode = 'BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC

--Problem 13.	Count Mountain Ranges

SELECT cm.CountryCode, COUNT(cm.MountainRange) AS MountainRanges
FROM (
SELECT c.CountryCode, m.MountainRange
  FROM Countries AS c
JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
JOIN Mountains AS m ON m.Id = mc.MountainId
WHERE c.CountryCode IN ('BG', 'RU', 'US')) AS cm
GROUP BY cm.CountryCode

--Problem 14.	Countries with Rivers

SELECT TOP(5) c.CountryName, r.RiverName 
         FROM Countries AS c
         LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
         LEFT JOIN Rivers AS r ON r.Id = cr.RiverId
        WHERE c.ContinentCode = 'AF'
     ORDER BY c.CountryName

--Problem 15.	*Continents and Currencies

WITH CTE_ContUsage (ContinentCode, CurrencyCode, CurrencyUsage) AS (
SELECT c.ContinentCode, c.CurrencyCode, COUNT(c.CurrencyCode) AS CurrencyUsage
FROM Countries AS c
GROUP BY ContinentCode, c.CurrencyCode )

SELECT cm.ContinentCode, ctu.CurrencyCode, cm.CurrencyUsage
FROM (
    SELECT ContinentCode, 
           MAX(CurrencyUsage) AS CurrencyUsage
      FROM CTE_ContUsage
  GROUP BY ContinentCode) AS cm  
    JOIN CTE_ContUsage AS ctu 
    ON cm.ContinentCode = ctu.ContinentCode AND cm.CurrencyUsage = ctu.CurrencyUsage
    ORDER BY cm.ContinentCode



    -----

    WITH CCYContUsage_CTE (ContinentCode, CurrencyCode, CurrencyUsage) AS (
  SELECT ContinentCode, CurrencyCode, COUNT(CountryCode) AS CurrencyUsage
  FROM Countries 
  GROUP BY ContinentCode, CurrencyCode
  HAVING COUNT(CountryCode) > 1  
)
SELECT ContMax.ContinentCode, ccy.CurrencyCode, ContMax.CurrencyUsage 
  FROM
  (SELECT ContinentCode, MAX(CurrencyUsage) AS CurrencyUsage
   FROM CCYContUsage_CTE 
   GROUP BY ContinentCode) AS ContMax
JOIN CCYContUsage_CTE AS ccy 
ON (ContMax.ContinentCode = ccy.ContinentCode AND ContMax.CurrencyUsage = ccy.CurrencyUsage)
ORDER BY ContMax.ContinentCode

--Problem 16.	Countries without any Mountains

SELECT COUNT(c.CountryCode) AS CountryCode FROM Countries AS c 
LEFT JOIN  MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
WHERE mc.CountryCode IS NULL

--Problem 17.	Highest Peak and Longest River by Country

SELECT TOP(5) c.CountryName, MAX(p.Elevation), MAX(r.Length) FROM Countries AS c
JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
JOIN Mountains AS m ON m.Id = mc.MountainId
JOIN Peaks AS p ON p.MountainId = m.Id
JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
JOIN Rivers AS r ON r.Id = cr.RiverId
GROUP BY c.CountryName
ORDER BY MAX(p.Elevation) DESC, MAX(r.Length) DESC, c.CountryName

--Problem 18.	* Highest Peak Name and Elevation by Country

WITH CTE_PeaksMountains (Country, PeakName, Elevation, Montain)
AS(
   SELECT c.CountryName, p.PeakName, p.Elevation, m.MountainRange
     FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
LEFT JOIN Peaks AS p ON p.MountainId = m.Id
)

SELECT TOP(5) f.Country, 
       ISNULL(cte.PeakName, '(no highest peak)') AS [Highest Peak Name],
       ISNULL(f.[Highest Peak Elevation], '0') AS [Highest Peak Elevation],
       ISNULL(cte.Montain, '(no mountain)') AS [Mountain]
  FROM 
(SELECT Country, MAX(Elevation) AS [Highest Peak Elevation]
   FROM CTE_PeaksMountains
   GROUP BY Country) AS f
   LEFT JOIN CTE_PeaksMountains AS cte 
   ON f.Country = cte.Country  AND f.[Highest Peak Elevation] = cte.Elevation
ORDER BY f.Country, f.[Highest Peak Elevation]

----

-- 18 RANK
SELECT TOP 5
       Country,
       ISNULL(PeakName, '(no highest peak)') AS [Highest Peak Name],
	   ISNULL(PeakElevation, 0) AS [Highest Peak Elevation],
	   ISNULL([Mountain], '(no mountain)') AS [Mountain]
       FROM
       (
         SELECT c.CountryName AS Country,
                p.PeakName AS PeakName,
         	    p.Elevation AS PeakElevation,
         	    m.MountainRange AS [Mountain],
                RANK() OVER(PARTITION BY m.MountainRange ORDER BY p.Elevation DESC) AS [Rank]
           FROM Countries AS c
      LEFT JOIN MountainsCountries AS mc
             ON mc.CountryCode = c.CountryCode
      LEFT JOIN Peaks AS p
             ON p.MountainId = mc.MountainId
      LEFT JOIN Mountains AS m
      ON m.Id = p.MountainId
       ) AS aa
 WHERE [Rank] = 1
 ORDER BY Country,
          PeakName
