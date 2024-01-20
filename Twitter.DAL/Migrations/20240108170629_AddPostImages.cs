using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Twitter.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddPostImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    ImgName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.ImgName);
                    table.ForeignKey(
                        name: "FK_Image_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Image_PostId",
                table: "Image",
                column: "PostId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Image");
        }
    }
}
