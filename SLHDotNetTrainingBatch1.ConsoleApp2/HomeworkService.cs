using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace SLHDotNetTrainingBatch1.ConsoleApp2
{
    internal class HomeworkService
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "DotNetTrainingBatch1",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };

        public void Read()
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = "select * from Tbl_Homework";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                //DataColumn dc = dt.Columns[0];
                //DataColumn dc2 = dt.Columns["No"];

                Console.WriteLine(dr["No"]);
                Console.WriteLine(dr["Name"]);
                Console.WriteLine(dr["GitHubUserName"]);
                Console.WriteLine("-------------------------");
            }
            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine(dr["No"]);
                Console.WriteLine(dr["Name"]);
                Console.WriteLine(dr["GitHubUserName"]);
                Console.WriteLine("-------------------------");
            }
        }

        public void Detail(int no)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = $"select * from Tbl_Homework where No = @No";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@No", no);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();

            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("No record found.");
                return;
            }

            DataRow dr = dt.Rows[0];
            Console.WriteLine(dr["No"]);
            Console.WriteLine(dr["Name"]);
            Console.WriteLine(dr["GitHubUserName"]);
            Console.WriteLine("-------------------------");
        }

        // List / Detail (Edit)

        // CRUD

        // CUD => Command (query) => Execute
        // R => Fetch

        public void Create()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine()!;

            Console.Write("Enter GitHubUserName: ");
            string githubUserName = Console.ReadLine()!;

            Console.Write("Enter GitHubRepoLink: ");
            string githubRepoLink = Console.ReadLine()!;

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = $@"
INSERT INTO [dbo].[Tbl_Homework]
           ([Name]
           ,[GitHubUserName]
           ,[GitHubRepoLink])
     VALUES
           (@Name
           ,@GitHubUserName
           ,@GitHubRepoLink)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@GitHubUserName", githubUserName);
            cmd.Parameters.AddWithValue("@GitHubRepoLink", githubRepoLink);

            int result = cmd.ExecuteNonQuery();

            //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //adapter.Fill(dt);

            connection.Close();
        }

        public void Update()
        {
            Console.Write("Enter Id: ");
            string id = Console.ReadLine()!;

            // Process

            // try parse

            // if success

            // check database

            // not found

            Console.Write("Enter Name: ");
            string name = Console.ReadLine()!;

            Console.Write("Enter GitHubUserName: ");
            string githubUserName = Console.ReadLine()!;

            Console.Write("Enter GitHubRepoLink: ");
            string githubRepoLink = Console.ReadLine()!;

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = $@"
UPDATE [dbo].[Tbl_Homework]
   SET [Name] = @Name
      ,[GitHubUserName] = @GitHubUserName 
      ,[GitHubRepoLink] = @GitHubRepoLink
 WHERE No = @Id";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@GitHubUserName", githubUserName);
            cmd.Parameters.AddWithValue("@GitHubRepoLink", githubRepoLink);

            int result = cmd.ExecuteNonQuery();

            //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //adapter.Fill(dt);

            connection.Close();
        }

        public void Login()
        {
            Console.Write("Enter UserName: ");
            string userName = Console.ReadLine()!;

            Console.Write("Enter Password: ");
            string password = Console.ReadLine()!;

            string query = @$"select * from Tbl_User 
where 
UserName = @UserName and 
Password = @Password";
            
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@UserName", userName);
            cmd.Parameters.AddWithValue("@Password", password);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();
        }
    }
}
