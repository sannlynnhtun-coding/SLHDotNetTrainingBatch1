using HomeBudget.BusinessLogic.Services.BudgetService.CreateBudgetFeature;
using HomeBudget.BusinessLogic.Services.BudgetService.GetAllBudgetFeature;
using HomeBudget.BusinessLogic.Services.ExpenseService.CreateExpense;
using HomeBudget.BusinessLogic.Services.ExpenseService.GetExpenseNameService;
using HomeBudget.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeBudget.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));

            builder.Services.AddScoped<CreateBudgetService>();

            builder.Services.AddScoped<GetExpenseNameService>();

            builder.Services.AddScoped<CreateExpenseService>();
            builder.Services.AddScoped<GetAllBudgetService>();



            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
