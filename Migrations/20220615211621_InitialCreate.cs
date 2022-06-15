using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventsFactory.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Participant",
                columns: table => new
                {
                    ParticipantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participant", x => x.ParticipantId);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfPeopleRequired = table.Column<int>(type: "int", nullable: false),
                    Availability = table.Column<int>(type: "int", nullable: true),
                    ParticipantId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Event_Participant_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "Participant",
                        principalColumn: "ParticipantId");
                });

            migrationBuilder.CreateTable(
                name: "ParticipantAssignment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    ParticipantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantAssignment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParticipantAssignment_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParticipantAssignment_Participant_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "Participant",
                        principalColumn: "ParticipantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Event_ParticipantId",
                table: "Event",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantAssignment_EventId",
                table: "ParticipantAssignment",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantAssignment_ParticipantId",
                table: "ParticipantAssignment",
                column: "ParticipantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParticipantAssignment");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Participant");
        }
    }
}
