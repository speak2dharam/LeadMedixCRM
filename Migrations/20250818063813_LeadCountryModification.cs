using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeadMedixCRM.Migrations
{
    /// <inheritdoc />
    public partial class LeadCountryModification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "Lead");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Lead");

            migrationBuilder.AddColumn<int>(
                name: "Country",
                table: "Lead",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Lead");

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "Lead",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "Lead",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
