using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoJira.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class cmtnew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_NewUsers_userId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Tasks_TaskId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_TaskId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_userId",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "MyTaskTaskId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_MyTaskTaskId",
                table: "Comments",
                column: "MyTaskTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Tasks_MyTaskTaskId",
                table: "Comments",
                column: "MyTaskTaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Tasks_MyTaskTaskId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_MyTaskTaskId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "MyTaskTaskId",
                table: "Comments");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_TaskId",
                table: "Comments",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_userId",
                table: "Comments",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_NewUsers_userId",
                table: "Comments",
                column: "userId",
                principalTable: "NewUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Tasks_TaskId",
                table: "Comments",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
