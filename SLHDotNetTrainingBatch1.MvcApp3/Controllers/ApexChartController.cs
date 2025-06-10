using Microsoft.AspNetCore.Mvc;

namespace SLHDotNetTrainingBatch1.MvcApp3.Controllers
{
    public class ApexChartController : Controller
    {
        public IActionResult PieChart()
        {
            ApexChartPieChartViewModel model = new ApexChartPieChartViewModel()
            {
                Series = new List<int> { 44, 55, 13, 43, 22 },
                Labels = new List<string> { "Team A", "Team B", "Team C", "Team D", "Team E" }
            };
            return View(model);
        }
    }

    public class ApexChartPieChartViewModel
    {
        public List<int> Series { get; set; }
        public List<string> Labels { get; set; }
    }
}
