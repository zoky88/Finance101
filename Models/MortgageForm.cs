using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Finance101.Models
{
    public class MortgageForm
    {
        // The following properties are used to bind the form data to the model that will be passed to the database
        public int Id { get; set; }

        [Required]
        [DisplayName("Remaining Mortgage Balance")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal OutstandingMortgageBalance { get; set; }

        [Required]
        [DisplayName("Repayment Term (Years)")]
        [DataType(DataType.Duration)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        public decimal RepaymentTerm { get; set; }

        [Required]
        [DisplayName("Current Interest Rate")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:0..##}%", ApplyFormatInEditMode = true)]
        public double CurrentInterestRate { get; set; }

        [Required]
        [DisplayName("Current Monthly Payment")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal CurrentMonthlyPayment { get; set; }


        // The following properties are used to display the results of the mortgage calculation
        [DisplayName("Daily Interest Rate Amount")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal DailyInterestRate { get; set; }
    }
}

































