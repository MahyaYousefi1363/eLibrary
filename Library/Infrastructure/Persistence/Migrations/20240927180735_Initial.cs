using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eLibrary.Library.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "eLibrary");

            migrationBuilder.CreateTable(
                name: "Books",
                schema: "eLibrary",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Isbn = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Place = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Count = table.Column<decimal>(type: "decimal(8,0)", precision: 8, scale: 0, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                schema: "eLibrary",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NationalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rents",
                schema: "eLibrary",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MemberNationalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    BookIsbn = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    RentDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ReturnDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsReturned = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rents", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books",
                schema: "eLibrary");

            migrationBuilder.DropTable(
                name: "Members",
                schema: "eLibrary");

            migrationBuilder.DropTable(
                name: "Rents",
                schema: "eLibrary");
        }
    }
}
