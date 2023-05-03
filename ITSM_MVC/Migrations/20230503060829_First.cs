using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITSM_MVC.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GPlex",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    start_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    stop_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    caller_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    did = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ivr_enter_time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ivr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    time_in_ivr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ivr_language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    skill_enter_time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    skill = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hold_in_queue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    agent_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nick_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    service_time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    total_time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    missed_call = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    disc_party = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    call_id = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GPlex", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "OTRS",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ticket_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    closed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    firstLock = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    firstResponse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    priority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    queue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    locks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    owner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userFirstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userLastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customerID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customer_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    from = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    accountedTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    articleTree = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    solutionInMin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    solutionDiffInMin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    firstResponseInMin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    firstResponseDiffInMin = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OTRS", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GPlex");

            migrationBuilder.DropTable(
                name: "OTRS");
        }
    }
}
