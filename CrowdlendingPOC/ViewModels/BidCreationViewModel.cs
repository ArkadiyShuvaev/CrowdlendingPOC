using System;
using System.ComponentModel.DataAnnotations;

namespace CrowdlendingPOC.ViewModels
{
    public class BidCreationViewModel
    {
        [Range(1, int.MaxValue)]
        public int LoanRequestId { get; set; }
        [Range(typeof(decimal), "100", "10000")]
        public decimal InvestorBidValue { get; set; }
    }
}
