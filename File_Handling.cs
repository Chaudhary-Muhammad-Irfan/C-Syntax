using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Handling_in_C_
{
    internal class Program
    {
        //Transfer of Data from one source to destination in the form of bytes is called 
        //Stream
        static void Main(string[] args)
        {
            //System.io library for file handling

            //Writing Data (A byte) to file
            //FileStream fin = new FileStream("file.txt", FileMode.Create);
            //fin.WriteByte((byte)'x');
            //fin.Close();

            //Reading Data (A byte) from file
            FileStream read = new FileStream("file.txt",FileMode.Open);
            //byte ko read krny klye aik int type k variable m store krry gy.
            int y;
            y = read.ReadByte();
            char ch=(char)y;
            Console.WriteLine(ch);
            read.Close();


            //Creating a Dublicate File through Program

            FileStream file1 = new FileStream("file1.txt", FileMode.Open);
            FileStream file2 = new FileStream("duplicate.txt", FileMode.Create);
            int readFile;
            readFile = file1.ReadByte();
            while(readFile!=-1)//file reading m file k end pr -1 atta ha
            {
                file2.WriteByte((byte)readFile);
                readFile = file1.ReadByte();
            }
            file1.Close();
            file2.Close();


            // Writing/Reading a whole string at a time

            FileStream writeWholeString = new FileStream("writeString.txt", FileMode.Create);
            string str = "Write this in file";
            StreamWriter sw=new StreamWriter(writeWholeString);
            sw.WriteLine(str);
            sw.Close();
            writeWholeString.Close();


            //Reading

            FileStream readString = new FileStream("writeString.txt", FileMode.Open);
            string readStr=string.Empty;
            StreamReader sr=new StreamReader(readString);
            readStr=sr.ReadLine();
            Console.WriteLine(readStr);
            readString.Close();
            sr.Close();

            // reading m file k end pr null milta ha

            //Two types of Stream
            //1. byte oriented. writing/reading byte by byte
            //2. character oriented. writing/reading whole string at a time using streamReader/StreamWriter

        }
    }
}
