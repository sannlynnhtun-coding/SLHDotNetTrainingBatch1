using System;
using System.Collections.Generic;

namespace HomeBudget.Database.Models;

public partial class TblBudget
{
    public int BudgetId { get; set; }

    public string BudgetName { get; set; } = null!;

    public decimal OriginalAmount { get; set; }

    public decimal UpdatedAmount { get; set; }

    public DateTime CreateDate { get; set; }
}
