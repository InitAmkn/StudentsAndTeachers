using System;

namespace StudentsAndTeachers.Models
{

    public class Person
    {
        public long ID { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }


        public override string ToString()
        {
            return $"id:{ID};Name:{Name};LastName:{LastName};Age:{Age};";
        }
    }
    
}
