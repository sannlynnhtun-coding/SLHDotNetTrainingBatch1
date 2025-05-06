using System;
using System.Collections.Generic;

namespace SLHDotNetTrainingBatch1.Database.NorthwindModels;

public partial class OrderSubtotal
{
    public int OrderId { get; set; }

    public decimal? Subtotal { get; set; }
}
