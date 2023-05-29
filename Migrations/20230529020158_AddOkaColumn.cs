using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VampireMedia.Migrations
{
    /// <inheritdoc />
    public partial class AddOkaColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AlsoKnownAs",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlsoKnownAs",
                table: "Movies");
        }
    }
}
