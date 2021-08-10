using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Intuition.Infrastructures.Migrations.Reference
{
    public partial class Initial : Migration
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
                    Id = table.Column<string>(type: "text", nullable: false),
                    DisplayName = table.Column<string>(type: "text", nullable: true),
                    StandartName = table.Column<string>(type: "text", nullable: true),
                    BaseUtcOffsetHours = table.Column<int>(type: "integer", nullable: false),
                    BaseUtcOffsetMinutes = table.Column<int>(type: "integer", nullable: false),
                    BaseUtcOffsetSeconds = table.Column<int>(type: "integer", nullable: false)
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
                    Name = table.Column<string>(type: "text", nullable: true),
                    DisplayName = table.Column<string>(type: "text", nullable: true)
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
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    DisplayName = table.Column<string>(type: "text", nullable: true)
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
