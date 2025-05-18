using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SLHDotNetTrainingBatch1.Project3.Databases.AppDbContextModels;

namespace SLHDotNetTrainingBatch1.Project3.Databases
{
    public static class Startup
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("DbConnnection"));
            });
        }
    }
}
