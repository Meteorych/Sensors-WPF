using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sensors_WPF__.NET_03._1_.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sensors",
                columns: table => new
                {
                    SensorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SensorType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeInterval = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensors", x => x.SensorId);
                });

            migrationBuilder.InsertData(
                table: "Sensors",
                columns: new[] { "SensorId", "SensorType", "TimeInterval" },
                values: new object[,]
                {
                    { new Guid("2e3e0618-291c-4226-8414-bdd8c6d5bfcc"), "Sensor №1", new TimeSpan(0, 0, 0, 5, 0) },
                    { new Guid("61311d52-f34a-465d-9f1e-93038e303aa3"), "Sensor №2", new TimeSpan(0, 0, 0, 2, 0) },
                    { new Guid("a7fb2d25-1b73-47e8-a890-0964d4d9a44c"), "Sensor №3", new TimeSpan(0, 0, 0, 4, 0) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sensors");
        }
    }
}
