using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpaceProgram.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_spaceSystem_spaceObject_SpaceObjectid",
                table: "spaceSystem");

            migrationBuilder.DropIndex(
                name: "IX_spaceSystem_SpaceObjectid",
                table: "spaceSystem");

            migrationBuilder.DropColumn(
                name: "SpaceObjectid",
                table: "spaceSystem");

            migrationBuilder.AddColumn<int>(
                name: "SpaceSystemid",
                table: "spaceObject",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_spaceObject_SpaceSystemid",
                table: "spaceObject",
                column: "SpaceSystemid");

            migrationBuilder.AddForeignKey(
                name: "FK_spaceObject_spaceSystem_SpaceSystemid",
                table: "spaceObject",
                column: "SpaceSystemid",
                principalTable: "spaceSystem",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_spaceObject_spaceSystem_SpaceSystemid",
                table: "spaceObject");

            migrationBuilder.DropIndex(
                name: "IX_spaceObject_SpaceSystemid",
                table: "spaceObject");

            migrationBuilder.DropColumn(
                name: "SpaceSystemid",
                table: "spaceObject");

            migrationBuilder.AddColumn<int>(
                name: "SpaceObjectid",
                table: "spaceSystem",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_spaceSystem_SpaceObjectid",
                table: "spaceSystem",
                column: "SpaceObjectid");

            migrationBuilder.AddForeignKey(
                name: "FK_spaceSystem_spaceObject_SpaceObjectid",
                table: "spaceSystem",
                column: "SpaceObjectid",
                principalTable: "spaceObject",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
