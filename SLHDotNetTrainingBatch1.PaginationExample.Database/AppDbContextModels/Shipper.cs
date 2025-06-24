using System;
using System.Collections.Generic;

namespace SLHDotNetTrainingBatch1.PaginationExample.Database.AppDbContextModels;

public partial class Shipper
{
    public int ShipperId { get; set; }

    public string CompanyName { get; set; } = null!;

    public string? Phone { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
