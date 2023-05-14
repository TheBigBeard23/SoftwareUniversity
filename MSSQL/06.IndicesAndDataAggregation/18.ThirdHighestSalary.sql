SELECT r.DepartmentID
      ,r.Salary AS ThirdHighestSalary
  FROM
      (SELECT e.DepartmentID
	     ,e.Salary
             ,DENSE_RANK() OVER(PARTITION BY e.DepartmentID ORDER BY e.Salary DESC) AS SalaryRank
         FROM Employees 
           AS e
     GROUP BY e.DepartmentID
	     ,e.Salary) 
           AS r
 WHERE r.SalaryRank = 3
