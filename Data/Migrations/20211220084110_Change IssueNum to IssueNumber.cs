using Microsoft.EntityFrameworkCore.Migrations;

namespace Dads_Site.Data.Migrations
{
    public partial class ChangeIssueNumtoIssueNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IssueNum",
                table: "Comic",
                newName: "IssueNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IssueNumber",
                table: "Comic",
                newName: "IssueNum");
        }
    }
}
