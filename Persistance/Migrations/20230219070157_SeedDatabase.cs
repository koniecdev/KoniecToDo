using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Priorities",
                columns: new[] { "Id", "Color", "Level", "Name", "StatusId" },
                values: new object[] { 1, "#ff0000", 0, "Very important", 1 });

            migrationBuilder.InsertData(
                table: "Priorities",
                columns: new[] { "Id", "Color", "Level", "Name", "StatusId" },
                values: new object[] { 2, "#ff6D0A", 0, "Important", 1 });

            migrationBuilder.InsertData(
                table: "Priorities",
                columns: new[] { "Id", "Color", "Level", "Name", "StatusId" },
                values: new object[] { 3, "#00ff00", 0, "Normal", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Priorities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Priorities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Priorities",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
