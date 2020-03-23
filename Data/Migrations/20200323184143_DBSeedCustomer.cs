using Microsoft.EntityFrameworkCore.Migrations;

namespace SAGEWebsite.Data.Migrations
{
    public partial class DBSeedCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdenityUserId",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUderId",
                table: "Customers",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "705f354f-e04f-49ec-a3c4-c1585c0825ca", "1eeb1450-01b7-4330-9063-f5d7419aafca", "Customer", "Customer" });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_IdentityUderId",
                table: "Customers",
                column: "IdentityUderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_IdentityUderId",
                table: "Customers",
                column: "IdentityUderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_IdentityUderId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_IdentityUderId",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "705f354f-e04f-49ec-a3c4-c1585c0825ca");

            migrationBuilder.DropColumn(
                name: "IdentityUderId",
                table: "Customers");

            migrationBuilder.AlterColumn<decimal>(
                name: "CreditCardNumber",
                table: "Payments",
                type: "decimal(20,0)",
                nullable: false,
                oldClrType: typeof(decimal))
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "IdenityUserId",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
