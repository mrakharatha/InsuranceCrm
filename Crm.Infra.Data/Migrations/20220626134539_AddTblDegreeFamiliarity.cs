using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crm.Infra.Data.Migrations
{
    public partial class AddTblDegreeFamiliarity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DegreeFamiliarities",
                columns: table => new
                {
                    DegreeFamiliarityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DegreeFamiliarities", x => x.DegreeFamiliarityId);
                    table.ForeignKey(
                        name: "FK_DegreeFamiliarities_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "PermissionId", "ParentId", "Title" },
                values: new object[] { 44, 11, "درجه آشنائیت" });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "PermissionId", "ParentId", "Title" },
                values: new object[] { 45, 44, "افزودن درجه آشنائیت" });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "PermissionId", "ParentId", "Title" },
                values: new object[] { 46, 44, "ویرایش درجه آشنائیت " });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "PermissionId", "ParentId", "Title" },
                values: new object[] { 47, 44, "حذف درجه آشنائیت" });

            migrationBuilder.CreateIndex(
                name: "IX_DegreeFamiliarities_UserId",
                table: "DegreeFamiliarities",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DegreeFamiliarities");

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 44);
        }
    }
}
