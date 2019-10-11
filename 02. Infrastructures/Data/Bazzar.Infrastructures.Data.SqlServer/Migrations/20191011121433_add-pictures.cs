using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bazzar.Infrastructures.Data.SqlServer.Migrations
{
    public partial class addpictures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Picture",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Size_Height = table.Column<int>(nullable: true),
                    Size_Width = table.Column<int>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    AdvertismentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Picture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Picture_Advertisments_AdvertismentId",
                        column: x => x.AdvertismentId,
                        principalTable: "Advertisments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Picture_AdvertismentId",
                table: "Picture",
                column: "AdvertismentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Picture");
        }
    }
}
