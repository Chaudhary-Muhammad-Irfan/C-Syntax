using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disconnecting_Model
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connection = "Data Source=(localdb)\\ProjectModels;Initial Catalog=Inline;Integrated Security=True";
            SqlConnection con=new SqlConnection(connection);
            //Writing Select Query to extract All data from DB table to inline table
            string query = $"select * from dummy";
            SqlCommand cmd=new SqlCommand(query, con);
            // creating an object of sqlDataAdapter
            SqlDataAdapter adapter=new SqlDataAdapter();
            // ab is adapter k object pr selectCommand set krry gy 
            adapter.SelectCommand = cmd;
            // Aik inline DataTable bnaye gy jis m sara data store hoga
            DataTable table= new DataTable();
            // ab sara data inline table  m fetch krry gy using Fill method
            adapter.Fill(table);
            //// for each loop lga k data display krwaye gy
            ///*foreach (DataRow row in table.Rows)
            //{
            //    Console.WriteLine("ID is : " + row[0]);
            //    Console.WriteLine("Name is : " + row[1]);
            //    Console.WriteLine("Age is : " + row[2]);
            //    Console.WriteLine();
            //}*/

            // Insert new Row into DB table
            // is klye pehle hum Inline table m row add krry gy

            DataRow row = table.NewRow();
            row[0] = 5;
            row[1] = "Habib";
            row[2] = 40;
            table.Rows.Add(row);

            // ab is row ko Parametarized query use kr k DB m insert krry gy

            // insert klye query likhy gy 

            string insertQuery = $"insert into dummy (Id, name , age) values (@id , @name,@age)";
            // ab jitny coloums ha utny hi sqlParameter k object bnaye gy
            // hr SqlParameter k 4 parameters hoty ha
            //1. jo hum ne query  m parametarized pass kiya ha wo 
            //2. DB table m us coloum ki data type
            //3. us coloum ka size
            //4. us coloum ka nam
            SqlParameter p1 = new SqlParameter("@id", SqlDbType.Int, 0, "Id");
            SqlParameter p2 = new SqlParameter("@name", SqlDbType.NVarChar, 50, "name");
            SqlParameter p3 = new SqlParameter("@age", SqlDbType.Int, 0, "age");
            SqlCommand insertCommand = new SqlCommand(insertQuery, con);
            // ab is insertCommand m ye tmam SqlParameters add krry gy
            insertCommand.Parameters.Add(p1);
            insertCommand.Parameters.Add(p2);
            insertCommand.Parameters.Add(p3);
            // ab insert command SqlAdapter ki insertCommand ko assign kr de gy
            adapter.InsertCommand = insertCommand;
            //ab is adapter ko update kr de gy
            // agr hum aik se zyada rows ko insert / update / delete kr rhy ho to update sirf
            // end m a kr aik mrtba hi krry gy hr bar alg alg ni
            //adapter.Update(table);

            // Updating Row

            // pehle update ki Query likhy gy

            string updateQuery = $"update dummy set name=@name,age=@age where Id=@id";
            // ab is klye bhi 3 sqlParameter k object bnaye gy
            SqlParameter p4 = new SqlParameter("@id", SqlDbType.Int, 0, "Id");
            SqlParameter p5 = new SqlParameter("@name", SqlDbType.NVarChar, 50, "name");
            SqlParameter p6 = new SqlParameter("@age", SqlDbType.Int, 0, "age");
            SqlCommand updateCommand = new SqlCommand(updateQuery, con);
            // ab is insertCommand m ye tmam SqlParameters add krry gy
            updateCommand.Parameters.Add(p4);
            updateCommand.Parameters.Add(p5);
            updateCommand.Parameters.Add(p6);
            // ab update command SqlAdapter ki updateCommand ko assign kr de gy
            adapter.UpdateCommand = updateCommand;
            // ab wo values likhy gy inline Table m jo update krry ha : updated values
            DataRow updateRow = table.Rows[0];
            // us row ka index jis ko update krna ha .
            // hum user se input bhi le skty ha k kis row ya PK value ko  update krna ha
            updateRow[1] = "Update";
            updateRow[2] = 1;
            // ab adapter ko update krry gy
            //adapter.Update(table);


            // Deleting Row from DB
            // pehle delete klye query likhy gy
            string deleteQuery = $"delete  from dummy where Id=@id";
            // ab is klye bs 1 sqlParameter k object bnaye gy id->Primary key klye
            SqlParameter p7 = new SqlParameter("@id", SqlDbType.Int, 0, "Id");
            //p7.Value = 3 ;// wo value jo hum delete krna chahty ha
            // hum user se bhi input le skty ha

            SqlCommand deleteCommand = new SqlCommand(deleteQuery, con);
            // ab is insertCommand m ye tmam SqlParameters add krry gy
            deleteCommand.Parameters.Add(p7);
            // ab delete command SqlAdapter ki deleteCommand ko assign kr de gy
            adapter.DeleteCommand = deleteCommand;
            // ab wo PK wali row likhy gy inline Table m jo delete krni ha

            DataRow[] deleteRow = table.Select("Id=2");   
            // us row ka index jis ko delete krna ha .
            // hum user se input bhi le skty ha k kis row ya PK value ko  delete krna ha
            foreach(DataRow rows in deleteRow)
            {
                table.Rows.Remove(rows);
            }
            // ab adapter ko update krry gy
            adapter.Update(table);
        }
    }
}
