using Microsoft.EntityFrameworkCore.Migrations;

namespace Solucao.Application.Migrations
{
    public partial class AddedAttributeTypesAndTechnicalAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttributeTypes",
                columns: table => new
                {
                    key = table.Column<string>(type: "varchar(50)", nullable: false),
                    value = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "TechnicalAttributes",
                columns: table => new
                {
                    key = table.Column<string>(type: "varchar(50)", nullable: false),
                    value = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttributeTypes");

            migrationBuilder.DropTable(
                name: "TechnicalAttributes");
        }
    }
}
