using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JacarandaCasaDeBrincar.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "jacaranda");

            migrationBuilder.CreateTable(
                name: "Addresses",
                schema: "jacaranda",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Street = table.Column<string>(type: "varchar(200)", nullable: false),
                    Complement = table.Column<string>(type: "varchar(150)", nullable: true),
                    Cep = table.Column<string>(type: "varchar(9)", nullable: false),
                    City = table.Column<string>(type: "varchar(150)", nullable: false),
                    State = table.Column<string>(type: "varchar(50)", nullable: false),
                    Neighborhood = table.Column<string>(type: "varchar(150)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Allergies",
                schema: "jacaranda",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Campaigns",
                schema: "jacaranda",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                schema: "jacaranda",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "varchar(250)", nullable: false),
                    PhoneOne = table.Column<string>(type: "varchar(14)", nullable: false),
                    PhoneTwo = table.Column<string>(type: "varchar(14)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactTypes",
                schema: "jacaranda",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                schema: "jacaranda",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Function = table.Column<string>(type: "varchar(100)", nullable: true),
                    Name = table.Column<string>(type: "varchar(250)", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(14)", nullable: true),
                    Rg = table.Column<string>(type: "varchar(12)", nullable: true),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodRestrictions",
                schema: "jacaranda",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodRestrictions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FrequencyPackages",
                schema: "jacaranda",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrequencyPackages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HowDidYouknows",
                schema: "jacaranda",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HowDidYouknows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                schema: "jacaranda",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BloodType = table.Column<string>(type: "varchar(3)", nullable: false),
                    Picture = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    Gender = table.Column<string>(type: "varchar(10)", nullable: false),
                    Name = table.Column<string>(type: "varchar(250)", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(14)", nullable: true),
                    Rg = table.Column<string>(type: "varchar(12)", nullable: true),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnauthorizedPeople",
                schema: "jacaranda",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnauthorizedPeople", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Guardians",
                schema: "jacaranda",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Kinship = table.Column<string>(type: "varchar(50)", nullable: false),
                    Occupation = table.Column<string>(type: "varchar(150)", nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(250)", nullable: true),
                    IsResponsable = table.Column<bool>(type: "bit", nullable: false),
                    ContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "varchar(250)", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(14)", nullable: false),
                    Rg = table.Column<string>(type: "varchar(12)", nullable: false),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guardians", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Guardians_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "jacaranda",
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Guardians_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalSchema: "jacaranda",
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InitialContacts",
                schema: "jacaranda",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsibleEmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ContactTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Informations = table.Column<string>(type: "varchar(500)", nullable: false),
                    DateAndHourFromContact = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InitialContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InitialContacts_ContactTypes_ContactTypeId",
                        column: x => x.ContactTypeId,
                        principalSchema: "jacaranda",
                        principalTable: "ContactTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InitialContacts_Employees_ResponsibleEmployeeId",
                        column: x => x.ResponsibleEmployeeId,
                        principalSchema: "jacaranda",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NextContacts",
                schema: "jacaranda",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsibleEmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ContactTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Informations = table.Column<string>(type: "varchar(500)", nullable: false),
                    DateAndHourFromContact = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NextContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NextContacts_ContactTypes_ContactTypeId",
                        column: x => x.ContactTypeId,
                        principalSchema: "jacaranda",
                        principalTable: "ContactTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NextContacts_Employees_ResponsibleEmployeeId",
                        column: x => x.ResponsibleEmployeeId,
                        principalSchema: "jacaranda",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AllergieStudent",
                schema: "jacaranda",
                columns: table => new
                {
                    AllergiesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllergieStudent", x => new { x.AllergiesId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_AllergieStudent_Allergies_AllergiesId",
                        column: x => x.AllergiesId,
                        principalSchema: "jacaranda",
                        principalTable: "Allergies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AllergieStudent_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalSchema: "jacaranda",
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FoodRestrictionStudent",
                schema: "jacaranda",
                columns: table => new
                {
                    FoodRestrictionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodRestrictionStudent", x => new { x.FoodRestrictionsId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_FoodRestrictionStudent_FoodRestrictions_FoodRestrictionsId",
                        column: x => x.FoodRestrictionsId,
                        principalSchema: "jacaranda",
                        principalTable: "FoodRestrictions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FoodRestrictionStudent_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalSchema: "jacaranda",
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentUnauthorizedPerson",
                schema: "jacaranda",
                columns: table => new
                {
                    StudentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnauthorizedPeopleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentUnauthorizedPerson", x => new { x.StudentsId, x.UnauthorizedPeopleId });
                    table.ForeignKey(
                        name: "FK_StudentUnauthorizedPerson_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalSchema: "jacaranda",
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentUnauthorizedPerson_UnauthorizedPeople_UnauthorizedPeopleId",
                        column: x => x.UnauthorizedPeopleId,
                        principalSchema: "jacaranda",
                        principalTable: "UnauthorizedPeople",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GuardianStudent",
                schema: "jacaranda",
                columns: table => new
                {
                    GuardiansId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuardianStudent", x => new { x.GuardiansId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_GuardianStudent_Guardians_GuardiansId",
                        column: x => x.GuardiansId,
                        principalSchema: "jacaranda",
                        principalTable: "Guardians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GuardianStudent_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalSchema: "jacaranda",
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Captures",
                schema: "jacaranda",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfCapture = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CampaignId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HowDidYouknowId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Period = table.Column<string>(type: "varchar(25)", nullable: false),
                    FrequencyPackageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InitialContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NextContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Captures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Captures_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalSchema: "jacaranda",
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Captures_FrequencyPackages_FrequencyPackageId",
                        column: x => x.FrequencyPackageId,
                        principalSchema: "jacaranda",
                        principalTable: "FrequencyPackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Captures_HowDidYouknows_HowDidYouknowId",
                        column: x => x.HowDidYouknowId,
                        principalSchema: "jacaranda",
                        principalTable: "HowDidYouknows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Captures_InitialContacts_InitialContactId",
                        column: x => x.InitialContactId,
                        principalSchema: "jacaranda",
                        principalTable: "InitialContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Captures_NextContacts_NextContactId",
                        column: x => x.NextContactId,
                        principalSchema: "jacaranda",
                        principalTable: "NextContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllergieStudent_StudentsId",
                schema: "jacaranda",
                table: "AllergieStudent",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Captures_CampaignId",
                schema: "jacaranda",
                table: "Captures",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Captures_FrequencyPackageId",
                schema: "jacaranda",
                table: "Captures",
                column: "FrequencyPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Captures_HowDidYouknowId",
                schema: "jacaranda",
                table: "Captures",
                column: "HowDidYouknowId");

            migrationBuilder.CreateIndex(
                name: "IX_Captures_InitialContactId",
                schema: "jacaranda",
                table: "Captures",
                column: "InitialContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Captures_NextContactId",
                schema: "jacaranda",
                table: "Captures",
                column: "NextContactId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodRestrictionStudent_StudentsId",
                schema: "jacaranda",
                table: "FoodRestrictionStudent",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Guardians_AddressId",
                schema: "jacaranda",
                table: "Guardians",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Guardians_ContactId",
                schema: "jacaranda",
                table: "Guardians",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_GuardianStudent_StudentsId",
                schema: "jacaranda",
                table: "GuardianStudent",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_InitialContacts_ContactTypeId",
                schema: "jacaranda",
                table: "InitialContacts",
                column: "ContactTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InitialContacts_ResponsibleEmployeeId",
                schema: "jacaranda",
                table: "InitialContacts",
                column: "ResponsibleEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_NextContacts_ContactTypeId",
                schema: "jacaranda",
                table: "NextContacts",
                column: "ContactTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_NextContacts_ResponsibleEmployeeId",
                schema: "jacaranda",
                table: "NextContacts",
                column: "ResponsibleEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentUnauthorizedPerson_UnauthorizedPeopleId",
                schema: "jacaranda",
                table: "StudentUnauthorizedPerson",
                column: "UnauthorizedPeopleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllergieStudent",
                schema: "jacaranda");

            migrationBuilder.DropTable(
                name: "Captures",
                schema: "jacaranda");

            migrationBuilder.DropTable(
                name: "FoodRestrictionStudent",
                schema: "jacaranda");

            migrationBuilder.DropTable(
                name: "GuardianStudent",
                schema: "jacaranda");

            migrationBuilder.DropTable(
                name: "StudentUnauthorizedPerson",
                schema: "jacaranda");

            migrationBuilder.DropTable(
                name: "Allergies",
                schema: "jacaranda");

            migrationBuilder.DropTable(
                name: "Campaigns",
                schema: "jacaranda");

            migrationBuilder.DropTable(
                name: "FrequencyPackages",
                schema: "jacaranda");

            migrationBuilder.DropTable(
                name: "HowDidYouknows",
                schema: "jacaranda");

            migrationBuilder.DropTable(
                name: "InitialContacts",
                schema: "jacaranda");

            migrationBuilder.DropTable(
                name: "NextContacts",
                schema: "jacaranda");

            migrationBuilder.DropTable(
                name: "FoodRestrictions",
                schema: "jacaranda");

            migrationBuilder.DropTable(
                name: "Guardians",
                schema: "jacaranda");

            migrationBuilder.DropTable(
                name: "Students",
                schema: "jacaranda");

            migrationBuilder.DropTable(
                name: "UnauthorizedPeople",
                schema: "jacaranda");

            migrationBuilder.DropTable(
                name: "ContactTypes",
                schema: "jacaranda");

            migrationBuilder.DropTable(
                name: "Employees",
                schema: "jacaranda");

            migrationBuilder.DropTable(
                name: "Addresses",
                schema: "jacaranda");

            migrationBuilder.DropTable(
                name: "Contacts",
                schema: "jacaranda");
        }
    }
}
