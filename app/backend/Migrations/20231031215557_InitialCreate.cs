using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreditDataSet",
                columns: table => new
                {
                    SocialSecurityNumber = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    AssessedIncome = table.Column<int>(type: "INTEGER", nullable: false),
                    DebtBalance = table.Column<int>(type: "INTEGER", nullable: false),
                    Complaints = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAtTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CacheLimit = table.Column<TimeSpan>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditDataSet", x => x.SocialSecurityNumber);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditDataSet");
        }
    }
}
