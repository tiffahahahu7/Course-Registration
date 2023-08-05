using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab8.Models
{
    public class FulltimeStudent :  Student 
    {
        public static int MaxWeeklyHours { get; set; }

        public FulltimeStudent(string name) : base (name)
        { 

        }

        public override void RegisterCourses(List<Course> selectedCourses)
        {
            int totalWeeklyHours = base.TotalWeeklyHours(selectedCourses);
            if (totalWeeklyHours > MaxWeeklyHours)
            {
                throw new ArgumentException($"Your selection exceeds the maximum weekly hours: {MaxWeeklyHours}");
            } else
            {
                base.RegisterCourses(selectedCourses);
            }
        }
        public override string ToString()
        {
            return $"{Id} - {Name} (Full Time)";
        }
    }
}