using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SLHDotNetTrainingBatch1.SampleProject.DataAccessLayer.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblBlog> TblBlogs { get; set; }

    public virtual DbSet<TblBlogDetail> TblBlogDetails { get; set; }

    public virtual DbSet<TblBlogHeader> TblBlogHeaders { get; set; }

    public virtual DbSet<TblHomework> TblHomeworks { get; set; }

    public virtual DbSet<TblLogEvent> TblLogEvents { get; set; }

    public virtual DbSet<TblProduct> TblProducts { get; set; }

    public virtual DbSet<TblProductCategory> TblProductCategories { get; set; }

    public virtual DbSet<TblTeam> TblTeams { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=DotNetTrainingBatch1;User Id=sa;Password=sasa@123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblBlog>(entity =>
        {
            entity.HasKey(e => e.BlogId);

            entity.ToTable("Tbl_Blog");

            entity.Property(e => e.BlogAuthor)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BlogContent)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BlogTitle)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblBlogDetail>(entity =>
        {
            entity.HasKey(e => e.BlogDetailId);

            entity.ToTable("Tbl_BlogDetail");

            entity.Property(e => e.BlogContent).HasMaxLength(500);
        });

        modelBuilder.Entity<TblBlogHeader>(entity =>
        {
            entity.HasKey(e => e.BlogId);

            entity.ToTable("Tbl_BlogHeader");

            entity.Property(e => e.BlogTitle).HasMaxLength(50);
        });

        modelBuilder.Entity<TblHomework>(entity =>
        {
            entity.HasKey(e => e.No);

            entity.ToTable("Tbl_Homework");

            entity.Property(e => e.GitHubRepoLink)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.GitHubUserName)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblLogEvent>(entity =>
        {
            entity.ToTable("Tbl_LogEvents");

            entity.Property(e => e.TimeStamp).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblProduct>(entity =>
        {
            entity.HasKey(e => e.ProductId);

            entity.ToTable("Tbl_Product");

            entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDateTime).HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.ProductCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasComputedColumnSql("('P'+right('0000'+CONVERT([varchar](4),[ProductId]),(4)))", false);
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblProductCategory>(entity =>
        {
            entity.ToTable("Tbl_ProductCategory");

            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<TblTeam>(entity =>
        {
            entity.ToTable("Tbl_Team");

            entity.Property(e => e.TeamName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.ToTable("Tbl_User");

            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
