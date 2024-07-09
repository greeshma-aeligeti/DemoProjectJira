using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoJira.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class itr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Iterations_Areas_ProjectEntityId",
                table: "Iterations");

            migrationBuilder.DropIndex(
                name: "IX_Iterations_ProjectEntityId",
                table: "Iterations");

            migrationBuilder.DropColumn(
                name: "ProjectEntityId",
                table: "Iterations");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Iterations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Iterations_ProjectId",
                table: "Iterations",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Iterations_Areas_ProjectId",
                table: "Iterations",
                column: "ProjectId",
                principalTable: "Areas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Iterations_Areas_ProjectId",
                table: "Iterations");

            migrationBuilder.DropIndex(
                name: "IX_Iterations_ProjectId",
                table: "Iterations");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Iterations");

            migrationBuilder.AddColumn<int>(
                name: "ProjectEntityId",
                table: "Iterations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Iterations_ProjectEntityId",
                table: "Iterations",
                column: "ProjectEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Iterations_Areas_ProjectEntityId",
                table: "Iterations",
                column: "ProjectEntityId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
