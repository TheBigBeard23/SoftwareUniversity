CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(MAX), @word NVARCHAR(MAX))
RETURNS BIT
AS
BEGIN
		DECLARE @counter INT = 1;
		DECLARE @crnLetter CHAR;

		WHILE(@counter <= LEN(@word))
		BEGIN
				SET @crnLetter = SUBSTRING(@word, @counter, 1);

				DECLARE @charIndex INT = CHARINDEX(@crnLetter, @setOfLetters)

				IF(@charIndex <= 0)
				BEGIN
						RETURN 0;
				END

				SET @counter += 1;
		END

		RETURN 1;
END
GO

SELECT 'asdjhpweublr' AS SetOfLetters
       ,e.FirstName AS Word
       ,dbo.ufn_IsWordComprised('asdjhpweublr', e.FirstName) AS Result
  FROM Employees 
    AS e
