using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeSnippetManager.Migrations
{
    /// <inheritdoc />
    public partial class SnippetTagNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Snippets_Tags_TagId",
                table: "Snippets");

            migrationBuilder.AlterColumn<int>(
                name: "TagId",
                table: "Snippets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Snippets_Tags_TagId",
                table: "Snippets",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Snippets_Tags_TagId",
                table: "Snippets");

            migrationBuilder.AlterColumn<int>(
                name: "TagId",
                table: "Snippets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Snippets_Tags_TagId",
                table: "Snippets",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
