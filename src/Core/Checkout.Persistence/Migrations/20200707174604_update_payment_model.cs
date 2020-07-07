using Microsoft.EntityFrameworkCore.Migrations;

namespace Checkout.Persistence.Migrations
{
    public partial class update_payment_model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "Payments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TransactionId",
                table: "Payments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
