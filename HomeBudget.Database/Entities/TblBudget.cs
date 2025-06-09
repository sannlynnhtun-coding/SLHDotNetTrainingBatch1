using System;
using System.Collections.Generic;

namespace HomeBudget.Database.Entities;

public partial class TblBudget
{
    public int BudgetId { get; set; }

    public string BudgetName { get; set; } = null!;

    public decimal Amount { get; set; }

    public DateTime CreatedDate { get; set; }
}
