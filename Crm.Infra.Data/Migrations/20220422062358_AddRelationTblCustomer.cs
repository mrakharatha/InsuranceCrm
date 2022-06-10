using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crm.Infra.Data.Migrations
{
    public partial class AddRelationTblCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProvinceId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TownshipId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ProvinceId",
                table: "Customers",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_TownshipId",
                table: "Customers",
                column: "TownshipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Provinces_ProvinceId",
                table: "Customers",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "ProvinceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Townships_TownshipId",
                table: "Customers",
                column: "TownshipId",
                principalTable: "Townships",
                principalColumn: "TownshipId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Provinces_ProvinceId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Townships_TownshipId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_ProvinceId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_TownshipId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "TownshipId",
                table: "Customers");
        }
    }
}
