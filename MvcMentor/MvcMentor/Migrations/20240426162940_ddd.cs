using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcMentor.Migrations
{
    /// <inheritdoc />
    public partial class ddd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardFeature");

            migrationBuilder.AddColumn<int>(
                name: "CardId",
                table: "Features",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FeatureId",
                table: "Features",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Features_CardId",
                table: "Features",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_Features_FeatureId",
                table: "Features",
                column: "FeatureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Features_Cards_CardId",
                table: "Features",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Features_Features_FeatureId",
                table: "Features",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Features_Cards_CardId",
                table: "Features");

            migrationBuilder.DropForeignKey(
                name: "FK_Features_Features_FeatureId",
                table: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Features_CardId",
                table: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Features_FeatureId",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "CardId",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "FeatureId",
                table: "Features");

            migrationBuilder.CreateTable(
                name: "CardFeature",
                columns: table => new
                {
                    CardsId = table.Column<int>(type: "int", nullable: false),
                    FeaturesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardFeature", x => new { x.CardsId, x.FeaturesId });
                    table.ForeignKey(
                        name: "FK_CardFeature_Cards_CardsId",
                        column: x => x.CardsId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardFeature_Features_FeaturesId",
                        column: x => x.FeaturesId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardFeature_FeaturesId",
                table: "CardFeature",
                column: "FeaturesId");
        }
    }
}
