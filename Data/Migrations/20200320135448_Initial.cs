using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SAGEWebsite.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(nullable: true),
                    LocationAddress = table.Column<string>(nullable: true),
                    LocationHours = table.Column<string>(nullable: true),
                    LocationMap = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    EmailOptIn = table.Column<bool>(nullable: false),
                    PaymentId = table.Column<decimal>(nullable: true),
                    SurveyId = table.Column<int>(nullable: true),
                    ShippingAddressId = table.Column<int>(nullable: true),
                    BillingAddressId = table.Column<int>(nullable: true),
                    OrderNumber = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address1 = table.Column<string>(nullable: true),
                    StreetAddress2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    ZipCode = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Addresses_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    CreditCardNumber = table.Column<decimal>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    ExpirationDate = table.Column<string>(nullable: true),
                    CVVSecurityCode = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.CreditCardNumber);
                    table.ForeignKey(
                        name: "FK_Payments_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    SurveyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StyleType = table.Column<string>(nullable: true),
                    HomeType = table.Column<string>(nullable: true),
                    LifeType = table.Column<string>(nullable: true),
                    CustomerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.SurveyId);
                    table.ForeignKey(
                        name: "FK_Surveys_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderNumber = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    ShippingAddressId = table.Column<int>(nullable: false),
                    ShippingOption = table.Column<string>(nullable: true),
                    ItemId = table.Column<int>(nullable: true),
                    CustomerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderNumber);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(nullable: true),
                    UnitPrice = table.Column<double>(nullable: false),
                    StyleType = table.Column<string>(nullable: true),
                    HomeType = table.Column<string>(nullable: true),
                    LifeType = table.Column<string>(nullable: true),
                    ProductType = table.Column<string>(nullable: true),
                    AutoReorder = table.Column<bool>(nullable: false),
                    OrderNumber = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Items_Orders_OrderNumber",
                        column: x => x.OrderNumber,
                        principalTable: "Orders",
                        principalColumn: "OrderNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CustomerId",
                table: "Addresses",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_BillingAddressId",
                table: "Customers",
                column: "BillingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_OrderNumber",
                table: "Customers",
                column: "OrderNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PaymentId",
                table: "Customers",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ShippingAddressId",
                table: "Customers",
                column: "ShippingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_SurveyId",
                table: "Customers",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_OrderNumber",
                table: "Items",
                column: "OrderNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ItemId",
                table: "Orders",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CustomerId",
                table: "Payments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_CustomerId",
                table: "Surveys",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Addresses_BillingAddressId",
                table: "Customers",
                column: "BillingAddressId",
                principalTable: "Addresses",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Addresses_ShippingAddressId",
                table: "Customers",
                column: "ShippingAddressId",
                principalTable: "Addresses",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Orders_OrderNumber",
                table: "Customers",
                column: "OrderNumber",
                principalTable: "Orders",
                principalColumn: "OrderNumber",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Payments_PaymentId",
                table: "Customers",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "CreditCardNumber",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Surveys_SurveyId",
                table: "Customers",
                column: "SurveyId",
                principalTable: "Surveys",
                principalColumn: "SurveyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Items_ItemId",
                table: "Orders",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Customers_CustomerId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Customers_CustomerId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_Customers_CustomerId",
                table: "Surveys");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Orders_OrderNumber",
                table: "Items");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Surveys");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
