using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeanSceneAppV1.Data.Migrations
{
    public partial class nameofarea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NameOf_Area",
                table: "Table",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameOf_Area",
                table: "Table");
        }
    }
}
