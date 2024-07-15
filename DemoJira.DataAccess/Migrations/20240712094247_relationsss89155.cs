using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoJira.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class relationsss89155 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskRelationship_Tasks_MainTaskId",
                table: "TaskRelationship");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskRelationship_Tasks_RelatedTaskId",
                table: "TaskRelationship");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskRelationship",
                table: "TaskRelationship");

            migrationBuilder.RenameTable(
                name: "TaskRelationship",
                newName: "Relations");

            migrationBuilder.RenameIndex(
                name: "IX_TaskRelationship_RelatedTaskId",
                table: "Relations",
                newName: "IX_Relations_RelatedTaskId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskRelationship_MainTaskId",
                table: "Relations",
                newName: "IX_Relations_MainTaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Relations",
                table: "Relations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Relations_Tasks_MainTaskId",
                table: "Relations",
                column: "MainTaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Relations_Tasks_RelatedTaskId",
                table: "Relations",
                column: "RelatedTaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Relations_Tasks_MainTaskId",
                table: "Relations");

            migrationBuilder.DropForeignKey(
                name: "FK_Relations_Tasks_RelatedTaskId",
                table: "Relations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Relations",
                table: "Relations");

            migrationBuilder.RenameTable(
                name: "Relations",
                newName: "TaskRelationship");

            migrationBuilder.RenameIndex(
                name: "IX_Relations_RelatedTaskId",
                table: "TaskRelationship",
                newName: "IX_TaskRelationship_RelatedTaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Relations_MainTaskId",
                table: "TaskRelationship",
                newName: "IX_TaskRelationship_MainTaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskRelationship",
                table: "TaskRelationship",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskRelationship_Tasks_MainTaskId",
                table: "TaskRelationship",
                column: "MainTaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskRelationship_Tasks_RelatedTaskId",
                table: "TaskRelationship",
                column: "RelatedTaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
