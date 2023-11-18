using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ticketissuesystem.Migrations
{
    /// <inheritdoc />
    public partial class AddBranchColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Branch",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Branch",
                table: "Employees");
        }
    }
}
