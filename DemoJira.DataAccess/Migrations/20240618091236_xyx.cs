using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoJira.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class xyx : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Statuses_CurStatusId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_CurStatusId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "CurStatusId",
                table: "Tasks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurStatusId",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CurStatusId",
                table: "Tasks",
                column: "CurStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Statuses_CurStatusId",
                table: "Tasks",
                column: "CurStatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
