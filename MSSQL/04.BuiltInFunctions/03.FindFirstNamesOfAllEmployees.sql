   USE SoftUni

SELECT FirstName
  FROM Employees
 WHERE DepartmentID IN (3, 10) AND
	   HireDate BETWEEN '1995-01-01' AND '2005-01-01'