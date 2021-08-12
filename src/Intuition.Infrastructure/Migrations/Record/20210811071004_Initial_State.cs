using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Intuition.Infrastructures.Migrations.Record
{
    public partial class Initial_State : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.EnsureSchema(
                name: "Record");

            //migrationBuilder.CreateTable(
            //    name: "AppTimeZone",
            //    schema: "Identity",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "text", nullable: false),
            //        DisplayName = table.Column<string>(type: "text", nullable: true),
            //        StandartName = table.Column<string>(type: "text", nullable: true),
            //        BaseUtcOffsetHours = table.Column<int>(type: "integer", nullable: false),
            //        BaseUtcOffsetMinutes = table.Column<int>(type: "integer", nullable: false),
            //        BaseUtcOffsetSeconds = table.Column<int>(type: "integer", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AppTimeZone", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Gender",
            //    schema: "Identity",
            //    columns: table => new
            //    {
            //        Id = table.Column<short>(type: "smallint", nullable: false)
            //            .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            //        Name = table.Column<string>(type: "text", nullable: true),
            //        DisplayName = table.Column<string>(type: "text", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Gender", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Language",
            //    schema: "Identity",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "text", nullable: false),
            //        Name = table.Column<string>(type: "text", nullable: true),
            //        DisplayName = table.Column<string>(type: "text", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Language", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UserStatus",
            //    schema: "Identity",
            //    columns: table => new
            //    {
            //        Id = table.Column<short>(type: "smallint", nullable: false)
            //            .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            //        Description = table.Column<string>(type: "text", nullable: true),
            //        Name = table.Column<string>(type: "text", nullable: true),
            //        DisplayName = table.Column<string>(type: "text", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UserStatus", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AppUsers",
            //    schema: "Identity",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "uuid", nullable: false),
            //        StatusId = table.Column<short>(type: "smallint", nullable: false),
            //        CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
            //        LastSignedInOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
            //        ReservedPhoneNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
            //        UserName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
            //        NormalizedUserName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
            //        Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
            //        NormalizedEmail = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
            //        EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
            //        PasswordHash = table.Column<string>(type: "text", nullable: true),
            //        SecurityStamp = table.Column<string>(type: "text", nullable: true),
            //        ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
            //        PhoneNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
            //        PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
            //        TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
            //        LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
            //        LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
            //        AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AppUsers", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AppUsers_UserStatus_StatusId",
            //            column: x => x.StatusId,
            //            principalSchema: "Identity",
            //            principalTable: "UserStatus",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            migrationBuilder.CreateTable(
                name: "Records",
                schema: "Record",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Data = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Records_AppUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.CreateTable(
            //    name: "UserProfiles",
            //    schema: "Identity",
            //    columns: table => new
            //    {
            //        UserId = table.Column<Guid>(type: "uuid", nullable: false),
            //        FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
            //        LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
            //        BirthDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
            //        LogoUrl = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
            //        GenderId = table.Column<short>(type: "smallint", nullable: true),
            //        Id = table.Column<Guid>(type: "uuid", nullable: false),
            //        Name = table.Column<string>(type: "text", nullable: true),
            //        DisplayName = table.Column<string>(type: "text", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UserProfiles", x => x.UserId);
            //        table.ForeignKey(
            //            name: "FK_UserProfiles_AppUsers_UserId",
            //            column: x => x.UserId,
            //            principalSchema: "Identity",
            //            principalTable: "AppUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_UserProfiles_Gender_GenderId",
            //            column: x => x.GenderId,
            //            principalSchema: "Identity",
            //            principalTable: "Gender",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UserSettings",
            //    schema: "Identity",
            //    columns: table => new
            //    {
            //        UserId = table.Column<Guid>(type: "uuid", nullable: false),
            //        LanguageId = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
            //        AppTimeZoneId = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
            //        TwoFactorAuthenticationEnabled = table.Column<bool>(type: "boolean", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UserSettings", x => x.UserId);
            //        table.ForeignKey(
            //            name: "FK_UserSettings_AppTimeZone_AppTimeZoneId",
            //            column: x => x.AppTimeZoneId,
            //            principalSchema: "Identity",
            //            principalTable: "AppTimeZone",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_UserSettings_AppUsers_UserId",
            //            column: x => x.UserId,
            //            principalSchema: "Identity",
            //            principalTable: "AppUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_UserSettings_Language_LanguageId",
            //            column: x => x.LanguageId,
            //            principalSchema: "Identity",
            //            principalTable: "Language",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_AppUsers_Email",
            //    schema: "Identity",
            //    table: "AppUsers",
            //    column: "Email",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_AppUsers_PhoneNumber",
            //    schema: "Identity",
            //    table: "AppUsers",
            //    column: "PhoneNumber",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_AppUsers_StatusId",
            //    schema: "Identity",
            //    table: "AppUsers",
            //    column: "StatusId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AppUsers_UserName",
            //    schema: "Identity",
            //    table: "AppUsers",
            //    column: "UserName",
            //    unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Records_UserId",
                schema: "Record",
                table: "Records",
                column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_UserProfiles_GenderId",
            //    schema: "Identity",
            //    table: "UserProfiles",
            //    column: "GenderId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_UserSettings_AppTimeZoneId",
            //    schema: "Identity",
            //    table: "UserSettings",
            //    column: "AppTimeZoneId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_UserSettings_LanguageId",
            //    schema: "Identity",
            //    table: "UserSettings",
            //    column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Records",
                schema: "Record");

            //migrationBuilder.DropTable(
            //    name: "UserProfiles",
            //    schema: "Identity");

            //migrationBuilder.DropTable(
            //    name: "UserSettings",
            //    schema: "Identity");

            //migrationBuilder.DropTable(
            //    name: "Gender",
            //    schema: "Identity");

            //migrationBuilder.DropTable(
            //    name: "AppTimeZone",
            //    schema: "Identity");

            //migrationBuilder.DropTable(
            //    name: "AppUsers",
            //    schema: "Identity");

            //migrationBuilder.DropTable(
            //    name: "Language",
            //    schema: "Identity");

            //migrationBuilder.DropTable(
            //    name: "UserStatus",
            //    schema: "Identity");
        }
    }
}
