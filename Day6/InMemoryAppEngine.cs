using System;
using System.Collections.Generic;
using System.Text;
using StudentManagementSystem;
using System.Linq;

namespace Aug11
{
    class InMemoryAppEngine:AppEngine
    {
        Info info = new Info();
        Enroll en = new Enroll();
        public List<Enroll> EnrollArr = new List<Enroll>();
        public void introduce(Course course) {

            Console.WriteLine("You are in introduce new course screen");
            Console.WriteLine("---Add a new Course---");
            Console.WriteLine("Enter the course details to be added:");
            Console.WriteLine("Course ID:");
            string CourseId = Console.ReadLine();
            Console.WriteLine("Course Name:");
            string CourseName = Console.ReadLine();
            Console.WriteLine("Course Duration:");
            string CourseDuration = Console.ReadLine();
            Console.WriteLine("Course Fees:");
            float CourseFees = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Seats available:");
            int seats = Int32.Parse(Console.ReadLine());
            //Level level;

            Console.WriteLine("Enter Degree/Diploma");
            string choice = Console.ReadLine();
            if (choice == "Degree")
            {
                Console.WriteLine("enter your degree type :Bachelors/Masters");
                string dtype = Console.ReadLine();
                Console.WriteLine("Is placement available");
                bool b = bool.Parse(Console.ReadLine());

                //  Console.WriteLine(b);
                if (dtype == "Bachelors")
                {

                    en.introduce(new DegreeCourse(CourseId, CourseName, CourseDuration, CourseFees, seats, Level.Bachelors, b));

                }
                else if (dtype == "Masters")
                {

                    en.introduce(new DegreeCourse(CourseId, CourseName, CourseDuration, CourseFees, seats, Level.Masters, b));
                }
            }
            else if (choice == "Diploma")
            {
                Console.WriteLine("Course Type:Professional/Academics");
                string type = Console.ReadLine();
                if (type.Equals("Professional"))
                {

                    en.introduce(new DiplomaCourse(CourseId, CourseName, CourseDuration, seats, CourseFees, Type.Professional));
                }
                else if (type.Equals("Academics"))
                {
                    en.introduce(new DiplomaCourse(CourseId, CourseName, CourseDuration, seats, CourseFees, Type.Academics));
                }

            }


        }
        public void Register() {
            Console.WriteLine("You are in student registration screen");
            Console.WriteLine("Enter student id:");
            string id = Console.ReadLine();
            Console.WriteLine("Enter student name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter date of birth");
            string date = Console.ReadLine();
            DateTime dateTime10 = Convert.ToDateTime(date);
            en.register(new Student(id, name, dateTime10));
        }
        public List<Student> listofStudents() {
            //List<Student> listofStudents = new List<Student>();

            return en.StudentArr;
        
        }
        public void enroll(Student student, Course course,DateTime enrollmentdate) {
            EnrollArr.Add(new Enroll(student, course, enrollmentdate));
        }
        public List<Enroll> listofEnrollments() {

            return EnrollArr;
                
      }

        public List<Course> listofCourses()
        {
            return en.CourseArr;
     
        
        }

        public int getCourseByIdLength(int id)
        {
            int a = 0;

            //Enroll e = new Enroll();
            for (int i = 0; i < listofEnrollments().Count; i++)
            {

                if (int.Parse(EnrollArr.ElementAt(i).course.CourseId) != id)
                {
                    continue;
                }
                a++;
            }

            return a;
        }

        public int getId(int id)
        {
            int ccid = 0;
            for (int i = 0; i < listofEnrollments().Count; i++)
            {
                if (int.Parse(EnrollArr[i].student.Id) == id)
                {
                    ccid = int.Parse(EnrollArr[i].course.CourseId);
                }
            }
            return ccid;
        }
    }
}
