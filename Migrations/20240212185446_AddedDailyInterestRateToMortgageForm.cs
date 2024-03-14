using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finance101.Migrations
{
    /// <inheritdoc />
    public partial class AddedDailyInterestRateToMortgageForm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DailyInterestRate",
                table: "MortgageForm",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DailyInterestRate",
                table: "MortgageForm");
        }
    }
}
