CREATE DATABASE [SoftUni]
GO

USE [SoftUni]
GO

CREATE TABLE [Towns] (
[Id]	INT PRIMARY KEY IDENTITY (1, 1),
[Name]	NVARCHAR(20) NOT NULL
)
GO

CREATE TABLE [Addresses] (
[Id]			INT PRIMARY KEY IDENTITY (1, 1),
[AddressText]	NVARCHAR(30) NOT NULL,
[TownId]		INT FOREIGN KEY REFERENCES [Towns](Id)
)
GO

CREATE TABLE [Departments] (
[Id]	INT PRIMARY KEY IDENTITY (1, 1),
[Name]	NVARCHAR(30) NOT NULL
)
GO

CREATE TABLE [Employees] (
[Id]			INT PRIMARY KEY IDENTITY (1, 1),
[FirstName]		NVARCHAR(20) NOT NULL,
[MiddleName]	NVARCHAR(20),
[LastName]		NVARCHAR(20) NOT NULL,
[JobTitle]		NVARCHAR(20) NOT NULL,
[DepartmentId]	INT FOREIGN KEY REFERENCES [Departments](Id),
[HireDate]		DATETIME2,
[Salary]		DECIMAL,
[AddressId]		INT FOREIGN KEY REFERENCES [Addresses](Id)
)
GO

INSERT INTO [Towns]
		([Name])
VALUES	    
		('Sofia'),
	    ('Plovdiv'),
	    ('Varna'),
	    ('Burgas')
GO

INSERT INTO [Addresses]
		([AddressText],[TownId])
VALUES 
		('ул. „Борис Сарафов“ 32', 1),
		('ул. „Петър Стоев“ 115', 2),
		('ул. „Георги Бенковски“ 99', 3),
		('ул. „Здраве“ 23', 4),
		('бул. „Владислав Варненчик“ 115', 3)
GO

INSERT INTO [Departments]
		([Name])
VALUES	   
		('Engineering'),
	    ('Sales'),
	    ('Marketing'),
	    ('Software Development'),
	    ('Quality Assurance')
GO

INSERT INTO [Employees]
	    ([FirstName], [MiddleName], [LastName],
	    [JobTitle], [DepartmentId], [HireDate],
	    [Salary], [AddressId])
VALUES	   
		('Dimitar', 'Dimitrov', 'Dimitrov', 'NET Developer', 4, '2013-02-01', 3500.00, 1),
	    ('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 10000.00, 3),
	    ('Maria', 'Marinova', 'Petrova', 'JS Developer', 5, '2016-08-28', 6000.25, 2),
	    ('Georgi', 'Georgiev', 'Dimitrov', 'JAVA Developer', 2, '2007-12-09', 8000.00, 4),
	    ('Ivan', 'Georgiev', 'Ivanov', 'QA', 3, '2016-08-28', 7000.88, 5)
