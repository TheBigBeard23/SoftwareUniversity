CREATE OR ALTER PROC usp_DeleteEmployeesFromDepartment(@departmentId INT)
AS
BEGIN
		DELETE FROM EmployeesProjects
			  WHERE EmployeeID IN (
					SELECT EmployeeID
					FROM Employees
					WHERE DepartmentID = @departmentId)

			 UPDATE Employees
			    SET ManagerID = NULL
			  WHERE ManagerID IN ( 
				    SELECT EmployeeID
				    FROM Employees
				    WHERE DepartmentID = @departmentId)

	    ALTER TABLE Departments
	   ALTER COLUMN ManagerId INT

	         UPDATE Departments
				SET ManagerID = NULL
			  WHERE DepartmentID = @departmentId

	    DELETE FROM Employees
		      WHERE DepartmentID = @departmentId

		DELETE FROM Departments
		      WHERE DepartmentID = @departmentId

			 SELECT COUNT(*)
			   FROM Employees
			  WHERE DepartmentID = @departmentId

END
 
BEGIN TRANSACTION

EXEC usp_DeleteEmployeesFromDepartment 7

SELECT * 
  FROM Employees AS e
  JOIN Departments AS d
    ON e.DepartmentID = d.DepartmentID

ROLLBACK