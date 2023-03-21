using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VampireMedia.Migrations
{
    /// <inheritdoc />
    public partial class addNoteTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ListTodoModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date_Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Date_Completed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListTodoModel", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListTodoModel");
        }
    }
}
