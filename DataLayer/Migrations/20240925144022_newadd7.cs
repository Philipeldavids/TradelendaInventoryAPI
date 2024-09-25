using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class newadd7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Suppliers_SupplierID",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Stores_SupplierID",
                table: "Stores");

            migrationBuilder.AlterColumn<int>(
                name: "SupplierID",
                table: "Stores",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ContactPerson",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactPerson",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Stores");

            migrationBuilder.AlterColumn<string>(
                name: "SupplierID",
                table: "Stores",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}
