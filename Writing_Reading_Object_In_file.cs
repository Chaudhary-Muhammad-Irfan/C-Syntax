using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Writing_Reading_An_Object_In_File
{
    internal class Product
    {
        private int id;
        private string name;
        private string description;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public void saveIntoFile()
        {
            string data = id + "," + name + "," + description;
            FileStream fin = new FileStream("file.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fin);
            sw.Write(data);
            sw.Close();
            fin.Close();
        }
        public void readFromFile()
        {
            string str;
            FileStream fin = new FileStream("file.txt", FileMode.Open);
            StreamReader sr=new StreamReader(fin);
            Product p=new Product();
            str = sr.ReadLine();
            string[] parts = str.Split(',');
            p.ID = int.Parse(parts[0]);
            p.Name = parts[1];
            p.Description = parts[2];
            Console.WriteLine(p.ID + "," + p.Name + "," + p.Description);
            sr.Close();
            fin.Close() ;
        }
        static void Main(string[] args)
        {
            Product p = new Product { ID = 1, Name = "biscuit", Description = "sweet dish" };
            p.saveIntoFile();
            p.readFromFile();
        }
    }
}
