using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace SLHDotNetTrainingBatch1.MvcApp2.Controllers
{
    public class WalletController : Controller
    {
        private readonly SqlConnectionStringBuilder sqlConnectionStringBuilder;

        public WalletController(IConfiguration configuration)
        {
            sqlConnectionStringBuilder = new SqlConnectionStringBuilder(configuration.GetConnectionString("DbConnection"));
        }

        [ActionName("Index")]
        public IActionResult WalletIndex()
        {
            return View("WalletIndex");
        }
    }
}
