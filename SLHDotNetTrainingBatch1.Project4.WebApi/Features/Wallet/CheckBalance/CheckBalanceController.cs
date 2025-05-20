using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SLHDotNetTrainingBatch1.Project.Databases.AppDbContextModels;
using SLHDotNetTrainingBatch1.Project4.WebApi.Features.Wallet.RegisterWallet;

namespace SLHDotNetTrainingBatch1.Project4.WebApi.Features.Wallet.CheckBalance
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class CheckBalanceController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public CheckBalanceController(AppDbContext appDbContext)
        {
            _appDbContext=appDbContext;
        }

        [HttpPost]
        public IActionResult Execute(CheckBalanceRequestModel requestModel)
        {
            CheckBalanceResponseModel model;
            if (string.IsNullOrEmpty(requestModel.MobileNo))
            {
                model = new CheckBalanceResponseModel
                {
                    Message = "Mobile No is required."
                };
                goto Result;
            }

            var item = _appDbContext.TblWallets.FirstOrDefault(x => x.MobileNo == requestModel.MobileNo);
            if (item is null)
            {
                model = new CheckBalanceResponseModel
                {
                    Message = "Mobile No doesn't exist."
                };
                goto Result;
            }
            var lst = _appDbContext.TblTransactions.Where(x =>
                (
                    x.FromMobileNo == requestModel.MobileNo ||
                    x.ToMobileNo == requestModel.MobileNo)
                )
                .OrderByDescending(x => x.TransactionDate)
                .Take(5)
                .ToList();

            var transactionHistoryList = lst.Select(x => new CheckBalanceTransactionHistoryModel
            {
                TransactionDate = x.TransactionDate,
                Amount = x.Amount,
                FromMobileNo = x.FromMobileNo,
                ToMobileNo  = x.ToMobileNo,
                TransactionNo = x.TransactionNo
            }).ToList();

            //List<CheckBalanceTransactionHistoryModel> lst2 = new List<CheckBalanceTransactionHistoryModel>();
            //foreach (var x in lst)
            //{
            //    lst2.Add(new CheckBalanceTransactionHistoryModel
            //    {
            //        TransactionDate = x.TransactionDate,
            //        Amount = x.Amount,
            //        FromMobileNo = x.FromMobileNo,
            //        ToMobileNo  = x.ToMobileNo,
            //        TransactionNo = x.TransactionNo
            //    });
            //}

            model = new CheckBalanceResponseModel()
            {
                Balance = item.Balance,
                MobileNo = item.MobileNo,
                IsSuccess = true,
                Message = "Balance Enquriry Success.",
                TransactionHistoryList = transactionHistoryList
            };

        Result:
            return Ok(model);
        }
    }
}
