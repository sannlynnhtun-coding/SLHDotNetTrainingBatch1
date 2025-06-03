using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using NOS_MVC.Controllers;
using SLHDotNetTrainingBatch1.Shared;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace SLHDotNetTrainingBatch1.MvcApp.Controllers
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
        public async Task<IActionResult> WalletIndex()
        {
            using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            db.Open();
            var lst = await db.QueryAsync<WalletModel>("select * from tbl_wallet");
            return View("WalletIndex", lst.ToList());
        }

        [ActionName("HistoryIndex")]
        public async Task<IActionResult> WalletHistroyIndex()
        {
            using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            db.Open();
            var lst = await db.QueryAsync<TranscationModel>("select * from Tbl_Transaction");
            return View("HistoryIndex", lst.ToList());
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

            var conditions = string.Empty;
            if (!string.IsNullOrEmpty(requestModel.WalletUserName))
            {
                conditions += " [WalletUserName] = @WalletUserName, ";
            }
            if (!string.IsNullOrEmpty(requestModel.FullName))
            {
                conditions += " [FullName] = @FullName, ";
            }
            if (!string.IsNullOrEmpty(requestModel.MobileNo))
            {
                conditions += " [MobileNo] = @MobileNo, ";
            }
            if (requestModel.Balance > 0)
            {
                conditions += " [Balance] = @Balance, ";
            }
            conditions = conditions.Substring(0, conditions.Length - 2);
            string query = $@"UPDATE [dbo].[Tbl_Wallet]
                     SET {conditions}
                     WHERE [WalletId] = @WalletId";

            var parameters = new
            {
                WalletId = id,
                WalletUserName = requestModel.WalletUserName,
                FullName = requestModel.FullName,
                MobileNo = requestModel.MobileNo,
                Balance = requestModel.Balance,
            };
            var result = await db.ExecuteAsync(query, parameters);
            bool isSuccess = result > 0;
            string message = isSuccess ? "Success." : "Fail.";

            TempData["IsSuccess"] = isSuccess;
            TempData["Message"] = message;

            return RedirectToAction("Index");
        }


        [ActionName("Delete")]

        public async Task<IActionResult> WalletDelete(int id)
        {
            IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            db.Open();
            string query = "DELETE FROM Tbl_Wallet WHERE WalletId = @WalletId";

            var result = await db.ExecuteAsync(query, new { WalletId = id });

            if (result > 0)
            {
                TempData["isSuccess"] = true;
                TempData["message"] = "Wallet deleted successfully";
            }
            else
            {
                TempData["isSuccess"] = false;
                TempData["message"] = "Failed to delete wallet";
            }

            return RedirectToAction("Index");
        }



        [ActionName("History")]
        public async Task<IActionResult> WalletHistory()
        {
            IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            db.Open();
            string query = "SELECT * FROM Tbl_WalletHistory";

            var result = await db.QueryAsync<WalletHistoryModel>(query);


            return View("WalletHistory", result.ToList());
        }



        [ActionName("Deposit")]
        public IActionResult WalletDepositView()
        {

            return View("WalletDeposit");
        }

        [HttpPost]
        [ActionName("Deposit")]
        public async Task<IActionResult> WalletDeposit(WalletDepositModel requestModel)
        {
            IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            db.Open();



            var data = await db.QueryAsync<WalletModel>(
                "SELECT * FROM Tbl_Wallet WHERE MobileNo = @MobileNo", new WalletModel
                {
                    MobileNo = requestModel.MobileNo


                });

            if (data.ToList().Count <= 0)
            {
                TempData["isSuccess"] = false;
                TempData["Message"] = "Mobile number doesn't exist";

                return RedirectToAction("Deposit");
            }



            string query = @"
                INSERT INTO Tbl_WalletHistory
                (TransactionType, Amount, MobileNo, DateTime)
                VALUES (@TransactionType, @Amount, @MobileNo, @DateTime)";

            var result = await db.ExecuteAsync(query, new WalletDepositModel
            {
                TransactionType = "Deposit",
                Amount = requestModel.Amount,
                MobileNo = requestModel.MobileNo,
                DateTime = DateTime.Now
            });

            await db.ExecuteAsync("UPDATE Tbl_Wallet SET Balance = Balance + @Amount WHERE MobileNo = @MobileNo", new
            {
                Amount = requestModel.Amount,
                MobileNo = requestModel.MobileNo
            });

            if (result > 0)
            {
                TempData["isSuccess"] = true;
                TempData["message"] = "Deposit successful";
            }
            return RedirectToAction("History");
        }




        //==============================================================================

        [ActionName("Withdraw")]
        public IActionResult WalletWithdrawView()
        {

            return View("WalletWithdraw");
        }

        [HttpPost]
        [ActionName("Withdraw")]
        public async Task<IActionResult> WalletWithdraw(WalletWithdrawModel requestModel)
        {
            IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            db.Open();



            var data = await db.QueryAsync<WalletModel>(
                "SELECT * FROM Tbl_Wallet WHERE MobileNo = @MobileNo", new WalletModel
                {
                    MobileNo = requestModel.MobileNo


                });

            if (data.ToList().Count <= 0)
            {
                TempData["isSuccess"] = false;
                TempData["Message"] = "Mobile number doesn't exist";

                return RedirectToAction("Withdraw");
            }



            string query = @"
                INSERT INTO Tbl_WalletHistory
                (TransactionType, Amount, MobileNo, DateTime)
                VALUES (@TransactionType, @Amount, @MobileNo, @DateTime)";

            var result = await db.ExecuteAsync(query, new WalletWithdrawModel
            {
                TransactionType = "Withdraw",
                Amount = requestModel.Amount,
                MobileNo = requestModel.MobileNo,
                DateTime = DateTime.Now
            });

            await db.ExecuteAsync("UPDATE Tbl_Wallet SET Balance = Balance - @Amount WHERE MobileNo = @MobileNo", new
            {
                Amount = requestModel.Amount,
                MobileNo = requestModel.MobileNo
            });

            if (result > 0)
            {
                TempData["isSuccess"] = true;
                TempData["message"] = "Withdraw successful";
            }
            return RedirectToAction("History");
        }



        [ActionName("Transfer")]
        public IActionResult WalletTransferView()
        {
            return View("WalletTransfer");
        }

        [HttpPost]
        [ActionName("Transfer")]
        public async Task<IActionResult> WalletTransfer(WalletTransferModel requestModel)
        {
            IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            db.Open();

            var fromWallet = await db.QueryFirstOrDefaultAsync<WalletModel>(
                "SELECT * FROM Tbl_Wallet WHERE MobileNo = @FromMobileNo", requestModel);

            var toWallet = await db.QueryFirstOrDefaultAsync<WalletModel>(
                "SELECT * FROM Tbl_Wallet WHERE MobileNo = @ToMobileNo", requestModel);

            if (fromWallet is null)
            {
                TempData["isSuccess"] = false;
                TempData["Message"] = "From Mobile number doesn't exist";

                return RedirectToAction("Transfer");
            }

            if (toWallet is null)
            {
                TempData["isSuccess"] = false;
                TempData["Message"] = "To Mobile number doesn't exist";

                return RedirectToAction("Transfer");
            }

            if (fromWallet.Balance < requestModel.Amount)
            {
                TempData["isSuccess"] = false;
                TempData["Message"] = "Insufficient balance for transfer";

                return RedirectToAction("Transfer");
            }

            string fromQuery = @"UPDATE Tbl_Wallet SET Balance = Balance - @Amount WHERE MobileNo = @FromMobileNo";

            string toQuery = @"UPDATE Tbl_Wallet SET Balance = Balance + @Amount WHERE MobileNo = @ToMobileNo";

            string transactionQuery = @"INSERT INTO Tbl_Transaction VALUES
                                            (@TransactionId,
                                             @TransactionNo,
                                            @FromMobileNo,
                                            @ToMobileNo,
                                            @Amount,
                                            @TransactionDate)";

            var fromResult = await db.ExecuteAsync(fromQuery, requestModel);

            var toResult = await db.ExecuteAsync(toQuery, requestModel);

            var transactionResult = await db.ExecuteAsync(transactionQuery, new TransactionModel
            {

                TransactionId = Guid.NewGuid().ToString(),
                TransactionNo = Guid.NewGuid().ToByteArray(),
                FromMobileNo = requestModel.FromMobileNo,
                ToMobileNo = requestModel.ToMobileNo,
                Amount = requestModel.Amount,
                TransactionDate = DateTime.Now
            });

            if (fromResult > 0 && toResult > 0 && transactionResult > 0)
            {
                TempData["isSuccess"] = true;
                TempData["message"] = "Transfer successful";
            }
            else
            {
                TempData["isSuccess"] = false;
                TempData["message"] = "Transfer failed";
            }

            return RedirectToAction("Index");




        }
        [ActionName("check-balance")]

        public IActionResult WalletCheckBalanceView()
        {
            return View("WalletCheckBalance");
        }

        [HttpPost]
        [ActionName("check-balance")]

        public async Task<IActionResult> WalletCheckBalance(WalletCheckBalanceModel requestModel)
        {
            IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            if (NOS_MVC.Controllers.DevCode.IsWalletExist(requestModel.MobileNo))
            {
                String query = "SELECT * FROM Tbl_Wallet WHERE MobileNo = @MobileNo";

                var Balance = await db.QueryFirstOrDefaultAsync<WalletCheckBalanceResponseModel>(query, requestModel);

                TempData["isSuccess"] = true;
                TempData["message"] = $"Your balance is {Balance.Balance.ToString("n0")}";
            }
            else
            {
                TempData["isSuccess"] = false;
                TempData["message"] = "Mobile number doesn't exist";
                return RedirectToAction("check-balance");
            }
            return RedirectToAction("check-balance");
        }




        //    [HttpGet]
        //    [ActionName("Transfer")]
        //    public IActionResult WalletTransfer()
        //    {
        //        return View("WalletTransfer");
        //    }

        //    [HttpPost]
        //    [ActionName("Transfer")]
        //    public async Task<IActionResult> WalletTransfer(TranscationModel requestModel)
        //    {
        //        bool isSuccess = false;
        //        string message = string.Empty;
        //        if (!requestModel.FromMobileNo.IsNullOrEmptyV3())
        //        {
        //            message = "From Mobile No is Required";
        //            goto InvalidResult;
        //        }
        //        if (!requestModel.ToMobileNo.IsNullOrEmptyV3())
        //        {
        //            message = "To mobile No is required";
        //            goto InvalidResult;
        //        }
        //        if (requestModel.Amount <= 0)
        //        {
        //            message = "Amount is invalid";
        //            goto InvalidResult;
        //        }

        //        using (IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
        //        {
        //            db.Open();
        //            string getQuery = "select * from Tbl_Wallet where MobileNo = @MobileNo;";

        //            var dataFromMobileNo = await db.QueryFirstOrDefaultAsync<WalletModel>(getQuery, new
        //            {
        //                MobileNo = requestModel.FromMobileNo
        //            });

        //            if (dataFromMobileNo is null)
        //            {
        //                message = "From Mobile No is Invalid";
        //                goto InvalidResult;
        //            }

        //            var dataToMobileNo = await db.QueryFirstOrDefaultAsync<WalletModel>(getQuery, new
        //            {
        //                MobileNo = requestModel.ToMobileNo
        //            });
        //            if (dataToMobileNo is null)
        //            {
        //                message = "To Mobile No is Invalid";
        //                goto InvalidResult;
        //            }

        //            if (dataFromMobileNo!.Balance - 10000 < requestModel.Amount)
        //            {
        //                message = "Insufficient Amount";
        //                goto InvalidResult;
        //            }


        //            dataFromMobileNo.Balance -= requestModel.Amount;

        //            dataToMobileNo.Balance += requestModel.Amount;

        //            string updQuery = @"INSERT INTO [dbo].[Tbl_Transcation]
        //       ([TranscationId]
        //       ,[TranscationNo]
        //       ,[FromMobileNo]
        //       ,[ToMobileNo]
        //       ,[Amount]
        //       ,[TransctationDate])
        // VALUES
        //       (@TranscationId
        //       ,@TranscationNo
        //       ,@FromMobileNo
        //       ,@ToMobileNo
        //       ,@Amount
        //       ,@TransctationDate)";

        //            TranscationModel responseModel = new TranscationModel()
        //            {
        //                FromMobileNo = dataFromMobileNo.MobileNo,
        //                ToMobileNo = dataToMobileNo.MobileNo,
        //                Amount = requestModel.Amount,
        //                TransctationDate = DateTime.Now,
        //                TranscationNo = DateTime.Now.ToString("yyyyMMdd_hhmmss_fff"),
        //                TranscationId = Ulid.NewUlid().ToString(),
        //            };

        //            int result = await db.ExecuteAsync(updQuery, responseModel);

        //            isSuccess = result > 0;
        //            message = isSuccess ? "Transfer Success" : "Transter Fail";
        //        }

        //    Result:

        //        TempData["IsSuccess"] = isSuccess;
        //        TempData["Message"] = message;

        //        return View("TranscationHistory", requestModel);

        //    InvalidResult:
        //        TempData["IsSuccess"] = false;
        //        TempData["Message"] = message;
        //        return RedirectToAction("Transfer");
        //    }
        //}
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


    public class WalletHistoryModel
    {
        public int WalletHistoryId { get; set; }
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
        public string MobileNo { get; set; }
        public DateTime DateTime { get; set; }
    }

public class WalletDepositModel
{
    public int WalletHistoryId { get; set; }
    public string TransactionType { get; set; }
    public decimal Amount { get; set; }
    public string MobileNo { get; set; }
    public DateTime DateTime { get; set; }
}
    public class WalletWithdrawModel
    {
        public int WalletHistoryId { get; set; }
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
        public string MobileNo { get; set; }
        public DateTime DateTime { get; set; }
    }

public class WalletTransferModel
{

    public decimal Amount { get; set; }
    public string FromMobileNo { get; set; }
    public string ToMobileNo { get; set; }

}

public class WalletCheckBalanceModel
{
    public string MobileNo { get; set; }
}

public class WalletCheckBalanceResponseModel
{

    public decimal Balance { get; set; }
}

    public class TranscationModel()
    {
        public string TranscationId { get; set; } = null!;

        public string TranscationNo { get; set; } = null!;

        public string FromMobileNo { get; set; } = null!;

        public string ToMobileNo { get; set; } = null!;

        public decimal Amount { get; set; }

        public DateTime TransctationDate { get; set; }
    }



