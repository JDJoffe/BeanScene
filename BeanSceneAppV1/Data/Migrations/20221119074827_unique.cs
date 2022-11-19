using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeanSceneAppV1.Migrations
{
    public partial class unique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TableReservation_TableId",
                table: "TableReservation");

            migrationBuilder.CreateIndex(
                name: "IX_TableReservation_TableId_ReservationId",
                table: "TableReservation",
                columns: new[] { "TableId", "ReservationId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TableReservation_TableId_ReservationId",
                table: "TableReservation");

            migrationBuilder.CreateIndex(
                name: "IX_TableReservation_TableId",
                table: "TableReservation",
                column: "TableId");
        }
    }
}
