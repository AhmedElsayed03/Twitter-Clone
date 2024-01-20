using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Twitter.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Following : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Follow",
                columns: table => new
                {
                    FollowingID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FollowerID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Follow", x => new { x.FollowerID, x.FollowingID });
                    table.ForeignKey(
                        name: "FK_Follow_User_FollowerID",
                        column: x => x.FollowerID,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Follow_User_FollowingID",
                        column: x => x.FollowingID,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Follow_FollowingID",
                table: "Follow",
                column: "FollowingID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Follow");
        }
    }
}
