using StudentManagementSystem;
using System;
namespace Aug11
{
    public enum Level
    {
        Bachelors,
        Masters
    }

    public enum Type
    {
        Professional,
        Academics
    }
    public abstract class Course
    {
        string id;
        string name;
        string duration;
        float fees;
        public int seatsavaialble;

        public Course() { }
        public Course(string id, string name, string duration, float fees,int seatsavaialble)
        {
            this.id = id;
            this.name = name;
            this.duration = duration;
            this.fees = fees;
            this.seatsavaialble = seatsavaialble;
        }

        public string CourseId
        {
            get { return id; }
            set { id = value; }
        }

        public string CourseName
        {
            get { return name; }
            set { name = value; }
        }

        public string CourseDuration
        {
            get { return duration; }
            set { duration = value; }
        }

        public float Fees
        {
            get { return fees; }
            set { fees = value; }
        }

        public abstract float Calculatemonthlyfees();
      
    }

    class DegreeCourse : Course
    {
       // public string level;
       public bool isplacementavailable;
       Level level;
        public DegreeCourse(string id, string name, string duration, float fees,int seats, Level level, bool isplacementavailable) : base(id, name,duration, fees,seats)
        {
           
            this.isplacementavailable = isplacementavailable;
            this.level = level;
        }

      public DegreeCourse() { }
       
             
        public  override float Calculatemonthlyfees()
        {
            if(isplacementavailable)
            {
                //Console.WriteLine(cal);
                return Fees+((Fees*10)/100);
            }
               
            return Fees;

        }

       // float fees = calculatemonthlyfees();
        public override string ToString()
        {
            return "\t" + CourseId + "\t" + CourseName + "\t" + CourseDuration + "\t" + Calculatemonthlyfees() + " " + level + "\n";
        }

    }
    class DiplomaCourse : Course
    {
        // public string type;
        Type type;
        public DiplomaCourse(string id, string name, string duration, int seats,float fees, Type type) : base(id, name, duration, fees,seats)
        {
            this.type = type;
        }

        public override float Calculatemonthlyfees()
        {
            if (type.Equals(Type.Academics))
            {
                //Console.WriteLine(cal);
                return Fees + ((Fees * 5) / 100);
            }
            else
            {
                return Fees + ((Fees * 10) / 100);
            }
        }
           


        public override string ToString()
        {
            return "\t" + CourseId + "\t" + CourseName + "\t" + CourseDuration + "\t" + Calculatemonthlyfees() + "\t"+type+"\n";
        }

    }
}