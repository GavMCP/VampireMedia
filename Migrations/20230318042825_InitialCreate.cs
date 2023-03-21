using System;
using Microsoft.EntityFrameworkCore.Migrations;
using VampireMedia.Enums;

#nullable disable

namespace VampireMedia.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type:"int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type:"nvarchar(100)", nullable: true),
                    Author = table.Column<string>(type:"nvarchar(75)", nullable: true),
                    YearPublished = table.Column<DateTime>(type:"datetime2",nullable: false),
                    BookType = table.Column<int>(type:"int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoverImage = table.Column<byte>(type:"varbinary(max)", nullable: true),
                    Rating = table.Column<RatingType>(type: "string", nullable: true),
                    Edition = table.Column<int>(type: "int", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });


            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MediaType = table.Column<int>(type: "int", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    StarActor = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    SupportingActors = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    CoverImage = table.Column<byte>(type: "varbinary(max)", nullable: true),
                    Rating = table.Column<RatingType>(type: "string", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
