using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read_Update_Delete
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // table nam se aik table bna k us m data reading k methods dekhy gy

            DataTable table = new DataTable();
            DataColumn idColoum = new DataColumn("id", typeof(int));
            DataColumn nameColoum = new DataColumn("name", typeof(string));
            table.Columns.Add(idColoum);
            table.Columns.Add(nameColoum);
            idColoum.AutoIncrement = true;
            idColoum.AutoIncrementSeed = 1;
            idColoum.AutoIncrementStep = 1;
            table.PrimaryKey = new DataColumn[] { idColoum };
            DataRow row1 = table.NewRow();
            DataRow row2 = table.NewRow();
            DataRow row3 = table.NewRow();
            row1["name"] = "Ali";
            row2["name"] = "Ahmad";
            row3["name"] = "Muhammad";
            table.Rows.Add(row1);
            table.Rows.Add(row2);
            table.Rows.Add(row3);
            // table bna k us m data insert kr diya ab data ko read krry gy 

            // aik table m se data read krny k 3 treeky hoty ha 

            // 1. index based .
            // is m hum kissi bhi row ka index jis ko display kewana ho wo dety ha 
            // is ki return type aik row ha 
            // is liye phle aik row bna k us m value store krwaye gy

            DataRow r = table.Rows[2];
            // 2 ka mtlb ha k index nmbr 2 pr jo row ha wo . yani row nmbr 3

            Console.WriteLine("ID is : " + r["id"]);
            Console.WriteLine("Name is : " + r[1]);


            // 2. second method ha primary key ki base pr data read krna
            // is ki return type aik row hogi 
            // aor us klye phle hum aik DataRow ko use kr k row bnaye gy phir us m data 
            // ko read krry gy

            DataRow readData;

            readData = table.Rows.Find(3);
            // 3 ka mtlb ha Primary key having value 3
            // ab is data ko display krwaye gy
            Console.WriteLine("ID is : " + readData["id"]);
            Console.WriteLine("Name is : " + readData[1]);

            //3. third method ha kissi condition ki base pr yani name=ali ya koi bhi condition
            // is ki return type aik array hoti ha q k multiple rows aik condition
            // ko satisfy kr skti ha . 

            DataRow[] array = table.Select("name='Ali'");
            // hum condition ko double quotes  m likhty ha 
            // lakin agr condition m kissi string ko likhna ho to us klye single quotes
            // ko usee krty ha 

            // ab is data ko agr display krwana ho to foreach loop use krry gy
            foreach (DataRow row in array)
            {
                Console.WriteLine("ID is : " + row["id"]);
                Console.WriteLine("Name is : " + row[1]);
            }

            // hum aik se zyada condition bhi mention kr skty ha 

            DataRow[] multipleConditions = table.Select("name='Ali' or id=2");
            Console.WriteLine("----------------------");
            foreach (DataRow row in multipleConditions)
            {
                Console.WriteLine("ID is : " + row["id"]);
                Console.WriteLine("Name is : " + row[1]);
            }


            // Teeno methods ka comparison


            //1
            //index based m humy jis row ka data chahiye ho uska index pass krty ha
            //Primary key based m primary key ki value pass krty ha aor find ka key word use krty ha
            //condition based m hum select ka key word use krty ah aor conditon dety ha

            //2.
            // index based ki return type row hoti ha
            // PK based ki return type bhi row ha
            // condition based ki return type array hoti ha

            //3.
            // PK based m find ka method aik specific row pr implement hoti ha
            // jb k condition base m select ka method puri table pr implement hoti ha



            // Update

            row1["name"] = "dfhdjhj";

            Console.WriteLine("ID is : " + row1[0]);
            Console.WriteLine("Updated Name is : " + row1[1]);


            // Delete Data

            table.Rows.Remove(row3);
            // jis row ko remove krna ho uska nam pass kr de 



            // agr hum ne kissi row ko us k nam se ni blky primary key ki base
            // pr delete krna ho to:

            int primaryKeyValueToDelete = 2;

            // hum user se bhi input le skty ha 

            // pehle is value wali row ko find krry gy :
            DataRow rowToDelete = table.Rows.Find(primaryKeyValueToDelete);

            // find krny k baad ab delete:

            table.Rows.Remove(rowToDelete);

            // issi trha hum primary key value ki jgga int m aik specific row
            // ka index jis ka nam maloom na ho store kr k bhi ussy delete kr skty ha


        }
    }
}
