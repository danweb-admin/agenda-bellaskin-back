using Microsoft.EntityFrameworkCore.Migrations;

namespace Solucao.Application.Migrations
{
    public partial class AddedNewColumnToCalendar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Value",
                table: "Calendars",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "Calendars");
        }
    }
}
