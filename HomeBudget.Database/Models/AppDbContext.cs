using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HomeBudget.Database.Models;

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

            entity.Property(e => e.BudgetName).HasMaxLength(50);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.OriginalAmount).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.UpdatedAmount).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<TblExpense>(entity =>
        {
            entity.HasKey(e => e.ExpenseId);

            entity.ToTable("Tbl_Expense");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
