using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DDD_Example.Customer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    Address_City = table.Column<string>(type: "text", nullable: false),
                    Address_Country = table.Column<string>(type: "text", nullable: false),
                    Address_Street = table.Column<string>(type: "text", nullable: false),
                    BirthDate_Value = table.Column<DateOnly>(type: "date", nullable: false),
                    Mail_Value = table.Column<string>(type: "text", nullable: false),
                    Name_FirstName = table.Column<string>(type: "text", nullable: false),
                    Name_LastName = table.Column<string>(type: "text", nullable: false),
                    Phone_CountryCode = table.Column<string>(type: "text", nullable: false),
                    Phone_Number = table.Column<string>(type: "text", nullable: false),
                    Status_IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Status_LicenceStatus_IsApproved = table.Column<bool>(type: "boolean", nullable: false),
                    Status_LicenceStatus_UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status_MailStatus_IsApproved = table.Column<bool>(type: "boolean", nullable: false),
                    Status_MailStatus_UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
