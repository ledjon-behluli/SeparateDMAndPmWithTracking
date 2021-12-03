using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SeparateDMAndPMWithTracking.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialAccount",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    AccountType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialAccount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PublisherAccount",
                columns: table => new
                {
                    PublisherId = table.Column<Guid>(nullable: false),
                    SocialAccountId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublisherAccount", x => new { x.PublisherId, x.SocialAccountId });
                    table.ForeignKey(
                        name: "FK_PublisherAccount_Publisher_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publisher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PublisherAccount_SocialAccount_SocialAccountId",
                        column: x => x.SocialAccountId,
                        principalTable: "SocialAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PublisherAccount_SocialAccountId",
                table: "PublisherAccount",
                column: "SocialAccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PublisherAccount");

            migrationBuilder.DropTable(
                name: "Publisher");

            migrationBuilder.DropTable(
                name: "SocialAccount");
        }
    }
}
