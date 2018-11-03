using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowdlendingPOC.Migrations
{
    public partial class updateBid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bids_LoanRequests_LoanRequestsId",
                table: "Bids");

            migrationBuilder.DropIndex(
                name: "IX_Bids_LoanRequestsId",
                table: "Bids");

            migrationBuilder.DropColumn(
                name: "LoanRequestsId",
                table: "Bids");

            migrationBuilder.AddColumn<int>(
                name: "LoanRequestId",
                table: "Bids",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bids_LoanRequestId",
                table: "Bids",
                column: "LoanRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_LoanRequests_LoanRequestId",
                table: "Bids",
                column: "LoanRequestId",
                principalTable: "LoanRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bids_LoanRequests_LoanRequestId",
                table: "Bids");

            migrationBuilder.DropIndex(
                name: "IX_Bids_LoanRequestId",
                table: "Bids");

            migrationBuilder.DropColumn(
                name: "LoanRequestId",
                table: "Bids");

            migrationBuilder.AddColumn<int>(
                name: "LoanRequestsId",
                table: "Bids",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bids_LoanRequestsId",
                table: "Bids",
                column: "LoanRequestsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_LoanRequests_LoanRequestsId",
                table: "Bids",
                column: "LoanRequestsId",
                principalTable: "LoanRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
