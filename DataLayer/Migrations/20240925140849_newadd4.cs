using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class newadd4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Stores");

            migrationBuilder.AddColumn<string>(
                name: "SupplierID",
                table: "Stores",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_SupplierID",
                table: "Stores",
                column: "SupplierID");

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Suppliers_SupplierID",
                table: "Stores",
                column: "SupplierID",
                principalTable: "Suppliers",
                principalColumn: "SupplierID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Suppliers_SupplierID",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Stores_SupplierID",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "SupplierID",
                table: "Stores");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
