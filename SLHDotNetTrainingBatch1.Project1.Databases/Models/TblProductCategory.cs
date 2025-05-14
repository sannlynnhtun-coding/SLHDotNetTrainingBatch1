using System;
using System.Collections.Generic;

namespace SLHDotNetTrainingBatch1.Project1.Databases.Models;

public partial class TblProductCategory
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;
}
