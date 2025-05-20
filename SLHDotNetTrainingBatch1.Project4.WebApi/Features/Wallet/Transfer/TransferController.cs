using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SLHDotNetTrainingBatch1.Project.Databases.AppDbContextModels;
using SLHDotNetTrainingBatch1.Project4.WebApi.Features.Wallet.Withdraw;
using static SLHDotNetTrainingBatch1.Project4.WebApi.Features.Wallet.CheckBalance.CheckBalanceController;

namespace SLHDotNetTrainingBatch1.Project4.WebApi.Features.Wallet.Transfer
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly decimal _minAmount;
        private readonly IConfiguration _configuration;

        public TransferController(AppDbContext appDbContext, IConfiguration configuration)
        {
            _appDbContext=appDbContext;
            _configuration=configuration;
            _minAmount =Convert.ToDecimal(_configuration.GetSection("MinAmount").Value);
        }

        [HttpPost]
        public IActionResult Execute(TransferRequestModel requestModel)
        {
            TransferResponseModel model;

            if (string.IsNullOrEmpty(requestModel.FromMobileNo))
            {
                model = new TransferResponseModel
                {
                    Message = "From Mobile No is required."
                };
                goto Result;
            }

            if (string.IsNullOrEmpty(requestModel.ToMobileNo))
            {
                model = new TransferResponseModel
                {
                    Message = "To Mobile No is required."
                };
                goto Result;
            }

            if (requestModel.Amount <= 0)
            {
                model = new TransferResponseModel
                {
                    Message = "Amount must be greater than zero."
                };
                goto Result;
            }

            // check from mobile no
            // check to mobile no
            // check amount
            // debit from mobile no
            // credit to mobile no
            // add transaction

            var itemFromMobileNo = _appDbContext.TblWallets
                .FirstOrDefault(x => x.MobileNo== requestModel.FromMobileNo);

            if (itemFromMobileNo is null)
            {
                model = new TransferResponseModel
                {
                    Message = "From Mobile No doesn't exist."
                };
                goto Result;
            }

            var itemToMobileNo = _appDbContext.TblWallets
            .FirstOrDefault(x => x.MobileNo== requestModel.ToMobileNo);

            if (itemToMobileNo is null)
            {
                model = new TransferResponseModel
                {
                    Message = "To Mobile No doesn't exist."
                };
                goto Result;
            }

            if (requestModel.Amount > itemFromMobileNo.Balance - _minAmount)
            {
                model = new TransferResponseModel
                {
                    Message = $"Insufficient Amount. Minimum Amount must be {_minAmount.ToString("n2")}"
                };
                goto Result;
            }

            itemFromMobileNo.Balance -= requestModel.Amount;
            itemToMobileNo.Balance += requestModel.Amount;
            _appDbContext.SaveChanges();

            _appDbContext.TblTransactions.Add(new TblTransaction
            {
                Amount = requestModel.Amount,
                FromMobileNo = requestModel.FromMobileNo,
                ToMobileNo = requestModel.ToMobileNo,
                TransactionDate = DateTime.Now,
                TransactionNo = DateTime.Now.ToString("yyyyMMdd_hhmmss_fff"),
                TransactionId = Ulid.NewUlid().ToString()
            });
            _appDbContext.SaveChanges();

            model = new TransferResponseModel()
            {
                IsSuccess = true,
                Message = "Transfer Success."
            };

        Result:
            return Ok(model);
        }
    }
}
