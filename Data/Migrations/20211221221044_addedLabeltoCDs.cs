using Microsoft.EntityFrameworkCore.Migrations;

namespace Dads_Site.Data.Migrations
{
    public partial class addedLabeltoCDs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Label",
                table: "CDs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Label",
                table: "CDs");
        }
    }
}
