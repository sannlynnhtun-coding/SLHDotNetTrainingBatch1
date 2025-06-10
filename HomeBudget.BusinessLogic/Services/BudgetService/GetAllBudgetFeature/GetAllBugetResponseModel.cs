using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.BusinessLogic.Services.BudgetService.GetAllBudgetFeature
{
    public class GetAllBugetResponseModel
    {
        public string Name { get; set; }

        public decimal OriginalAmount { get; set; }

        public decimal UpdatedAmount { get; set; }

        public string SpentPercentage { get; set; }

        public int BudgetId { get; set; }
    }
}   
