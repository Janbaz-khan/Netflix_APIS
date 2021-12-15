using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeTag_Assignment.Migrations
{
    public partial class initdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_MovieGenre_GenreId",
                table: "MovieGenre",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieGenre_Genre_GenreId",
                table: "MovieGenre",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenre_Genre_GenreId",
                table: "MovieGenre");

            migrationBuilder.DropIndex(
                name: "IX_MovieGenre_GenreId",
                table: "MovieGenre");
        }
    }
}
