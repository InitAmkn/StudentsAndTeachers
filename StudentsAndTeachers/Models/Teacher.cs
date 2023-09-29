using System;

namespace StudentsAndTeachers.Models
{
    public class Teacher : Person
    {
        public LessonType Lesson { get; set; }

        public override string ToString()
        {
            
            return base.ToString() +$" Lesson:{Lesson}";
        }
    }
}
