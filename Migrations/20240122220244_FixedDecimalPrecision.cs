using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finance101.Migrations
{
    /// <inheritdoc />
    public partial class FixedDecimalPrecision : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MortgageForm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OutstandingMortgageBalance = table.Column<decimal>(type: "decimal(12,3)", nullable: false),
                    RepaymentTerm = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    CurrentInterestRate = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    CurrentMonthlyPayment = table.Column<decimal>(type: "decimal(6,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MortgageForm", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MortgageForm");
        }
    }
}
