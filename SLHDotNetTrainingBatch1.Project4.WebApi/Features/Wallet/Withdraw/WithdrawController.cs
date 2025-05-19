using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SLHDotNetTrainingBatch1.Project.Databases.AppDbContextModels;
using SLHDotNetTrainingBatch1.Project4.WebApi.Features.Wallet.Withdraw;

namespace SLHDotNetTrainingBatch1.Project4.WebApi.Features.Wallet.Withdraw
{
    [Route("api/[controller]")]
    [ApiController]
    public class WithdrawController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly decimal _minAmount;
        private readonly IConfiguration _configuration;

        public WithdrawController(AppDbContext appDbContext, IConfiguration configuration)
        {
            _appDbContext=appDbContext;
            _configuration=configuration;
            _minAmount =Convert.ToDecimal(_configuration.GetSection("MinAmount").Value);
        }

        [HttpPost]
        public IActionResult Execute(WithdrawRequestModel requestModel)
        {
            WithdrawResponseModel model;

            if (string.IsNullOrEmpty(requestModel.MobileNo))
            {
                model = new WithdrawResponseModel
                {
                    Message = "Mobile No is required."
                };
                goto Result;
            }
            if (requestModel.Amount <= 0)
            {
                model = new WithdrawResponseModel
                {
                    Message = "Amout must be greater than zero."
                };
                goto Result;
            }

            var itemWallet = _appDbContext.TblWallets.FirstOrDefault(x => x.MobileNo == requestModel.MobileNo);
            if (itemWallet is null)
            {
                model = new WithdrawResponseModel
                {
                    Message = "Wallet User doesn't exist."
                };
                goto Result;
            }

            decimal oldBalance = itemWallet.Balance;
            if (requestModel.Amount > oldBalance - _minAmount) // 100,000 > 100,000 - 10,000 (90,000)
            {
                model = new WithdrawResponseModel
                {
                    Message = $"Insufficient Amount. Minimum Amount must be {_minAmount.ToString("n2")}"
                };
                goto Result;
            }

            decimal newBalance = itemWallet.Balance - requestModel.Amount;

            itemWallet.Balance = newBalance;
            _appDbContext.SaveChanges();

            _appDbContext.TblWalletHistories.Add(new TblWalletHistory
            {
                Amount =requestModel.Amount,
                MobileNo = requestModel.MobileNo,
                TransactionType = "Withdraw"
            });
            _appDbContext.SaveChanges();

            model = new WithdrawResponseModel
            {
                IsSuccess = true,
                Message = $"Withdraw Amount - {requestModel.Amount}",
                OldBalance = oldBalance,
                NewBalance = newBalance,
            };

        Result:
            return Ok(model);
        }
    }
}
