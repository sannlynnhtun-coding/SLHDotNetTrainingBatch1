using HomeBudget.BusinessLogic.Services.BudgetService.GetAllBudgetFeature;
using HomeBudget.BusinessLogic.Services.ExpenseService;

namespace HomeBudget.MVC.Models
{
    public class BudgetIndexViewModel
    {
        public List<GetAllBugetResponseModel> BudgetList { get; set; } = new List<GetAllBugetResponseModel>();

    }
}
