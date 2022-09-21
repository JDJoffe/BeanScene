using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeanSceneAppV1.Data.Migrations
{
    public partial class justarea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Area_Id",
                table: "Table");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Area_Id",
                table: "Table",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
