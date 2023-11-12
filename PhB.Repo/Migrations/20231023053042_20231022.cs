using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhB.Repo.Migrations
{
    /// <inheritdoc />
    public partial class _20231022 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "PhoneBooks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "PhoneBooks");
        }
    }
}
