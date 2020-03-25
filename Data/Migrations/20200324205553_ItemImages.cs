using Microsoft.EntityFrameworkCore.Migrations;

namespace SAGEWebsite.Data.Migrations
{
    public partial class ItemImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "ItemImage",
                table: "Items",
                nullable: true);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
