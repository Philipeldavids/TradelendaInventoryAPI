using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class newone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SupplierID",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "WarehouseId",
                table: "Stores",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stores_WarehouseId",
                table: "Stores",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Warehouses_WarehouseId",
                table: "Stores",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "WarehouseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Warehouses_WarehouseId",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Stores_WarehouseId",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "Stores");

            migrationBuilder.AlterColumn<int>(
                name: "SupplierID",
                table: "Stores",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
