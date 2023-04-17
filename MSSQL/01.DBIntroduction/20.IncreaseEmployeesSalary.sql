
UPDATE [Employees]
SET    [Salary] += [Salary] * 0.10
GO

SELECT [Salary]
FROM   [Employees]
