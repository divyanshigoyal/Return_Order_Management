using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class AddBillingModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Billings",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProcessResponseId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreditCardNumber = table.Column<string>(type: "TEXT", nullable: true),
                    CreditLimit = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Billings", x => x.id);
                    table.ForeignKey(
                        name: "FK_Billings_ProcessResponse_ProcessResponseId",
                        column: x => x.ProcessResponseId,
                        principalTable: "ProcessResponse",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Billings_ProcessResponseId",
                table: "Billings",
                column: "ProcessResponseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Billings");
        }
    }
}
