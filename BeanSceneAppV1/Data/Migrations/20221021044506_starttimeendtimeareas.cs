using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeanSceneAppV1.Data.Migrations
{
    public partial class starttimeendtimeareas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AreaAvailability_TimeSlot_TimeSlotId",
                table: "AreaAvailability");

            migrationBuilder.DropIndex(
                name: "IX_AreaAvailability_Date_TimeSlotId",
                table: "AreaAvailability");

            migrationBuilder.DropIndex(
                name: "IX_AreaAvailability_TimeSlotId",
                table: "AreaAvailability");

            migrationBuilder.DropColumn(
                name: "TimeSlotId",
                table: "AreaAvailability");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "End_Time",
                table: "AreaAvailability",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Start_Time",
                table: "AreaAvailability",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "End_Time",
                table: "AreaAvailability");

            migrationBuilder.DropColumn(
                name: "Start_Time",
                table: "AreaAvailability");

            migrationBuilder.AddColumn<int>(
                name: "TimeSlotId",
                table: "AreaAvailability",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AreaAvailability_Date_TimeSlotId",
                table: "AreaAvailability",
                columns: new[] { "Date", "TimeSlotId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AreaAvailability_TimeSlotId",
                table: "AreaAvailability",
                column: "TimeSlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_AreaAvailability_TimeSlot_TimeSlotId",
                table: "AreaAvailability",
                column: "TimeSlotId",
                principalTable: "TimeSlot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
