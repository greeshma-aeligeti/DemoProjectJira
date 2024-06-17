using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoJira.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class y : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Areas_AreaId",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "CurStatus",
                table: "Tasks",
                newName: "ProjectId");

            migrationBuilder.RenameColumn(
                name: "AreaId",
                table: "Tasks",
                newName: "CurStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_AreaId",
                table: "Tasks",
                newName: "IX_Tasks_CurStatusId");

            migrationBuilder.AddColumn<DateOnly>(
                name: "ExpEndDate",
                table: "Tasks",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "ExpStartDate",
                table: "Tasks",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "desp",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ProjectId",
                table: "Tasks",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Areas_ProjectId",
                table: "Tasks",
                column: "ProjectId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Status_CurStatusId",
                table: "Tasks",
                column: "CurStatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Areas_ProjectId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Status_CurStatusId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_ProjectId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "ExpEndDate",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "ExpStartDate",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "desp",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "Tasks",
                newName: "CurStatus");

            migrationBuilder.RenameColumn(
                name: "CurStatusId",
                table: "Tasks",
                newName: "AreaId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_CurStatusId",
                table: "Tasks",
                newName: "IX_Tasks_AreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Areas_AreaId",
                table: "Tasks",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
