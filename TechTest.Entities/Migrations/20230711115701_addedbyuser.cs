using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechTest.Entities.Migrations
{
    /// <inheritdoc />
    public partial class addedbyuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AddedByUser",
                table: "Shows",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedByUser",
                table: "Shows");
        }
    }
}
