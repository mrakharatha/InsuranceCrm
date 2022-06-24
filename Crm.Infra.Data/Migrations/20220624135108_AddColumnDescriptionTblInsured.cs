using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crm.Infra.Data.Migrations
{
    public partial class AddColumnDescriptionTblInsured : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Insureds",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Insureds");
        }
    }
}
