using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStoreBeMErik.Migrations
{
    /// <inheritdoc />
    public partial class GameStoreVideoGameUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VideoGameUsers",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    VideoGameId1 = table.Column<int>(type: "int", nullable: false),
                    VideoGameId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoGameUsers", x => new { x.UserId, x.VideoGameId1 });
                    table.ForeignKey(
                        name: "FK_VideoGameUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoGameUsers_VideoGames_VideoGameId1",
                        column: x => x.VideoGameId1,
                        principalTable: "VideoGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VideoGameUsers_VideoGameId1",
                table: "VideoGameUsers",
                column: "VideoGameId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VideoGameUsers");
        }
    }
}
