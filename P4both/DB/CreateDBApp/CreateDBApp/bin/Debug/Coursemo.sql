CREATE TABLE Students (
  NetID	NVARCHAR(16) PRIMARY KEY NOT NULL,
  FirstName NVARCHAR(64) NOT NULL,
  LastName NVARCHAR(64) NOT NULL
);

CREATE TABLE Courses (
  CRN INT PRIMARY KEY,
  Department NVARCHAR(16) NOT NULL,
  CourseNumber INT NOT NULL,
  Type NVARCHAR(16) NOT NULL,
  ClassSize INT NOT NULL,
  Days NVARCHAR(16) NOT NULL,
  ClassTime NVARCHAR(32) NOT NULL,
  Semester NVARCHAR(16) NOT NULL,
  Year INT NOT NULL
);

CREATE TABLE Enrolled (
  Priority INT IDENTITY(0, 1) PRIMARY KEY,
  NetID NVARCHAR(16) NOT NULL FOREIGN KEY REFERENCES Students(NetID),
  CRN INT NOT NULL FOREIGN KEY REFERENCES Courses(CRN),
  Active BIT DEFAULT 1
);

CREATE INDEX Enrolled_NetID_Index ON Enrolled(NetID);

CREATE INDEX Enrolled_CRN_Index ON Enrolled(CRN);



CREATE TABLE Waitlist (
  Priority INT IDENTITY(0, 1) PRIMARY KEY,
  NetID NVARCHAR(16) NOT NULL FOREIGN KEY REFERENCES Students(NetID),
  CRN INT NOT NULL FOREIGN KEY REFERENCES Courses(CRN),
  Active BIT DEFAULT 1
);

CREATE INDEX Waitlist_NetID_Index ON Enrolled(NetID);

CREATE INDEX Waitlist_CRN_Index ON Enrolled(CRN);