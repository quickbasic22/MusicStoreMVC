using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicStoreMVC.Migrations
{
    public partial class RemovedVirtualFromModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AlbumArtistViewModelAlbumId",
                table: "Genre",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AlbumArtistViewModelAlbumId",
                table: "Artist",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AlbumArtistViewModel",
                columns: table => new
                {
                    AlbumId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AlbumArtUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArtistName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenreName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenreDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumArtistViewModel", x => x.AlbumId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Genre_AlbumArtistViewModelAlbumId",
                table: "Genre",
                column: "AlbumArtistViewModelAlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Artist_AlbumArtistViewModelAlbumId",
                table: "Artist",
                column: "AlbumArtistViewModelAlbumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artist_AlbumArtistViewModel_AlbumArtistViewModelAlbumId",
                table: "Artist",
                column: "AlbumArtistViewModelAlbumId",
                principalTable: "AlbumArtistViewModel",
                principalColumn: "AlbumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genre_AlbumArtistViewModel_AlbumArtistViewModelAlbumId",
                table: "Genre",
                column: "AlbumArtistViewModelAlbumId",
                principalTable: "AlbumArtistViewModel",
                principalColumn: "AlbumId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artist_AlbumArtistViewModel_AlbumArtistViewModelAlbumId",
                table: "Artist");

            migrationBuilder.DropForeignKey(
                name: "FK_Genre_AlbumArtistViewModel_AlbumArtistViewModelAlbumId",
                table: "Genre");

            migrationBuilder.DropTable(
                name: "AlbumArtistViewModel");

            migrationBuilder.DropIndex(
                name: "IX_Genre_AlbumArtistViewModelAlbumId",
                table: "Genre");

            migrationBuilder.DropIndex(
                name: "IX_Artist_AlbumArtistViewModelAlbumId",
                table: "Artist");

            migrationBuilder.DropColumn(
                name: "AlbumArtistViewModelAlbumId",
                table: "Genre");

            migrationBuilder.DropColumn(
                name: "AlbumArtistViewModelAlbumId",
                table: "Artist");
        }
    }
}
