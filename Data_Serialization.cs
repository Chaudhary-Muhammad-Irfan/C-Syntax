using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
namespace Data_Serialization
{
    internal class Student
    {
        //[JsonIgnore]
        // to ignore a property so that it is not serealized 
        // when we deserialize the object the default value will be stored for this ignored member
        public int Age { get; set; }
        public string Name { get; set; }
        public string RollNo { get; set; }
        static void Main(string[] args)
        {
            Student std = new Student { Age = 22, Name = "Muhammad Irfan", RollNo = "BSEF21M010" };
            string json=JsonSerializer.Serialize(std);
            StreamWriter sw=new StreamWriter("data.txt",append:true);
            sw.WriteLine(json);
            sw.Close();

            //Reading sigle object

            /*StreamReader sr = new StreamReader("data.txt");
            string read = sr.ReadLine();
            Student s = JsonSerializer.Deserialize<Student>(read);
            sr.Close();
            Console.WriteLine(s.Name + "," + s.RollNo + "," + s.Age);*/


            //To read multiple Objects

            StreamReader sr = new StreamReader("data.txt");
            List<Student> list = new List<Student>();
            string read = sr.ReadLine();
            while(read!=null)
            {
                Student s = JsonSerializer.Deserialize<Student>(read);
                list.Add(s);
                read=sr.ReadLine();
            }
            sr.Close();
            foreach (Student st in list)
            {
                Console.WriteLine(st.Name + "," + st.RollNo + "," + st.Age);
            }
        }
    }
}
