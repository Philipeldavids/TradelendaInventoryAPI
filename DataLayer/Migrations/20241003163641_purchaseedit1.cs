using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class purchaseedit1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseReports_Products_ProductId",
                table: "PurchaseReports");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseReports_ProductId",
                table: "PurchaseReports");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "PurchaseReports");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductId",
                table: "PurchaseReports",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReports_ProductId",
                table: "PurchaseReports",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseReports_Products_ProductId",
                table: "PurchaseReports",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
