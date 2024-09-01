using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeSnippetManager.Migrations
{
    /// <inheritdoc />
    public partial class SnippetTagLinkingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "SnippetTag",
                columns: table => new
                {
                    SnippetsId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SnippetTag", x => new { x.SnippetsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_SnippetTag_Snippets_SnippetsId",
                        column: x => x.SnippetsId,
                        principalTable: "Snippets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SnippetTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SnippetTag_TagsId",
                table: "SnippetTag",
                column: "TagsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SnippetTag");

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
    }
}
