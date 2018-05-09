CREATE TABLE Course(
	CourseId int NOT NULL,
	CourseName nvarchar(64) NOT NULL,
	CourseNumber int NULL,
	PRIMARY KEY (CourseId)
);

CREATE TABLE Transcript(
	TranscriptId int NOT NULL,
	PRIMARY KEY(TranscriptId)
);

CREATE TABLE CourseTaken(
	TranscriptId int NOT NULL,
	CourseId int NOT NULL,
	Grade string NULL,
    FOREIGN KEY (TranscriptId) REFERENCES Transcript,
    FOREIGN KEY (CourseId) REFERENCES Course
);

CREATE TABLE Major(
	MajorId int NOT NULL,
	MajorName nvarchar(64) NOT NULL,
	Description nvarchar(256) NULL,
	PRIMARY KEY (MajorId)
);

CREATE TABLE MajorRequirements(
	MajorId int NOT NULL,
	CourseId int NOT NULL,
    FOREIGN KEY (MajorId) REFERENCES Major,
    FOREIGN KEY (CourseId) REFERENCES Course
);

CREATE TABLE Student(
	StudentId int NOT NULL,
	FirstName nvarchar(64) NOT NULL,
	LastName nvarchar(64) NOT NULL,
	Email nvarchar(256) NOT NULL,
	TranscriptId int NOT NULL,
	PRIMARY KEY (StudentId),
    FOREIGN KEY (TranscriptId) REFERENCES Transcript
);

CREATE TABLE dbo.TranscriptMajors(
	TranscriptId int NOT NULL,
	MajorId int NOT NULL,
    FOREIGN KEY (TranscriptId) REFERENCES Transcript,
    FOREIGN KEY (MajorId) REFERENCES Major
);

CREATE TABLE User(
	UserId int NOT NULL,
	FirstName nvarchar(64) NOT NULL,
	LastName nvarchar(64) NOT NULL,
	Email nvarchar(256) NOT NULL,
	UserGroup int NOT NULL,
	PRIMARY KEY (UserId)
);
