using System;
using ConsoleApp1;
using StudentManagementSystem;
using System.Collections.Generic;
using System.Linq;
namespace Aug11
{

    class ExceedLimitException : Exception
    {
        public ExceedLimitException(string message) : base(message)
        {
        }
    }
    class AlreadySelectedCourse : Exception
    {
        public AlreadySelectedCourse(string message) : base(message)
        {
        }
    }
    class ScreenDescription : UserInterface
    {
        //Presentation Layer
        Info info = new Info();
        Enroll en = new Enroll();
        InMemoryAppEngine inMemory = new InMemoryAppEngine();
        Course course = new DegreeCourse();

        public void showAdminScreen()
        {
            Console.WriteLine("You are in admin screen");
            Console.WriteLine("---Welcome to Admin Dashboard---");
            Console.WriteLine("\nEnter your choice:\n1.Show all Student Details\n2.Show all current Student Enrollments\n" +
                "3.Introduce new course\n4.Show all courses\n5.Display Student Details by ID\n6.Enroll Student");
            int ch = Convert.ToInt32(Console.ReadLine());
            switch (ch)
            {
                case 1:
                    showAllStudentsScreen();
                    break;
                case 2:
                    showEnrollments();
                    break;
            
                case 3:
                    // introduceNewCourseScreen();
                    inMemory.introduce(course);
                    break;
                case 4:
                    showAllCoursesScreen();
                    break;
                case 5:
                    //showStudentDetails();
                    break;
                case 6:
                    try { showEnrollmentScreen(); }
                    catch(Exception e) { Console.Write(e); }
                    
                    break;
                default:
                    Console.WriteLine("Please enter correct choice");
                    break;
            }
        }


        public void showEnrollments()
        {
            Console.WriteLine("You are in all enrollment screen");
            Console.WriteLine("Id\tName\tDate of Birth\n");
            Console.WriteLine("Student array length:" + en.enrollmentcount);
            List<Enroll> enrolllist = new List<Enroll>();
            enrolllist = inMemory.listofEnrollments();
            foreach (var enr in enrolllist)
                info.display(enr);
        }
        public void showStudentScreen()
        {
            Console.WriteLine("You are in student screen");
            Console.WriteLine("\nEnter your choice:\n1.Register for a Course\n2.Show all Student Enrollments\n3.Show all Student Details\n");
            int ch = Convert.ToInt32(Console.ReadLine());
            switch (ch)
            {
                case 1:
                    StudentManagementSystem.Student student = new StudentManagementSystem.Student();
                    inMemory.Register();
                    break;
                case 2:
                    showEnrollmentScreen();
                    break;
                case 3:
                    showAllStudentsScreen();
                    break;
                default:
                    Console.WriteLine("Please enter correct choice");
                    break;
            }

        }

        public void showAllStudentsScreen()
        {
            
            Console.WriteLine("You are in all students screen");
            Console.WriteLine("Id\tName\tDate of Birth\n");
            //Console.WriteLine("Student array length:" + en.listOfStudents().Length);
            // Console.WriteLine("List count" + en.count);
            List<StudentManagementSystem.Student> studentlist = new List<StudentManagementSystem.Student>();
            //studentlist= en.listOfStudents();
            studentlist = inMemory.listofStudents();
              foreach(var i in studentlist)
            {
                info.display(i);
            }
        }

        public void showStudentRegistrationScreen()
        {
            Console.WriteLine("You are in student registration screen");
            Console.WriteLine("Enter student id:");
            string id = Console.ReadLine();
            Console.WriteLine("Enter student name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter date of birth");
            string date = Console.ReadLine();
            DateTime dateTime10 = Convert.ToDateTime(date);
            en.register(new StudentManagementSystem.Student(id, name, dateTime10));
        }

        public void showAllCoursesScreen()
        {
            Console.WriteLine("You are in all courses screen");
            Console.WriteLine("Id\tName\tDate of Birth\n");
            //Console.WriteLine("Student array length:" + en.listOfStudents().Length);
            // Console.WriteLine("List count" + en.count);
            List<Course> courselist = new List<Course>();
            //studentlist= en.listOfStudents();
            courselist = inMemory.listofCourses();
            foreach (var i in courselist)
            {
                info.display(i);
            }
        }

