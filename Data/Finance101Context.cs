using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Finance101.Models;

namespace Finance101.Data
{
    public class Finance101Context : DbContext
    {
        public Finance101Context(DbContextOptions<Finance101Context> options)
            : base(options)
        {
        }

        public DbSet<Finance101.Models.MortgageForm> MortgageForm { get; set; } = default!;

        //determine precision of decimal values for mortgage model that is stored in the database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MortgageForm>().Property(m => m.OutstandingMortgageBalance).HasColumnType("decimal(12,3)");
            modelBuilder.Entity<MortgageForm>().Property(m => m.RepaymentTerm).HasColumnType("decimal(4,2)");
            modelBuilder.Entity<MortgageForm>().Property(m => m.CurrentInterestRate).HasColumnType("decimal(4,2)");
            modelBuilder.Entity<MortgageForm>().Property(m => m.CurrentMonthlyPayment).HasColumnType("decimal(6,2)");
            modelBuilder.Entity<MortgageForm>().Property(m => m.DailyInterestRate).HasColumnType("decimal(16, 6)");
        }
    }
}
