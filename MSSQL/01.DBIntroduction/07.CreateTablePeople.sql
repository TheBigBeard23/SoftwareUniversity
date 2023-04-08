USE Minions

CREATE TABLE [People](
[Id] INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(200) NOT NULL,
[Picture] VARBINARY(MAX),
[Height] DECIMAL(3,2),
[Weight] DECIMAL(5,2),
[Gender] CHAR(1) NOT NULL,
[Birthdate] DATETIME NOT NULL,
[Biography] NVARCHAR(MAX)
)

INSERT INTO [People]([Name],[Gender],[Birthdate]) VALUES
('Vlad','m','1997-06-02'),
('Pesho','m','1998-11-13'),
('Petko','m','1995-03-23'),
('Misho','m','1994-02-13'),
('Dimo','m','1987-01-11')
