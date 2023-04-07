using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DroneEntity.Migrations
{
    public partial class createDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DroneEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<string>(maxLength: 100, nullable: true),
                    Model = table.Column<string>(nullable: true),
                    WeightLimit = table.Column<double>(nullable: true),
                    BatteryCapasity = table.Column<double>(nullable: true),
                    State = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DroneEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicationEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Weight = table.Column<double>(nullable: true),
                    code = table.Column<double>(nullable: true),
                    image = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DroneMedications",
                columns: table => new
                {
                    DroneId = table.Column<int>(nullable: false),
                    MedicationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DroneMedications", x => new { x.DroneId, x.MedicationId });
                    table.ForeignKey(
                        name: "FK_DroneMedications_DroneEntity_DroneId",
                        column: x => x.DroneId,
                        principalTable: "DroneEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DroneMedications_MedicationEntity_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "MedicationEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DroneMedications_MedicationId",
                table: "DroneMedications",
                column: "MedicationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DroneMedications");

            migrationBuilder.DropTable(
                name: "DroneEntity");

            migrationBuilder.DropTable(
                name: "MedicationEntity");
        }
    }
}
