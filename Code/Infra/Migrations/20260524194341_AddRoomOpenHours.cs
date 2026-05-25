using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gym.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddRoomOpenHours : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RoomBookings_BookingId",
                table: "RoomBookings");

            migrationBuilder.AddColumn<TimeOnly>(
                name: "OpenFrom",
                table: "Rooms",
                type: "TEXT",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "OpenTo",
                table: "Rooms",
                type: "TEXT",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.CreateIndex(
                name: "IX_RoomBookings_BookingId",
                table: "RoomBookings",
                column: "BookingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RoomBookings_BookingId",
                table: "RoomBookings");

            migrationBuilder.DropColumn(
                name: "OpenFrom",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "OpenTo",
                table: "Rooms");

            migrationBuilder.CreateIndex(
                name: "IX_RoomBookings_BookingId",
                table: "RoomBookings",
                column: "BookingId",
                unique: true);
        }
    }
}
