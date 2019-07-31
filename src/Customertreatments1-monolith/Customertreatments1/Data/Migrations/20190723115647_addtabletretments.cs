using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Customertreatments1.Data.Migrations
{
    public partial class addtabletretments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Treatments",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Weight = table.Column<float>(nullable: false),
                    Height = table.Column<float>(nullable: false),
                    DailyFood = table.Column<string>(nullable: true),
                    Vitmens = table.Column<string>(nullable: true),
                    ProplemHistory = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatments", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Treatments");
        }
    }
}
