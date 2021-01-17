using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FigureDB.Model.Migrations
{
    public partial class dropcoverimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverImageId",
                table: "Figures");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CoverImageId",
                table: "Figures",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
