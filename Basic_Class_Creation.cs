using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Class_Creation_And_Properties
{
    internal class Student
    {
        private string name;
        private string rollNo;
        private int age;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string RollNo
        {
            get { return rollNo; }
            set { rollNo = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public void display()
        {
            Console.WriteLine("Name is : " + name);
            Console.WriteLine("RollNo is : " + rollNo);
            Console.WriteLine("Age is : " + age);
        }
        //Constructors
        public Student()    //Default
        {
            name = "Muhammad Irfan";
            rollNo = "BSEF21M010";
            age = 22;
        }
        public Student(string n , string r , int a) //Parametarized
        {
            //Agr declaration k time data members ko values assign krni to Constructor
            //use krty ha.
            name = n;
            rollNo = r;
            age = a;
        }
        //String Interpolation
        public override string ToString()
        {
            return $"Name is {name} RollNo is {rollNo} Age is {age}\n";
        }


        //Param . To avoid function Over Loading

        public int add(params int[] args)
        {
            int sum = 0;
            foreach (int i in args)
            {
                sum = sum + i;
            }
            return sum;
        }
        static void Main(string[] args)
        {
            //Every Class is Inherited from a base class called Object Class
            Student std = new Student();
            string stdName, stdRoll;
            int stdAge;
            Console.WriteLine("Enter your Name");
            stdName = Console.ReadLine();
            std.Name = stdName;
            Console.WriteLine("Enter your RollNo");
            stdRoll = Console.ReadLine();
            std.RollNo = stdRoll;
            Console.WriteLine("Enter your Age");
            //Return typr of Console.ReadLine() is always a String 
            stdAge = int.Parse(Console.ReadLine());
            std.Age = stdAge;
            std.display();

            //Object Initializer Syntax. 
            //Ab object ko initialize krny klye Constructor ki Zrort ni.
            Student std2 = new Student { Name = "Muhammad Irfan", RollNo = "Bsef21M010", Age = 22 };
            
            Console.WriteLine(std2);//Automatically call ToString Function


            //Variable initialization

            //1. implicit type variables.

            var x = 10;//At compile time dataType is assigned.
                       // Ab hum is ki value to change kr skty ha but type ni

            //2. Explicit Type variables

            dynamic y = 12;// type is assigned at run time . we can change it later
            y = "ali";


            //Calling param function

            int sum = std.add(1, 2, 3, 4, 5, 6, 7, 7);//we can pass as many parameters as we want
            Console.WriteLine(sum);
        }
    }
}
