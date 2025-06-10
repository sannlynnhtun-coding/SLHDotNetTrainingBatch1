using HomeBudget.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.BusinessLogic.Services.ExpenseService.GetExpenseNameService
{
    public class GetExpenseNameService
    {
        private readonly AppDbContext _context;

        public GetExpenseNameService(AppDbContext context)
        {
            _context = context;
        }



        public async Task<GetExpenseModelResponseModel> GetBudgetNames()
        {
            var list = await _context.TblBudgets.ToListAsync();

            var responseList = new List<ExpenseModel>();

            foreach (var item in list)
            {
                responseList.Add(new ExpenseModel
                {
                    BudgetId = item.BudgetId,
                    Name = item.BudgetName,
                });
            }

            return new GetExpenseModelResponseModel
            {
                ExpenseModels = responseList,
                IsSuccess = true,
                Message = "Success"
            };
        }


    }
}
