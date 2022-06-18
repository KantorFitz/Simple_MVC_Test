using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SzkolenieTechniczne.Projekt.Cimena.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    SeanceTime = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seances_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PeopleCount = table.Column<int>(type: "int", nullable: false),
                    PurchasesDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SeanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Seances_SeanceId",
                        column: x => x.SeanceId,
                        principalTable: "Seances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Name", "SeanceTime", "Year" },
                values: new object[] { new Guid("0feff996-9f16-4f7b-8db8-a9a7c4970600"), "Garry", 150, 2010 });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Name", "SeanceTime", "Year" },
                values: new object[] { new Guid("2a6ccafc-551f-4d7a-8157-de1370e23544"), "Lolita", 150, 2010 });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Name", "SeanceTime", "Year" },
                values: new object[] { new Guid("3f9e7587-9ac6-4ddd-9ab4-edb28b609356"), "Harry", 150, 2010 });

            migrationBuilder.InsertData(
                table: "Seances",
                columns: new[] { "Id", "Date", "MovieId" },
                values: new object[] { new Guid("06ca2b8c-9aed-4acb-8718-9a2e43ec88be"), new DateTime(2019, 3, 10, 18, 30, 0, 0, DateTimeKind.Unspecified), new Guid("3f9e7587-9ac6-4ddd-9ab4-edb28b609356") });

            migrationBuilder.InsertData(
                table: "Seances",
                columns: new[] { "Id", "Date", "MovieId" },
                values: new object[] { new Guid("4001318b-9790-4c13-9016-536f0dc2592d"), new DateTime(2019, 3, 10, 18, 30, 0, 0, DateTimeKind.Unspecified), new Guid("0feff996-9f16-4f7b-8db8-a9a7c4970600") });

            migrationBuilder.InsertData(
                table: "Seances",
                columns: new[] { "Id", "Date", "MovieId" },
                values: new object[] { new Guid("bbcc5941-e385-4bf3-9e87-e08fefa81ec3"), new DateTime(2019, 3, 10, 18, 30, 0, 0, DateTimeKind.Unspecified), new Guid("2a6ccafc-551f-4d7a-8157-de1370e23544") });

            migrationBuilder.CreateIndex(
                name: "IX_Seances_MovieId",
                table: "Seances",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SeanceId",
                table: "Tickets",
                column: "SeanceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Seances");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
