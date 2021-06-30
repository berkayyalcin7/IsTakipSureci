using Microsoft.EntityFrameworkCore.Migrations;

namespace IsTakipSureci.DataAccess.Migrations
{
    public partial class newColumnWorkAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Works",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Works");
        }
    }
}
