
CREATE TABLE Students(
[StudentID] INT PRIMARY KEY IDENTITY,
[Name]		NVARCHAR(20) NOT NULL)

GO

CREATE TABLE Exams(
[ExamID]    INT PRIMARY KEY IDENTITY(101, 1),
[Name]		NVARCHAR(20) NOT NULL)

GO

CREATE TABLE StudentsExams(
[StudentID] INT FOREIGN KEY REFERENCES Students([StudentID]) NOT NULL,
[ExamID]	INT FOREIGN KEY REFERENCES Exams([ExamID]) NOT NULL,
PRIMARY KEY(StudentID, ExamID))

GO

INSERT INTO Students([Name])
VALUES ('Mila'),
	   ('Toni'),
	   ('Ron')

GO

INSERT INTO Exams([Name])
VALUES ('SpringMVC'),
	   ('Neo4j'),
	   ('Oracle 11g')

GO

INSERT INTO StudentsExams([StudentID],[ExamID])
VALUES		(1, 101),
			(1, 102),
			(2, 101),
			(3, 103),
			(2, 102),
			(2, 103)
