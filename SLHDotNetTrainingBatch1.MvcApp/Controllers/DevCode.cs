using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace NOS_MVC.Controllers
{
    public static class DevCode
    {
        private static SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "MiniWallet",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };
        public static Boolean IsNullOrEmptyV3(this string? number)
        {
            if (String.IsNullOrEmpty(number) || String.IsNullOrEmpty(number.Trim()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static Boolean IsWalletExist(string number)
        {
            IDbConnection db = new SqlConnection(stringBuilder.ConnectionString);

          
            string query = "SELECT * FROM Tbl_Wallet WHERE MobileNo = @MobileNo";
            var result = db.QueryFirstOrDefault(query, new
            {
                MobileNo = number
            });

            if (result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
