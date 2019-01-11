using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketR.Services.Account.Infrastructure.Migrations
{
    public partial class rolesFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c100691f-2893-4cb7-86a8-e1347479da4e", "c46f63d2-a271-4afa-b4f0-08844c56f15d", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b79926e0-fcc2-4ca7-a04b-bdec992773f6", "d1a8c93c-0da2-43e0-a64a-f7cdbb2a4010", "Organiser", "ORGANISER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2aaefccc-0528-4ec6-965d-1458dfe55fb1", "ed132580-982a-4af2-b620-9f6e12f1f71e", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "2aaefccc-0528-4ec6-965d-1458dfe55fb1", "ed132580-982a-4af2-b620-9f6e12f1f71e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "b79926e0-fcc2-4ca7-a04b-bdec992773f6", "d1a8c93c-0da2-43e0-a64a-f7cdbb2a4010" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "c100691f-2893-4cb7-86a8-e1347479da4e", "c46f63d2-a271-4afa-b4f0-08844c56f15d" });

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
    }
}
