using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace OsDbWebApi.Migrations
{
    /// <inheritdoc />
    public partial class NewMigrationAAAA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntityPhoneOs",
                columns: table => new
                {
                    PhoneOsID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SystemName = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Manufacturer = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityPhoneOs", x => x.PhoneOsID);
                });

            migrationBuilder.CreateTable(
                name: "EntityOsVersions",
                columns: table => new
                {
                    VersionID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VersionName = table.Column<string>(type: "text", nullable: true),
                    Futures = table.Column<string>(type: "text", nullable: true),
                    ReleaseDate = table.Column<string>(type: "text", nullable: true),
                    PhoneOsID = table.Column<int>(type: "integer", nullable: false),
                    PhoneOperationSystemsPhoneOsID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityOsVersions", x => x.VersionID);
                    table.ForeignKey(
                        name: "FK_EntityOsVersions_EntityPhoneOs_PhoneOperationSystemsPhoneOs~",
                        column: x => x.PhoneOperationSystemsPhoneOsID,
                        principalTable: "EntityPhoneOs",
                        principalColumn: "PhoneOsID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntityOsVersions_PhoneOperationSystemsPhoneOsID",
                table: "EntityOsVersions",
                column: "PhoneOperationSystemsPhoneOsID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntityOsVersions");

            migrationBuilder.DropTable(
                name: "EntityPhoneOs");
        }
    }
}
