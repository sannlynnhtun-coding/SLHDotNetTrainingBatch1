using HomeBudget.BusinessLogic.Services.ExpenseService;

namespace HomeBudget.MVC.Models
{
    public class GetBudgetNameViewModel
    {
       public List<ExpenseModel> Name { get; set; } = new List<ExpenseModel>();
    }
}
