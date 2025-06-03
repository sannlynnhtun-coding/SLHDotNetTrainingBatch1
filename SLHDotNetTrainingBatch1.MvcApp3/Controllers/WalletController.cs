using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace SLHDotNetTrainingBatch1.MvcApp3.Controllers
{
    public class WalletController : Controller
    {
        private readonly SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder
        {
            DataSource = ".",
            InitialCatalog = "MiniWallet",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };

        [ActionName("Index")]
        public IActionResult WalletIndex()
        {
            return View("WalletIndex");
        }

        [HttpPost]
        [ActionName("Index")]
        public async Task<IActionResult> WalletListAsync()
        {
            try
            {
                using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
                db.Open();
                var lst = await db.QueryAsync<WalletModel>("select * from tbl_wallet");
                return Json(new { IsSuccess = true, Message = "Success", Data = lst });
            }
            catch (Exception ex)
            {
                return Json(new { IsSuccess = false, Message = ex.ToString() });
            }
        }

        [ActionName("Create")]
        public IActionResult WalletCreate()
        {
            return View("WalletCreate");
        }

        [HttpPost]
        [ActionName("Save")]
        public async Task<IActionResult> WalletSaveAsync(WalletModel requestModel)
        {
            // validation

            requestModel.FullName = requestModel.FullName?.Trim();

            using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            db.Open();

            string query = @"INSERT INTO [dbo].[Tbl_Wallet]
           ([WalletUserName]
           ,[FullName]
           ,[MobileNo]
           ,[Balance])
     VALUES
           (@WalletUserName
           ,@FullName
           ,@MobileNo
           ,@Balance)";
            var result = await db.ExecuteAsync(query, requestModel);
            bool isSuccess = result > 0;
            string message = isSuccess ? "Success." : "Fail.";

            return Json(new { IsSuccess = isSuccess, Message = message });
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> WalletDelete(WalletModel requestModel)
        {
            try
            {
                using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
                db.Open();

                string query = @"Delete FROM [dbo].[Tbl_Wallet] where WalletId = @WalletId";
                var result = await db.ExecuteAsync(query, requestModel);
                return Json(new { IsSuccess = result > 0, Message = result > 0 ? "Success" : "Fail" });
            }
            catch (Exception ex)
            {
                return Json(new { IsSuccess = false, Message = ex.ToString() });
            }
        }
    }

    public class WalletModel
    {
        public int WalletId { get; set; }
        public string WalletUserName { get; set; }
        public string FullName { get; set; }
        public string MobileNo { get; set; }
        public decimal Balance { get; set; }
    }
}
