using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoJira.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class m : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyUserId",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserIdF",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_MyUserId",
                table: "Tasks",
                column: "MyUserId");

          /*  migrationBuilder.AddForeignKey(
                name: "FK_Tasks_NewUsers_MyUserId",
                table: "Tasks",
                column: "MyUserId",
                principalTable: "NewUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);*/
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {/*
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_NewUsers_MyUserId",
                table: "Tasks");*/

            migrationBuilder.DropIndex(
                name: "IX_Tasks_MyUserId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "MyUserId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "UserIdF",
                table: "Tasks");
        }
    }
}
