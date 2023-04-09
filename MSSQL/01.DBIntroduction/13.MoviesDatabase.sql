CREATE DATABASE [Movies]

GO

USE [Movies]

GO

CREATE TABLE [Directors] (
[Id]			INT PRIMARY KEY IDENTITY (1, 1),
[DirectorName]  NVARCHAR(50) NOT NULL,
[Notes]			NVARCHAR(MAX)
)

GO

CREATE TABLE [Genres] (
[Id]			INT PRIMARY KEY IDENTITY (1, 1),
[GenreName]	    NVARCHAR(20) NOT NULL,
[Notes]		    NVARCHAR(MAX)
)

GO

CREATE TABLE [Categories] (
[Id]			INT PRIMARY KEY IDENTITY (1, 1),
[CategoryName]	NVARCHAR(20) NOT NULL,
[Notes]			NVARCHAR(MAX)
)

GO

CREATE TABLE [Movies](
[Id]		    INT PRIMARY KEY IDENTITY (1, 1),
[Title]		    NVARCHAR(30) NOT NULL,
[DirectorId]    INT FOREIGN KEY REFERENCES [Directors](Id),
[CopyrightYear] DATETIME2,
[Length]		NVARCHAR(10),
[GenreId]		INT FOREIGN KEY REFERENCES [Genres](Id),
[CategoryId]	INT FOREIGN KEY REFERENCES [Categories](Id),
[Rating]		DECIMAL(5, 2),
[Notes]			NVARCHAR(MAX)
)

GO

INSERT INTO [Directors]([DirectorName])
VALUES 
('Jorge'),
('Eric'),
('Jones')

GO

INSERT INTO [Genres] ([GenreName])
VALUES 
('Adventure'),
('Drama'),
('Fantasy'),
('Action'),
('Mystery')

GO

INSERT INTO [Categories]([CategoryName])
VALUES
('Sports'),
('Drama'),
('Musicals'),
('Fantasy')

GO

INSERT INTO [Movies]
([Title], [Length], [Rating], [DirectorId], [CategoryId], [GenreId])
VALUES
('The Night Agent', '2h 16m', 4.60, '1', '4', '4'),
('John Wick: Chapter 4', '1h 30m', 5.60, '2', '4', '4'),
('The Night Agent', '2h 30m', 4.40, '3', '4', '4')

SELECT * FROM [Movies]