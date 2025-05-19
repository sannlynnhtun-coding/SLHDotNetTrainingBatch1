using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SLHDotNetTrainingBatch1.Project.Databases.AppDbContextModels;

namespace SLHDotNetTrainingBatch1.Project4.WebApi.Features.Wallet.RegisterWallet
{
    // Ctrl + M, O
    // Ctrl + M, A
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterWalletController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public RegisterWalletController(AppDbContext appDbContext)
        {
            _appDbContext=appDbContext;
        }

        [HttpPost]
        public IActionResult Execute(RegisterWalletRequestModel requestModel)
        {
            RegisterWalletResponseModel model;

            #region Check Required Fields

            if (string.IsNullOrEmpty(requestModel.WalletUserName))
            {
                model = new RegisterWalletResponseModel
                {
                    Message = "Wallet User Name is required."
                };
                goto Result;
            }
            if (string.IsNullOrEmpty(requestModel.FullName))
            {
                model = new RegisterWalletResponseModel
                {
                    Message = "FullName is required."
                };
                goto Result;
            }
            if (string.IsNullOrEmpty(requestModel.MobileNo))
            {
                model = new RegisterWalletResponseModel
                {
                    Message = "Mobile No is required."
                };
                goto Result;
            }

            #endregion

            #region Validate Duplicate Record

            var itemWallet = _appDbContext.TblWallets.FirstOrDefault(x => x.WalletUserName == requestModel.WalletUserName);
            if(itemWallet is not null)
            {
                model = new RegisterWalletResponseModel
                {
                    Message = "Wallet User Name already registered."
                };
                goto Result;
            }

            itemWallet = _appDbContext.TblWallets.FirstOrDefault(x => x.MobileNo == requestModel.MobileNo);
            if (itemWallet is not null)
            {
                model = new RegisterWalletResponseModel
                {
                    Message = "Mobile No already registered."
                };
                goto Result;
            }

            #endregion

            #region Register Wallet

            TblWallet item = new TblWallet
            {
                Balance = 0,
                FullName = requestModel.FullName,
                MobileNo = requestModel.MobileNo,
                WalletUserName = requestModel.WalletUserName,
            };
            _appDbContext.TblWallets.Add(item);
            _appDbContext.SaveChanges();

            #endregion

            model = new RegisterWalletResponseModel()
            {
                FullName = requestModel.FullName,
                IsSuccess = true,
                WalletUserName = requestModel.WalletUserName,
                Message = "Success",
                MobileNo = requestModel.MobileNo,
                WalletId = item.WalletId
            };

        Result:
            return Ok(model);
        }
    }
}
