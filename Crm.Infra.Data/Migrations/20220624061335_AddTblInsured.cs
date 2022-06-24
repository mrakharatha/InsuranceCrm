using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crm.Infra.Data.Migrations
{
    public partial class AddTblInsured : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Insureds",
                columns: table => new
                {
                    InsuredId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    InstallmentId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false),
                    TermInsuranceId = table.Column<int>(type: "int", nullable: false),
                    InsuranceId = table.Column<int>(type: "int", nullable: false),
                    FirstYearPremiumAmount = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    InstallmentStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AmountPerInstallment = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    CapitalDeathFirstYear = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    StartDateOfInsurancePolicy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insureds", x => x.InsuredId);
                    table.ForeignKey(
                        name: "FK_Insureds_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Insureds_Installments_InstallmentId",
                        column: x => x.InstallmentId,
                        principalTable: "Installments",
                        principalColumn: "InstallmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Insureds_Insurance_InsuranceId",
                        column: x => x.InsuranceId,
                        principalTable: "Insurance",
                        principalColumn: "InsuranceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Insureds_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "PaymentMethodId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Insureds_TermInsurances_TermInsuranceId",
                        column: x => x.TermInsuranceId,
                        principalTable: "TermInsurances",
                        principalColumn: "TermInsuranceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Insureds_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "PermissionId", "ParentId", "Title" },
                values: new object[] { 36, null, "بیمه شدگان" });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "PermissionId", "ParentId", "Title" },
                values: new object[] { 37, 36, "افزودن  بیمه شده" });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "PermissionId", "ParentId", "Title" },
                values: new object[] { 38, 36, "ویرایش  بیمه شده " });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "PermissionId", "ParentId", "Title" },
                values: new object[] { 39, 36, "حذف  بیمه شده" });

            migrationBuilder.CreateIndex(
                name: "IX_Insureds_CustomerId",
                table: "Insureds",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Insureds_InstallmentId",
                table: "Insureds",
                column: "InstallmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Insureds_InsuranceId",
                table: "Insureds",
                column: "InsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_Insureds_PaymentMethodId",
                table: "Insureds",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Insureds_TermInsuranceId",
                table: "Insureds",
                column: "TermInsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_Insureds_UserId",
                table: "Insureds",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Insureds");

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 36);
        }
    }
}
