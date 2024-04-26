using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcMentor.Migrations
{
    /// <inheritdoc />
    public partial class TablesRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Features_Features_FeatureId",
                table: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Features_FeatureId",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "FeatureId",
                table: "Features");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FeatureId",
                table: "Features",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Features_FeatureId",
                table: "Features",
                column: "FeatureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Features_Features_FeatureId",
                table: "Features",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "Id");
        }
    }
}
