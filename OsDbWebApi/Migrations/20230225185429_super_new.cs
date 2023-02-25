using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OsDbWebApi.Migrations
{
    /// <inheritdoc />
    public partial class super_new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneOsID",
                table: "EntityOsVersions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PhoneOsID",
                table: "EntityOsVersions",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
