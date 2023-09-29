-- Active: 1695924862363@@host.docker.internal@5432@db
CREATE TABLE Teacher(  
    Id int NOT NULL PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(255),
    Birthdate DATE
);

CREATE TABLE Student(  
    Id int NOT NULL PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(255),
    Birthdate DATE,
    TeacherID int,
    FOREIGN KEY (TeacherID)  REFERENCES Teacher (Id)
);


CREATE TABLE Lesson (  
    Id int NOT NULL PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(255));

CREATE TABLE Exam (  
    Id int NOT NULL PRIMARY KEY AUTO_INCREMENT,
    StudentID int,
    LessonID int,
    `Date` DATE,
    Score int,
    FOREIGN KEY (StudentID) REFERENCES Student (Id),
    FOREIGN KEY (LessonID) REFERENCES Lesson (Id)
);

INSERT INTO `Teacher`(Teacher.`Name`,Teacher.`Birthdate`)
VALUES
    ("Тимур","1985-01-15"),
    ("Екатерина","1965-06-07"),
    ("Василий","1994-08-08");

INSERT INTO `Student`(
    Student.`Name`,
    Student.`TeacherID`)
VALUES 
    ("Петя",1),
    ("Вася",2),
    ("Игорь",2),
    ("Света",3),
    ("Лена",1);

INSERT INTO `Lesson`(Lesson.`Name`)
VALUES
    ("Математика"),
    ("Русский"),
    ("Информатика");

INSERT INTO `Exam`(Exam.`LessonID`,Exam.`StudentID`,Exam.`Score`,Exam.`Date`) 
VALUES
    (1,1,5,'2021-07-15'),
    (2,2,4,'2023-01-22'),
    (3,3,3,'2020-06-24'),
    (3,5,4,'2022-07-11'),
    (2,4,5,'2022-01-09'),
    (1,2,3,'2021-01-08'),
    (1,3,5,'2021-05-02'),
    (2,1,4,'2021-11-01')
;

--1.  Сколько учеников у каждого учителя. Сортировать по количеству учеников 
--от меньшего


SELECT Teacher.`Id`, Teacher.`Name`, COUNT(*) as StudentCount
FROM `Teacher`
Left JOIN `Student` 
ON Student.`TeacherID` = Teacher.`Id`
GROUP BY Teacher.`Id`
ORDER BY StudentCount;


--2.  Найти ученика, у которого максимальный бал по Математике с 01.01.2021 
--по 01.01.2022, не брать учителей, у которых возраст старше 40.


SELECT  
    Student.`Id`,
    Student.`Name` as StudentName,
    Teacher.`Name` as TeacherName,
    Lesson.`Name` as LessonName,
    Exam.`Score`
FROM `Teacher`
Left JOIN `Student` 
ON Student.`TeacherID` = Teacher.`Id`
Left JOIN `Exam`
ON Student.`Id` = Exam.`StudentID`
Left JOIN `Lesson`
ON Lesson.`Id` = Exam.`LessonID`
WHERE Lesson.`Name` = "Математика"
AND Exam.`Date` BETWEEN "2021-01-01" AND "2022-01-01"
AND Exam.`Score` = 5
AND TIMESTAMPDIFF(YEAR, Teacher.`Birthdate`, curdate())<=40;

DELIMITER ;

CALL FindStudent();



SELECT
Student.`Id`,
Student.`Name` as StudentName,
Teacher.`Name` as TeacherName,
Lesson.`Name`,
Exam.`Score`
FROM 
WHERE Lesson.`Name` = "Математика"
AND Exam.`Date` BETWEEN "2021-01-01" AND "2022-01-01"
WHERE
; ---включительно