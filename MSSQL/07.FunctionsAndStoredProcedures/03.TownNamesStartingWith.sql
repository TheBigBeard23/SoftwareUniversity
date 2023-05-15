CREATE OR ALTER PROC usp_GetTownsStartingWith(@str VARCHAR(50))
    AS
 BEGIN
	   SELECT [Name] 
	     FROM Towns
	    WHERE [Name] LIKE @str + '%'
   END
    GO

  EXEC usp_GetTownsStartingWith S
