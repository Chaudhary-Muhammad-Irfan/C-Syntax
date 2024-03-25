using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static_Const_ReadOnly_Tuple_Default_Argyments
{
    internal class Program
    {
        public const int c=100;
        // const can be initialized at the time of declaration only.
        //they are by default static.
        //they can be accessed without an object with the class name
        public static int s=0;
        // they can be initialized at the time of declaration or in a static construtor
        //they can be accessed without an object with the class name just
        public readonly int r=100;
        //they can be initialized at the time of declaration or in any construtor
        // their value can't be changed later

        //static readonly  is similar to const


        //Default/optional arguments
        public void add(int a,int b=7)
        {
            Console.WriteLine(a + b);
        }

        //ref keyword

        //There are two types of data types . value types and reference types
        //when value types passed in a function there copy is generated and all the changes
        // are made in the copy but original variable remain same.
        //But in reference type no copy generated and the changes are made in original varibale

        public void refPass(int a , ref int b)
        {
            a = a + 10;
            b=b+10;
        }

        //Tuple to return more than one values from a function

        public (string str1 , string str2) getMoreThanOneValue(string a , string b)
        {
            a = a + "Ali";
            b = b + "ahmad";
            return (a, b);
        }

        //Out key word

        public void outUsage(out int a , out int b)
        {
            a = 30;
            b = 50;
        }
        static void Main(string[] args)
        {
            Program p=new Program();
            //Function with default arguments called
            p.add(3);

            //Ref key word function call

            int a=7,b = 7;
            p.refPass(a,ref b);
            Console.WriteLine(a + " " + b);


            //Tuple function call . We call the function
            //that return more than one value in a var type variable

            var tupleCalled = p.getMoreThanOneValue("a", "b");
            Console.WriteLine(tupleCalled);

            //Out function called

            // to pass variable in function as out parameter we don't need to initialize
            // that variable before passing. compiler itself is responsible to initialize it

            int x, y;
            p.outUsage(out x, out y);
            Console.WriteLine(x + " " + y);
        }
    }
}
