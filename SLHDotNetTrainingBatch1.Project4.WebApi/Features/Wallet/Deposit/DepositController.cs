using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SLHDotNetTrainingBatch1.Project.Databases.AppDbContextModels;
using SLHDotNetTrainingBatch1.Project4.WebApi.Features.Wallet.RegisterWallet;

namespace SLHDotNetTrainingBatch1.Project4.WebApi.Features.Wallet.Deposit
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepositController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public DepositController(AppDbContext appDbContext)
        {
            _appDbContext=appDbContext;
        }

        [HttpPost]
        public IActionResult Execute(DepositRequestModel requestModel)
        {
            DepositResponseModel model;

            if (string.IsNullOrEmpty(requestModel.MobileNo))
            {
                model = new DepositResponseModel
                {
                    Message = "Mobile No is required."
                };
                goto Result;
            }
            if (requestModel.Amount <= 0)
            {
                model = new DepositResponseModel
                {
                    Message = "Amout must be greater than zero."
                };
                goto Result;
            }

            var itemWallet = _appDbContext.TblWallets.FirstOrDefault(x => x.MobileNo == requestModel.MobileNo);
            if (itemWallet is null)
            {
                model = new DepositResponseModel
                {
                    Message = "Wallet User doesn't exist."
                };
                goto Result;
            }

            decimal oldBalance = itemWallet.Balance;
            decimal newBalance = itemWallet.Balance + requestModel.Amount;

            itemWallet.Balance = newBalance;
            _appDbContext.SaveChanges();

            _appDbContext.TblWalletHistories.Add(new TblWalletHistory
            {
                Amount =requestModel.Amount,
                MobileNo = requestModel.MobileNo,
                TransactionType = "Deposit"
            });
            _appDbContext.SaveChanges();

            model = new DepositResponseModel
            {
                IsSuccess = true,
                Message = $"Deposit Amount - {requestModel.Amount}",
                OldBalance = oldBalance,
                NewBalance = newBalance,
            };

        Result:
            return Ok(model);
        }
    }
}
