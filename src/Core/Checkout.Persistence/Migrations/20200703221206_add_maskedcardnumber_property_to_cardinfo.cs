using Microsoft.EntityFrameworkCore.Migrations;

namespace Checkout.Persistence.Migrations
{
    public partial class add_maskedcardnumber_property_to_cardinfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CardInformation_MaskedCardNumber",
                table: "Payments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardInformation_MaskedCardNumber",
                table: "Payments");
        }
    }
}
