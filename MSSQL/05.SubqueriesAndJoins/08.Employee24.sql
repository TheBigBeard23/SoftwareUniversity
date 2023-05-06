Use SoftUni
SELECT e.EmployeeID
		,e.FirstName
		,CASE
			WHEN p.StartDate >= CAST('2005' AS DATE) THEN NULL
			ELSE p.Name 
		END AS ProjectName
FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep
ON e.EmployeeID = ep.EmployeeID
LEFT JOIN Projects AS p
ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24
