using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //addCandidate();
            //deleteCandidate();
            //displayAllCandidates();
            //updateCandidate();
            //totalVotes();
            addCandidateUsingParametarizedQuery();
        }
        static void addCandidate()
        {
            try
            {
                string connection = "Data Source=(localdb)\\ProjectModels;Initial Catalog=VotingSystem;Integrated Security=True";
                SqlConnection conn = new SqlConnection(connection);
                //Insert Data in DB
                string name, party;
                int votes, id;
                Console.WriteLine("Enter the Name of Candidate");
                name = Console.ReadLine();
                Console.WriteLine("Enter the Name of Party");
                party = Console.ReadLine();
                Console.WriteLine("Enter the CandidateID");
                id = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Votes of Candidate");
                votes = int.Parse(Console.ReadLine());
                string insert = $"insert into Candidate(CandidateID,Name,Party,Votes) values({id},'{name}','{party}',{votes})";
                SqlCommand cmd = new SqlCommand(insert, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Console.Write("Row inserted in DB successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void deleteCandidate()
        {
            try
            {
                string connection = "Data Source=(localdb)\\ProjectModels;Initial Catalog=VotingSystem;Integrated Security=True";
                SqlConnection conn = new SqlConnection(connection);
                int id;
                Console.WriteLine("Enter the CandidateID whom u want to delete");
                id = int.Parse(Console.ReadLine());
                string delete = $"delete from Candidate where CandidateID={id}";
                SqlCommand cmd = new SqlCommand(delete, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Console.Write("Row deleted successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void displayAllCandidates()
        {
            try
            {
                string connection = "Data Source=(localdb)\\ProjectModels;Initial Catalog=VotingSystem;Integrated Security=True";
                SqlConnection conn = new SqlConnection(connection);
                string query = $"select * from Candidate";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();// for reading data from DB
                while (reader.Read())
                {
                    Console.WriteLine(reader[0].ToString());
                    Console.WriteLine(reader[1].ToString());
                    Console.WriteLine(reader[2].ToString());
                    Console.WriteLine(reader[3].ToString());
                    Console.WriteLine("---------------------------------");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void updateCandidate()
        {
            try
            {
                string connection = "Data Source=(localdb)\\ProjectModels;Initial Catalog=VotingSystem;Integrated Security=True";
                SqlConnection conn = new SqlConnection(connection);
                string name, party;
                int votes, id;
                Console.WriteLine("Enter the CandidateID whose record u want to update");
                id = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the new Name of Candidate");
                name = Console.ReadLine();
                Console.WriteLine("Enter the new Name of Party");
                party = Console.ReadLine();
                Console.WriteLine("Enter the Votes of Candidate");
                votes = int.Parse(Console.ReadLine());
                string update = $"update Candidate set Name='{name}' , Party='{party}',Votes={votes} where CandidateID={id}";
                SqlCommand cmd = new SqlCommand(update, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                // To check how many rows are updated
                int rowsUpdated = cmd.ExecuteNonQuery();
                Console.WriteLine("Updated rows are : " + rowsUpdated);
                conn.Close();
                Console.Write("Row updated successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void totalVotes()
        {
            try
            {
                string connection = "Data Source=(localdb)\\ProjectModels;Initial Catalog=VotingSystem;Integrated Security=True";
                SqlConnection conn = new SqlConnection(connection);
                string scalar = $"select sum(Votes) from Candidate";
                SqlCommand cmd = new SqlCommand(scalar, conn);
                conn.Open();
                object result=cmd.ExecuteScalar();
                conn.Close();
                Console.WriteLine("Sum of Votes is : "+result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void addCandidateUsingParametarizedQuery()
        {
            try
            {
                string connection = "Data Source=(localdb)\\ProjectModels;Initial Catalog=VotingSystem;Integrated Security=True";
                SqlConnection conn = new SqlConnection(connection);
                string name, party;
                int votes, id;
                Console.WriteLine("Enter the Name of Candidate");
                name = Console.ReadLine();
                Console.WriteLine("Enter the Name of Party");
                party = Console.ReadLine();
                Console.WriteLine("Enter the CandidateID");
                id = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Votes of Candidate");
                votes = int.Parse(Console.ReadLine());
                string insert = $"insert into Candidate(CandidateID,Name,Party,Votes) values(@id,@name,@party,@votes)";
                SqlCommand cmd = new SqlCommand(insert, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@party", party);
                cmd.Parameters.AddWithValue("@votes", votes);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Console.Write("Row inserted in DB successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
