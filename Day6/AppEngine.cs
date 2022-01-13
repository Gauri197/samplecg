using System;
using System.Collections.Generic;
using System.Text;
using StudentManagementSystem;

namespace Aug11
{
    interface AppEngine
    {
        public void introduce(Course course);
        public void Register();
        public List<Student> listofStudents();
        public List<Course> listofCourses();
        public void enroll(Student student,Course course,DateTime enrollmentDate);
        public List<Enroll> listofEnrollments();
    }
}
