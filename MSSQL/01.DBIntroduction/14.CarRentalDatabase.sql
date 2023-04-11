CREATE DATABASE [CarRental]

GO

USE [CarRental]

GO

CREATE TABLE [Categories] (
[Id]			INT PRIMARY KEY IDENTITY (1, 1),
[CategoryName]  NVARCHAR(50) NOT NULL,
[DailyRate]		DECIMAL NOT NULL,
[WeeklyRate]	DECIMAL NOT NULL,
[MonthlyRate]	DECIMAL NOT NULL,
[WeekendRate]	DECIMAL NOT NULL
)

GO

CREATE TABLE [Cars] (
[Id]			INT PRIMARY KEY IDENTITY (1, 1),
[PlateNumber]   NVARCHAR(10) NOT NULL,
[Manufacturer]	NVARCHAR(20) NOT NULL,
[Model]			NVARCHAR(10) NOT NULL,
[CarYear]		DATETIME2 NOT NULL,
[CategoryId]	INT FOREIGN KEY REFERENCES [Categories](Id),
[Doors]			INT,
[Picture]		VARBINARY(MAX),
[Condition]		NVARCHAR(10),
[Available]		BIT
)
