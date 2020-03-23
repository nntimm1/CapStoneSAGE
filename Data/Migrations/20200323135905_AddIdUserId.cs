using Microsoft.EntityFrameworkCore.Migrations;

namespace SAGEWebsite.Data.Migrations
{
    public partial class AddIdUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AddColumn<string>(
                name: "IdenityUserId",
                table: "Customers",
                nullable: true);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropColumn(
                name: "IdenityUserId",
                table: "Customers");

            migrationBuilder.AlterColumn<decimal>(
                name: "CreditCardNumber",
                table: "Payments",
                type: "decimal(20,0)",
                nullable: false,
                oldClrType: typeof(decimal))
                .Annotation("SqlServer:Identity", "1, 1");
        }
    }
}
