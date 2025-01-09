using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DDD_Example.Vehicle.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Brand_Value = table.Column<string>(type: "text", nullable: false),
                    Color_Code = table.Column<string>(type: "text", nullable: false),
                    Color_Name = table.Column<string>(type: "text", nullable: false),
                    Mileage_Value = table.Column<int>(type: "integer", nullable: false),
                    Plate_Value = table.Column<string>(type: "text", nullable: false),
                    Price_Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Price_Currency = table.Column<int>(type: "integer", nullable: false),
                    Type_Value = table.Column<string>(type: "text", nullable: false),
                    Year_Value = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
