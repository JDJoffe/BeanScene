using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeanSceneAppV1.Migrations
{
    public partial class tableavailabilityreservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TableAvailabilityReservation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableAvailabilityId = table.Column<int>(type: "int", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableAvailabilityReservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TableAvailabilityReservation_Reservation_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TableAvailabilityReservation_TableAvailability_TableAvailabilityId",
                        column: x => x.TableAvailabilityId,
                        principalTable: "TableAvailability",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TableAvailabilityReservation_ReservationId",
                table: "TableAvailabilityReservation",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_TableAvailabilityReservation_TableAvailabilityId",
                table: "TableAvailabilityReservation",
                column: "TableAvailabilityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TableAvailabilityReservation");
        }
    }
}
