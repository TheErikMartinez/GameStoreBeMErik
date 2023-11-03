using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStoreBeMErik.Migrations
{
    /// <inheritdoc />
    public partial class FixGameUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VideoGameUsers_VideoGames_VideoGameId1",
                table: "VideoGameUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VideoGameUsers",
                table: "VideoGameUsers");

            migrationBuilder.DropIndex(
                name: "IX_VideoGameUsers_VideoGameId1",
                table: "VideoGameUsers");

            migrationBuilder.DropColumn(
                name: "VideoGameId1",
                table: "VideoGameUsers");

            migrationBuilder.AlterColumn<int>(
                name: "VideoGameId",
                table: "VideoGameUsers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VideoGameUsers",
                table: "VideoGameUsers",
                columns: new[] { "UserId", "VideoGameId" });

            migrationBuilder.CreateIndex(
                name: "IX_VideoGameUsers_VideoGameId",
                table: "VideoGameUsers",
                column: "VideoGameId");

            migrationBuilder.AddForeignKey(
                name: "FK_VideoGameUsers_VideoGames_VideoGameId",
                table: "VideoGameUsers",
                column: "VideoGameId",
                principalTable: "VideoGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VideoGameUsers_VideoGames_VideoGameId",
                table: "VideoGameUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VideoGameUsers",
                table: "VideoGameUsers");

            migrationBuilder.DropIndex(
                name: "IX_VideoGameUsers_VideoGameId",
                table: "VideoGameUsers");

            migrationBuilder.AlterColumn<string>(
                name: "VideoGameId",
                table: "VideoGameUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "VideoGameId1",
                table: "VideoGameUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VideoGameUsers",
                table: "VideoGameUsers",
                columns: new[] { "UserId", "VideoGameId1" });

            migrationBuilder.CreateIndex(
                name: "IX_VideoGameUsers_VideoGameId1",
                table: "VideoGameUsers",
                column: "VideoGameId1");

            migrationBuilder.AddForeignKey(
                name: "FK_VideoGameUsers_VideoGames_VideoGameId1",
                table: "VideoGameUsers",
                column: "VideoGameId1",
                principalTable: "VideoGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
