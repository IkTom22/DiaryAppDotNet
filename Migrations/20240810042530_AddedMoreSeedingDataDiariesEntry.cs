using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Diary.Migrations
{
    /// <inheritdoc />
    public partial class AddedMoreSeedingDataDiariesEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 8, 10, 16, 25, 30, 442, DateTimeKind.Local).AddTicks(9460));

            migrationBuilder.InsertData(
                table: "DiaryEntries",
                columns: new[] { "Id", "Content", "Created", "Title" },
                values: new object[,]
                {
                    { 2, "WEnt hiking with Joe", new DateTime(2024, 8, 10, 16, 25, 30, 442, DateTimeKind.Local).AddTicks(9460), "Went Hiking" },
                    { 3, "Went swimming with Miffy", new DateTime(2024, 8, 10, 16, 25, 30, 442, DateTimeKind.Local).AddTicks(9460), "Went Swimming" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 8, 10, 15, 36, 20, 364, DateTimeKind.Local).AddTicks(2530));
        }
    }
}
