namespace Finance101.Interfaces
{
    public interface IDailyInterestRate
    {
        public decimal CalculateDailyInterestRate(decimal currentInterestRate, int daysInYear);
    }
}