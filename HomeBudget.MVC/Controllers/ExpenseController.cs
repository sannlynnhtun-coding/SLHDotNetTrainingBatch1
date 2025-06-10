using HomeBudget.BusinessLogic.Services.ExpenseService.CreateExpense;
using HomeBudget.BusinessLogic.Services.ExpenseService.CreateExpenseService;
using HomeBudget.BusinessLogic.Services.ExpenseService.GetExpenseNameService;
using HomeBudget.Database.Models;
using HomeBudget.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeBudget.MVC.Controllers
{
    public class ExpenseController : Controller
    {

        private readonly GetExpenseNameService _getExpenseName;
        private readonly CreateExpenseService _createExpenseService;

        public ExpenseController(GetExpenseNameService getExpenseName, CreateExpenseService createExpenseService)
        {
            _getExpenseName = getExpenseName;
            _createExpenseService = createExpenseService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ActionName("Create")]
        public async Task<IActionResult> CreateExpenseViewAsync()
        {
            var budgetListNames = await _getExpenseName.GetBudgetNames();

            GetBudgetNameViewModel model = new GetBudgetNameViewModel();

            model.Name = budgetListNames.ExpenseModels;


            return View("CreateExpense", model);
        }

        [HttpPost]
        [ActionName("Create")]
        public async Task<IActionResult> CreateExpense(CreateExpenseRequestModel requestModel)
        {
            var result = await _createExpenseService.CreateExpense(requestModel);

            if(result.IsSuccess)
            {
                TempData["IsSuccess"] = true;
                TempData["Message"] = "Expense Created";

                return RedirectToAction("Create");
            }


                TempData["IsSuccess"] = false;
                TempData["Message"] = "Fail to create expense";
            
            return RedirectToAction("Create");
        }


    }
}
