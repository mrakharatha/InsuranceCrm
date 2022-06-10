using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crm.Infra.Data.Migrations
{
    public partial class CreatePermissionSeederUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 3,
                column: "Title",
                value: "کاربران");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 4,
                column: "Title",
                value: "افزودن کاربران");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 5,
                column: "Title",
                value: "ویرایش کاربران ");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 6,
                column: "Title",
                value: "حذف کاربران");

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "PermissionId", "ParentId", "Title" },
                values: new object[] { 7, 2, "سطح دسترسی" });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "PermissionId", "ParentId", "Title" },
                values: new object[] { 8, 7, "افزودن سطح دسترسی" });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "PermissionId", "ParentId", "Title" },
                values: new object[] { 9, 7, "ویرایش سطح دسترسی" });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "PermissionId", "ParentId", "Title" },
                values: new object[] { 10, 7, "حذف سطح دسترسی" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 3,
                column: "Title",
                value: "سطح دسترسی");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 4,
                column: "Title",
                value: "افزودن سطح دسترسی");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 5,
                column: "Title",
                value: "ویرایش سطح دسترسی");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 6,
                column: "Title",
                value: "حذف سطح دسترسی");
        }
    }
}
