using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Data.SqlClient;
using SLHDotNetTrainingBatch1.SignalrExample2.Hubs;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace SLHDotNetTrainingBatch1.SignalrExample2.Controllers
{
    public class TeamController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IHubContext<ChatHub> _hub;

        public TeamController(IConfiguration configuration, IHubContext<ChatHub> hub)
        {
            _configuration=configuration;
            _hub=hub;
        }

        public IActionResult Index()
        {
            List<TeamModel> lst = new List<TeamModel>();
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DbConnection")))
            {
                lst = db.Query<TeamModel>("select * from Tbl_Team").ToList();
            }
            return View(lst);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveAsync(TeamModel requestModel)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DbConnection")))
            {
                string query = @"INSERT INTO [dbo].[Tbl_Team]
           ([TeamName]
           ,[TeamValue])
     VALUES
           (@TeamName
           ,@TeamValue)";
                db.Execute(query, requestModel);
            }

            List<TeamModel> lst = new List<TeamModel>();
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DbConnection")))
            {
                lst = db.Query<TeamModel>("select * from Tbl_Team").ToList();
            }

            List<int> series = lst.Select(x => x.TeamValue).ToList();
            List<string> labels = lst.Select(x => x.TeamName).ToList();

            // update noti
            await _hub.Clients.All.SendAsync("UpdateChart", series, labels, lst.Count);
            return RedirectToAction("Create");
        }
    }

    public class TeamModel
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public int TeamValue { get; set; }
    }
}
