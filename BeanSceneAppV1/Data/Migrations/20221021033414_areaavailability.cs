using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeanSceneAppV1.Data.Migrations
{
    public partial class areaavailability : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AreaAvailability",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeSlotId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaAvailability", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AreaAvailability_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AreaAvailability_TimeSlot_TimeSlotId",
                        column: x => x.TimeSlotId,
                        principalTable: "TimeSlot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableAvailability",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeSlotId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableAvailability", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TableAvailability_Table_TableId",
                        column: x => x.TableId,
                        principalTable: "Table",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TableAvailability_TimeSlot_TimeSlotId",
                        column: x => x.TimeSlotId,
                        principalTable: "TimeSlot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AreaAvailability_AreaId",
                table: "AreaAvailability",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_AreaAvailability_Date_TimeSlotId",
                table: "AreaAvailability",
                columns: new[] { "Date", "TimeSlotId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AreaAvailability_TimeSlotId",
                table: "AreaAvailability",
                column: "TimeSlotId");

            migrationBuilder.CreateIndex(
                name: "IX_TableAvailability_Date_TimeSlotId",
                table: "TableAvailability",
                columns: new[] { "Date", "TimeSlotId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TableAvailability_TableId",
                table: "TableAvailability",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_TableAvailability_TimeSlotId",
                table: "TableAvailability",
                column: "TimeSlotId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AreaAvailability");

            migrationBuilder.DropTable(
                name: "TableAvailability");
        }
    }
}
