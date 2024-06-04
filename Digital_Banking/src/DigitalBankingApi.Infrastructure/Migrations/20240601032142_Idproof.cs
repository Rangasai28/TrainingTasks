using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalBankingApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Idproof : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdProof",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdProof",
                table: "Customers");
        }
    }
}
