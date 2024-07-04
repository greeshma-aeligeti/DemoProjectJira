using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoJira.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Links : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Relations",
                columns: table => new
                {
                    RelationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskId1 = table.Column<int>(type: "int", nullable: false),
                    Task1TaskId = table.Column<int>(type: "int", nullable: false),
                    TaskId2 = table.Column<int>(type: "int", nullable: false),
                    Task2TaskId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relations", x => x.RelationId);
                    table.ForeignKey(
                        name: "FK_Relations_Tasks_Task1TaskId",
                        column: x => x.Task1TaskId,
                        principalTable: "Tasks",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Relations_Tasks_Task2TaskId",
                        column: x => x.Task2TaskId,
                        principalTable: "Tasks",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Relations_Task1TaskId",
                table: "Relations",
                column: "Task1TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Relations_Task2TaskId",
                table: "Relations",
                column: "Task2TaskId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Relations");
        }
    }
}
