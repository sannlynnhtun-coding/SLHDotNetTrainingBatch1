using System;
using System.Collections.Generic;

namespace SnakeLadder.Database.Entities;

public partial class TblSnake
{
    public int SnakeId { get; set; }

    public int FromPosition { get; set; }

    public int ToPosition { get; set; }
}
