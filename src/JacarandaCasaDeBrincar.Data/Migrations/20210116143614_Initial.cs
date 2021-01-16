using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JacarandaCasaDeBrincar.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "jacaranda");

            migrationBuilder.CreateTable(
                name: "Guardians",
                schema: "jacaranda",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(14)", nullable: false),
                    Rg = table.Column<string>(type: "varchar(12)", nullable: false),
                    Kinship = table.Column<string>(type: "varchar(50)", nullable: false),
                    Occupation = table.Column<string>(type: "varchar(150)", nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(250)", nullable: true),
                    Name = table.Column<string>(type: "varchar(250)", nullable: false),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guardians", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Guardians",
                schema: "jacaranda");
        }
    }
}
