using Microsoft.AspNetCore.Mvc;
using SLHDotNetTrainingBatch1.MvcApiExample.MvcWebApp.Models;
using SLHDotNetTrainingBatch1.MvcApiExample.MvcWebApp.Services;

namespace SLHDotNetTrainingBatch1.MvcApiExample.MvcWebApp.Controllers
{
    public class WalletController : Controller
    {
        private readonly WalletService _walletService;

        public WalletController(WalletService walletService)
        {
            _walletService=walletService;
        }

        [ActionName("Index")]
        public async Task<IActionResult> WalletIndexAsync()
        {
            List<WalletModel> lst = await _walletService.GetWalletsAsync();
            return View("WalletIndex", lst);
        }
    }
}
