using System;
using System.Collections.Generic;

namespace SLHDotNetTrainingBatch1.SampleProject.DataAccessLayer.Models;

public partial class TblProduct
{
    public int ProductId { get; set; }

    public string? ProductCode { get; set; }

    public string ProductName { get; set; } = null!;

    public int? ProductCategoryId { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public DateTime CreatedDateTime { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? ModifiedDateTime { get; set; }

    public int? ModifiedBy { get; set; }
}
