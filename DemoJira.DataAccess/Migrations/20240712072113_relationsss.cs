using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoJira.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class relationsss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Relationships_Tasks_MainTaskId",
                table: "Relationships");

            migrationBuilder.DropForeignKey(
                name: "FK_Relationships_Tasks_RelatedTaskId",
                table: "Relationships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Relationships_1",
                table: "Relationships");

            migrationBuilder.RenameTable(
                name: "Relationships",
                newName: "TaskRelationship");

            migrationBuilder.RenameIndex(
                name: "IX_Relationships_RelatedTaskId",
                table: "TaskRelationship",
                newName: "IX_TaskRelationship_RelatedTaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Relationships_MainTaskId",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                newName: "Relationships");

            migrationBuilder.RenameIndex(
                name: "IX_TaskRelationship_RelatedTaskId",
                table: "Relationships",
                newName: "IX_Relationships_RelatedTaskId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskRelationship_MainTaskId",
                table: "Relationships",
                newName: "IX_Relationships_MainTaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Relationships_1",
                table: "Relationships",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Relationships_Tasks_MainTaskId",
                table: "Relationships",
                column: "MainTaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Relationships_Tasks_RelatedTaskId",
                table: "Relationships",
                column: "RelatedTaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
