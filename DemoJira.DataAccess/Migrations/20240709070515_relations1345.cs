using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoJira.DataAccess.Migrations
{
    public partial class relations1345 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Step 1: Drop foreign keys
            migrationBuilder.DropForeignKey(
                name: "FK_Relationships_Tasks_ChildTaskId",
                table: "Relationships");

            migrationBuilder.DropForeignKey(
                name: "FK_Relationships_Tasks_ParentTaskId",
                table: "Relationships");

            // Step 2: Rename columns
            migrationBuilder.RenameColumn(
                name: "ParentTaskId",
                table: "Relationships",
                newName: "MainTaskId");

            migrationBuilder.RenameColumn(
                name: "ChildTaskId",
                table: "Relationships",
                newName: "RelatedTaskId");

            // Step 3: Rename indexes
            migrationBuilder.RenameIndex(
                name: "IX_Relationships_ParentTaskId",
                table: "Relationships",
                newName: "IX_Relationships_MainTaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Relationships_ChildTaskId",
                table: "Relationships",
                newName: "IX_Relationships_RelatedTaskId");

            // Step 4: Add foreign keys back with updated column names
            migrationBuilder.AddForeignKey(
                name: "FK_Relationships_Tasks_MainTaskId",
                table: "Relationships",
                column: "MainTaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Relationships_Tasks_RelatedTaskId",
                table: "Relationships",
                column: "RelatedTaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Step 1: Drop foreign keys
            migrationBuilder.DropForeignKey(
                name: "FK_Relationships_Tasks_MainTaskId",
                table: "Relationships");

            migrationBuilder.DropForeignKey(
                name: "FK_Relationships_Tasks_RelatedTaskId",
                table: "Relationships");

            // Step 2: Rename columns back to original names
            migrationBuilder.RenameColumn(
                name: "MainTaskId",
                table: "Relationships",
                newName: "ParentTaskId");

            migrationBuilder.RenameColumn(
                name: "RelatedTaskId",
                table: "Relationships",
                newName: "ChildTaskId");

            // Step 3: Rename indexes back to original names
            migrationBuilder.RenameIndex(
                name: "IX_Relationships_MainTaskId",
                table: "Relationships",
                newName: "IX_Relationships_ParentTaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Relationships_RelatedTaskId",
                table: "Relationships",
                newName: "IX_Relationships_ChildTaskId");

            // Step 4: Add foreign keys back with original column names
            migrationBuilder.AddForeignKey(
                name: "FK_Relationships_Tasks_ChildTaskId",
                table: "Relationships",
                column: "ChildTaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Relationships_Tasks_ParentTaskId",
                table: "Relationships",
                column: "ParentTaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
