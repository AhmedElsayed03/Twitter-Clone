using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Twitter.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Replies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReplyId",
                table: "Image",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Reply",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(280)", maxLength: 280, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PostId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reply", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reply_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reply_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Image_ReplyId",
                table: "Image",
                column: "ReplyId");

            migrationBuilder.CreateIndex(
                name: "IX_Reply_PostId",
                table: "Reply",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Reply_UserId",
                table: "Reply",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Reply_ReplyId",
                table: "Image",
                column: "ReplyId",
                principalTable: "Reply",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Reply_ReplyId",
                table: "Image");

            migrationBuilder.DropTable(
                name: "Reply");

            migrationBuilder.DropIndex(
                name: "IX_Image_ReplyId",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "ReplyId",
                table: "Image");
        }
    }
}
