using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finance101.Migrations
{
    /// <inheritdoc />
    public partial class CorrectedDailyInterestRate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "DailyInterestRate",
                table: "MortgageForm",
                type: "decimal(16,6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "DailyInterestRate",
                table: "MortgageForm",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16,6)");
        }
    }
}
