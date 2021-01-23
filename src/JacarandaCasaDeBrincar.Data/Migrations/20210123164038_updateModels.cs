using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JacarandaCasaDeBrincar.Data.Migrations
{
    public partial class updateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                schema: "jacaranda",
                table: "Guardians");

            migrationBuilder.DropColumn(
                name: "Phone",
                schema: "jacaranda",
                table: "Guardians");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Students",
                newSchema: "jacaranda");

            migrationBuilder.RenameTable(
                name: "GuardianStudent",
                newName: "GuardianStudent",
                newSchema: "jacaranda");

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                schema: "jacaranda",
                table: "Guardians",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ContactId",
                schema: "jacaranda",
                table: "Guardians",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsResponsable",
                schema: "jacaranda",
                table: "Guardians",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                schema: "jacaranda",
                table: "Students",
                type: "varchar(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "jacaranda",
                table: "Students",
                type: "varchar(250)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                schema: "jacaranda",
                table: "Students",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BloodType",
                schema: "jacaranda",
                table: "Students",
                type: "varchar(3)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                schema: "jacaranda",
                table: "Students",
                type: "varchar(14)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rg",
                schema: "jacaranda",
                table: "Students",
                type: "varchar(12)",
                nullable: true);

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
                    Name = table.Column<string>(type: "varchar(250)", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Allergies_Students_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "jacaranda",
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_Allergies_StudentId",
                schema: "jacaranda",
                table: "Allergies",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Guardians_Addresses_AddressId",
                schema: "jacaranda",
                table: "Guardians",
                column: "AddressId",
                principalSchema: "jacaranda",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Guardians_Contacts_ContactId",
                schema: "jacaranda",
                table: "Guardians",
                column: "ContactId",
                principalSchema: "jacaranda",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guardians_Addresses_AddressId",
                schema: "jacaranda",
                table: "Guardians");

            migrationBuilder.DropForeignKey(
                name: "FK_Guardians_Contacts_ContactId",
                schema: "jacaranda",
                table: "Guardians");

            migrationBuilder.DropTable(
                name: "Addresses",
                schema: "jacaranda");

            migrationBuilder.DropTable(
                name: "Allergies",
                schema: "jacaranda");

            migrationBuilder.DropTable(
                name: "Contacts",
                schema: "jacaranda");

            migrationBuilder.DropIndex(
                name: "IX_Guardians_AddressId",
                schema: "jacaranda",
                table: "Guardians");

            migrationBuilder.DropIndex(
                name: "IX_Guardians_ContactId",
                schema: "jacaranda",
                table: "Guardians");

            migrationBuilder.DropColumn(
                name: "AddressId",
                schema: "jacaranda",
                table: "Guardians");

            migrationBuilder.DropColumn(
                name: "ContactId",
                schema: "jacaranda",
                table: "Guardians");

            migrationBuilder.DropColumn(
                name: "IsResponsable",
                schema: "jacaranda",
                table: "Guardians");

            migrationBuilder.DropColumn(
                name: "Cpf",
                schema: "jacaranda",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Rg",
                schema: "jacaranda",
                table: "Students");

            migrationBuilder.RenameTable(
                name: "Students",
                schema: "jacaranda",
                newName: "Students");

            migrationBuilder.RenameTable(
                name: "GuardianStudent",
                schema: "jacaranda",
                newName: "GuardianStudent");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "jacaranda",
                table: "Guardians",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                schema: "jacaranda",
                table: "Guardians",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(MAX)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(250)");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(10)");

            migrationBuilder.AlterColumn<string>(
                name: "BloodType",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(3)");
        }
    }
}
