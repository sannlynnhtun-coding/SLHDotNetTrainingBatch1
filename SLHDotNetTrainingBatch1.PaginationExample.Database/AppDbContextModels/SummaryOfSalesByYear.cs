using System;
using System.Collections.Generic;

namespace SLHDotNetTrainingBatch1.PaginationExample.Database.AppDbContextModels;

public partial class SummaryOfSalesByYear
{
    public DateTime? ShippedDate { get; set; }

    public int OrderId { get; set; }

    public decimal? Subtotal { get; set; }
}
