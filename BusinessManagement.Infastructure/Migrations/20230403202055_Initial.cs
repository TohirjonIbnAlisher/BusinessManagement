using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessManagement.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Country = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Region = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    District = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Street = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PostalCode = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Salt = table.Column<string>(type: "text", nullable: false),
                    RefreshToken = table.Column<string>(type: "text", nullable: true),
                    ExpiredRefreshToken = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Roles = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LegalPersons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    INN = table.Column<long>(type: "bigint", nullable: false),
                    IndustryType = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LegalEntityType = table.Column<int>(type: "integer", nullable: false),
                    AddressId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalPersons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LegalPersons_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    JobPosition = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    EmploymentType = table.Column<int>(type: "integer", nullable: false),
                    Salary = table.Column<decimal>(type: "numeric", nullable: false),
                    TellNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    LegalPersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    AddressId = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Salt = table.Column<string>(type: "text", nullable: false),
                    RefreshToken = table.Column<string>(type: "text", nullable: true),
                    ExpiredRefreshToken = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Roles = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_LegalPersons_LegalPersonId",
                        column: x => x.LegalPersonId,
                        principalTable: "LegalPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "ExpiredRefreshToken", "PasswordHash", "RefreshToken", "Roles", "Salt" },
                values: new object[] { new Guid("0d9c9d0a-47b3-4be2-966c-6fbea330eff9"), "tohirjon@gmail.com", null, "", null, 1, "a9feaa2d-8692-4d2e-bf64-3d8200ad8c8b" });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AddressId",
                table: "Employees",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_LegalPersonId",
                table: "Employees",
                column: "LegalPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalPersons_AddressId",
                table: "LegalPersons",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LegalPersons_INN",
                table: "LegalPersons",
                column: "INN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "LegalPersons");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
