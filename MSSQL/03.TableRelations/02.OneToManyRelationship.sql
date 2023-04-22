
CREATE TABLE Manufacturers(
[ManufacturerID] INT PRIMARY KEY IDENTITY,
[Name]			 VARCHAR(15) NOT NULL,
[EstablishedOn]  DATETIME2 NOT NULL)

GO

CREATE TABLE Models(
[ModelID]	INT PRIMARY KEY NOT NULL,
[Name]		VARCHAR(20) NOT NULL,
[ManufacturerID] INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID))

GO

INSERT INTO Manufacturers([Name],[EstablishedOn])
VALUES	   ('BMW', '1916/03/17'),
		   ('Tesla', '2003/01/01'),
		   ('Lada', '1966/05/01')

GO

INSERT INTO Models([ModelID], [Name], [ManufacturerID])
VALUES      (101, 'X1', 1),
			(102, 'i6', 1),
			(103, 'Model S', 2),
			(104, 'Model X', 2),
			(105, 'Model 3', 2),
			(106, 'Nova', 3)
