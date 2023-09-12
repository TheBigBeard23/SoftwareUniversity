using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class AddTaskAndBoardAndSeedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MyProperty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyProperty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BoardId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_MyProperty_BoardId",
                        column: x => x.BoardId,
                        principalTable: "MyProperty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "MyProperty",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Open" });

            migrationBuilder.InsertData(
                table: "MyProperty",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "InProgress" });

            migrationBuilder.InsertData(
                table: "MyProperty",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Done" });

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

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_BoardId",
                table: "Tasks",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_OwnerId",
                table: "Tasks",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "MyProperty");
        }
    }
}
