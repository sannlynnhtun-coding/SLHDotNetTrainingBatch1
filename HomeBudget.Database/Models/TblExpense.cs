using System;
using System.Collections.Generic;

namespace HomeBudget.Database.Models;

public partial class TblExpense
{
    public int ExpenseId { get; set; }

    public string Name { get; set; } = null!;

    public int BudgetId { get; set; }

    public decimal Amount { get; set; }

    public DateTime CreatedDate { get; set; }
}
