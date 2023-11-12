using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhB.Repo.Migrations
{
    /// <inheritdoc />
    public partial class _2023101901 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneBooks_Jobs_JobId1",
                table: "PhoneBooks");

            migrationBuilder.DropIndex(
                name: "IX_PhoneBooks_JobId1",
                table: "PhoneBooks");

            migrationBuilder.DropColumn(
                name: "JobId1",
                table: "PhoneBooks");

            migrationBuilder.AlterColumn<long>(
                name: "JobId",
                table: "PhoneBooks",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhoneBooks_JobId",
                table: "PhoneBooks",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneBooks_Jobs_JobId",
                table: "PhoneBooks",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneBooks_Jobs_JobId",
                table: "PhoneBooks");

            migrationBuilder.DropIndex(
                name: "IX_PhoneBooks_JobId",
                table: "PhoneBooks");

            migrationBuilder.AlterColumn<int>(
                name: "JobId",
                table: "PhoneBooks",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "JobId1",
                table: "PhoneBooks",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_PhoneBooks_JobId1",
                table: "PhoneBooks",
                column: "JobId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneBooks_Jobs_JobId1",
                table: "PhoneBooks",
                column: "JobId1",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
