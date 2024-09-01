using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeSnippetManager.Migrations
{
    /// <inheritdoc />
    public partial class NewTableTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "Snippets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Colour = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Snippets_TagId",
                table: "Snippets",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Snippets_Tags_TagId",
                table: "Snippets",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Snippets_Tags_TagId",
                table: "Snippets");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Snippets_TagId",
                table: "Snippets");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Snippets");
        }
    }
}
