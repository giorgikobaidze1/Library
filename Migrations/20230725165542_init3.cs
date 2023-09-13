using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library1.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_authors_authorPersonallInfos_AuthorPersonalInfoId",
                table: "authors");

            migrationBuilder.DropIndex(
                name: "IX_authors_AuthorPersonalInfoId",
                table: "authors");

            migrationBuilder.DropColumn(
                name: "AuthorPersonalInfoId",
                table: "authors");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "authorPersonallInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_authorPersonallInfos_AuthorId",
                table: "authorPersonallInfos",
                column: "AuthorId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_authorPersonallInfos_authors_AuthorId",
                table: "authorPersonallInfos",
                column: "AuthorId",
                principalTable: "authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_authorPersonallInfos_authors_AuthorId",
                table: "authorPersonallInfos");

            migrationBuilder.DropIndex(
                name: "IX_authorPersonallInfos_AuthorId",
                table: "authorPersonallInfos");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "authorPersonallInfos");

            migrationBuilder.AddColumn<int>(
                name: "AuthorPersonalInfoId",
                table: "authors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_authors_AuthorPersonalInfoId",
                table: "authors",
                column: "AuthorPersonalInfoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_authors_authorPersonallInfos_AuthorPersonalInfoId",
                table: "authors",
                column: "AuthorPersonalInfoId",
                principalTable: "authorPersonallInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
