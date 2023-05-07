
SELECT MIN(a.AverageSalary) AS MinAverageSalay
  FROM (SELECT AVG(e.Salary) AS AverageSalary
          FROM Employees AS e
      GROUP BY e.DepartmentID) AS a

