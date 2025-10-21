using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MINICORE.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reglas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinimumAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CommissionPercentage = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reglas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendedores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SellerId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SaleDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ventas_Vendedores_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Vendedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Reglas",
                columns: new[] { "Id", "CommissionPercentage", "MinimumAmount" },
                values: new object[,]
                {
                    { 1, 5m, 0m },
                    { 2, 7.5m, 10000m },
                    { 3, 10m, 50000m },
                    { 4, 12.5m, 100000m }
                });

            migrationBuilder.InsertData(
                table: "Vendedores",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Juan Pérez" },
                    { 2, "María González" },
                    { 3, "Carlos Ramírez" }
                });

            migrationBuilder.InsertData(
                table: "Ventas",
                columns: new[] { "Id", "Amount", "SaleDate", "SellerId" },
                values: new object[,]
                {
                    { 1, 15000m, new DateTime(2025, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 25000m, new DateTime(2025, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, 80000m, new DateTime(2025, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, 45000m, new DateTime(2025, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, 120000m, new DateTime(2025, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_SellerId",
                table: "Ventas",
                column: "SellerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reglas");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Vendedores");
        }
    }
}
