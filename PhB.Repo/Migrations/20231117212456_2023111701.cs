using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhB.Repo.Migrations
{
    /// <inheritdoc />
    public partial class _2023111701 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "PhoneBooks");

            migrationBuilder.CreateTable(
                name: "PhoneBook_Image",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneBookId = table.Column<long>(type: "bigint", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneBook_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneBook_Image_PhoneBooks_PhoneBookId",
                        column: x => x.PhoneBookId,
                        principalTable: "PhoneBooks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhoneBook_Image_PhoneBookId",
                table: "PhoneBook_Image",
                column: "PhoneBookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhoneBook_Image");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "PhoneBooks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
