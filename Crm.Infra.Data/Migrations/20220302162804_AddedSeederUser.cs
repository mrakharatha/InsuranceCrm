using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crm.Infra.Data.Migrations
{
    public partial class AddedSeederUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreateDate", "DeleteDate", "IsActive", "Name", "Password", "UpdateDate", "UserName" },
                values: new object[] { 1, new DateTime(2022, 3, 2, 19, 56, 32, 968, DateTimeKind.Local).AddTicks(1379), null, true, "سید محمد رضا آزاد", "7D-A1-88-C2-E2-D8-3E-38-B7-D9-E7-5E-50-0F-1A-F8", null, "SuperAdmin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);
        }
    }
}
