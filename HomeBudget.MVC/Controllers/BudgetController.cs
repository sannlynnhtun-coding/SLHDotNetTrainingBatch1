using HomeBudget.BusinessLogic.Services.BudgetService.CreateBudgetFeature;
using HomeBudget.BusinessLogic.Services.BudgetService.GetAllBudgetFeature;
using HomeBudget.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeBudget.MVC.Controllers
{
    public class BudgetController : Controller
    {
        private readonly CreateBudgetService _createBudgetService;

        private readonly GetAllBudgetService _getBudgetService;

        public BudgetController(CreateBudgetService createBudgetService, GetAllBudgetService getBudgetService)
        {
            _createBudgetService = createBudgetService;
            _getBudgetService = getBudgetService;
        }


        public async Task<IActionResult> IndexAsync()
        {
            var result = await _getBudgetService.GetBudgets();

            var response = new BudgetIndexViewModel
            {
                BudgetList = result.BudgetList,
            };

            return View("BudgetIndex", response);
        }


        [ActionName("Create")]
        public IActionResult CreateBudgetView()
        {
            return View("CreateBudget");
        }


        [HttpPost]
        [ActionName("Create")]
        public async Task<IActionResult> CreateBudgetAsync(CreateBudgetRequestModel requestModel)
        {
            var result = await _createBudgetService.CreateBudget(requestModel);

            if (result.IsSuccess)
            {
                TempData["SuccessMessage"] = result.Message;
            }
            else
            {
                TempData["ErrorMessage"] = result.Message;
            }
            return RedirectToAction("Create");
        }



    }
}
