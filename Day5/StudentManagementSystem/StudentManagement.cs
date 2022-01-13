class Student
{
	//Auto Implemented Properties
	public int StudentId{get;set;}
	public string StudentName{get;set;}
	public DateTime DateOfBirth{get;set;}
	public double ExamFees{get;set;}
	//Variables
	//protected int StudentId;
	//protected string StudentName;
	//protected DateTime DateOfBirth;
	//protected double ExamFees;
	//Constructors
	public Student()
	{
		StudentId=101;
		StudentName="Kavin";
		ExamFees=8000;
	}
	public Student(int id,string name,double fees)
	{
		StudentId=id;
		StudentName=name;
		ExamFees=fees;
	}
	//Methods
	public void DisplayStudent()
	{
		string str="Student Name is {0}, Student Id is {1},Fees is {2}",StudentName,StudentId,ExamFees);
		Console.WriteLine(str);
	}
	public double PayFees()
	{
		return ExamFees;	
	}
	public Student AcceptStudent()
	{	
		Student s1=new Student();
		//cw and cr Accept the full student details here
		Console.WriteLine("Please enter StudentId");
		s1.StudentId=int.Parse(Console.ReadLine());
		
		return s1;

	}
	//public int GetStudentId()
	//{
	//	return StudentId;
	//}
	//public void SetStudentId(int id)
	//{
	//	StudentId=id;
	//}
	//Properties
	//public string SName//properties to access private member variables
	//{
	//	get{return StudentName;}
	//	set{StudentName=value;}
	//}
	//public double Fees
	//{
	//	get{return ExamFees;}
	//	set{ExamFees=value;}
	//}
	

}

public class Enroll
{
	Student[] students=new Student[5];//has a relationship
	static int count=0;
	public Enroll()
	{
		foreach(int i in students.Length)
		{
			students[i]=new Student();
		}
	}
	public void Register(Student s)
	{
		students[count]=s;
		count++:
		
	}
	public Student[] ListOfStudents()
	{
		return students;
	}

}

public class App
{
	public void showFirstScreen()
	{
		Console.WriteLine("Welcome to SMS");
		showStudentScreen();

	}
	public void showStudentScreen()
	{
		Console.WriteLine("---Welcome to Student Center----");
		Console.WriteLine("ENter your Choice:\n1.Register \n2.Show Student Details \n3.Exit");
		string ch=Console.ReadLine();
		switch(ch)
		{
			case "1":
				showStudentRegistrationScreen();
				break;
			case "2":
				showStudentDetails();
				break();
			case "3":
				return;
			default:
				Console.WriteLine("Pls enter correct choice");
				break;
		}

	}
	public static void Main()
	{
		App app=new App();
		app.showFirstScreen();
		
	}
}