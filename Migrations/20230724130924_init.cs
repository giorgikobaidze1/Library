using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library1.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "authorPersonallInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authorPersonallInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirsName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorPersonalInfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_authors_authorPersonallInfos_AuthorPersonalInfoId",
                        column: x => x.AuthorPersonalInfoId,
                        principalTable: "authorPersonallInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    authorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_books_authors_authorId",
                        column: x => x.authorId,
                        principalTable: "authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bookGenres",
                columns: table => new
                {
                    bookId = table.Column<int>(type: "int", nullable: false),
                    GreneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookGenres", x => new { x.bookId, x.GreneId });
                    table.ForeignKey(
                        name: "FK_bookGenres_books_bookId",
                        column: x => x.bookId,
                        principalTable: "books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bookGenres_genres_GreneId",
                        column: x => x.GreneId,
                        principalTable: "genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_authors_AuthorPersonalInfoId",
                table: "authors",
                column: "AuthorPersonalInfoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_bookGenres_GreneId",
                table: "bookGenres",
                column: "GreneId");

            migrationBuilder.CreateIndex(
                name: "IX_books_authorId",
                table: "books",
                column: "authorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookGenres");

            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "genres");

            migrationBuilder.DropTable(
                name: "authors");

            migrationBuilder.DropTable(
                name: "authorPersonallInfos");
        }
    }
}
