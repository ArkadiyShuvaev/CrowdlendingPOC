using System;
using System.ComponentModel.DataAnnotations;

namespace CrowdlendingPOC.ViewModels
{

    public class LoanRequestCreationViewModel
    {
        [Range(1, int.MaxValue)]
        public int LoanRequestId { get; set; }
        [Range(typeof(decimal), "100", "10000")]
        public decimal CurrentInvestorProposal { get; set; }
    }
}
