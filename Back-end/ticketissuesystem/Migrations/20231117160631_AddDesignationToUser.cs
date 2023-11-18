using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ticketissuesystem.Migrations
{
    /// <inheritdoc />
    public partial class AddDesignationToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Designation",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Designation",
                table: "Users");
        }
    }
}
