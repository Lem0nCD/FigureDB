using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FigureDB.Model.Migrations
{
    public partial class changerecommendschema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recommands_Images_ImageId",
                table: "Recommands");

            migrationBuilder.DropIndex(
                name: "IX_Recommands_ImageId",
                table: "Recommands");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Recommands");

            migrationBuilder.DropColumn(
                name: "RecommandId",
                table: "Images");

            migrationBuilder.AddColumn<Guid>(
                name: "FigureImageId",
                table: "Recommands",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Recommands_FigureImageId",
                table: "Recommands",
                column: "FigureImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recommands_FigureImages_FigureImageId",
                table: "Recommands",
                column: "FigureImageId",
                principalTable: "FigureImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recommands_FigureImages_FigureImageId",
                table: "Recommands");

            migrationBuilder.DropIndex(
                name: "IX_Recommands_FigureImageId",
                table: "Recommands");

            migrationBuilder.DropColumn(
                name: "FigureImageId",
                table: "Recommands");

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Recommands",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RecommandId",
                table: "Images",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Recommands_ImageId",
                table: "Recommands",
                column: "ImageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Recommands_Images_ImageId",
                table: "Recommands",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
