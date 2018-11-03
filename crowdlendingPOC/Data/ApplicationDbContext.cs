﻿using Microsoft.EntityFrameworkCore;

namespace CrowdlendingPOC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Models.LoanRequest> LoanRequests { get; set; }
        public DbSet<Models.Bid> Bids { get; set; }
    }
}
