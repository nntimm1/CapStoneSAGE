using Microsoft.EntityFrameworkCore.Migrations;

namespace SAGEWebsite.Data.Migrations
{
    public partial class DirectionsForLocation1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LocationDirections",
                table: "Locations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
