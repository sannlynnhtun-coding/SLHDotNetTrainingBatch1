// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using SLHDotNetTrainingBatch1.Database.Models;
using SLHDotNetTrainingBatch1.Database.NorthwindModels;

Console.WriteLine("Hello, World!");

//AppDbContext db = new AppDbContext();
//db.TblProductCategories.Add(new TblProductCategory
//{
//    Code = "P001",
//    Name = "Product 1"
//});

//db.SaveChanges();

//db.TblProductCategories.FirstOrDefault(x => x.Id == 1);


NorthwindAppDbContext db2 = new NorthwindAppDbContext();
var lst = db2.Categories.Include(x => x.Products).ToList();

Console.ReadLine();
