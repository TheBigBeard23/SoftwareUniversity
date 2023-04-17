USE [Hotel]
GO

UPDATE [Payments]
SET    [TaxRate] -= 0.03
GO

SELECT [TaxRate]
FROM   [Payments]
