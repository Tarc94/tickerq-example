using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchedulerEF.Migrations
{
    /// <inheritdoc />
    public partial class AddJobExceptionLogTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobExceptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TickerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TickerType = table.Column<int>(type: "int", nullable: false),
                    ExceptionMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobExceptions", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobExceptions");
        }
    }
}
