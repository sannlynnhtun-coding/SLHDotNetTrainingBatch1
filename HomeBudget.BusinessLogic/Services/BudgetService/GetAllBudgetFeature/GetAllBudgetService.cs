using HomeBudget.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.BusinessLogic.Services.BudgetService.GetAllBudgetFeature
{
    public class GetAllBudgetService
    {
        private readonly AppDbContext _context;

        public GetAllBudgetService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<GetAllBudgetListResponseModel> GetBudgets()
        {
            var budgets = await _context.TblBudgets.ToListAsync();

            var budgetList = new List<GetAllBugetResponseModel>();

            
            foreach (var item in budgets)
            {
                var spentAmount = item.OriginalAmount - item.UpdatedAmount;
                budgetList.Add(new GetAllBugetResponseModel
                {
                    Name = item.BudgetName,
                    OriginalAmount = item.OriginalAmount,
                    UpdatedAmount = item.UpdatedAmount,
                    SpentPercentage = item.UpdatedAmount != 0 ? (((spentAmount / item.OriginalAmount) *100).ToString("N0")) :"0" ,
                    BudgetId = item.BudgetId
                });
            }


            return new GetAllBudgetListResponseModel
            {
                IsSuccess = true,
                Message = "Buget List Extracted",
                BudgetList = budgetList
            };
        }
    }
}
