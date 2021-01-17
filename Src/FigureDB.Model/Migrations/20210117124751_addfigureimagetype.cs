using Microsoft.EntityFrameworkCore.Migrations;

namespace FigureDB.Model.Migrations
{
    public partial class addfigureimagetype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FigureImageType",
                table: "FigureImages",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FigureImageType",
                table: "FigureImages");
        }
    }
}
