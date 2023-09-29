
using Microsoft.Extensions.Primitives;
using StudentsAndTeachers.Controllers;
using StudentsAndTeachers.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

Controller controller = new();

StringBuilder sb = new StringBuilder();

foreach (var item in controller.Exams)
{
    sb.Append(item);
    sb.Append("\n\n");
}

sb.Append("\n Average Score The Physics Exam By 2023:\n"
    + controller.AverageScoreThePhysicsExamBy2023y()+ "\n\n");


sb.Append("\n min Teacher:\n");
foreach (var item in controller.FindTeacherWithMinCountStudents())
{
    sb.Append(item);
    sb.Append("\n\n");
}
Teacher teacher = controller.GetTeacherByID(2);
sb.Append("\n Count of excellent students by teachers: " 
    +"\n" 
    +teacher
    +"\n"
    +controller.CountExcellentStudentsByTeacher(teacher) + " \n");

var app = builder.Build();

app.MapGet("/", () => 
sb.ToString());   

app.Run();
