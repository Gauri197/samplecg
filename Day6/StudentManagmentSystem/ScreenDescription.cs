using System;
namespace Student3rdPart
{
    class ScreenDescription : Exception, IUserInterface
    {
        Info info = new Info();
        Enroll en = new Enroll();
        public void showFirstScreen()
        {

            Console.WriteLine("\n\n----------Welcome to Student Management System----------\n");
            Console.WriteLine("\nLogin as : \n\n1. Student\n2. Admin\n");
            try
            {
                int op = Convert.ToInt32(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        showStudentScreen();
                        break;
                    case 2:
                        showAdminScreen();
                        break;
                    default:
                        Console.WriteLine("Wrong choice");
                        break;
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void showStudentScreen()
        {
            Console.WriteLine("\n----------Welcome to Student Center----------\n");

            Console.WriteLine("\nEnter your choice:\n\n0.Register\n1.Enroll for a Course\n2.Show all Student Enrollments\n3.Show all Student Details\n" +
                "4.Show all courses\n");
            int ch = Convert.ToInt32(Console.ReadLine());
            switch (ch)
            {
                case 0:
                    showStudentRegistrationScreen();
                    break;
                case 1:
                    showCourseEnrollmentScreen();
                    break;
                case 2:
                    showAllEnrollments();
                    break;
                case 3:
                    showAllStudentsScreen();
                    break;
                case 4:
                    showAllCoursesScreen();
                    break;
                default:
                    Console.WriteLine("Please enter correct choice");
                    break;
            }

        }
        public void showCourseEnrollmentScreen()
        {
            Boolean status = true;
            Console.WriteLine("Student ID:");
            string StudentId = Console.ReadLine();
            try
            { 
                if (showStudentDetails(StudentId, status))
                {
                    if(en.checkEnrollment(StudentId, status))
                    {
                        Console.WriteLine("Student Name:");
                        string StudentName = Console.ReadLine();
                        Console.WriteLine("Student DOB:");
                        DateTime DOB = Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine("Enter course type: \n 1.Diploma \n2.Degree");
                        int type = int.Parse(Console.ReadLine());
                        switch (type)
                        {
                            case 1:
                                Console.WriteLine("Available Courses are:");
                                for (int i = 0; i < en.crs.Count; i++)
                                {
                                    if (en.crs[i].type.Equals("Diploma"))
                                    {
                                        Console.WriteLine($"{i + 1} {en.crs[i].CourseName} {en.crs[i].CourseId}");
                                    }
                                }
                                Console.WriteLine("Enter Course ID:");
                                string DipCourseID = Console.ReadLine();
                                en.preEnrollment(StudentId, StudentName, DOB, DipCourseID);
                                break;
                            case 2:
                                Console.WriteLine("Available Courses are:");
                                for (int i = 0; i < en.crs.Count; i++)
                                {
                                    if (en.crs[i].type.Equals("Degree"))
                                    {
                                        Console.WriteLine($"{i} {en.crs[i].CourseName} {en.crs[i].CourseId}");
                                    }
                                }
                                Console.WriteLine("Enter Course ID:");
                                string DEgCourseID = Console.ReadLine();
                                en.preEnrollment(StudentId, StudentName, DOB, DEgCourseID);
                                break;
                        }
                    }
                    else
                    {
                        throw new AlreadyEnrolled("Only one enrrollment is allowed per student!");
                    }
                }
                else
                {
                    throw new NotRegistered("Only Registered students can enroll. Register first.");
                }
            }
            catch (AlreadyEnrolled e)
            {
                Console.WriteLine(e.Message);
            }
            catch (NotRegistered e)
            {
                Console.WriteLine(e.Message);
            }   
        }
        public void showAllEnrollments()
        {
            en.listOfEnrollments();
        }
        public void showAllStudentsScreen()
        {
            en.listOfStudents();
        }

        public void showStudentRegistrationScreen()//Admin can admit student into university
        {
            try
            {
                Boolean status = true;
                Console.WriteLine("\n-----Student Admission-----\n");
                Console.WriteLine("Enter the student details to be added:\n");
                Console.WriteLine("Student ID:");
                string StudentId = Console.ReadLine();
                try
                {
                    if (showStudentDetails(StudentId, status))
                    {
                        throw new AlreadyRegistered("Student Already Registered!");
                    }
                    else
                    {
                        Console.WriteLine("Student Name:");
                        string StudentName = Console.ReadLine();
                        Console.WriteLine("Student DOB:");
                        DateTime DOB = Convert.ToDateTime(Console.ReadLine());
                        en.register(new Student(StudentId, StudentName, DOB));
                    }
                }
                catch (AlreadyRegistered a)
                {
                    Console.WriteLine(a.Message);
                }
            }

            catch (StudentException e)
            {
                Console.WriteLine(e.Message);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        
        

        public void showAdminScreen()
        {
            Boolean status = true;
            do
            {
                Console.WriteLine("\n----------Welcome to Admin Dashboard----------\n");
                Console.WriteLine("\nEnter your choice:\n\n1.Show all Student Details\n2.Show all current Student Enrollments\n" +
                    "3.Introduce new course\n4.Show all courses\n5.Display Student Details by ID\n6.Admit a student in university\n7.Exit");
                int ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        showAllStudentsScreen();
                        break;
                    case 2:
                        showAllEnrollments();
                        break;
                    case 3:
                        introduceNewCourseScreen();
                        break;
                    case 4:
                        showAllCoursesScreen();
                        break;
                    case 5:
                        Console.WriteLine("Enter ID:");
                        string id = Console.ReadLine();
                        showStudentDetails(id);
                        break;
                    case 6:
                        showStudentRegistrationScreen();
                        break;
                    case 7:
                        status = false;
                        break;
                    default:
                        Console.WriteLine("Please enter correct choice");
                        break;
                }
            } while (status);
        }
        public void showStudentDetails()
        {
            en.listOfStudents();
        }
        public void showStudentDetails(string id)
        {
            for (int i = 0; i < en.std.Count; i++)
            {
                if (en.std[i].StudentId.Equals(id))
                {
                    info.display(en.std[i]);
                }
            }
        }
        public Boolean showStudentDetails(string id, Boolean status)
        {
            int count = 0;
            for (int i = 0; i < en.std.Count; i++)
            {
                if (en.std[i].StudentId.Equals(id))
                {
                    count++;
                }
            }
            if (count == 0)
            {
                status = false;
            }
            return status;
        }
        public void showAllCoursesScreen()
        {
            en.listOfCourses();
        }
        public void introduceNewCourseScreen()
        {
            try
            {
                Console.WriteLine("\n-----Add a new Course-----\n");
                Console.WriteLine("Enter the course details to be added:\n");
                Console.WriteLine("Course ID:");
                string CourseId = Console.ReadLine();
                Console.WriteLine("Course Name:");
                string CourseName = Console.ReadLine();
                Console.WriteLine("Course Duration:");
                string CourseDuration = Console.ReadLine();
                Console.WriteLine("Course Fees:");
                float CourseFees = float.Parse(Console.ReadLine());
                Console.WriteLine("Enter seat availibility:");
                int availibility = int.Parse(Console.ReadLine());
                Console.WriteLine("Course type :\n1.Diploma 2.Degree");
                int ch = int.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        en.introduce(new Diploma(CourseId, CourseName, CourseDuration, CourseFees, availibility));
                        break;
                    case 2:
                        en.introduce(new Degree(CourseId, CourseName, CourseDuration, CourseFees, availibility));
                        break;
                }
            }
            catch (StudentException e)
            {
                Console.WriteLine(e.Message);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
