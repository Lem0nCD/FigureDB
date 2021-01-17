using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FigureDB.Model.Migrations
{
    public partial class changefigureimageschema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FigureImages_FigureId",
                table: "FigureImages");

            migrationBuilder.DropColumn(
                name: "FigureImageId",
                table: "Figures");

            migrationBuilder.CreateIndex(
                name: "IX_FigureImages_FigureId",
                table: "FigureImages",
                column: "FigureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FigureImages_FigureId",
                table: "FigureImages");

            migrationBuilder.AddColumn<Guid>(
                name: "FigureImageId",
                table: "Figures",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_FigureImages_FigureId",
                table: "FigureImages",
                column: "FigureId",
                unique: true);
        }
    }
}
