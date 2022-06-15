using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventsFactory.Migrations
{
    public partial class AddParticipantAssignment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventParticipant");

            migrationBuilder.AddColumn<int>(
                name: "ParticipantId",
                table: "Event",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ParticipantAssignment",
                columns: table => new
                {
                    ParticipantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    ParticipantId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantAssignment", x => x.ParticipantId);
                    table.ForeignKey(
                        name: "FK_ParticipantAssignment_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParticipantAssignment_Participant_ParticipantId1",
                        column: x => x.ParticipantId1,
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
                name: "IX_ParticipantAssignment_ParticipantId1",
                table: "ParticipantAssignment",
                column: "ParticipantId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Participant_ParticipantId",
                table: "Event",
                column: "ParticipantId",
                principalTable: "Participant",
                principalColumn: "ParticipantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Participant_ParticipantId",
                table: "Event");

            migrationBuilder.DropTable(
                name: "ParticipantAssignment");

            migrationBuilder.DropIndex(
                name: "IX_Event_ParticipantId",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "ParticipantId",
                table: "Event");

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
    }
}
