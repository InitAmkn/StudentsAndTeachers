using StudentsAndTeachers.Models;
using System.Collections.Generic;

namespace StudentsAndTeachers.FileReader
{
    public class StudentParser
    {
        public List<Student> GetStudents(string data) 
        {
            Parser parser = new();

            List<Student> students = new();

            String[][] studentsList = parser.GetData(data);
            try
            {
                for (int i = 1; i < studentsList.GetLength(0); i++)
                {
                
                    students.Add(new Student
                    {
                        ID = i,
                        Name = studentsList[i][0],
                        LastName = studentsList[i][1],
                        Age = Int32.Parse(studentsList[i][2])
                    }
                   );
                }
            }
            catch (Exception ex)
            {
                new Exception("File Students: " + ex.Message);
            }
        
            return students; 
        }
    }
}
