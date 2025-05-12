using System;

namespace SLHDotNetTrainingBatch1.WebApi.Models
{
    public class ProductModel
    {
        public int? ProductId { get; set; }
        public string? ProductCode { get; set; }
        public string? ProductName { get; set; }
        public int? ProductCategoryId { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
