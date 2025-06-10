using HomeBudget.BusinessLogic.Services.ExpenseService.CreateExpenseService;
using HomeBudget.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.BusinessLogic.Services.ExpenseService.CreateExpense
{
    public class CreateExpenseService
    {
        private readonly AppDbContext _context;

        public CreateExpenseService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CreateExpenseResponseModel> CreateExpense(CreateExpenseRequestModel requestModel)
        {
            var result =await _context.TblExpenses.AddAsync(new TblExpense
            {
                Name = requestModel.Name,
                Amount = requestModel.Amount,
                CreatedDate = DateTime.UtcNow,
                BudgetId = requestModel.BudgetId
            });


            var budgetDeductResult = await _context.TblBudgets.FirstOrDefaultAsync(x => x.BudgetId == requestModel.BudgetId);
            
            if(budgetDeductResult == null)
            {
                return new CreateExpenseResponseModel
                {
                    IsSuccess = false,
                    Message = "Budget not found"
                };
            }
            decimal updatedAmount = 0;
            if(budgetDeductResult.UpdatedAmount == 0)
            {
                updatedAmount = budgetDeductResult.OriginalAmount - requestModel.Amount;
            }

            else
            {
                updatedAmount = budgetDeductResult.UpdatedAmount - requestModel.Amount;
            }

            budgetDeductResult.UpdatedAmount = updatedAmount;



            await _context.SaveChangesAsync();

            return new CreateExpenseResponseModel
            {
                IsSuccess = true,
                Message = "Expense created successfully",             
            };
        }
    }
}
