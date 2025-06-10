using HomeBudget.BusinessLogic.Services.BudgetService.CreateBudgetFeature;

using HomeBudget.Database.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.BusinessLogic.Services.ExpenseService.CreateExpenseFeature
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


            var result = await _context.TblExpenses.AddAsync(new TblExpense
            {
                Name = requestModel.Name,
                BudgetId = requestModel.BudgetId,
                Amount = requestModel.Amount,
                CreatedDate = DateTime.UtcNow
            });

            var saveResult = await _context.SaveChangesAsync();

            if (saveResult > 0)
            {
                return new CreateExpenseResponseModel
                {
                    IsSuccess = true,
                    Message = "Budget created successfully",
                    Data = saveResult
                };
            }

            return new CreateExpenseResponseModel
            {
                IsSuccess = false,
                Message = "Expense created unsuccessfully",

            };
        }
    }
}
