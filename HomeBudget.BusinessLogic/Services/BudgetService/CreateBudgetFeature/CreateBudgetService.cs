
using HomeBudget.Database.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.BusinessLogic.Services.BudgetService.CreateBudgetFeature
{
    public class CreateBudgetService
    {

        private readonly AppDbContext _context;

        public CreateBudgetService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CreateBudgetResponseModel> CreateBudget(CreateBudgetRequestModel requestModel)
        {

            var _budgetamount = requestModel.Amount;

            var result = await _context.TblBudgets.AddAsync(new TblBudget
            {
                BudgetName = requestModel.Name,
                OriginalAmount = requestModel.Amount,
                UpdatedAmount = 0,
                CreateDate = DateTime.UtcNow
            });

            var saveResult = await _context.SaveChangesAsync();

            if (saveResult > 0)
            {

                return new CreateBudgetResponseModel
                {
                    IsSuccess = true,
                    Message = "Budget created successfully",
                };
            }

            return new CreateBudgetResponseModel
            {
                IsSuccess = false,
                Message = "Budget created unsuccessfully",

            };
        }
    }
}
