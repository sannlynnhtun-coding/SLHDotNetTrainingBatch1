using System;
using System.Collections.Generic;

namespace HomeBudget.Database.Entities;

public partial class TblExpense
{
    public int ExpenseId { get; set; }

    public int BudgetId { get; set; }

    public decimal ExpenseAmount { get; set; }

    public DateTime CreatedDate { get; set; }
}
