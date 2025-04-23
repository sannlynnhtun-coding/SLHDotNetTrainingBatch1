using System.Data;
using Microsoft.Data.SqlClient;
using SLHDotNetTrainingBatch1.ConsoleApp2;

Console.WriteLine("Hello, World!");

// Data Source = Server Name = .
// Initial Catalog = Database Name = DotNetTrainingBatch1
// User ID = Login = sa
// Password = sasa@123

// .
// (local)
// server name

//SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
//sqlConnectionStringBuilder.DataSource = ".";
//sqlConnectionStringBuilder.InitialCatalog = "DotNetTrainingBatch1";
//sqlConnectionStringBuilder.UserID = "sa";
//sqlConnectionStringBuilder.Password = "sasa@123";
//sqlConnectionStringBuilder.TrustServerCertificate = true;

//SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
//{
//    DataSource  = ".",
//    InitialCatalog = "DotNetTrainingBatch1",
//    UserID = "sa",
//    Password = "sasa@123",
//    TrustServerCertificate = true
//};

////SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=DotNetTrainingBatch1;User ID=sa;Password=sasa@123;TrustServerCertificate=True;");
//SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
//connection.Open();

//string query = "select * from Tbl_Homework";
//SqlCommand cmd = new SqlCommand(query, connection);
//SqlDataAdapter adapter = new SqlDataAdapter(cmd);
//DataTable dt = new DataTable();
//adapter.Fill(dt);

//connection.Close();

HomeworkService service = new HomeworkService();
service.Read();
//service.Detail(1);

Console.ReadLine();

// Run = F5
// Ctrl + Shift + F5