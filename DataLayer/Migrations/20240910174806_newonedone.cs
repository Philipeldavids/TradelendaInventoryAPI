using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class newonedone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PurchaseId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PurchaseReturns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReferenceNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Paid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Due = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Shipping = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseReturns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseReturns_Suppliers_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierID");
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    PurchaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Paid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Due = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Shipping = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.PurchaseId);
                    table.ForeignKey(
                        name: "FK_Purchases_Suppliers_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierID");
                });

            migrationBuilder.CreateTable(
                name: "StockAdjustments",
                columns: table => new
                {
                    StockAdjustmentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StockId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantityAdjusted = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdjustmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdjustedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockAdjustments", x => x.StockAdjustmentId);
                });

            migrationBuilder.CreateTable(
                name: "StockTransfers",
                columns: table => new
                {
                    StockTransferId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    QuantityTransferred = table.Column<int>(type: "int", nullable: false),
                    TransferDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FromWarehouseWarehouseId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ToWarehouseWarehouseId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockTransfers", x => x.StockTransferId);
                    table.ForeignKey(
                        name: "FK_StockTransfers_Warehouses_FromWarehouseWarehouseId",
                        column: x => x.FromWarehouseWarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseId");
                    table.ForeignKey(
                        name: "FK_StockTransfers_Warehouses_ToWarehouseWarehouseId",
                        column: x => x.ToWarehouseWarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_PurchaseId",
                table: "Products",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturns_SupplierID",
                table: "PurchaseReturns",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_SupplierID",
                table: "Purchases",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_StockTransfers_FromWarehouseWarehouseId",
                table: "StockTransfers",
                column: "FromWarehouseWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_StockTransfers_ToWarehouseWarehouseId",
                table: "StockTransfers",
                column: "ToWarehouseWarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Purchases_PurchaseId",
                table: "Products",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "PurchaseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Purchases_PurchaseId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "PurchaseReturns");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "StockAdjustments");

            migrationBuilder.DropTable(
                name: "StockTransfers");

            migrationBuilder.DropIndex(
                name: "IX_Products_PurchaseId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PurchaseId",
                table: "Products");
        }
    }
}
