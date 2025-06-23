using System;
using System.Collections.Generic;

namespace SLHDotNetTrainingBatch1.SampleProject.DataAccessLayer.Models;

public partial class TblTeam
{
    public int Id { get; set; }

    public string TeamName { get; set; } = null!;

    public int TeamValue { get; set; }
}
