using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Tarefas",
                newName: "Username");

            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "Tarefas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Tarefas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DOB",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Tarefas");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Tarefas",
                newName: "Descricao");
        }
    }
}
