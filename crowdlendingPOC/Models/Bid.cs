using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrowdlendingPOC.Models
{
    [Table("Bids")]
    public class Bid
    {
        [Key]
        public int Id { get; set; }
        public int InvestorId { get; set; }
        //TODO define precision dec(19,4)
        public decimal Amount { get; set; }
        public int LoanRequestId { get; set; }
        public virtual LoanRequest LoanRequest { get; set; }
    }
}