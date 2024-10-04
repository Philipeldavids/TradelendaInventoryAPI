using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class stocktransfer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefNumber",
                table: "StockTransfers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StockTransferId",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_StockTransferId",
                table: "Products",
                column: "StockTransferId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_StockTransfers_StockTransferId",
                table: "Products",
                column: "StockTransferId",
                principalTable: "StockTransfers",
                principalColumn: "StockTransferId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_StockTransfers_StockTransferId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_StockTransferId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RefNumber",
                table: "StockTransfers");

            migrationBuilder.DropColumn(
                name: "StockTransferId",
                table: "Products");
        }
    }
}
