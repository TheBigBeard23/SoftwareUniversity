CREATE OR ALTER PROC usp_GetHoldersWithBalanceHigherThan(@number DECIMAL(15, 2))
AS
BEGIN

		SELECT  ah.FirstName
			   ,ah.LastName
		  FROM Accounts AS a
          JOIN AccountHolders AS ah
            ON a.AccountHolderId = ah.Id
      GROUP BY ah.FirstName
              ,ah.LastName
        HAVING SUM(a.Balance) > 60000
      ORDER BY ah.FirstName
		      ,ah.LastName

END

EXEC usp_GetHoldersWithBalanceHigherThan 60000
