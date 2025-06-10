using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.BusinessLogic.Services.ExpenseService.GetExpenseNameService
{
    public class GetExpenseModelResponseModel:BasedResponseModel
    {
        public List<ExpenseModel> ExpenseModels { get; set; } = new List<ExpenseModel>();
    }
}
