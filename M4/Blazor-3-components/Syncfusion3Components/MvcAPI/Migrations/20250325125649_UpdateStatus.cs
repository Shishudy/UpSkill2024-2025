using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Concluida",
                table: "Tarefas");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Tarefas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Tarefas");

            migrationBuilder.AddColumn<bool>(
                name: "Concluida",
                table: "Tarefas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
