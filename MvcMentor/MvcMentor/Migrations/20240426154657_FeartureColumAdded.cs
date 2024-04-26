using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcMentor.Migrations
{
    /// <inheritdoc />
    public partial class FeartureColumAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFeature",
                table: "Cards",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFeature",
                table: "Cards");
        }
    }
}
