using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRepairWorkshops.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class workshopLogoAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WorkshopLogo",
                table: "CarRepairWorkshops",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkshopLogo",
                table: "CarRepairWorkshops");
        }
    }
}
