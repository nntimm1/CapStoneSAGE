using Microsoft.EntityFrameworkCore.Migrations;

namespace SAGEWebsite.Data.Migrations
{
    public partial class DisplayUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef11a973-1ac1-427b-8ac4-c2b50587b5de");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f919a806-dec9-4fea-8b75-17ae5d3242c3", "7df96d93-101f-4d0d-8d91-6eabecd7712e", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f919a806-dec9-4fea-8b75-17ae5d3242c3");

            migrationBuilder.AlterColumn<decimal>(
                name: "CreditCardNumber",
                table: "Payments",
                type: "decimal(20,0)",
                nullable: false,
                oldClrType: typeof(decimal))
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ef11a973-1ac1-427b-8ac4-c2b50587b5de", "5baa3a41-0f64-4f26-8284-3c22b696d0f2", "Customer", "CUSTOMER" });
        }
    }
}
