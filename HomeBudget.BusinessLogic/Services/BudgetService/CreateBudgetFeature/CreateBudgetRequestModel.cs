using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.BusinessLogic.Services.BudgetService.CreateBudgetFeature
{
    public class CreateBudgetRequestModel
    {
        public string Name { get; set; } = string.Empty;
        
        public decimal Amount { get; set; }
    }
}
