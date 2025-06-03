using System;
using System.Collections.Generic;

namespace SnakeLadder.Database.Entities;

public partial class TblLadder
{
    public int LadderId { get; set; }

    public int FromPosition { get; set; }

    public int ToPosition { get; set; }
}
