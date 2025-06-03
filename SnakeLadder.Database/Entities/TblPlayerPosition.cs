using System;
using System.Collections.Generic;

namespace SnakeLadder.Database.Entities;

public partial class TblPlayerPosition
{
    public int PlayerPositionId { get; set; }

    public int PlayerId { get; set; }

    public int CurrentPosition { get; set; }

    public DateTime CreatedDate { get; set; }
}
