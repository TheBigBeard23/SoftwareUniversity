CREATE FUNCTION ufn_CashInUsersGames(@gameName)
RETURNS TABLE
AS
RETURN
	SELECT SUM(r.Cash) AS SumCash
	  FROM
		(SELECT g.Name
		       ,ug.Cash
		       ,ROW_NUMBER() OVER(PARTITION BY @gameName ORDER BY ug.Cash DESC) AS RowNumber
		   FROM Games AS g
		   JOIN UsersGames AS ug
		     ON g.Id = ug.GameId
		  WHERE g.Name = @gameName) AS r
	 WHERE r.RowNumber % 2 != 0


	
