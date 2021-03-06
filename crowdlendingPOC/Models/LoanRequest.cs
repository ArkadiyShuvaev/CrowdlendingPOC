﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrowdlendingPOC.Models
{
    [Table("LoanRequests")]
    public class LoanRequest
    {
        [Key]
        public int Id { get; set; }
        public int CreditSeekerId { get; set; }
        // TODO define a precision dec(??,??) before go on PROD
        public decimal InterestRate { get; set; }
        // TODO define a precision dec(19,4) 
        public decimal AmountRequest { get; set; }
        public DateTime RepaymentStartDate { get; set; }
        public DateTime RepaymentEndDate { get; set; }
        public DateTime ActiveTo { get; set; }
        public bool IsWithdrawn { get; set; }
        public int CurrencyId { get; set; }

        [StringLength(250)]
        public string Purpose { get; set; }
        public virtual ICollection<Bid> Bids { get; set; }
    }
}
