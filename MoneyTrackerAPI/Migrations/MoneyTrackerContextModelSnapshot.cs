﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoneyTrackerAPI.Contexts;

#nullable disable

namespace MoneyTrackerAPI.Migrations
{
    [DbContext(typeof(MoneyTrackerContext))]
    partial class MoneyTrackerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MoneyTrackerAPI.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("MoneyTrackerAPI.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("MoneyTrackerAPI.Models.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("ExpenseCategoryId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("ExpenseDate")
                        .HasColumnType("date");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("ExpenseCategoryId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("MoneyTrackerAPI.Models.ExpenseCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("ExpenseCategories");
                });

            modelBuilder.Entity("MoneyTrackerAPI.Models.Income", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("IncomeCategoryId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("IncomeDate")
                        .HasColumnType("date");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("IncomeCategoryId");

                    b.ToTable("Incomes");
                });

            modelBuilder.Entity("MoneyTrackerAPI.Models.IncomeCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("IncomeCategories");
                });

            modelBuilder.Entity("MoneyTrackerAPI.Models.Expense", b =>
                {
                    b.HasOne("MoneyTrackerAPI.Models.Account", "Account")
                        .WithMany("Expenses")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoneyTrackerAPI.Models.ExpenseCategory", "ExpenseCategory")
                        .WithMany("Expenses")
                        .HasForeignKey("ExpenseCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("ExpenseCategory");
                });

            modelBuilder.Entity("MoneyTrackerAPI.Models.ExpenseCategory", b =>
                {
                    b.HasOne("MoneyTrackerAPI.Models.Category", "Category")
                        .WithMany("ExpensesCategory")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("MoneyTrackerAPI.Models.Income", b =>
                {
                    b.HasOne("MoneyTrackerAPI.Models.Account", "Account")
                        .WithMany("Incomes")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoneyTrackerAPI.Models.IncomeCategory", "IncomeCategory")
                        .WithMany("Incomes")
                        .HasForeignKey("IncomeCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("IncomeCategory");
                });

            modelBuilder.Entity("MoneyTrackerAPI.Models.IncomeCategory", b =>
                {
                    b.HasOne("MoneyTrackerAPI.Models.Category", "Category")
                        .WithMany("IncomesCategory")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("MoneyTrackerAPI.Models.Account", b =>
                {
                    b.Navigation("Expenses");

                    b.Navigation("Incomes");
                });

            modelBuilder.Entity("MoneyTrackerAPI.Models.Category", b =>
                {
                    b.Navigation("ExpensesCategory");

                    b.Navigation("IncomesCategory");
                });

            modelBuilder.Entity("MoneyTrackerAPI.Models.ExpenseCategory", b =>
                {
                    b.Navigation("Expenses");
                });

            modelBuilder.Entity("MoneyTrackerAPI.Models.IncomeCategory", b =>
                {
                    b.Navigation("Incomes");
                });
#pragma warning restore 612, 618
        }
    }
}
