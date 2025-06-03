using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SnakeLadder.Database.Entities;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblLadder> TblLadders { get; set; }

    public virtual DbSet<TblPlayer> TblPlayers { get; set; }

    public virtual DbSet<TblPlayerPosition> TblPlayerPositions { get; set; }

    public virtual DbSet<TblSnake> TblSnakes { get; set; }

  

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblLadder>(entity =>
        {
            entity.HasKey(e => e.LadderId);

            entity.ToTable("Tbl_Ladder");
        });

        modelBuilder.Entity<TblPlayer>(entity =>
        {
            entity.HasKey(e => e.PlayerId);

            entity.ToTable("Tbl_Player");

            entity.Property(e => e.PlayerName).HasMaxLength(50);
        });

        modelBuilder.Entity<TblPlayerPosition>(entity =>
        {
            entity.HasKey(e => e.PlayerPositionId);

            entity.ToTable("Tbl_PlayerPosition");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblSnake>(entity =>
        {
            entity.HasKey(e => e.SnakeId).HasName("PK_Snake");

            entity.ToTable("Tbl_Snake");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
