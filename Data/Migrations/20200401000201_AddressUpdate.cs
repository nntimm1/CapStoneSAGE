using Microsoft.EntityFrameworkCore.Migrations;

namespace SAGEWebsite.Data.Migrations
{
    public partial class AddressUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Locations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Locations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Locations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Zip",
                table: "Locations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "City",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Zip",
                table: "Locations");
        }
    }
}
