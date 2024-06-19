using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoJira.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class xy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Descriptions_DescriptionId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_DescriptionId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "DescriptionId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "ProjID",
                table: "Iterations");

            migrationBuilder.AlterColumn<int>(
                name: "desp",
                table: "Tasks",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_desp",
                table: "Tasks",
                column: "desp");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Descriptions_desp",
                table: "Tasks",
                column: "desp",
                principalTable: "Descriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Descriptions_desp",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_desp",
                table: "Tasks");

            migrationBuilder.AlterColumn<string>(
                name: "desp",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DescriptionId",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjID",
                table: "Iterations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_DescriptionId",
                table: "Tasks",
                column: "DescriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Descriptions_DescriptionId",
                table: "Tasks",
                column: "DescriptionId",
                principalTable: "Descriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
