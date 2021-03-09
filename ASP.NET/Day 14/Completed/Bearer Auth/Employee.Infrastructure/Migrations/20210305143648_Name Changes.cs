using Microsoft.EntityFrameworkCore.Migrations;

namespace Employee.Infrastructure.Migrations
{
    public partial class NameChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
              name: "Name",
              table: "Employee",
              nullable: true);

            migrationBuilder.Sql(
            @"
                UPDATE Employee
                SET Name = FirstName + ' ' + LastName;
            ");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Employee");

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.Sql(
            @"
                UPDATE Employee
                SET Name = FirstName + ' ' + LastName;
            ");


            migrationBuilder.DropColumn(
                name: "Name",
                table: "Employee");
        }
    }
}
