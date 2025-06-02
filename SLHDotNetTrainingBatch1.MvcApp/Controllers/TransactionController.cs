using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace NOS_MVC.Controllers
{
    public class TransactionController : Controller
    {
        SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "MiniWallet",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };


        [ActionName("History")]
        public async Task<IActionResult> TransactionHistory()
        {
            IDbConnection db = new SqlConnection(stringBuilder.ConnectionString);
            db.Open();

            string query = @"SELECT TOP 40 
            t.TransactionId,
            t.FromMobileNo, 
            t.ToMobileNo, 
            w.FullName, 
            t.Amount, 
            t.TransactionDate 
            FROM Tbl_Transaction t 
                JOIN 
            Tbl_Wallet w ON w.MobileNo = t.ToMobileNo ";

            var lst = await db.QueryAsync<TransactionModel>(query);

            return View("TransactionHistory", lst.ToList());
        }
    }


    public class TransactionModel
    {
        public string TransactionId { get; set; }
        public byte[] TransactionNo { get; set; }
        public string FromMobileNo { get; set; }
        public string ToMobileNo { get; set; }

        public string FullName { get; set; }
        public decimal Amount { get; set; }

        public DateTime TransactionDate { get; set; }
      
    }
}
