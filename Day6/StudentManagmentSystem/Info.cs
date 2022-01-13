using System;
using System.Collections.Generic;
using System.Text;

namespace Student3rdPart
{
    class Info
    {
        public void display(Student s)
        {
            //Code here to display the details of given student
            Console.WriteLine("{0,-20}{1,-40}{2,-20}", s.StudentId, s.StudentName, s.DOB);

        }

        public void display(Course c)
        {
            //Code here to display the details of given course
            Console.WriteLine("{0,-20} {1,-30} {2,-20} {3,-15}{4,-20}", c.CourseId, c.CourseName, c.CourseDuration, c.CourseFees,c.type);
        }

        public void display(Enroll e)
        {
            //Code here to display the details of given enrollments
            Console.WriteLine(e.enStudentId+" "+e.enStudentName+" "+e.enDOB+" "+e.enCourseID+" "+e.enCourseName+" "+e.enCourseDuration+" "+e.enCoursefees+" "+e.enrollmentDate);
        }
    }
}
