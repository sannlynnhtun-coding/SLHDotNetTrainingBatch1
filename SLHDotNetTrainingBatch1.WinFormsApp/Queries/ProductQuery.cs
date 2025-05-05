using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLHDotNetTrainingBatch1.WinFormsApp.Queries
{
    internal class ProductQuery
    {
        public static string GetAllProducts { get; } = @"select 
ProductId,
ProductCode,
ProductName,
Price,
Quantity,
CreatedDateTime,
U.UserName as CreatedBy from Tbl_Product P 
left join Tbl_User U on P.CreatedBy = U.Id
left join Tbl_ProductCategory PC on PC.Id = P.ProductCategoryId
";
        public static string InsertProduct { get; } = @"INSERT INTO [dbo].[Tbl_Product]
           ([ProductCode]
           ,[ProductName]
           ,[Price]
           ,[Quantity]
           ,[CreatedDateTime]
           ,[CreatedBy])
     VALUES
           (@Code
           ,@Name
           ,@Price
           ,@Quantity
           ,@CreatedDate
           ,@CreatedBy)";
        //public const string GetAllProducts2 = "select * from tbl_product";
    }
}
