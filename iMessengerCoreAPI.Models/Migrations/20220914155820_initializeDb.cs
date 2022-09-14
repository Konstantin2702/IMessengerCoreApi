using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iMessengerCoreAPI.Models.Migrations
{
    public partial class initializeDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RGDialogsClients",
                columns: table => new
                {
                    IDUnique = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDRGDialog = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDClient = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateEvent = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RGDialogsClients", x => x.IDUnique);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RGDialogsClients");
        }
    }
}
