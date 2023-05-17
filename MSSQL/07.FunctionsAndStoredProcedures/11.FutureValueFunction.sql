CREATE FUNCTION ufn_CalculateFutureValue(@sum DECIMAL(8, 4), @rate FLOAT, @years INT)
RETURNS DECIMAL(8, 4)
AS
BEGIN
		DECLARE @result DECIMAL(8, 4)
		SET @result = @sum * (POWER((1 + @rate), @years))
		RETURN @result
END
GO

SELECT 'Initial sum: 1000, Yearly Interest rate: 10%, years: 5' AS Input
        ,dbo.ufn_CalculateFutureValue(1000, 0.1, 5) AS Output