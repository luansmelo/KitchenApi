using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kitchen.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Add_Product_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_Measurement_MeasurementId1",
                table: "Ingredient");

            migrationBuilder.DropTable(
                name: "GroupsOnInputs");

            migrationBuilder.DropIndex(
                name: "IX_Ingredient_MeasurementId1",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "GroupIds",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "MeasurementId1",
                table: "Ingredient");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Measurement",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "MeasurementId",
                table: "Ingredient",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "GroupsOnIngredient",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IngredientId = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupsOnIngredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupsOnIngredient_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupsOnIngredient_Ingredient_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Accession = table.Column<int>(type: "integer", nullable: false),
                    Resource = table.Column<string>(type: "text", nullable: false),
                    PreparationTime = table.Column<string>(type: "text", nullable: false),
                    Photo_url = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IngredientOnProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IngredientId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Measurement = table.Column<string>(type: "text", nullable: false),
                    Grammager = table.Column<decimal>(type: "numeric", nullable: false)
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
                name: "IX_GroupsOnIngredient_GroupId",
                table: "GroupsOnIngredient",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupsOnIngredient_IngredientId",
                table: "GroupsOnIngredient",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientOnProducts_IngredientId",
                table: "IngredientOnProducts",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientOnProducts_ProductId",
                table: "IngredientOnProducts",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupsOnIngredient");

            migrationBuilder.DropTable(
                name: "IngredientOnProducts");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Measurement",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MeasurementId",
                table: "Ingredient",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<List<string>>(
                name: "GroupIds",
                table: "Ingredient",
                type: "text[]",
                nullable: false);

            migrationBuilder.AddColumn<Guid>(
                name: "MeasurementId1",
                table: "Ingredient",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "GroupsOnInputs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupId1 = table.Column<Guid>(type: "uuid", nullable: false),
                    IngredientId1 = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupId = table.Column<string>(type: "text", nullable: false),
                    IngredientId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupsOnInputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupsOnInputs_Group_GroupId1",
                        column: x => x.GroupId1,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupsOnInputs_Ingredient_IngredientId1",
                        column: x => x.IngredientId1,
                        principalTable: "Ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_MeasurementId1",
                table: "Ingredient",
                column: "MeasurementId1");

            migrationBuilder.CreateIndex(
                name: "IX_GroupsOnInputs_GroupId1",
                table: "GroupsOnInputs",
                column: "GroupId1");

            migrationBuilder.CreateIndex(
                name: "IX_GroupsOnInputs_IngredientId1",
                table: "GroupsOnInputs",
                column: "IngredientId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_Measurement_MeasurementId1",
                table: "Ingredient",
                column: "MeasurementId1",
                principalTable: "Measurement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
