using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpaceProgram.Migrations
{
    public partial class UpdateReference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "object_id",
                table: "spaceSystem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "object_id",
                table: "spaceSystem",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
