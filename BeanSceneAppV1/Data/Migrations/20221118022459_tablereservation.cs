using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeanSceneAppV1.Migrations
{
    public partial class tablereservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "TableAvailability");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "AreaAvailability");

            migrationBuilder.CreateTable(
                name: "TableReservation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableId = table.Column<int>(type: "int", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableReservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TableReservation_Reservation_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TableReservation_Table_TableId",
                        column: x => x.TableId,
                        principalTable: "Table",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TableReservation_ReservationId",
                table: "TableReservation",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_TableReservation_TableId",
                table: "TableReservation",
                column: "TableId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TableReservation");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "TableAvailability",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "AreaAvailability",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
