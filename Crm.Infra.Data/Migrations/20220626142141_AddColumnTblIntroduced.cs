using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crm.Infra.Data.Migrations
{
    public partial class AddColumnTblIntroduced : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InsuredId",
                table: "Introduceds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Introduceds_InsuredId",
                table: "Introduceds",
                column: "InsuredId");

            migrationBuilder.AddForeignKey(
                name: "FK_Introduceds_Insureds_InsuredId",
                table: "Introduceds",
                column: "InsuredId",
                principalTable: "Insureds",
                principalColumn: "InsuredId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Introduceds_Insureds_InsuredId",
                table: "Introduceds");

            migrationBuilder.DropIndex(
                name: "IX_Introduceds_InsuredId",
                table: "Introduceds");

            migrationBuilder.DropColumn(
                name: "InsuredId",
                table: "Introduceds");
        }
    }
}
