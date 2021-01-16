using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FigureDB.Model.Migrations
{
    public partial class changeschema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtistJobs_Artists_ArtistId",
                table: "ArtistJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistJobs_Jobs_JobId",
                table: "ArtistJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Users_UserId",
                table: "Favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_FigureImages_Figures_FigureId",
                table: "FigureImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Figures_Characters_CharacterId",
                table: "Figures");

            migrationBuilder.DropForeignKey(
                name: "FK_Figures_Origins_OriginId",
                table: "Figures");

            migrationBuilder.DropForeignKey(
                name: "FK_FigureTags_Figures_FigureId",
                table: "FigureTags");

            migrationBuilder.DropForeignKey(
                name: "FK_FigureTags_Tags_TagId",
                table: "FigureTags");

            migrationBuilder.DropForeignKey(
                name: "FK_News_Figures_FigureId",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Figures_FigureId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Shops_ShopId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserIdentities_Users_UserId",
                table: "UserIdentities");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_FigureImages_FigureId",
                table: "FigureImages");

            migrationBuilder.DropColumn(
                name: "UserRoleId",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "Shops",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Icon",
                table: "Shops",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CoverImage",
                table: "Origins",
                nullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Scale",
                table: "Figures",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Release",
                table: "Figures",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<float>(
                name: "Dimensions",
                table: "Figures",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<Guid>(
                name: "FigureImageId",
                table: "Figures",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "FigureTypeId",
                table: "Figures",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "FigureImages",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Icon",
                table: "Companies",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Avatar",
                table: "Characters",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Avator",
                table: "Artists",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "FigureTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsRemove = table.Column<bool>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    FigureId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FigureTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FigureTypes_Figures_FigureId",
                        column: x => x.FigureId,
                        principalTable: "Figures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsRemove = table.Column<bool>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    RecommandId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recommands",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsRemove = table.Column<bool>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    ImageId = table.Column<Guid>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    FigureId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recommands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recommands_Figures_FigureId",
                        column: x => x.FigureId,
                        principalTable: "Figures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recommands_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FigureImages_FigureId",
                table: "FigureImages",
                column: "FigureId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FigureImages_ImageId",
                table: "FigureImages",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_FigureTypes_FigureId",
                table: "FigureTypes",
                column: "FigureId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recommands_FigureId",
                table: "Recommands",
                column: "FigureId");

            migrationBuilder.CreateIndex(
                name: "IX_Recommands_ImageId",
                table: "Recommands",
                column: "ImageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistJobs_Artists_ArtistId",
                table: "ArtistJobs",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistJobs_Jobs_JobId",
                table: "ArtistJobs",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Users_UserId",
                table: "Favorites",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FigureImages_Figures_FigureId",
                table: "FigureImages",
                column: "FigureId",
                principalTable: "Figures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FigureImages_Images_ImageId",
                table: "FigureImages",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Figures_Characters_CharacterId",
                table: "Figures",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Figures_Origins_OriginId",
                table: "Figures",
                column: "OriginId",
                principalTable: "Origins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FigureTags_Figures_FigureId",
                table: "FigureTags",
                column: "FigureId",
                principalTable: "Figures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FigureTags_Tags_TagId",
                table: "FigureTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_News_Figures_FigureId",
                table: "News",
                column: "FigureId",
                principalTable: "Figures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Figures_FigureId",
                table: "Offers",
                column: "FigureId",
                principalTable: "Figures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Shops_ShopId",
                table: "Offers",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserIdentities_Users_UserId",
                table: "UserIdentities",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtistJobs_Artists_ArtistId",
                table: "ArtistJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistJobs_Jobs_JobId",
                table: "ArtistJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Users_UserId",
                table: "Favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_FigureImages_Figures_FigureId",
                table: "FigureImages");

            migrationBuilder.DropForeignKey(
                name: "FK_FigureImages_Images_ImageId",
                table: "FigureImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Figures_Characters_CharacterId",
                table: "Figures");

            migrationBuilder.DropForeignKey(
                name: "FK_Figures_Origins_OriginId",
                table: "Figures");

            migrationBuilder.DropForeignKey(
                name: "FK_FigureTags_Figures_FigureId",
                table: "FigureTags");

            migrationBuilder.DropForeignKey(
                name: "FK_FigureTags_Tags_TagId",
                table: "FigureTags");

            migrationBuilder.DropForeignKey(
                name: "FK_News_Figures_FigureId",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Figures_FigureId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Shops_ShopId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserIdentities_Users_UserId",
                table: "UserIdentities");

            migrationBuilder.DropTable(
                name: "FigureTypes");

            migrationBuilder.DropTable(
                name: "Recommands");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropIndex(
                name: "IX_FigureImages_FigureId",
                table: "FigureImages");

            migrationBuilder.DropIndex(
                name: "IX_FigureImages_ImageId",
                table: "FigureImages");

            migrationBuilder.DropColumn(
                name: "About",
                table: "Shops");

            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Shops");

            migrationBuilder.DropColumn(
                name: "CoverImage",
                table: "Origins");

            migrationBuilder.DropColumn(
                name: "FigureImageId",
                table: "Figures");

            migrationBuilder.DropColumn(
                name: "FigureTypeId",
                table: "Figures");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "FigureImages");

            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "Characters");

            migrationBuilder.AddColumn<Guid>(
                name: "UserRoleId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<float>(
                name: "Scale",
                table: "Figures",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Release",
                table: "Figures",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Dimensions",
                table: "Figures",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Icon",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Avator",
                table: "Artists",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRemove = table.Column<bool>(type: "bit", nullable: false),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRemove = table.Column<bool>(type: "bit", nullable: false),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FigureImages_FigureId",
                table: "FigureImages",
                column: "FigureId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistJobs_Artists_ArtistId",
                table: "ArtistJobs",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistJobs_Jobs_JobId",
                table: "ArtistJobs",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Users_UserId",
                table: "Favorites",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FigureImages_Figures_FigureId",
                table: "FigureImages",
                column: "FigureId",
                principalTable: "Figures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Figures_Characters_CharacterId",
                table: "Figures",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Figures_Origins_OriginId",
                table: "Figures",
                column: "OriginId",
                principalTable: "Origins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FigureTags_Figures_FigureId",
                table: "FigureTags",
                column: "FigureId",
                principalTable: "Figures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FigureTags_Tags_TagId",
                table: "FigureTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_News_Figures_FigureId",
                table: "News",
                column: "FigureId",
                principalTable: "Figures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Figures_FigureId",
                table: "Offers",
                column: "FigureId",
                principalTable: "Figures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Shops_ShopId",
                table: "Offers",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserIdentities_Users_UserId",
                table: "UserIdentities",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