        public void introduceNewCourseScreen()
        {
            DegreeCourse degreecourse = new DegreeCourse();
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
		if(choice=="Degree")
		{
			    Console.WriteLine("enter your degree type :Bachelors/Masters");
                string dtype = Console.ReadLine();
                Console.WriteLine("Is placement available");
                bool b=bool.Parse(Console.ReadLine());

              //  Console.WriteLine(b);
                if (dtype=="Bachelors"){
                    
                    en.introduce(new DegreeCourse(CourseId,CourseName, CourseDuration, CourseFees, seats, Level.Bachelors, b));
                    
                }
			   else if(dtype=="Masters")
			     {
                    
                    en.introduce(new DegreeCourse(CourseId,CourseName, CourseDuration, CourseFees, seats, Level.Masters, b));
			    }
		}
		else if(choice=="Diploma")
		{
                Console.WriteLine("Course Type:Professional/Academics");
                string type = Console.ReadLine();
                if(type.Equals("Professional"))
                {
                    
                    en.introduce(new DiplomaCourse(CourseId, CourseName, CourseDuration, seats, CourseFees, Type.Professional));
                }
                else if (type.Equals("Academics"))
                {
                    en.introduce(new DiplomaCourse(CourseId, CourseName, CourseDuration, seats, CourseFees, Type.Academics));
                }     				
		}  
        }

        public void showEnrollmentScreen()
        {
            StudentManagementSystem.Student student = new StudentManagementSystem.Student();
           
            List<StudentManagementSystem.Student> studentlist = new List<StudentManagementSystem.Student>();
            //studentlist= en.listOfStudents();
            studentlist = inMemory.listofStudents();
            List<Course> courselist = new List<Course>();
            //studentlist= en.listOfStudents();
            courselist = inMemory.listofCourses();
           Course course = new DegreeCourse();
            Console.WriteLine("enter student id");
            string id = Console.ReadLine();
            int iid = Int32.Parse(id);
            for (int i = 0; i < inMemory.listofStudents().Count; i++)
            {
                if (iid == Int32.Parse(studentlist.ElementAt(i).Id))
                {
                    student = studentlist.ElementAt(i);
                }
                
            }

            Console.WriteLine("Enter course id");
            string courseid = Console.ReadLine();
            int ccid = Int32.Parse(courseid);

            for (int i = 0; i < inMemory.listofCourses().Count; i++)
            {
                if (ccid == Int32.Parse(courselist.ElementAt(i).CourseId))
                {
                    int length = inMemory.getCourseByIdLength(ccid);
                    int courid = inMemory.getId(iid);

                     if (courid == ccid)
                    {
                        throw new AlreadySelectedCourse("You have already selected the course");
                    }

                   else if (length >= courselist.ElementAt(i).seatsavaialble)
                    {
                        throw new ExceedLimitException("Seats not available");
                    }
                    
                    else
                    {
                        course = courselist.ElementAt(i);
                    }
                }
               
            }
                Console.WriteLine("Enter date of enrollment");
                string date = Console.ReadLine();
                DateTime date1 = Convert.ToDateTime(date);

                inMemory.enroll(student, course, date1);
            

        }
        public void showFirstScreen()
        {
            
            Console.WriteLine("Welcome to SMS(Student Mgmt. System) v1.0");
            Console.WriteLine("Tell us who you are : \n1. Student\n2. Admin");
            Console.WriteLine("Enter your choice ( 1 or 2 ) : ");

            int op = Convert.ToInt32(Console.ReadLine());
            switch (op)
            {
                case 1:
                    showStudentScreen();
                    break;
                case 2:
                    showAdminScreen();
                    break;
            }
        }
    }
}

namespace ConsoleApp1
{
   internal interface UserInterface
    {
        public void showFirstScreen();
        public void introduceNewCourseScreen();
        public void showAdminScreen();
        public void  showStudentScreen();
        public void showAllCoursesScreen();
        public void showStudentRegistrationScreen();
        public void showEnrollmentScreen();
        public void showEnrollments();

    }
}