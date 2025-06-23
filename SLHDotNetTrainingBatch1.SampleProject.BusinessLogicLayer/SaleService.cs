using SLHDotNetTrainingBatch1.SampleProject.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLHDotNetTrainingBatch1.SampleProject.BusinessLogicLayer
{
    public class SaleService
    {
        public void Execute()
        {
            AppDbContext db = new AppDbContext();
            db.TblProducts.ToList();
        }
    }
}
