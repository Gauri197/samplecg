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
		Student[] std = new Student[4];
		std[0]=new Student(1,"Saloni","29/03/2000");
		std[1]=new Student(2,"Yash","24/08/1999");
		std[2]=new Student(3,"Divya","04/08/2000");
		std[3]=new Student(4,"Tanmayee","11/04/2001");
		for(int i=0; i<4 ;i++){
			Console.WriteLine(std[i].id+" "+std[i].name+" "+std[i].DateOfBirth);
		}
	}
}