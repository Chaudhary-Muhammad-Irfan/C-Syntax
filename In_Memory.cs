using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace C_Sharp_Practice 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creating a Table Name Person
            DataTable person = new DataTable("Person");
            // Creating Coloums for Table
            DataColumn idColoum = new DataColumn("id", typeof(int));
            DataColumn nameColoum = new DataColumn("name", typeof(string));
            DataColumn ageColoum = new DataColumn("age", typeof(int));

            // Applying auto increment Property true on id so it is incremented automatically

            idColoum.AutoIncrement = true;
            idColoum.AutoIncrementSeed = 1; // Seed ka mtlb ha k value kha se start hogi
            idColoum.AutoIncrementStep = 1; // sted ka mtlb ha increment kitny ka krna ha


            // Adding Coloums in Table

            person.Columns.Add(idColoum);
            person.Columns.Add(nameColoum);
            person.Columns.Add(ageColoum);

            //Defining Primary key

            person.PrimaryKey = new DataColumn[] { idColoum };

            // Define rows and enter Data in rows

            DataRow person1 = person.NewRow();
            person1["name"] = "Irfan"; // yha pr hum ne jis coloum m value enter krni ha uska nam diya ha [] m yani "name" is ki jgga hum index bhi de skty ha
            person1[2] = 22;// yha pr hum ne age m value input krny klye index diya ha nam ki jgga 

            // Add row in Table

            person.Rows.Add(person1);

            // Add another Row

            DataRow person2 = person.NewRow();
            person2["name"] = "Chaudhary";
            person2[2] = 21;
            person.Rows.Add(person2);

            //Displaying Data of Table by foreach loop

            /*foreach (DataRow row in person.Rows)
            {
                Console.WriteLine("ID of Person Is : " + row[0]);
                Console.WriteLine("Name of Person is : " + row[1]);
                Console.WriteLine("Age of Person is : " + row[2]);
                Console.WriteLine("----------------------------------------------");
            }*/

            // Ab is table ko dataset m add krry gy

            DataSet ds = new DataSet();
            ds.Tables.Add(person);

            // Create Another Table


            DataTable employee = new DataTable();
            DataColumn id = new DataColumn("empID", typeof(int));
            DataColumn name = new DataColumn("empName", typeof(string));
            DataColumn pid = new DataColumn("pid", typeof(int));
            id.AutoIncrement = true;
            id.AutoIncrementSeed = 1;
            id.AutoIncrementStep = 1;
            employee.Columns.Add(id);
            employee.Columns.Add(name);
            employee.Columns.Add(pid);
            employee.PrimaryKey = new DataColumn[] { id };
            DataRow emp1 = employee.NewRow();
            emp1["empName"] = "BSEF21M010";
            emp1["pid"] = 1;   //78
            // ab agr yha m pid m 1 ki jgga koi aesi value de du jo person ki id se match 
            // na krry to sysntax error ni aye ga lakin exception aye gi q k parent key 
            // m aesi value exist ni krti . Exception --> parent key not found
            DataRow emp2 = employee.NewRow();
            emp2["empName"] = "BSEF21M100";
            emp2["pid"] = 2;
            employee.Rows.Add(emp1);
            employee.Rows.Add(emp2);
            // aik se zyada tables ko dataSet m add krny klye
            // hum dataSet ka aik e object bnaye gy

            ds.Tables.Add(employee);

            //foreach (DataRow row in employee.Rows)
            //{
            //    Console.WriteLine("ID of Employee is : " + row[0]);
            //    Console.WriteLine("Name of Employee is : " + row[1]);
            //    Console.WriteLine("Person Id of Employee is : " + row[2]);
            //    Console.WriteLine("--------------------------------------------");
            //}


            // Define Relation between Two tables

            DataRelation relation = new DataRelation("PersonEmpRelation", person.Columns["id"], employee.Columns["pid"]);

            // aik relation m 3 parameters pass hoty ha phla relation ka name double quotes m
            // dusra parent table ka name aor uska coloum
            // tesra child table ka name aor uska coloum jo k foreign key hogi

            // ab is relation ko bhi ussi dataset m add krry gy

            ds.Relations.Add(relation);


            // ab Person table m se id 1 ki child rows access krry gy employee table m se

            // jb bhi hum child rows ko access krry gy to uski return type aik array hogi
            // q k aik parent k multiple child ho skty ha

            DataRow[] child = person.Rows[0].GetChildRows("PersonEmpRelation");
            // yha pr hum ne [] operator m 0 pass kiya ha
            // iska mtlb ha k person table ki  jo first row ha
            // uski PK id ki jo bhi value hogi us k child 


            // ab agr in childs ko display krwana ho to
            foreach (DataRow row in child)
            {
                Console.WriteLine("ID of child employee of person ID 1 is  :  " + row[0]);
                Console.WriteLine("Name of Child employee of person ID 1 is :  " + row[1]);
                Console.WriteLine("Pid Of child employee is :  " + row[2]);
            }

            // ab agr hum ne child table ki kissi row k parent ko find krna ho to 

            DataRow parent = employee.Rows[0].GetParentRow("PersonEmpRelation");
            // index 0 ka mtlb ha phli row m foreign key
            // ki jo bhi value ha us value ka person

            Console.WriteLine("Parent ID is : " + parent[0]);
            Console.WriteLine("Parent Name is : " + parent[1]);
            Console.WriteLine("Age of parent is : " + parent[2]);


            // agr data set m mojood tmam tables k nam , nmbr of row/columns aor data print krwany ho to 

            /*foreach (DataTable table in ds.Tables)
            {
                Console.WriteLine("Name of Table is: " + table.TableName);
                Console.WriteLine("Nmbr of rows in table are : " + table.Rows.Count);
                Console.WriteLine("Nmbr of Coloumns is : " + table.Columns.Count);
                Console.WriteLine("Data in table is : \n");
                foreach (DataRow row in table.Rows)
                {
                    Console.WriteLine("Row[0] is : " + row[0]);
                    Console.WriteLine("Row[1] is : " + row[1]);
                    Console.WriteLine("Row[2] is : " + row[2]);
                }
            }*/


        }
    }
}
