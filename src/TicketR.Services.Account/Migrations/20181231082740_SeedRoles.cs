using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketR.Services.Account.Migrations
{
    public partial class SeedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c558f36a-c96d-4c32-9ec1-c2d95494e4ee", "1b3fd9dd-2aed-43d7-a2c2-97b99d81bc40", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8ce8a703-dc45-44f2-94d6-6936f49976f0", "c827268e-004e-4acb-9a95-45f6bdfb5120", "Organiser", "ORGANISER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e59c0134-ddad-4135-bb48-22f685368b33", "4de03189-b5b1-4b0f-9904-2ceb8dd214ed", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "8ce8a703-dc45-44f2-94d6-6936f49976f0", "c827268e-004e-4acb-9a95-45f6bdfb5120" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "c558f36a-c96d-4c32-9ec1-c2d95494e4ee", "1b3fd9dd-2aed-43d7-a2c2-97b99d81bc40" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "e59c0134-ddad-4135-bb48-22f685368b33", "4de03189-b5b1-4b0f-9904-2ceb8dd214ed" });
        }
    }
}
