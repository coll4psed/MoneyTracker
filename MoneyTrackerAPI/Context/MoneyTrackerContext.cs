using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MoneyTrackerAPI.Entities;

namespace MoneyTrackerAPI.Context;

public partial class MoneyTrackerContext : DbContext
{
    public MoneyTrackerContext()
    {
    }

    public MoneyTrackerContext(DbContextOptions<MoneyTrackerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CategoryType> CategoryTypes { get; set; }

    public virtual DbSet<Operation> Operations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Database=MoneyTracker;Port=5432;Username=postgres;Password=12345678");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Account_pkey");

            entity.ToTable("Account");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.Name).HasMaxLength(40);
            entity.Property(e => e.Value).HasColumnType("money");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Category_pkey");

            entity.ToTable("Category");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CategoryTypeId).HasColumnName("Category_Type_Id");
            entity.Property(e => e.Name).HasMaxLength(40);

            entity.HasOne(d => d.CategoryType).WithMany(p => p.Categories)
                .HasForeignKey(d => d.CategoryTypeId)
                .HasConstraintName("Category_Category_Type_Id_fkey");
        });

        modelBuilder.Entity<CategoryType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Category_Type_pkey");

            entity.ToTable("Category_Type");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.TypeName)
                .HasMaxLength(50)
                .HasColumnName("Type_Name");
        });

        modelBuilder.Entity<Operation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Operation_pkey");

            entity.ToTable("Operation");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.AccountId).HasColumnName("Account_Id");
            entity.Property(e => e.CategoryId).HasColumnName("Category_Id");
            entity.Property(e => e.Comment).HasMaxLength(250);
            entity.Property(e => e.Value).HasColumnType("money");

            entity.HasOne(d => d.Account).WithMany(p => p.Operations)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("Operation_Account_Id_fkey");

            entity.HasOne(d => d.Category).WithMany(p => p.Operations)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("Operation_Category_Id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
