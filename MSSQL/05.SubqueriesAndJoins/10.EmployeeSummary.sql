     USE SoftUni
  SELECT e.EmployeeID
         ,CONCAT(e.FirstName, ' ', e.MiddleName, ' ',  e.LastName) AS EmployeeName
	     ,CONCAT(em.FirstName, ' ', em.MiddleName, ' ',  em.LastName) AS ManagerName
		 ,d.Name
    FROM Employees AS e
    JOIN Employees AS em
      ON em.EmployeeID = e.ManagerID
	JOIN Departments AS d
	  ON d.DepartmentID = e.DepartmentID
ORDER BY e.EmployeeID