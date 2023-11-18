using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhB.Repo.Migrations
{
    /// <inheritdoc />
    public partial class _2023111702 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneBook_Image_PhoneBooks_PhoneBookId",
                table: "PhoneBook_Image");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhoneBook_Image",
                table: "PhoneBook_Image");

            migrationBuilder.RenameTable(
                name: "PhoneBook_Image",
                newName: "PhoneBook_Images");

            migrationBuilder.RenameIndex(
                name: "IX_PhoneBook_Image_PhoneBookId",
                table: "PhoneBook_Images",
                newName: "IX_PhoneBook_Images_PhoneBookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhoneBook_Images",
                table: "PhoneBook_Images",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneBook_Images_PhoneBooks_PhoneBookId",
                table: "PhoneBook_Images",
                column: "PhoneBookId",
                principalTable: "PhoneBooks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneBook_Images_PhoneBooks_PhoneBookId",
                table: "PhoneBook_Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhoneBook_Images",
                table: "PhoneBook_Images");

            migrationBuilder.RenameTable(
                name: "PhoneBook_Images",
                newName: "PhoneBook_Image");

            migrationBuilder.RenameIndex(
                name: "IX_PhoneBook_Images_PhoneBookId",
                table: "PhoneBook_Image",
                newName: "IX_PhoneBook_Image_PhoneBookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhoneBook_Image",
                table: "PhoneBook_Image",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneBook_Image_PhoneBooks_PhoneBookId",
                table: "PhoneBook_Image",
                column: "PhoneBookId",
                principalTable: "PhoneBooks",
                principalColumn: "Id");
        }
    }
}
