using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class addNameToPriority : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoTasks_TodoLists_TodoListId",
                table: "TodoTasks");

            migrationBuilder.AlterColumn<int>(
                name: "TodoListId",
                table: "TodoTasks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Priorities",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoTasks_TodoLists_TodoListId",
                table: "TodoTasks",
                column: "TodoListId",
                principalTable: "TodoLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoTasks_TodoLists_TodoListId",
                table: "TodoTasks");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Priorities");

            migrationBuilder.AlterColumn<int>(
                name: "TodoListId",
                table: "TodoTasks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoTasks_TodoLists_TodoListId",
                table: "TodoTasks",
                column: "TodoListId",
                principalTable: "TodoLists",
                principalColumn: "Id");
        }
    }
}
