
UPDATE [Employees]
Set    [Salary] += [Salary] * 0.10
GO

SELECT [Salary]
FROM   [Employees]
