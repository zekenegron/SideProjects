USE master
GO

DROP DATABASE IF EXISTS Disc_Golf_Tracker
GO

CREATE DATABASE Disc_Golf_Tracker
GO

USE Disc_Golf_Tracker
GO

BEGIN TRANSACTION

	CREATE TABLE Course (
		course_id int IDENTITY(1,1),
		name nvarchar(140) NOT NULL,
		number_of_holes int NOT NULL

		CONSTRAINT PK_Course PRIMARY KEY (course_id),
		CONSTRAINT UQ_Course UNIQUE (name),
		CONSTRAINT CHK_number_of_holes CHECK (number_of_holes >= 9)
	);
	GO

	CREATE TABLE Round (
		round_id int IDENTITY(1,1),
		course_id int NOT NULL, -- Foreign Key to Course
		date_played datetime2 NOT NULL,
		final_score int

		CONSTRAINT PK_Round PRIMARY KEY (round_id),
		CONSTRAINT FK_Round FOREIGN KEY (course_id) REFERENCES Course(course_id)
	);
	GO

	CREATE TABLE Course_Round (
		course_id int NOT NULL,
		round_id int NOT NULL

		CONSTRAINT FK_Course_Round_course_id FOREIGN KEY (course_id) REFERENCES Course(course_id),
		CONSTRAINT FK_Course_Round_round_id FOREIGN KEY (round_id) REFERENCES Round(round_id)
	);
	GO

	INSERT INTO Course
		(name, number_of_holes)
	VALUES
		('Brent Hambrick Memorial Disc Golf Course', 27),
		('Blendon Woods Disc Golf Course', 18),
		('Griggs Reservoir Park', 18),
		('The Players Course at Alum Creek', 18),
		('Kinslow Disc Golf Course', 18)

COMMIT

