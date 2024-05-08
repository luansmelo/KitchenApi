using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kitchen.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Change_Table_Name : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientOnProducts");

            migrationBuilder.CreateTable(
                name: "IngredientsOnProduct",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IngredientId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Measurement = table.Column<string>(type: "text", nullable: false),
                    Grammage = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientsOnProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngredientsOnProduct_Ingredient_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientsOnProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientsOnProduct_IngredientId",
                table: "IngredientsOnProduct",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientsOnProduct_ProductId",
                table: "IngredientsOnProduct",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientsOnProduct");

            migrationBuilder.CreateTable(
                name: "IngredientOnProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IngredientId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Grammage = table.Column<decimal>(type: "numeric", nullable: false),
                    Measurement = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientOnProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngredientOnProducts_Ingredient_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientOnProducts_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientOnProducts_IngredientId",
                table: "IngredientOnProducts",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientOnProducts_ProductId",
                table: "IngredientOnProducts",
                column: "ProductId");
        }
    }
}
