using System;
using System.Collections.Generic;

using StudentManagementSystem;
namespace Aug11
{
    public class SameCourse : Exception
    {
        public SameCourse(String message)
            : base(message)
        {

        }
    }
    class Enroll
    {
        Info info=new Info();
        public Student student=new Student();
        public Course course=new DegreeCourse();
        private DateTime enrollmentDate;
        public int count;
        public int coursecount;
        public int enrollmentcount;
        public List<Course> CourseArr = new List<Course>();
        public List<Student> StudentArr = new List<Student>();
        public List<Enroll> EnrollArr = new List<Enroll>();

        public Enroll() { }
        
       public Enroll(Student student, Course course, DateTime enrollmentDate)
       {
              this.student = student;
              this.course = course;
             this.enrollmentDate = enrollmentDate;
      }

        public DateTime EnrollmentDate
        {
            get { return enrollmentDate; }
            set { enrollmentDate = value; }
        }
       
        public void introduce(Course course)
        {
            //int inx = CourseArr.GetLength(10);
            CourseArr.Add(course);
           // coursecount++;
          
        }

        public List<Course> listOfCourses()
        {
            
            return CourseArr;
        }

        public void register(Student student)
        {
           
            StudentArr.Add(student);
         
        }

        public List<Student> listOfStudents()
        {
            return StudentArr;
        }

        public void enroll(Student student, Course course,DateTime enrollmentdate)
        {

            EnrollArr.Add(new Enroll(student, course, enrollmentdate));
            //enrollmentcount++;
        }

        public List<Enroll> listOfEnrollments()
        {
            return EnrollArr;
        }

        public int getCourseByIdLength(int id)
        {
            int a=0;

            Enroll e = new Enroll();
            for(int i=0;i<enrollmentcount;i++)
            {

                if (int.Parse(EnrollArr[i].course.CourseId) != id)
                {
                    continue;
                }
                a++;
            }

            return a;
        }

        public int getId(int id)
        {
            int ccid=0;
            for(int i=0;i<enrollmentcount;i++)
            {
                if(int.Parse(EnrollArr[i].student.Id) == id)
                {
                    ccid = int.Parse(EnrollArr[i].course.CourseId);
                }
            }
            return ccid;
        }

        
        public override string ToString()
        {
            return "\t" + student.Name + "\t" + course.CourseName + "\t" + EnrollmentDate + "\n";
        }

    }

}
