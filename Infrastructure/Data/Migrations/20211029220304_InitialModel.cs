using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DefectiveComponentDetails",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ComponentType = table.Column<string>(type: "TEXT", nullable: true),
                    ComponentName = table.Column<string>(type: "TEXT", nullable: true),
                    Quantity = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefectiveComponentDetails", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ProcessResponse",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProcessingCharge = table.Column<decimal>(type: "TEXT", nullable: false),
                    PackagingAndDeliveryCharge = table.Column<decimal>(type: "TEXT", nullable: false),
                    DateOfDelivery = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessResponse", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ProcessRequests",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", nullable: true),
                    ContactNumber = table.Column<string>(type: "TEXT", nullable: true),
                    DefectiveComponentDetailId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessRequests", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProcessRequests_DefectiveComponentDetails_DefectiveComponentDetailId",
                        column: x => x.DefectiveComponentDetailId,
                        principalTable: "DefectiveComponentDetails",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProcessRequests_DefectiveComponentDetailId",
                table: "ProcessRequests",
                column: "DefectiveComponentDetailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProcessRequests");

            migrationBuilder.DropTable(
                name: "ProcessResponse");

            migrationBuilder.DropTable(
                name: "DefectiveComponentDetails");
        }
    }
}
