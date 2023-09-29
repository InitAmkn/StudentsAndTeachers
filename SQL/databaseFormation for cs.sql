-- Active: 1695924862363@@host.docker.internal@5432@db_for_cs

CREATE TABLE Teacher(  
    Id int NOT NULL PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(255),
    LastName VARCHAR(255),
    Birthdate DATE,
    LessonTypeID int,
    FOREIGN KEY (LessonTypeID) REFERENCES LessonType (Id)
);

CREATE TABLE Student(  
    Id int NOT NULL PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(255),
    LastName VARCHAR(255),
    Birthdate DATE
);


CREATE TABLE LessonType (  
    Id int NOT NULL PRIMARY KEY AUTO_INCREMENT,
    LessonType VARCHAR(255));

CREATE TABLE Exam (  
    Id int NOT NULL PRIMARY KEY AUTO_INCREMENT,
    Score DECIMAL,
    `Date` DATETIME,
    LessonTypeID int,
    TeacherID int,
    FOREIGN KEY (TeacherID) REFERENCES Teacher (Id),
    FOREIGN KEY (LessonTypeID) REFERENCES LessonType (Id)
);


INSERT INTO `Student`(
    Student.`Name`,
    Student.`LastName`,
    Student.`Birthdate`)
VALUES
    ("Петя","Иванов","2009-01-15"),
    ("Марина","Иванова","2009-11-22"),
    ("Влад","Иванов","2009-02-06");

Имя 		Фамилия 	Возраст		Урок
Марина 		Петрова		41		Физика
Светлана	Иванова		45		Математика
Надежда		Карпова		39		Физика

INSERT INTO `Teacher`(
    Teacher.`Name`,
    Teacher.`LastName`,
    Teacher.`Birthdate`,
    Teacher.`LessonTypeID`)
VALUES
    ("Марина","Петрова","1981-02-14",1),
    ("Светлана","Иванова","1977-12-11",2),
    ("Надежда","Карпова","1983-05-08",1);