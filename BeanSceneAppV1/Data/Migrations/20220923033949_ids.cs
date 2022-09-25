using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeanSceneAppV1.Data.Migrations
{
    public partial class ids : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Table_Area_Area_Name",
                table: "Table");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Table",
                table: "Table");

            migrationBuilder.DropIndex(
                name: "IX_Table_Area_Name",
                table: "Table");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Area",
                table: "Area");

            migrationBuilder.DropColumn(
                name: "Table_Id",
                table: "Table");

            migrationBuilder.DropColumn(
                name: "Area_Name",
                table: "Table");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Table",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "AreaId",
                table: "Table",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Area_Id",
                table: "Table",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Table_Name",
                table: "Table",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Area_Name",
                table: "Area",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Area",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Table",
                table: "Table",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Area",
                table: "Area",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Table_AreaId",
                table: "Table",
                column: "AreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Table_Area_AreaId",
                table: "Table",
                column: "AreaId",
                principalTable: "Area",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Table_Area_AreaId",
                table: "Table");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Table",
                table: "Table");

            migrationBuilder.DropIndex(
                name: "IX_Table_AreaId",
                table: "Table");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Area",
                table: "Area");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Table");

            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "Table");

            migrationBuilder.DropColumn(
                name: "Area_Id",
                table: "Table");

            migrationBuilder.DropColumn(
                name: "Table_Name",
                table: "Table");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Area");

            migrationBuilder.AddColumn<string>(
                name: "Table_Id",
                table: "Table",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Area_Name",
                table: "Table",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Area_Name",
                table: "Area",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Table",
                table: "Table",
                column: "Table_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Area",
                table: "Area",
                column: "Area_Name");

            migrationBuilder.CreateIndex(
                name: "IX_Table_Area_Name",
                table: "Table",
                column: "Area_Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Table_Area_Area_Name",
                table: "Table",
                column: "Area_Name",
                principalTable: "Area",
                principalColumn: "Area_Name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
