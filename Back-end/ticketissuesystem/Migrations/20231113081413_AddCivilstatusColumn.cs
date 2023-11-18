using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ticketissuesystem.Migrations
{
    /// <inheritdoc />
    public partial class AddCivilstatusColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Civilstatus",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Civilstatus",
                table: "Employees");
        }
    }
}
