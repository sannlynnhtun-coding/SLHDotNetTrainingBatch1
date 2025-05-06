// See https://aka.ms/new-console-template for more information
using System.Data;
using Microsoft.Data.SqlClient;
using SLHDotNetTrainingBatch1.ConsoleApp4;
using SLHDotNetTrainingBatch1.Shared;

Console.WriteLine("Hello, World!");

AppDbContext db = new AppDbContext();
//var lst = db.ProductCategories.ToList();

//foreach (var item in lst)
//{
//    Console.WriteLine(item.Name);
//}

//var product = new ProductCategory
//{
//    Code = "P004",
//    Name = "Product Test"
//};

//db.ProductCategories.Add(product);
//int result = db.SaveChanges();

var item = db.ProductCategories.FirstOrDefault(x => x.ProductCategoryId == 3);
if(item is null)
{
    Console.WriteLine("Item not found");
    return;
}

db.ProductCategories.Remove(item);

int result = db.SaveChanges();

var item2 = db.ProductCategories.FirstOrDefault(x => x.ProductCategoryId == 3);

Console.ReadLine();

//AdoDotNetService service = new AdoDotNetService(new SqlConnectionStringBuilder
//{
//    DataSource = ".",
//    InitialCatalog = "DotNetTrainingBatch1",
//    UserID = "sa",
//    Password = "sasa@123",
//    TrustServerCertificate = true
//});
//var lst = service.QueryV2<Product>("select * from Tbl_Product");
//foreach (var item in lst)
//{
//    Console.WriteLine(item.ProductName);
//}

//Console.ReadLine();

//public class Product
//{
//    public int ProductId { get; set; }
//    public string ProductCode { get; set; }
//    public string ProductName { get; set; }
//    public decimal Price { get; set; }
//    public int Quantity { get; set; }
//    public DateTime CreatedDateTime { get; set; }
//}