using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crm.Infra.Data.Migrations
{
    public partial class RemoveTblTypeSystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Installments_TypeSystems_TypeSystemId",
                table: "Installments");

            migrationBuilder.DropTable(
                name: "TypeSystems");

            migrationBuilder.DropIndex(
                name: "IX_Installments_TypeSystemId",
                table: "Installments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypeSystems",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeSystems", x => x.TypeId);
                });

            migrationBuilder.InsertData(
                table: "TypeSystems",
                columns: new[] { "TypeId", "Title" },
                values: new object[] { 1, "سال" });

            migrationBuilder.InsertData(
                table: "TypeSystems",
                columns: new[] { "TypeId", "Title" },
                values: new object[] { 2, "ماه" });

            migrationBuilder.InsertData(
                table: "TypeSystems",
                columns: new[] { "TypeId", "Title" },
                values: new object[] { 3, "روز" });

            migrationBuilder.CreateIndex(
                name: "IX_Installments_TypeSystemId",
                table: "Installments",
                column: "TypeSystemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Installments_TypeSystems_TypeSystemId",
                table: "Installments",
                column: "TypeSystemId",
                principalTable: "TypeSystems",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
