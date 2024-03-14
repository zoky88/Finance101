﻿// <auto-generated />
using Finance101.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Finance101.Migrations
{
    [DbContext(typeof(Finance101Context))]
    [Migration("20240212185446_AddedDailyInterestRateToMortgageForm")]
    partial class AddedDailyInterestRateToMortgageForm
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Finance101.Models.MortgageForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("CurrentInterestRate")
                        .HasColumnType("decimal(4,2)");

                    b.Property<decimal>("CurrentMonthlyPayment")
                        .HasColumnType("decimal(6,2)");

                    b.Property<decimal>("DailyInterestRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("OutstandingMortgageBalance")
                        .HasColumnType("decimal(12,3)");

                    b.Property<decimal>("RepaymentTerm")
                        .HasColumnType("decimal(4,2)");

                    b.HasKey("Id");

                    b.ToTable("MortgageForm");
                });
#pragma warning restore 612, 618
        }
    }
}
