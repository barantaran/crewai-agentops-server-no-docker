using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AgentopsServer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAgentopsServerSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    AgentId = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.AgentId);
                });

            migrationBuilder.CreateTable(
                name: "AgentSessions",
                columns: table => new
                {
                    AgentSessionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AgentId = table.Column<int>(type: "integer", nullable: false),
                    InitTimestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndTimestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndState = table.Column<string>(type: "text", nullable: true),
                    EndStateReason = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentSessions", x => x.AgentSessionId);
                });

            migrationBuilder.CreateTable(
                name: "EventReturns",
                columns: table => new
                {
                    EventReturnId = table.Column<string>(type: "text", nullable: false),
                    EventId = table.Column<int>(type: "integer", nullable: false),
                    Model = table.Column<string>(type: "text", nullable: true),
                    PromptTokens = table.Column<int>(type: "integer", nullable: false),
                    CompletionTokens = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventReturns", x => x.EventReturnId);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<Guid>(type: "uuid", nullable: false),
                    EventExtGuid = table.Column<string>(type: "text", nullable: true),
                    AgentExtGuid = table.Column<string>(type: "text", nullable: true),
                    EventType = table.Column<string>(type: "text", nullable: true),
                    InitTimestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndTimestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Model = table.Column<string>(type: "text", nullable: true),
                    PromptTokens = table.Column<int>(type: "integer", nullable: false),
                    CompletionTokens = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "Prompts",
                columns: table => new
                {
                    PromptId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Role = table.Column<string>(type: "text", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: true),
                    EventId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prompts", x => x.PromptId);
                    table.ForeignKey(
                        name: "FK_Prompts_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prompts_EventId",
                table: "Prompts",
                column: "EventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "AgentSessions");

            migrationBuilder.DropTable(
                name: "EventReturns");

            migrationBuilder.DropTable(
                name: "Prompts");

            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
