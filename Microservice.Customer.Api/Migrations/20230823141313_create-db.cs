using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Microservice.Customer.Migrations
{
    /// <inheritdoc />
    public partial class createdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "Email", "FirstName", "Surname" },
                values: new object[,]
                {
                    { new Guid("2385de72-2302-4ced-866a-fa199116ca6e"), "smateal@hotmail.com", "Sam", "Mateal" },
                    { new Guid("47417642-87d9-4047-ae13-4c721d99ab48"), "tabertson@hotmail.com", "Tanya", "Abertson" },
                    { new Guid("55b431ff-693e-4664-8f65-cfd8d0b14b1b"), "pmohammed@hotmail.com", "Mohammed", "Patel" },
                    { new Guid("5ff79dfe-c1fa-4dd9-996f-bc96649d6dfc"), "borton@hotmail.com", "Beth", "Orton" },
                    { new Guid("aa1dc96f-3be5-41cd-8a1b-207284af3fdd"), "jhopkins@hotmail.com", "Jane", "Hopkins" },
                    { new Guid("ae55b0d1-ba02-41e1-9efa-9b4d4ac15eec"), "tamos@hotmail.com", "Tori", "Amos" },
                    { new Guid("af95fb7e-8d97-4892-8da3-5e6e51c54044"), "jarthur@hotmail.com", "Arthur", "James" },
                    { new Guid("c95ba8ff-06a1-49d0-bc45-83f89b3ce820"), "jpage@hotmail.com", "James", "Page" },
                    { new Guid("f07e88ac-53b2-4def-af07-957cbb18523c"), "josbourne@hotmail.com", "John", "Osbourne" },
                    { new Guid("ff4d5a80-81e3-42e3-8052-92cf5c51e797"), "stansor@hotmail.com", "Steven", "Tansor" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
