using Finance101.Data;
using Finance101.Models;
using Finance101.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Finance101.Tests
{
    [TestFixture]
    public class CalculateDailyInterestRateServiceTests
    {
        [Test]
        public void CalculateDailyInterestRate_ReturnsCorrectValue()
        {
            //Arrange
            decimal currentInterestRate = 4.24m;
            int daysInYear = 365;

            DailyInterestRateService dailyInterestRateService = new();

            //Act
            Task<decimal> dailyInterestRate = dailyInterestRateService.CalculateDailyInterestRate();

            //Assert
            Assert.That(dailyInterestRate, Is.EqualTo(currentInterestRate / daysInYear));

        }
    }

}


namespace Finance101.Services
{
    public class DailyInterestRateService
    {

        private readonly Finance101Context _context;

        public DailyInterestRateService()
        {
        }

        public DailyInterestRateService(Finance101Context context)
        {
            _context = context;
        }

        public async Task<decimal> CalculateDailyInterestRate()
        {
            int daysInYear = 365;
            decimal dailyInterestRate;
            //retrieve current interest rate from the database
            var mortgageForm = await _context.MortgageForm.FirstOrDefaultAsync();
            if (mortgageForm == null)
            {
                throw new Exception("No mortgage form data found in the database");
            }
            else
            {
                dailyInterestRate = (decimal)mortgageForm.CurrentInterestRate * mortgageForm.OutstandingMortgageBalance / (100 * daysInYear);
            }

            return dailyInterestRate;
        }
    }
}
