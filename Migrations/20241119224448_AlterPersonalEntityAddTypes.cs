using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_personal.Migrations
{
    /// <inheritdoc />
    public partial class AlterPersonalEntityAddTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Per_confirmado",
                table: "Personal",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Per_confirmado",
                table: "Personal");
        }
    }
}
