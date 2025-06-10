using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.BusinessLogic.Services.ExpenseService.CreateExpenseFeature
{
    public class CreateExpenseRequestModel
    {
        public string Name { get; set; } = null!;

        public int BudgetId { get; set; }

        public decimal Amount { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
