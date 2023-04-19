USE [SoftUni]

SELECT 
CONCAT([FirstName], ' ', [MiddleName], ' ', [LastName]) AS [Full Name]
  FROM [Employees] AS e
 WHERE e.Salary IN (25000, 14000, 12500, 23600)
