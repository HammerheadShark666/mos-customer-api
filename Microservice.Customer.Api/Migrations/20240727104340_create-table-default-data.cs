using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Microservice.Customer.Api.Migrations
{
    /// <inheritdoc />
    public partial class createtabledefaultdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MSOS_Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MSOS_Customer", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "MSOS_Customer",
                columns: new[] { "Id", "Created", "Email", "FirstName", "LastUpdated", "Surname" },
                values: new object[,]
                {
                    { new Guid("6c84d0a3-0c0c-435f-9ae0-4de09247ee15"), new DateTime(2024, 7, 27, 11, 43, 40, 6, DateTimeKind.Local).AddTicks(4536), "intergration-test-user@example.com", "Intergration_Test", new DateTime(2024, 7, 27, 11, 43, 40, 6, DateTimeKind.Local).AddTicks(4581), "Intergration_Test" },
                    { new Guid("929eaf82-e4fd-4efe-9cae-ce4d7e32d159"), new DateTime(2024, 7, 27, 11, 43, 40, 6, DateTimeKind.Local).AddTicks(4592), "intergration-test-user2@example.com", "Intergration_Test2", new DateTime(2024, 7, 27, 11, 43, 40, 6, DateTimeKind.Local).AddTicks(4594), "Intergration_Test2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MSOS_Customer");
        }
    }
}
