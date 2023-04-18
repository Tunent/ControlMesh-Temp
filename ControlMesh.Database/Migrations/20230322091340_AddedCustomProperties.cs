using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlMesh.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddedCustomProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MessageCustomProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndPoint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageForeignKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageCustomProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageCustomProperties_Messages_MessageForeignKey",
                        column: x => x.MessageForeignKey,
                        principalTable: "Messages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MessageSystemProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessagePropertyId = table.Column<int>(type: "int", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorrelationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeadLetterErrorDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeadLetterReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeadLetterSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryCount = table.Column<int>(type: "int", nullable: false),
                    EnqueuedSequenceNumber = table.Column<long>(type: "bigint", nullable: false),
                    EnqueuedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ExpiresAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LockedUntil = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LockToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartitionKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReplyTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReplyToSessionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScheduledEnqueueTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    SequenceNumber = table.Column<long>(type: "bigint", nullable: false),
                    SessionsId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeToLive = table.Column<TimeSpan>(type: "time", nullable: false),
                    To = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionPartitionKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageForeignKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageSystemProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageSystemProperties_Messages_MessageForeignKey",
                        column: x => x.MessageForeignKey,
                        principalTable: "Messages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MessageCustomProperties_MessageForeignKey",
                table: "MessageCustomProperties",
                column: "MessageForeignKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MessageSystemProperties_MessageForeignKey",
                table: "MessageSystemProperties",
                column: "MessageForeignKey",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MessageCustomProperties");

            migrationBuilder.DropTable(
                name: "MessageSystemProperties");

            migrationBuilder.DropTable(
                name: "Messages");
        }
    }
}
