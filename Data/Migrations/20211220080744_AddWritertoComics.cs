using Microsoft.EntityFrameworkCore.Migrations;

namespace Dads_Site.Data.Migrations
{
    public partial class AddWritertoComics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Writer",
                table: "Comic",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Writer",
                table: "Comic");
        }
    }
}
