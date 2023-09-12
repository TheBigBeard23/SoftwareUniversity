using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class RenameBoardTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_MyProperty_BoardId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MyProperty",
                table: "MyProperty");

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("c2cdbb29-60fe-443a-be2e-8982b3bf7400"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("cbfd1d63-1225-4a40-919c-9a84cdf669df"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("d7c833c7-fddd-4f9a-a3c0-5454232669b0"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("e824b9ae-c597-475e-ac38-f0c570555229"));

            migrationBuilder.RenameTable(
                name: "MyProperty",
                newName: "Board");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Board",
                table: "Board",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { new Guid("990f52fa-09fe-462d-b0cc-d4f8d4b329fa"), 1, new DateTime(2023, 2, 24, 13, 19, 46, 875, DateTimeKind.Utc).AddTicks(573), "Implement better styling for all public pages", "01e0c6e2-6e72-42dd-9e24-e17d308cf4ed", "Improve CSS styles" },
                    { new Guid("c8167547-03e6-41dc-8656-7884954a0e90"), 3, new DateTime(2022, 9, 12, 13, 19, 46, 875, DateTimeKind.Utc).AddTicks(642), "Implement [Create Task] page for adding tasks", "01e0c6e2-6e72-42dd-9e24-e17d308cf4ed", "Create Tasks" },
                    { new Guid("d3d9fd9a-d664-4862-9ed3-20c490554f87"), 2, new DateTime(2023, 8, 12, 13, 19, 46, 875, DateTimeKind.Utc).AddTicks(623), "Create Desktop client app for the TaskBoard RESTful API", "e6ea5cef-68af-4b86-be06-97802e5c4c44", "Desktop Client App" },
                    { new Guid("ed4bde3b-c087-4461-9dff-70b3425aa92d"), 1, new DateTime(2023, 4, 12, 13, 19, 46, 875, DateTimeKind.Utc).AddTicks(617), "Create Android client app for the TaskBoard RESTful API", "e6ea5cef-68af-4b86-be06-97802e5c4c44", "Android Client App" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Board_BoardId",
                table: "Tasks",
                column: "BoardId",
                principalTable: "Board",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Board_BoardId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Board",
                table: "Board");

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("990f52fa-09fe-462d-b0cc-d4f8d4b329fa"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("c8167547-03e6-41dc-8656-7884954a0e90"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("d3d9fd9a-d664-4862-9ed3-20c490554f87"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("ed4bde3b-c087-4461-9dff-70b3425aa92d"));

            migrationBuilder.RenameTable(
                name: "Board",
                newName: "MyProperty");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyProperty",
                table: "MyProperty",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { new Guid("c2cdbb29-60fe-443a-be2e-8982b3bf7400"), 2, new DateTime(2023, 8, 12, 13, 12, 10, 67, DateTimeKind.Utc).AddTicks(7270), "Create Desktop client app for the TaskBoard RESTful API", "e6ea5cef-68af-4b86-be06-97802e5c4c44", "Desktop Client App" },
                    { new Guid("cbfd1d63-1225-4a40-919c-9a84cdf669df"), 1, new DateTime(2023, 4, 12, 13, 12, 10, 67, DateTimeKind.Utc).AddTicks(7244), "Create Android client app for the TaskBoard RESTful API", "e6ea5cef-68af-4b86-be06-97802e5c4c44", "Android Client App" },
                    { new Guid("d7c833c7-fddd-4f9a-a3c0-5454232669b0"), 1, new DateTime(2023, 2, 24, 13, 12, 10, 67, DateTimeKind.Utc).AddTicks(7177), "Implement better styling for all public pages", "01e0c6e2-6e72-42dd-9e24-e17d308cf4ed", "Improve CSS styles" },
                    { new Guid("e824b9ae-c597-475e-ac38-f0c570555229"), 3, new DateTime(2022, 9, 12, 13, 12, 10, 67, DateTimeKind.Utc).AddTicks(7276), "Implement [Create Task] page for adding tasks", "01e0c6e2-6e72-42dd-9e24-e17d308cf4ed", "Create Tasks" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_MyProperty_BoardId",
                table: "Tasks",
                column: "BoardId",
                principalTable: "MyProperty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
