using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace SLHDotNetTrainingBatch1.MvcApp.Controllers
{
    public class WalletController : Controller
    {
        SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder
        {
            DataSource = ".",
            InitialCatalog = "MiniWallet",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };

        [ActionName("Index")]
        public async Task<IActionResult> WalletIndex()
        {
            using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            db.Open();
            var lst = await db.QueryAsync<WalletModel>("select * from tbl_wallet");
            return View("WalletIndex", lst.ToList());
        }

        [ActionName("Create")]
        public IActionResult WalletCreate()
        {
            return View("WalletCreate");
        }

        [HttpPost]
        [ActionName("Create")]
        public async Task<IActionResult> WalletCreateAsync(WalletModel requestModel)
        {
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

            TempData["IsSuccess"] = isSuccess;
            TempData["Message"] = message;

            //var task1 = Run();
            //var task2 = Run();
            //var task3 = Run();

            //await Task.WhenAll(task1, task2, task3);

            return RedirectToAction("Index");
            //var lst = await db.QueryAsync<WalletModel>("select * from tbl_wallet");
            //return View("WalletIndex", lst.ToList());
        }

        //private async Task Run()
        //{
        //    await Task.Delay(5000);
        //}

        [HttpGet]
        [ActionName("Edit")]
        public async Task<IActionResult> WalletEdit(int id)
        {
            using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            db.Open();

            string query = @"SELECT [WalletId]
      ,[WalletUserName]
      ,[FullName]
      ,[MobileNo]
      ,[Balance]
  FROM [dbo].[Tbl_Wallet]
  where WalletId = @WalletId";
            var model = await db.QueryFirstOrDefaultAsync<WalletModel>(query, new { WalletId = id });
            if (model is null)
            {
                TempData["IsSuccess"] = false;
                TempData["Message"] = "No data found.";
                return RedirectToAction("Index");
            }
            return View("WalletEdit", model);
        }

        [HttpPost]
        [ActionName("Update")]
        public async Task<IActionResult> WalletUpdate(int id, WalletModel requestModel)
        {
            using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            db.Open();

            string query = @"";

            //var result = await db.ExecuteAsync(query, requestModel);
            var result = 1;
            bool isSuccess = result > 0;
            string message = isSuccess ? "Success." : "Fail.";

            TempData["IsSuccess"] = isSuccess;
            TempData["Message"] = message;

            return RedirectToAction("Index");
        }


        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> WalletDelete(int id)
        {
            using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            db.Open();

            string query = @"SELECT [WalletId]
      ,[WalletUserName]
      ,[FullName]
      ,[MobileNo]
      ,[Balance]
  FROM [dbo].[Tbl_Wallet]
  where WalletId = @WalletId";
            //var model = await db.QueryFirstOrDefaultAsync<WalletModel>(query, new { WalletId = id });

            var result = 1;
            if (result == 0)
            {
                TempData["IsSuccess"] = false;
                TempData["Message"] = "No data found.";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
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
