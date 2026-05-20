using System.Collections.Generic;

namespace CodeAcademy.Models
{
    public class Student
    {
        public string Name { get; set; }
        public List<int> EnrolledCourseIds { get; set; }

        public Student(string name)
        {
            Name = name;
            EnrolledCourseIds = new List<int>();
        }
    }
}