namespace Finance101.Models
{
    public class MortgageForm
    {
        // The following properties are used to bind the form data to the model that will be passed to the database

        public int Id { get; set; }
        public decimal OutstandingMortgageBalance { get; set; }
        public decimal RepaymentTerm { get; set; }
        public decimal CurrentInterestRate { get; set; }
        public decimal CurrentMonthlyPayment { get; set; }
    }
}

































