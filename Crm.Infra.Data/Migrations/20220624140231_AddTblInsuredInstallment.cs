using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crm.Infra.Data.Migrations
{
    public partial class AddTblInsuredInstallment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InsuredInstallments",
                columns: table => new
                {
                    InsuredInstallmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsuredId = table.Column<int>(type: "int", nullable: false),
                    DateInstallment = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuredInstallments", x => x.InsuredInstallmentId);
                    table.ForeignKey(
                        name: "FK_InsuredInstallments_Insureds_InsuredId",
                        column: x => x.InsuredId,
                        principalTable: "Insureds",
                        principalColumn: "InsuredId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InsuredInstallments_InsuredId",
                table: "InsuredInstallments",
                column: "InsuredId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InsuredInstallments");
        }
    }
}
