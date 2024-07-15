using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoJira.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class reporterid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "NewUsers",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "NewUsers",
                newName: "UserId");

            migrationBuilder.AddColumn<int>(
                name: "ReporterId",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ReporterId",
                table: "Tasks",
                column: "ReporterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_NewUsers_ReporterId",
                table: "Tasks",
                column: "ReporterId",
                principalTable: "NewUsers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_NewUsers_ReporterId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_ReporterId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "ReporterId",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "NewUsers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "NewUsers",
                newName: "Id");
        }
    }
}
