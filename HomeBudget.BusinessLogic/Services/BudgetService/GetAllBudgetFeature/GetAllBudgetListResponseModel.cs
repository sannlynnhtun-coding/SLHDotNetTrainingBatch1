using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.BusinessLogic.Services.BudgetService.GetAllBudgetFeature
{
    public class GetAllBudgetListResponseModel : BasedResponseModel
    {

        public List<GetAllBugetResponseModel> BudgetList { get; set; }
    }
}
