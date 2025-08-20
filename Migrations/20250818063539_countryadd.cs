using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeadMedixCRM.Migrations
{
    /// <inheritdoc />
    public partial class countryadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedByUserId",
                table: "Lead",
                newName: "CreatedBy");

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "Lead",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MedicalIssue",
                table: "Lead",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alpha2Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alpha3Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumericCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "Lead");

            migrationBuilder.DropColumn(
                name: "MedicalIssue",
                table: "Lead");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Lead",
                newName: "CreatedByUserId");
        }
    }
}
