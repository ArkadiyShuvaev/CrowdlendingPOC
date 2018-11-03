using System;

namespace CrowdlendingPOC.ViewModels
{

    public class LoanRequestViewModel
    {
        public int Id { get; set; }
        public int CreditSeekerId { get; set; }
        public string CreditSeekerName { get; set; }
        public string Currency { get; set; }
        public int CurrencyId { get; set; }
        public decimal InterestRate { get; set; }
        public decimal AmountRequest { get; set; }
        public DateTime RepaymentStartDate { get; set; }
        public DateTime RepaymentEndDate { get; set; }
        public string Purpose { get; set; }        
    }
}
