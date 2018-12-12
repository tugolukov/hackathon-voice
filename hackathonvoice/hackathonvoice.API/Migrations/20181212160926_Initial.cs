using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace hackathonvoice.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientGuid = table.Column<Guid>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    Poliсy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientGuid);
                });

            migrationBuilder.CreateTable(
                name: "Visits",
                columns: table => new
                {
                    VisitGuid = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Diagnoses = table.Column<string>(nullable: true),
                    Recipe = table.Column<string>(nullable: true),
                    PatientGuid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visits", x => x.VisitGuid);
                    table.ForeignKey(
                        name: "FK_Visits_Patients_PatientGuid",
                        column: x => x.PatientGuid,
                        principalTable: "Patients",
                        principalColumn: "PatientGuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visits_PatientGuid",
                table: "Visits",
                column: "PatientGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Visits");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
