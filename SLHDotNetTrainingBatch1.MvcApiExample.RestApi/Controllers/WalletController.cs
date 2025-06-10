using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SLHDotNetTrainingBatch1.MvcApiExample.Database.AppDbContextModels;
using System.Threading.Tasks;

namespace SLHDotNetTrainingBatch1.MvcApiExample.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly AppDbContext _db;

        public WalletController(AppDbContext db)
        {
            _db=db;
        }

        [HttpGet]
        public async Task<IActionResult> GetWallets()
        {
            var lst = await _db.TblWallets.ToListAsync();
            return Ok(lst);
        }
    }
}
