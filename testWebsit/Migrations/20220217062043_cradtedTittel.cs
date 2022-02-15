using Microsoft.EntityFrameworkCore.Migrations;

namespace testWebsit.Migrations
{
    public partial class cradtedTittel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tittel",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tittel",
                table: "Comments");
        }
    }
}
