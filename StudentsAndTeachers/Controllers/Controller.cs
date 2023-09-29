using StudentsAndTeachers.Models;
using StudentsAndTeachers.FileReader;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Immutable;

namespace StudentsAndTeachers.Controllers
{
    public class Controller
    {
        public List<Exams> Exams { set; get; }
        public List<Student> Students { set; get; }
        public List<Teacher> Teachers { set; get; }


        public Controller()
        {
            StudentParser studentParser = new();
            TeacherParser teacherParser = new();
            ReaderDataFromFile dataFromFileStudent = new();
            ReaderDataFromFile dataFromFileTeacher = new();

            Students = new(studentParser.GetStudents(dataFromFileStudent.GetData(@"Tasks/Ученики.txt"))); // Заполнить из файла Ученики.txt
            Teachers = new(teacherParser.GetTeachers(dataFromFileTeacher.GetData(@"Tasks/Учителя.txt")));// Заполнить из файла Учителя.txt


            Exams = new();
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                Exams.Add(
                     new Exams()
                     {
                         Score = random.Next(2, 101),
                         ExamDate = new DateTime(
                             random.Next(2022, 2024), // год 
                             random.Next(1, 13), //  месяц 
                             random.Next(1, 28), // день
                             random.Next(7, 13), // час
                             0, // минута 
                             0),  // секунда
                         Student = Students[random.Next(Students.Count)],
                         Teacher = Teachers[random.Next(Teachers.Count)]
                     });
            }
        }
        public Teacher GetTeacherByID(int id)
        {
            
            return Teachers.Where(x=>x.ID == id).ToArray()[0];
        }

        //1. Найти учителя у которого в классе меньше всего учеников 
        public List<Teacher> FindTeacherWithMinCountStudents()  
        {
            int[] count = new int[Teachers.Count];
            int i = 0;
            int minCount = 0;
            List<Teacher> tempTeacher = new();
            foreach (var val in Teachers)
            {

                count[i] = Exams.Where(x => x.Teacher == val).Count();
                if (minCount == count[i])
                {
                    tempTeacher.Add(val);
                }
                if (minCount > count[i] || i == 0)
                {
                    tempTeacher = new();
                    minCount = count[i];
                    tempTeacher.Add(val);
                }

                i++;
            }
            return tempTeacher;

        }
        //2. Найти средний бал экзамена по Физики за 2023 год.	
        public decimal AverageScoreThePhysicsExamBy2023y() 
        {
            decimal sumScore = 0;
            int countScore = 0;
            foreach (var item in Exams)
            {
                if (item.Teacher.Lesson == LessonType.Physics
                    && item.ExamDate >= new DateTime(2023, 1, 1)
                    && item.ExamDate < new DateTime(2024, 1, 1))
                {
                    sumScore = item.Score + sumScore;
                    countScore++;
                }
            }
            if (countScore <= 0)
            {
                throw new Exception("По физике не было экзаменов в 2023 году");
            }
            return sumScore / countScore;
        }


        //3. Получить количество учеников которые по экзамену Математики получили больше 90 баллов, где учитель Alex 
        public int CountExcellentStudentsByTeacher(Teacher teacher)
        {
            return Exams.Where(x => x.Teacher == teacher).Where(x => x.Score>90).Count();
        }
    }
}
