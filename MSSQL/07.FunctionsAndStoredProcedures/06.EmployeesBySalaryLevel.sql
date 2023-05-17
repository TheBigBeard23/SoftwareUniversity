CREATE OR ALTER PROC usp_EmployeesBySalaryLevel(@level VARCHAR(10))
    AS
 BEGIN
      SELECT e.FirstName
	    ,e.LastName
	    FROM Employees 
		  AS e
	   WHERE dbo.ufn_GetSalaryLevel(e.Salary) = @level
   END
    GO

  EXEC usp_EmployeesBySalaryLevel high

	
