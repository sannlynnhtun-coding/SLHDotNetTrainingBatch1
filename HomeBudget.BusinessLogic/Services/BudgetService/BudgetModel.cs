using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.BusinessLogic.Services.BudgetService
{
    public class BudgetModel
    {
        public int BudgetId { get; set; }

        public string BudgetName { get; set; } = null!;

        public decimal Amount { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
