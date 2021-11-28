using Microsoft.EntityFrameworkCore.Migrations;

namespace MyToDoList.Migrations
{
    public partial class todoidadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ToDoID",
                table: "ToDos",
                type: "int",
                nullable: false,
                defaultValue: 0).Annotation("SqlServer:Identity", "1,1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ToDoID",
                table: "ToDos");
        }
    }
}
