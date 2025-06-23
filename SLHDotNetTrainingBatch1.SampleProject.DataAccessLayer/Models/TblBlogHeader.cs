using System;
using System.Collections.Generic;

namespace SLHDotNetTrainingBatch1.SampleProject.DataAccessLayer.Models;

public partial class TblBlogHeader
{
    public int BlogId { get; set; }

    public string BlogTitle { get; set; } = null!;
}
