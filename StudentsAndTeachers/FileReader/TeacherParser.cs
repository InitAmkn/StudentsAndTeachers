using StudentsAndTeachers.Models;

namespace StudentsAndTeachers.FileReader
{
    public class TeacherParser
    {
        public List<Teacher> GetTeachers(string data)
        {
            Parser parser = new ();

            List<Teacher> teachers = new();

            String[][] teachersList = parser.GetData(data);
            try
            {
                for (int i = 1; i < teachersList.GetLength(0); i++)
                {
                    Teacher teacher = new Teacher();
                    teacher.ID = i;
                    teacher.Name = teachersList[i][0];
                    teacher.LastName = teachersList[i][1];
                    teacher.Age = Int32.Parse(teachersList[i][2]);
                    if (teachersList[i][3] == "Физика") teacher.Lesson = LessonType.Physics;
                    if (teachersList[i][3] == "Математика") teacher.Lesson = LessonType.Mathematics;
                    teachers.Add(teacher);
                }
            }
            catch (Exception ex)
            {
                new Exception("File Teachers: " + ex.Message);
            }
            return teachers;
        }
    }
}
