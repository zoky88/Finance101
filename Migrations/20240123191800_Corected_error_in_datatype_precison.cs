using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finance101.Migrations
{
    /// <inheritdoc />
    public partial class Corected_error_in_datatype_precison : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "RepaymentTerm",
                table: "MortgageForm",
                type: "decimal(4,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "RepaymentTerm",
                table: "MortgageForm",
                type: "decimal(3,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(4,2)");
        }
    }
}
