using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kitchen.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Add_Menu_Relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Menu",
                newName: "Name");

            migrationBuilder.CreateTable(
                name: "MenuSelections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    WeekDay = table.Column<string>(type: "text", nullable: false),
                    MenuId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuSelections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuSelections_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuSelections_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuSelections_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuSelections_CategoryId",
                table: "MenuSelections",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuSelections_MenuId",
                table: "MenuSelections",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuSelections_ProductId",
                table: "MenuSelections",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuSelections");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Menu",
                newName: "Nome");
        }
    }
}
