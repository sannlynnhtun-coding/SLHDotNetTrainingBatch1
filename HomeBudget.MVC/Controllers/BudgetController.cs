using HomeBudget.BusinessLogic.Services.BudgetService.CreateBudgetFeature;
using Microsoft.AspNetCore.Mvc;

namespace HomeBudget.MVC.Controllers
{
    public class BudgetController : Controller
    {
        private readonly CreateBudgetService _createBudgetService;

        public BudgetController(CreateBudgetService createBudgetService)
        {
            _createBudgetService = createBudgetService;
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

            if(result.IsSuccess)
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
