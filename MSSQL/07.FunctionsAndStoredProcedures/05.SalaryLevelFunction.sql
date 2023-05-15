CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS NVARCHAR(10)
   AS
BEGIN
       DECLARE @salaryLevel NVARCHAR(10)

	   IF(@salary < 30000)
	        SET @salaryLevel = 'Low'
	   ELSE IF(@salary <= 50000)
            SET @salaryLevel = 'Average'
	   ELSE SET @salaryLevel = 'High'

	   RETURN @salaryLevel
  END
   GO

  SELECT *
         ,dbo.ufn_GetSalaryLevel(e.Salary) AS SalaryLevel
    FROM 
          Employees 
	  AS  e
