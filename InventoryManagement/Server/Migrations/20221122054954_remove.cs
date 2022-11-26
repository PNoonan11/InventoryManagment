using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagement.Server.Migrations
{
    public partial class remove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SaleEntityId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_SaleEntityId",
                table: "Customers",
                column: "SaleEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Sales_SaleEntityId",
                table: "Customers",
                column: "SaleEntityId",
                principalTable: "Sales",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Sales_SaleEntityId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_SaleEntityId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "SaleEntityId",
                table: "Customers");
        }
    }
}
