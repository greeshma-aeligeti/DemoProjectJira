using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoJira.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Linkssse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Relations_Tasks_Task1TaskId",
                table: "Relations");

            migrationBuilder.DropForeignKey(
                name: "FK_Relations_Tasks_Task2TaskId",
                table: "Relations");

            migrationBuilder.DropIndex(
                name: "IX_Relations_Task1TaskId",
                table: "Relations");

            migrationBuilder.DropIndex(
                name: "IX_Relations_Task2TaskId",
                table: "Relations");

            migrationBuilder.DropColumn(
                name: "Task1TaskId",
                table: "Relations");

            migrationBuilder.DropColumn(
                name: "Task2TaskId",
                table: "Relations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Task1TaskId",
                table: "Relations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Task2TaskId",
                table: "Relations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Relations_Task1TaskId",
                table: "Relations",
                column: "Task1TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Relations_Task2TaskId",
                table: "Relations",
                column: "Task2TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Relations_Tasks_Task1TaskId",
                table: "Relations",
                column: "Task1TaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Relations_Tasks_Task2TaskId",
                table: "Relations",
                column: "Task2TaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
