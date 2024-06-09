using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_1.Models
{
    public class Degree
    {
        public string DegreeName { get; set; }
        public string Result { get; set; }
        public int PassingYear { get; set; }
        public string Group { get; set; }
        public string Institution { get; set; }
    }
    public class Project
    {
        public string ProjectTitle { get; set; }
        public string Description { get; set; }
        public string Course { get; set; }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<Degree> Degrees { get; set; }
        public List<Project> Projects { get; set; }
        public string Expertise { get; set; }

        public Student()
        {
            Degrees = new List<Degree>();
            Projects = new List<Project>();
        }
    }
}
