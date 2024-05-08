using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kitchen.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Add_Relation_measurement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Grammager",
                table: "IngredientOnProducts",
                newName: "Grammage");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_MeasurementId",
                table: "Ingredient",
                column: "MeasurementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_Measurement_MeasurementId",
                table: "Ingredient",
                column: "MeasurementId",
                principalTable: "Measurement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_Measurement_MeasurementId",
                table: "Ingredient");

            migrationBuilder.DropIndex(
                name: "IX_Ingredient_MeasurementId",
                table: "Ingredient");

            migrationBuilder.RenameColumn(
                name: "Grammage",
                table: "IngredientOnProducts",
                newName: "Grammager");
        }
    }
}
