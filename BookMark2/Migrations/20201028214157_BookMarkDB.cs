using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;

namespace BookMark2.Migrations
{
    public partial class BookMarkDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonalBookMark",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    BookType = table.Column<string>(nullable: true),
                    BookGenre = table.Column<string>(nullable: true),
                    BookSubject = table.Column<string>(nullable: true),
                    CurrentChapters = table.Column<int>(nullable: false),
                    CurrentPage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalBookMark", x => x.Id);
                });
            var sqlFile = Path.Combine(".\\DatabaseScripts", @"data.sql");

            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonalBookMark");
        }
    }
}
