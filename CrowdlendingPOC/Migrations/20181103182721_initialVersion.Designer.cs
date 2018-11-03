﻿// <auto-generated />
using System;
using CrowdlendingPOC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CrowdlendingPOC.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20181103182721_initialVersion")]
    partial class initialVersion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CrowdlendingPOC.Models.Bid", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<int>("InvestorId");

                    b.Property<int?>("LoanRequestsId");

                    b.HasKey("Id");

                    b.HasIndex("LoanRequestsId");

                    b.ToTable("Bids");
                });

            modelBuilder.Entity("CrowdlendingPOC.Models.LoanRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ActiveTo");

                    b.Property<decimal>("AmountRequest");

                    b.Property<int>("CreditSeekerId");

                    b.Property<int>("CurrencyId");

                    b.Property<decimal>("InterestRate");

                    b.Property<bool>("IsWithdrawn");

                    b.Property<string>("Purpose")
                        .HasMaxLength(250);

                    b.Property<DateTime>("RepaymentEndDate");

                    b.Property<DateTime>("RepaymentStartDate");

                    b.HasKey("Id");

                    b.ToTable("LoanRequests");
                });

            modelBuilder.Entity("CrowdlendingPOC.Models.Bid", b =>
                {
                    b.HasOne("CrowdlendingPOC.Models.LoanRequest", "LoanRequests")
                        .WithMany("Bids")
                        .HasForeignKey("LoanRequestsId");
                });
#pragma warning restore 612, 618
        }
    }
}