using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoJira.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class listrel1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Tasks_MyTaskTaskId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_MyTaskTaskId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "MyTaskTaskId",
                table: "Tasks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyTaskTaskId",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_MyTaskTaskId",
                table: "Tasks",
                column: "MyTaskTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Tasks_MyTaskTaskId",
                table: "Tasks",
                column: "MyTaskTaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId");
        }
    }
}
