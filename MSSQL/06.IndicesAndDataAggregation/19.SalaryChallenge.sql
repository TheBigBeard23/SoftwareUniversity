    SELECT TOP(10) e.FirstName
                  ,e.LastName
	          ,e.DepartmentID
      FROM (SELECT e.DepartmentID
	          ,AVG(e.Salary) 
		AS AvgSalary
	      FROM Employees 
      	        AS e
	  GROUP BY e.DepartmentID) 
	AS a,
	   Employees 
        AS e
     WHERE e.DepartmentID = a.DepartmentID
       AND e.Salary > a.AvgSalary
  ORDER BY e.DepartmentID
	            
