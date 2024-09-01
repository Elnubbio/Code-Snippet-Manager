using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeSnippetManager.Migrations
{
    /// <inheritdoc />
    public partial class SnippetTagNowEnumerable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Snippets_Tags_TagId",
                table: "Snippets");

            migrationBuilder.DropIndex(
                name: "IX_Snippets_TagId",
                table: "Snippets");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Snippets");

            migrationBuilder.AddColumn<int>(
                name: "SnippetId",
                table: "Tags",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_SnippetId",
                table: "Tags",
                column: "SnippetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Snippets_SnippetId",
                table: "Tags",
                column: "SnippetId",
                principalTable: "Snippets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Snippets_SnippetId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_SnippetId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "SnippetId",
                table: "Tags");

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "Snippets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Snippets_TagId",
                table: "Snippets",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Snippets_Tags_TagId",
                table: "Snippets",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id");
        }
    }
}
