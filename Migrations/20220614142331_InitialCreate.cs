using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventsFactory.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfPeopleRequired = table.Column<int>(type: "int", nullable: false),
                    Availability = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.EventId);
                });

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
                name: "EventParticipant",
                columns: table => new
                {
                    EventsEventId = table.Column<int>(type: "int", nullable: false),
                    ParticipantsParticipantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventParticipant", x => new { x.EventsEventId, x.ParticipantsParticipantId });
                    table.ForeignKey(
                        name: "FK_EventParticipant_Event_EventsEventId",
                        column: x => x.EventsEventId,
                        principalTable: "Event",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventParticipant_Participant_ParticipantsParticipantId",
                        column: x => x.ParticipantsParticipantId,
                        principalTable: "Participant",
                        principalColumn: "ParticipantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventParticipant_ParticipantsParticipantId",
                table: "EventParticipant",
                column: "ParticipantsParticipantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventParticipant");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Participant");
        }
    }
}
