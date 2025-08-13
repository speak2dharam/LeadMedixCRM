using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeadMedixCRM.Migrations
{
    /// <inheritdoc />
    public partial class descriptionadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "LeadStatus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "LeadSource",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "LeadQuality",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "LeadStatus");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "LeadSource");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "LeadQuality");
        }
    }
}
