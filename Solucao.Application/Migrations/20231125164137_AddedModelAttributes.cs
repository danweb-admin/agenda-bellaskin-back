using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Solucao.Application.Migrations
{
    public partial class AddedModelAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ModelAttributes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),                   
                    active = table.Column<bool>(type: "bit", nullable: false),
                    fileAttribute = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    technicalAttribute = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    AttributeType = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    modelId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModelAttributes_Models_modelId",
                        column: x => x.modelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModelAttributes_modelId",
                table: "ModelAttributes",
                column: "modelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModelAttributes");
        }
    }
}
