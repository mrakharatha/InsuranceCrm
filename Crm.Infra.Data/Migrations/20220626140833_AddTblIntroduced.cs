using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crm.Infra.Data.Migrations
{
    public partial class AddTblIntroduced : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Introduceds",
                columns: table => new
                {
                    IntroducedId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DegreeFamiliarityId = table.Column<int>(type: "int", nullable: false),
                    RatioId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Introduceds", x => x.IntroducedId);
                    table.ForeignKey(
                        name: "FK_Introduceds_DegreeFamiliarities_DegreeFamiliarityId",
                        column: x => x.DegreeFamiliarityId,
                        principalTable: "DegreeFamiliarities",
                        principalColumn: "DegreeFamiliarityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Introduceds_Ratios_RatioId",
                        column: x => x.RatioId,
                        principalTable: "Ratios",
                        principalColumn: "RatioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Introduceds_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "PermissionId", "ParentId", "Title" },
                values: new object[] { 48, 36, "مشاهده اقساط بیمه شده" });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "PermissionId", "ParentId", "Title" },
                values: new object[] { 49, 36, "معرفی شدگان" });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "PermissionId", "ParentId", "Title" },
                values: new object[] { 50, 49, "افزودن معرفی شده" });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "PermissionId", "ParentId", "Title" },
                values: new object[] { 51, 49, "ویرایش معرفی شده" });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "PermissionId", "ParentId", "Title" },
                values: new object[] { 52, 49, "حذف معرفی شده" });

            migrationBuilder.CreateIndex(
                name: "IX_Introduceds_DegreeFamiliarityId",
                table: "Introduceds",
                column: "DegreeFamiliarityId");

            migrationBuilder.CreateIndex(
                name: "IX_Introduceds_RatioId",
                table: "Introduceds",
                column: "RatioId");

            migrationBuilder.CreateIndex(
                name: "IX_Introduceds_UserId",
                table: "Introduceds",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Introduceds");

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 49);
        }
    }
}
