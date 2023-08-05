using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab8.Models
{
    public class ParttimeStudent : Student
    {
        public static int MaxNumOfCourses { get; set; }
        public ParttimeStudent(string name) : base (name)
        {

        }
        public override void RegisterCourses(List<Course> selectedCourses)
        {
            if(selectedCourses.Count > MaxNumOfCourses)
            {
                throw new ArgumentException($"Your selection exceeds the maximum number of courses: {MaxNumOfCourses}");
            } else
            {
                base.RegisterCourses(selectedCourses);
            }
            
        }
        public override string ToString()
        {
            return $"{Id} - {Name} (Part Time)";
        }
    }
}