using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gym.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddContactMethod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartyRole_Memberships_MembershipId",
                table: "PartyRole");

            migrationBuilder.AddColumn<Guid>(
                name: "MemberId",
                table: "Memberships",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<decimal>(
                name: "PricePaid",
                table: "Memberships",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Memberships",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ContactMethods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: false),
                    PersonId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Timestamp = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true),
                    ValidFrom = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactMethods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactMethods_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MembershipType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DurationDays = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true),
                    ValidFrom = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactMethods_PersonId",
                table: "ContactMethods",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_PartyRole_MembershipType_MembershipId",
                table: "PartyRole",
                column: "MembershipId",
                principalTable: "MembershipType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartyRole_MembershipType_MembershipId",
                table: "PartyRole");

            migrationBuilder.DropTable(
                name: "ContactMethods");

            migrationBuilder.DropTable(
                name: "MembershipType");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Memberships");

            migrationBuilder.DropColumn(
                name: "PricePaid",
                table: "Memberships");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Memberships");

            migrationBuilder.AddForeignKey(
                name: "FK_PartyRole_Memberships_MembershipId",
                table: "PartyRole",
                column: "MembershipId",
                principalTable: "Memberships",
                principalColumn: "Id");
        }
    }
}
