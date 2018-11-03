using System;
using System.ComponentModel.DataAnnotations;

namespace CrowdlendingPOC.ViewModels
{

    public class LoanRequestCreationViewModel
    {
        public int LoanRequestId { get; set; }
        [Range(typeof(decimal), "100", "10000")]
        public decimal CurrentInvestorAmount { get; set; }
    }
}
