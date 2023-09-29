using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;

namespace StudentsAndTeachers.Models
{
    public class Exams
    {
        public LessonType Lesson { get; set; }

        //public long StudentId { get; set; }
        //public long TeacherId { get; set; }

        public decimal Score { get; set; }
        public DateTime ExamDate { get; set; }

        public Student? Student { get; set; }
        public Teacher? Teacher { get; set; }


        public override string ToString()
        {
            return
                $"ExamDate:{ExamDate}; Score:{Score};" +
                $"\nStudent:{Student};" +
                $"\nTeacher:{Teacher}";
               
        }
    }
}
