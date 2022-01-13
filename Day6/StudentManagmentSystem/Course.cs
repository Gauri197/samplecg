using System;
using System.Collections.Generic;
using System.Text;

namespace Student3rdPart
{
    class Course
    {
            public string CourseId { get; set; }
            public string CourseName { get; set; }
            public string CourseDuration { get; set; }
            public float CourseFees { get; set; }
            public string type { get; set; }
            public int availibility { get; set; }
        public Course()
        {

        }
        public Course(string CourseId, string CourseName, string CourseDuration, float CourseFees, int availibility)
        {
            this.CourseId = CourseId;
            this.CourseName = CourseName;
            this.CourseDuration = CourseDuration;
            this.CourseFees = CourseFees;
            this.availibility = availibility;
        }
        
    }
    class Diploma : Course
    {
        public Diploma(string CourseId, string CourseName, string CourseDuration, float CourseFees, int availibility) : base(CourseId, CourseName, CourseDuration, CourseFees,availibility)
        {
            base.type = "Diploma";
        }
    }
    class Degree : Course
    {
        public Degree(string CourseId, string CourseName, string CourseDuration, float CourseFees, int availibility) : base(CourseId, CourseName, CourseDuration, CourseFees, availibility)
        {
            base.type = "Degree";
        }
    }
}
