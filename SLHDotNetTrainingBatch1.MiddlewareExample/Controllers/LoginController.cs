using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace SLHDotNetTrainingBatch1.MiddlewareExample.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginRequestModel requestModel)
        {
            // db => login table data == request

            //HttpContext.Response.Cookies.Add("Username", requestModel.Username);    
            var opts = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.Now.AddMinutes(30),
                SameSite = SameSiteMode.Lax,
                Secure = true
            };
            //HttpContext.Response.Cookies.Delete("Username");
            HttpContext.Response.Cookies.Append("Username", requestModel.Username, opts);

            return Redirect("/Home");
        }
    }

    public class LoginRequestModel
    {
        public string Username { get; set;}
        public string Password { get; set;}
    }
}
