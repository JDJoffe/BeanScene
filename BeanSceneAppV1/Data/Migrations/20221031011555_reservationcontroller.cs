using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeanSceneAppV1.Data.Migrations
{
    public partial class reservationcontroller : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeSlotId = table.Column<int>(type: "int", nullable: false),
                    SittingId = table.Column<int>(type: "int", nullable: false),
                    GuestAmmount = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeatingRequest = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservation_Sitting_SittingId",
                        column: x => x.SittingId,
                        principalTable: "Sitting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_TimeSlot_TimeSlotId",
                        column: x => x.TimeSlotId,
                        principalTable: "TimeSlot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_SittingId",
                table: "Reservation",
                column: "SittingId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_TimeSlotId",
                table: "Reservation",
                column: "TimeSlotId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservation");
        }
    }
}
