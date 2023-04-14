CREATE DATABASE Hotel
GO

USE [Hotel]
GO

CREATE TABLE [Employees] (
[Id]			INT PRIMARY KEY IDENTITY,
[FirstName]     NVARCHAR(20) NOT NULL,
[LastName]      NVARCHAR(20) NOT NULL,
[Title]		    NVARCHAR(20),
[Notes]		    NVARCHAR(MAX)	
)
GO

CREATE TABLE [Customers] (
[AccountNumber]		INT PRIMARY KEY IDENTITY,
[FirstName]			NVARCHAR(20) NOT NULL,
[LastName]			NVARCHAR(20) NOT NULL,
[PhoneNumber]		VARCHAR(10) UNIQUE NOT NULL,
[EmergencyName]		NVARCHAR(20),
[EmergencyNumber]	VARCHAR(10),
[Notes]				NVARCHAR(MAX)
)
GO

CREATE TABLE [RoomStatus] (
[RoomStatus] NVARCHAR(20) PRIMARY KEY,
[Notes]		 NVARCHAR(MAX)
)
GO

CREATE TABLE [RoomTypes] (
[RoomType]	NVARCHAR(20) PRIMARY KEY,
[Notes]		NVARCHAR(MAX)
)
GO

CREATE TABLE [BedTypes] (
[BedType]	NVARCHAR(20) PRIMARY KEY,
[Notes]		NVARCHAR(MAX)
)
GO

CREATE TABLE [Rooms] (
[RoomNumber]	INT PRIMARY KEY IDENTITY,
[RoomType]		NVARCHAR(20) FOREIGN KEY REFERENCES [RoomTypes](RoomType),
[BedType]		NVARCHAR(20) FOREIGN KEY REFERENCES [BedTypes](BedType),
[Rate]			DECIMAL(5,2),
[RoomStatus]	NVARCHAR(20) FOREIGN KEY REFERENCES [RoomStatus](RoomStatus),
[Notes]			NVARCHAR(MAX)
)
GO

CREATE TABLE [Payments] (
[Id]					INT PRIMARY KEY IDENTITY,
[EmployeeId]			INT FOREIGN KEY REFERENCES [Employees](Id),
[PaymentDate]			DATETIME2		NOT NULL,
[AccountNumber]			INT FOREIGN KEY REFERENCES [Customers](AccountNumber),
[FirstDateOccupied]		DATETIME2		NOT NULL,
[LastDateOccupied]		DATETIME2		NOT NULL,
[TotalDays]				INT				NOT NULL,
[AmountCharged]			DECIMAL(10,2)	NOT NULL,
[TaxRate]				DECIMAL(3,2)	NOT NULL,
[TaxAmount]				DECIMAL(10,2)	NOT NULL,
[PaymentTotal]			DECIMAL(10,2)	NOT NULL,
[Notes]					NVARCHAR(MAX)
)
GO

CREATE TABLE [Occupancies] (
[Id]					INT PRIMARY KEY IDENTITY,
[EmployeeId]			INT FOREIGN KEY REFERENCES [Employees](Id),
[DateOccupied]			DATETIME2	NOT NULL,
[AccountNumber]			INT FOREIGN KEY REFERENCES [Customers](AccountNumber),
[RoomNumber]			INT FOREIGN KEY REFERENCES [Rooms](RoomNumber),
[RateApplied]			DECIMAL(3,2),
[PhoneCharge]			DECIMAL(3,2),
[Notes]					NVARCHAR(MAX)
)
GO

INSERT INTO [Employees]
		([FirstName], [LastName], [Title], [Notes])
VALUES	    
	    ('Jon', 'Jones', 'Maneger', NULL),
	    ('Jose', 'Aldo', 'Receptionist', NULL),
	    ('Jogre', 'Masvidal', 'Housekeeper', NULL)
GO

INSERT INTO [Customers]
	    ([FirstName], [LastName], [PhoneNumber],
	    [EmergencyName], [EmergencyNumber], [Notes])
VALUES	    
	    ('Eric', 'Thomas', 0899999999, NULL, NULL, NULL),
	    ('Israel', 'Adesanya', 0898888888, NULL, NULL, NULL),
	    ('Alex', 'Pereira', 0890000000, NULL, NULL, NULL)
GO

INSERT INTO [RoomStatus]
		([RoomStatus], [Notes])
VALUES	    
		('Good', NULL),
	    ('Excellent', NULL),
	    ('Very Good', NULL)
GO

INSERT INTO [RoomTypes]
		([RoomType], [Notes])
VALUES	    
		('Basic', NULL),
	    ('Royal', NULL),
	    ('?iddle', NULL)
GO

INSERT INTO [BedTypes]
		([BedType], [Notes])
VALUES	    
		('single', NULL),
	    ('double', NULL),
	    ('triple', NULL)
GO

INSERT INTO [Rooms]
	    ([RoomType], [BedType], [Rate], [RoomStatus], [Notes])
VALUES     
	    ('Basic', 'single', 100.99, 'Good', NULL),
	    ('Royal', 'triple', 300.30, 'Excellent', NULL),
	    ('?iddle', 'double', 200.20, 'Very Good', NULL)
GO

INSERT INTO [Payments]
         ([EmployeeId], [PaymentDate], [AccountNumber], 
          [FirstDateOccupied], [LastDateOccupied], 
          [TotalDays], [AmountCharged], [TaxRate], 
          [TaxAmount], [PaymentTotal], [Notes])
VALUES            
            (1, '2005-05-10', 1, '2005-05-05', '2005-05-10', 5, 300.00, 0.24, 72.00, 372.00, NULL),
            (2, '2007-07-15', 2, '2007-07-21', '2007-07-15', 6, 500.00, 0.24, 120.00, 620.00, NULL),
            (3, '2012-02-09', 3, '2012-02-16', '2012-02-09', 7, 600.00, 0.24, 144.00, 744.00, NULL)
GO

INSERT INTO [Occupancies]
	    ([EmployeeId], [DateOccupied], [AccountNumber],
	     [RoomNumber], [RateApplied], [PhoneCharge], [Notes])
VALUES    
	    (1, '2019-09-15', 1, 1, NULL, 50.00, NULL),
	    (3, '2015-07-16', 3, 3, 7.50, 40.00, NULL),
	    (2, '1999-05-16', 2, 2, 8.32, 30.00, NULL)



