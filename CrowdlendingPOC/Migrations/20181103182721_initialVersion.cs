using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowdlendingPOC.Migrations
{
    public partial class initialVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoanRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreditSeekerId = table.Column<int>(nullable: false),
                    InterestRate = table.Column<decimal>(nullable: false),
                    AmountRequest = table.Column<decimal>(nullable: false),
                    RepaymentStartDate = table.Column<DateTime>(nullable: false),
                    RepaymentEndDate = table.Column<DateTime>(nullable: false),
                    ActiveTo = table.Column<DateTime>(nullable: false),
                    IsWithdrawn = table.Column<bool>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: false),
                    Purpose = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bids",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InvestorId = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    LoanRequestsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bids_LoanRequests_LoanRequestsId",
                        column: x => x.LoanRequestsId,
                        principalTable: "LoanRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bids_LoanRequestsId",
                table: "Bids",
                column: "LoanRequestsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bids");

            migrationBuilder.DropTable(
                name: "LoanRequests");
        }
    }
}
