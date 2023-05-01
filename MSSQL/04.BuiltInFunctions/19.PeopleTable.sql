
CREATE TABLE People(
[ID]        INT PRIMARY KEY IDENTITY,
[Name]      NVARCHAR(20),
[Birthdate] DATETIME2)

GO

INSERT INTO People(Name, Birthdate)
VALUES
      ('Jon', '1999-01-02')
	 ,('Bob', '1899-04-05')
	 ,('Alex', '2019-05-12')

GO

SELECT [Name]
       ,DATEDIFF(YEAR, Birthdate, GETDATE())[Age in Years]
	   ,DATEDIFF(MONTH, Birthdate, GETDATE())[Age in Months]
	   ,DATEDIFF(DAY, Birthdate, GETDATE())[Age in Days]
	   ,DATEDIFF(MINUTE, Birthdate, GETDATE())[Age in Minutes]
FROM People
