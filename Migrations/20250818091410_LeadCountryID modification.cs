using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeadMedixCRM.Migrations
{
    /// <inheritdoc />
    public partial class LeadCountryIDmodification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Lead");

            migrationBuilder.AddColumn<int>(
                name: "CountryID",
                table: "Lead",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryID",
                table: "Lead");

            migrationBuilder.AddColumn<int>(
                name: "Country",
                table: "Lead",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
