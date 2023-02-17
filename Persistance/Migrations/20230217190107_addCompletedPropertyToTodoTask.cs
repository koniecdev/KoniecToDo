using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class addCompletedPropertyToTodoTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "TodoTasks");

            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "TodoTasks",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Completed",
                table: "TodoTasks");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TodoTasks",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);
        }
    }
}
