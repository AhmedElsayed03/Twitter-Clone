using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Twitter.DAL.Migrations
{
    /// <inheritdoc />
    public partial class OnlineUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OnlineUser",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConnectionId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineUser", x => new { x.ConnectionId, x.UserId });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OnlineUser");
        }
    }
}
