using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class newaddone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warehouses_Suppliers_ContactPersonSupplierID",
                table: "Warehouses");

            migrationBuilder.RenameColumn(
                name: "ContactPersonSupplierID",
                table: "Warehouses",
                newName: "SupplierID");

            migrationBuilder.RenameIndex(
                name: "IX_Warehouses_ContactPersonSupplierID",
                table: "Warehouses",
                newName: "IX_Warehouses_SupplierID");

            migrationBuilder.AddColumn<string>(
                name: "ContactPerson",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouses_Suppliers_SupplierID",
                table: "Warehouses",
                column: "SupplierID",
                principalTable: "Suppliers",
                principalColumn: "SupplierID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warehouses_Suppliers_SupplierID",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "ContactPerson",
                table: "Suppliers");

            migrationBuilder.RenameColumn(
                name: "SupplierID",
                table: "Warehouses",
                newName: "ContactPersonSupplierID");

            migrationBuilder.RenameIndex(
                name: "IX_Warehouses_SupplierID",
                table: "Warehouses",
                newName: "IX_Warehouses_ContactPersonSupplierID");

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouses_Suppliers_ContactPersonSupplierID",
                table: "Warehouses",
                column: "ContactPersonSupplierID",
                principalTable: "Suppliers",
                principalColumn: "SupplierID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
