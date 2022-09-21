using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeanSceneAppV1.Data.Migrations
{
    public partial class appdbcontextv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "First_Name",
                table: "AspNetUsers",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Last_Name",
                table: "AspNetUsers",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    Area_Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.Area_Name);
                });

            migrationBuilder.CreateTable(
                name: "Table",
                columns: table => new
                {
                    Table_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Table_Seats = table.Column<int>(type: "int", nullable: false),
                    Area_Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table", x => x.Table_Id);
                    table.ForeignKey(
                        name: "FK_Table_Area_Area_Name",
                        column: x => x.Area_Name,
                        principalTable: "Area",
                        principalColumn: "Area_Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Table_Area_Name",
                table: "Table",
                column: "Area_Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Table");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropColumn(
                name: "First_Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Last_Name",
                table: "AspNetUsers");
        }
    }
}
