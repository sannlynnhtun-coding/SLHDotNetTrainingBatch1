using System;
using System.Collections.Generic;

namespace SLHDotNetTrainingBatch1.Project3.Databases.AppDbContextModels;

public partial class TblBlogDetail
{
    public int BlogDetailId { get; set; }

    public int BlogId { get; set; }

    public string BlogContent { get; set; } = null!;
}
