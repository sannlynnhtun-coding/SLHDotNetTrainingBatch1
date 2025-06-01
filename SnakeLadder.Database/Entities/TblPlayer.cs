using System;
using System.Collections.Generic;

namespace SnakeLadder.Database.Entities;

public partial class TblPlayer
{
    public int PlayerId { get; set; }

    public string? PlayerName { get; set; }
}
