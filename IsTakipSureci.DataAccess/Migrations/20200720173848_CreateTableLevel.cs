using Microsoft.EntityFrameworkCore.Migrations;

namespace IsTakipSureci.DataAccess.Migrations
{
    public partial class CreateTableLevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LevelId",
                table: "Works",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Levels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tanim = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Levels", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Works_LevelId",
                table: "Works",
                column: "LevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Levels_LevelId",
                table: "Works",
                column: "LevelId",
                principalTable: "Levels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Works_Levels_LevelId",
                table: "Works");

            migrationBuilder.DropTable(
                name: "Levels");

            migrationBuilder.DropIndex(
                name: "IX_Works_LevelId",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "LevelId",
                table: "Works");
        }
    }
}
