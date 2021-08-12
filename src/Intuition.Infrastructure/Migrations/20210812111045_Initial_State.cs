using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Intuition.Infrastructures.Migrations
{
    public partial class Initial_State : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Reference");

            migrationBuilder.CreateTable(
                name: "AppTimeZones",
                schema: "Reference",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    DisplayName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "The general display name that represents the time zone."),
                    StandartName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "The display name for the time zone's standard time."),
                    BaseUtcOffsetHours = table.Column<int>(type: "integer", nullable: false, comment: "The minutes component of the time interval."),
                    BaseUtcOffsetMinutes = table.Column<int>(type: "integer", nullable: false, comment: "The minutes component of the time interval."),
                    BaseUtcOffsetSeconds = table.Column<int>(type: "integer", nullable: false, comment: "The seconds component of the time interval.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppTimeZones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                schema: "Reference",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    DisplayName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                schema: "Reference",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    DisplayName = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppTimeZones",
                schema: "Reference");

            migrationBuilder.DropTable(
                name: "Genders",
                schema: "Reference");

            migrationBuilder.DropTable(
                name: "Languages",
                schema: "Reference");
        }
    }
}
