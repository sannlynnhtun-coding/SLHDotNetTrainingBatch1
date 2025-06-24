using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SLHDotNetTrainingBatch1.PaginationExample.Database.AppDbContextModels;
using System.Threading.Tasks;

namespace SLHDotNetTrainingBatch1.PaginationExample.MvcApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AppDbContext _db;

        public CustomerController(AppDbContext db)
        {
            _db=db;
        }

        // https://localhost:3000/customer/index?pageNo=1&pageSize=10
        public async Task<IActionResult> Index(int pageNo = 1, int pageSize = 10)
        {
            CustomerListResponseModel model = new CustomerListResponseModel();
            //var lst = await _db.Customers.ToListAsync();

            // 91
            // ko

            // 20 => 2

            var query = _db.Customers.AsQueryable();

            //if (!string.IsNullOrEmpty(name))
            //{
            //    query =query.Where(x => x.ContactName.Contains(name));
            //}

            var rowCount = await query.CountAsync();
            var pageCount = rowCount / pageSize; // 91 / 10 = 9
            if(rowCount % pageSize > 0) // 1
            {
                pageCount++;
            }

            var lst = await query
                .Skip((pageNo - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            model.Data = lst;
            model.PageCount = pageCount;
            model.PageNo = pageNo;
            model.PageSize = pageSize;

            return View(model);
        }
    }

    public class CustomerListResponseModel
    {
        public int PageCount { get; set; } // total page no
        public int PageNo { get; set; } // current page no
        public int PageSize { get; set; } // row count
        public List<Customer> Data { get; set; }
    }
}
