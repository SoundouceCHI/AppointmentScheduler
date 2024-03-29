﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Appointment_Scheduler.Migrations
{
    /// <inheritdoc />
    public partial class AddIdUserToAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Users_UserAppId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_UserAppId",
                table: "Appointments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Appointments_UserAppId",
                table: "Appointments",
                column: "UserAppId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Users_UserAppId",
                table: "Appointments",
                column: "UserAppId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
