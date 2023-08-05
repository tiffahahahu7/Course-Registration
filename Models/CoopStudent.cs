using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab8.Models
{
    public class CoopStudent : Student
    {
        public static int MaxWeeklyHours { get; set; } 
        public static int MaxNumOfCourses { get; set; }
        public CoopStudent(string name) : base(name)
        {

        }
        public override void RegisterCourses(List<Course> selectedCourses)
        {
            int totalWeeklyHours = base.TotalWeeklyHours(selectedCourses);
            if (totalWeeklyHours > MaxWeeklyHours)
            {
                throw new ArgumentException($"Your selection exceeds the maximum weekly hours: {MaxWeeklyHours}");
            } else if (selectedCourses.Count > MaxNumOfCourses)
            {
                throw new ArgumentException($"Your selection exceeds the maximum number of courses: {MaxNumOfCourses}");
            } else
            {
                base.RegisterCourses(selectedCourses);
            }
            
        }
        public override string ToString()
        {
            return $"{Id} - {Name} (Coop)";
        }
    }
}