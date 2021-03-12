using Microsoft.EntityFrameworkCore.Migrations;

namespace Employee.Infrastructure.Migrations
{
    public partial class UpdatedCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IsoCode",
                table: "Country",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsoCode",
                table: "Country");
        }
    }
}
