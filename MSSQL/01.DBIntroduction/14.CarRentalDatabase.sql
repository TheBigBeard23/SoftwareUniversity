
CREATE DATABASE [CarRental]

GO

USE [CarRental]

GO

CREATE TABLE [Categories] (
[Id]			INT PRIMARY KEY IDENTITY (1, 1),
[CategoryName]  NVARCHAR(50) UNIQUE NOT NULL,
[DailyRate]		DECIMAL NOT NULL,
[WeeklyRate]	DECIMAL NOT NULL,
[MonthlyRate]	DECIMAL NOT NULL,
[WeekendRate]	DECIMAL NOT NULL
)

GO

CREATE TABLE [Cars] (
[Id]			INT PRIMARY KEY IDENTITY (1, 1),
[PlateNumber]   NVARCHAR(10) UNIQUE NOT NULL,
[Manufacturer]	NVARCHAR(20) NOT NULL,
[Model]			NVARCHAR(20) NOT NULL,
[CarYear]		DATETIME2 NOT NULL,
[CategoryId]	INT FOREIGN KEY REFERENCES [Categories](Id),
[Doors]			INT NOT NULL,
[Picture]		VARBINARY(MAX),
[Condition]		NVARCHAR(10),
[Available]		BIT NOT NULL
)

GO

CREATE TABLE [Employees] (
[Id]		   INT PRIMARY KEY IDENTITY (1,1),
[FirstName]	   NVARCHAR(20) NOT NULL,
[LastName]	   NVARCHAR(20) NOT NULL,
[Title]		   NVARCHAR(20),
[Notes]		   NVARCHAR(MAX)
)

GO

CREATE TABLE [Customers] (
[Id]					INT PRIMARY KEY IDENTITY (1,1),
[DriverLicenceNumber]   INT NOT NULL,
[FullName]				NVARCHAR(50) NOT NULL,
[Address]				NVARCHAR(50),
[City]					NVARCHAR(20) NOT NULL,
[ZIPCode]				INT,
[Notes]					NVARCHAR(MAX)
)

GO

CREATE TABLE [RentalOrders] (
[Id]					INT PRIMARY KEY IDENTITY (1,1),
[EmployeeId]			INT FOREIGN KEY REFERENCES [Employees](Id),
[CustomerId]			INT FOREIGN KEY REFERENCES [Customers](Id),
[CarId]					INT FOREIGN KEY	REFERENCES [Cars](Id),
[TankLevel]				DECIMAL		NOT NULL,
[KilometrageStart]		INT			NOT NULL,
[KilometrageEnd]		INT			NOT NULL,
[TotalKilometrage]		INT,
[StartDate]				DATETIME2	NOT NULL,
[EndDate]				DATETIME2	NOT NULL,
[TotalDays]				INT,
[RateApplied]			DECIMAL,
[TaxRate]				DECIMAL,
[OrderStatus]			NVARCHAR(10),
[Notes]					NVARCHAR(MAX)
)

GO 

INSERT INTO [Categories] 
			([CategoryName], [DailyRate], [WeeklyRate], [MonthlyRate], [WeekendRate])
VALUES		
			('Cars', 50.4, 500.2, 2000.3, 200.0),
			('El-cars', 40.4, 400.2, 1500.2, 150.0),
			('Cargo', 100.3, 600.2, 6000.2, 500.9)

GO

INSERT INTO [Cars]
			([PlateNumber], [Manufacturer], [Model], [CarYear], [CategoryId], [Doors], [Picture], [Condition], [Available])
VALUES
			('9999', 'Mercedes', 'G-Class', '2020', 1, 5, NULL, NULL, 1),
			('6666', 'Tesla', 'S-Model', '2019', 2, 5, NULL, NULL, 1),
			('1313', 'VW', 'Transporter', '2017', 3, 4, NULL, NULL, 0)

GO

INSERT INTO [Employees]
			([FirstName], [LastName], [Title], [Notes])
VALUES 
			('Kiro', 'Kirov', NULL, NULL),
			('Pesho', 'Peshev', NULL, NULL),
			('Gosho', 'Goshov', NULL, NULL)

GO

INSERT INTO [Customers]
			([DriverLicenceNumber], [FullName], [Address], [City], [ZIPCode], [Notes])
VALUES 
			('12345', 'Mike', NULL, 'London', NULL, NULL),
			('123456', 'Jon', NULL, 'New York', NULL, NULL),
			('1234567', 'Eric', NULL, 'Los Angeles', NULL, NULL)

GO

INSERT INTO [RentalOrders]
			([EmployeeId], [CustomerId], [CarId], [TankLevel], [KilometrageStart], [KilometrageEnd], 
			[TotalKilometrage], [StartDate], [EndDate], [TotalDays], [RateApplied], [TaxRate], 
			[OrderStatus], [Notes])
VALUES
			(1, 1, 1, 50, 0, 320, 198000, '2010-05-10', '2010-05-15', 5, NULL, NULL, NULL, NULL),
			(2, 2, 2, 50, 0, 260, 35682, '2012-11-15', '2012-11-21', 6, NULL, NULL, NULL, NULL),
			(3, 3, 3, 50, 0, 220, 67820, '2014-08-31', '2014-09-01', 1, NULL, NULL, NULL, NULL)

