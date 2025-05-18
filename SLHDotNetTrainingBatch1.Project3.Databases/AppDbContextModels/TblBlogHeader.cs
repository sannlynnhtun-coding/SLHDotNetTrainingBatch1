using System;
using System.Collections.Generic;

namespace SLHDotNetTrainingBatch1.Project3.Databases.AppDbContextModels;

public partial class TblBlogHeader
{
    public int BlogId { get; set; }

    public string BlogTitle { get; set; } = null!;
}
