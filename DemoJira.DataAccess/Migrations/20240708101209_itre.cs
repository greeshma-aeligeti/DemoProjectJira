using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoJira.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class itre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_Iterations_ProjId",
                table: "Iterations",
                column: "ProjId");

            migrationBuilder.AddForeignKey(
                name: "FK_Iterations_Areas_ProjId",
                table: "Iterations",
                column: "ProjId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Iterations_Areas_ProjId",
                table: "Iterations");

            migrationBuilder.DropIndex(
                name: "IX_Iterations_ProjId",
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
    }
}
