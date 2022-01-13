using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Student3rdPart
{
    class Enroll 
    {
        Info info = new Info();
        private Course course { get; set; }
        private Student student { get; set; }
        public  DateTime enrollmentDate;
        public List<Course> crs = new List<Course>();
        public List<Student> std = new List<Student>();
        public List<Enroll> enr = new List<Enroll>();
        public string enStudentId;
        public string enStudentName;
        public DateTime enDOB;
        public string enCourseID;
        public string enCourseName;
        public string enCourseDuration;
        public float enCoursefees;
        Enroll(string StudentId, string StudentName, DateTime DOB, string CourseId, string CourseName, string CourseDuration, float CourseFees, DateTime enrollmentDate)
        {
            this.enStudentId = StudentId;
            this.enStudentName = StudentName;
            this.enDOB = DOB;
            this.enCourseID = CourseId;
            this.enCourseName = CourseName;
            this.enCourseDuration = CourseDuration;
            this.enCoursefees = CourseFees;
            this.enrollmentDate = enrollmentDate;
        } 
        public Enroll()
        {

        }
        public void introduce(Course course)
        { 
            crs.Add(course);
        }
        public void register(Student student)
        {
            std.Add(student);
        }
        public void listOfStudents()
        {
            string id = "ID";
            string name = "Name";
            string DOB = "Date of Birth";
            Console.WriteLine("{0,-20}{1,-40}{2,-20}", id, name, DOB);
            for (int i=0; i<std.Count; i++)
            {
                info.display(std[i]);
            }
        }
        public void listOfCourses()
        {
            for (int i = 0; i < crs.Count; i++)
            {
                info.display(crs[i]);
            }
        }
        public void enroll(string StudentId, string StudentName, DateTime DOB, string CourseId, string CourseName, string CourseDuration, float CourseFees)
        {
            enr.Add(new Enroll(StudentId,StudentName,DOB,CourseId,CourseName,CourseDuration,CourseFees,DateTime.Now));
        }
        public void listOfEnrollments()
        {
            for (int i = 0; i < enr.Count; i++)
            {
                info.display(enr[i]);
            }
        }
        public void preEnrollment(string StudentId, string StudentName, DateTime DOB, string Courseid)
        {
            try
            {
                for (int i = 0; i < crs.Count; i++)
                {
                    if (crs[i].CourseId.Equals(Courseid))
                    {
                        int count = 0;
                        for (int j = 0; j < enr.Count; j++)
                        {
                            if (Courseid.Equals(enr[j].enCourseID))
                            {
                                count++;
                            }
                        }
                        if (count >= crs[i].availibility)
                        {
                            throw new NoSeatsAvailableException("Sorry no seats avaible");
                        }
                        if (count < crs[i].availibility)
                        {
                            string CourseName = crs[i].CourseName;
                            string CourseDuration = crs[i].CourseDuration;
                            float CourseFees = crs[i].CourseFees;
                            enroll(StudentId, StudentName, DOB, Courseid, CourseName, CourseDuration, CourseFees);
                            Console.WriteLine("Successfully Enrolled!!!!");
                        }
                    }
                }
            }
            catch (NoSeatsAvailableException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public Boolean checkEnrollment(string StudentId, Boolean status)
        {
            for (int i = 0; i < enr.Count; i++)
            {
                if (enr[i].enStudentId.Equals(StudentId))
                {
                    status = false;
                }
            }
            return status;
        }
    }
}
