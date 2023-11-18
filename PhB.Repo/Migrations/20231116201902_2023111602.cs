using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhB.Repo.Migrations
{
    /// <inheritdoc />
    public partial class _2023111602 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CenterId",
                table: "PhoneBooks",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "GovernorateId",
                table: "PhoneBooks",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhoneBooks_CenterId",
                table: "PhoneBooks",
                column: "CenterId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneBooks_GovernorateId",
                table: "PhoneBooks",
                column: "GovernorateId");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneBooks_Centers_CenterId",
                table: "PhoneBooks",
                column: "CenterId",
                principalTable: "Centers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneBooks_Governorates_GovernorateId",
                table: "PhoneBooks",
                column: "GovernorateId",
                principalTable: "Governorates",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneBooks_Centers_CenterId",
                table: "PhoneBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneBooks_Governorates_GovernorateId",
                table: "PhoneBooks");

            migrationBuilder.DropIndex(
                name: "IX_PhoneBooks_CenterId",
                table: "PhoneBooks");

            migrationBuilder.DropIndex(
                name: "IX_PhoneBooks_GovernorateId",
                table: "PhoneBooks");

            migrationBuilder.DropColumn(
                name: "CenterId",
                table: "PhoneBooks");

            migrationBuilder.DropColumn(
                name: "GovernorateId",
                table: "PhoneBooks");
        }
    }
}
