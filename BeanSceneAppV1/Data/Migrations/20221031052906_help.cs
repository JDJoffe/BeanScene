using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeanSceneAppV1.Data.Migrations
{
    public partial class help : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TableAvailability_Date_TimeSlotId",
                table: "TableAvailability");

            migrationBuilder.DropIndex(
                name: "IX_TableAvailability_TableId",
                table: "TableAvailability");

            migrationBuilder.CreateIndex(
                name: "IX_TableAvailability_TableId_Date_TimeSlotId",
                table: "TableAvailability",
                columns: new[] { "TableId", "Date", "TimeSlotId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TableAvailability_TableId_Date_TimeSlotId",
                table: "TableAvailability");

            migrationBuilder.CreateIndex(
                name: "IX_TableAvailability_Date_TimeSlotId",
                table: "TableAvailability",
                columns: new[] { "Date", "TimeSlotId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TableAvailability_TableId",
                table: "TableAvailability",
                column: "TableId");
        }
    }
}
