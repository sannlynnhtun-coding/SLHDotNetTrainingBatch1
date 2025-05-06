using System;
using System.Collections.Generic;

namespace SLHDotNetTrainingBatch1.Database.NorthwindModels;

public partial class CustomerDemographic
{
    public string CustomerTypeId { get; set; } = null!;

    public string? CustomerDesc { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
