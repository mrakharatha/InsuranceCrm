using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crm.Infra.Data.Migrations
{
    public partial class CreatePermissionSeederCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 4,
                column: "Title",
                value: "افزودن کاربر");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 5,
                column: "Title",
                value: "ویرایش کاربر ");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 6,
                column: "Title",
                value: "حذف کاربر");

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "PermissionId", "ParentId", "Title" },
                values: new object[] { 16, null, "مشتریان" });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "PermissionId", "ParentId", "Title" },
                values: new object[] { 17, 16, "افزودن مشتری" });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "PermissionId", "ParentId", "Title" },
                values: new object[] { 18, 16, "ویرایش مشتری " });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "PermissionId", "ParentId", "Title" },
                values: new object[] { 19, 16, "حذف مشتری" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 16);

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
        }
    }
}
