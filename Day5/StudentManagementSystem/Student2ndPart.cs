using System;
class Student
{
	public int id;
	public string name, DateOfBirth;
	public Student(int id, string name, string DateOfBirth)
	{
		this.id=id;
		this.name=name;
		this.DateOfBirth=DateOfBirth;
	}
}
public class Program
{
	public static void Main()
	{
		Console.WriteLine("Enter number of students:");
		int n = int.Parse(Console.ReadLine());
		Student[] std = new Student[n];
		for(int i=0 ; i<n; i++){
			Console.WriteLine("Enter details of Student {0}:",i+1);
			Console.WriteLine("Enter student id:");
			int id=int.Parse(Console.ReadLine());
			Console.WriteLine("Enter Student name:");
			string name=Console.ReadLine();
			Console.WriteLine("Enter Student Date of birth in DD/MM/YYYY format:");
			string DateOfBirth=Console.ReadLine();
			std[i]=new Student(id,name,DateOfBirth);
		}
		Console.WriteLine("Details of student are:");
		for(int i=0; i<n ;i++){
			Console.WriteLine(std[i].id+" "+std[i].name+" "+std[i].DateOfBirth);
		}
	}
}