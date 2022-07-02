using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SzkolenieTechniczne.Projekt.Cimena.Infrastructure.Migrations
{
    public partial class AddedToTableInconfigurations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Seances",
                keyColumn: "Id",
                keyValue: new Guid("06ca2b8c-9aed-4acb-8718-9a2e43ec88be"));

            migrationBuilder.DeleteData(
                table: "Seances",
                keyColumn: "Id",
                keyValue: new Guid("4001318b-9790-4c13-9016-536f0dc2592d"));

            migrationBuilder.DeleteData(
                table: "Seances",
                keyColumn: "Id",
                keyValue: new Guid("bbcc5941-e385-4bf3-9e87-e08fefa81ec3"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("0feff996-9f16-4f7b-8db8-a9a7c4970600"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("2a6ccafc-551f-4d7a-8157-de1370e23544"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("3f9e7587-9ac6-4ddd-9ab4-edb28b609356"));

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Name", "SeanceTime", "Year" },
                values: new object[] { new Guid("045173b2-5066-43e4-a3d1-c24f4b1e0dc6"), "Harry", 150, 2010 });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Name", "SeanceTime", "Year" },
                values: new object[] { new Guid("6529baea-e7be-4198-87a0-f653706327ce"), "Lolita", 150, 2010 });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Name", "SeanceTime", "Year" },
                values: new object[] { new Guid("682f6c81-2f95-4d49-84fd-925f2b26e4e6"), "Garry", 150, 2010 });

            migrationBuilder.InsertData(
                table: "Seances",
                columns: new[] { "Id", "Date", "MovieId" },
                values: new object[] { new Guid("0d7fa239-28c3-462e-825f-d049d99b10d2"), new DateTime(2019, 3, 10, 18, 30, 0, 0, DateTimeKind.Unspecified), new Guid("682f6c81-2f95-4d49-84fd-925f2b26e4e6") });

            migrationBuilder.InsertData(
                table: "Seances",
                columns: new[] { "Id", "Date", "MovieId" },
                values: new object[] { new Guid("ee12c596-8bdd-4458-86b3-cbc3ffd605f5"), new DateTime(2019, 3, 10, 18, 30, 0, 0, DateTimeKind.Unspecified), new Guid("045173b2-5066-43e4-a3d1-c24f4b1e0dc6") });

            migrationBuilder.InsertData(
                table: "Seances",
                columns: new[] { "Id", "Date", "MovieId" },
                values: new object[] { new Guid("f3e7390e-9a73-4df8-a9d0-767cd6bd8ebe"), new DateTime(2019, 3, 10, 18, 30, 0, 0, DateTimeKind.Unspecified), new Guid("6529baea-e7be-4198-87a0-f653706327ce") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Seances",
                keyColumn: "Id",
                keyValue: new Guid("0d7fa239-28c3-462e-825f-d049d99b10d2"));

            migrationBuilder.DeleteData(
                table: "Seances",
                keyColumn: "Id",
                keyValue: new Guid("ee12c596-8bdd-4458-86b3-cbc3ffd605f5"));

            migrationBuilder.DeleteData(
                table: "Seances",
                keyColumn: "Id",
                keyValue: new Guid("f3e7390e-9a73-4df8-a9d0-767cd6bd8ebe"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("045173b2-5066-43e4-a3d1-c24f4b1e0dc6"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("6529baea-e7be-4198-87a0-f653706327ce"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("682f6c81-2f95-4d49-84fd-925f2b26e4e6"));

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
        }
    }
}
