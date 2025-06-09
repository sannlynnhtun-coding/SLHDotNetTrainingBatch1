using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HomeBudget.Database.Entities;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblBudget> TblBudgets { get; set; }

    public virtual DbSet<TblExpense> TblExpenses { get; set; }

   

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblBudget>(entity =>
        {
            entity.HasKey(e => e.BudgetId);

            entity.ToTable("Tbl_Budget");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.BudgetName).HasMaxLength(200);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblExpense>(entity =>
        {
            entity.HasKey(e => e.ExpenseId);

            entity.ToTable("Tbl_Expense");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ExpenseAmount).HasColumnType("decimal(18, 0)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
