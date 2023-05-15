CREATE OR ALTER PROC usp_GetEmployeesFromTown(@town VARCHAR(50))
    AS
 BEGIN
       SELECT e.FirstName
	         ,e.LastName
	     FROM Employees AS e
	     JOIN Addresses AS a
	       ON e.AddressID = a.AddressID
	     JOIN Towns AS t
	       ON a.TownID = t.TownID
	    WHERE t.[Name] = @town
   END
    GO

  EXEC usp_GetEmployeesFromTown Sofia
