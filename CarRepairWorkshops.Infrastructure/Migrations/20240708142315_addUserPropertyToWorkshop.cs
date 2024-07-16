using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRepairWorkshops.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addUserPropertyToWorkshop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarRepairWorkshops_AspNetUsers_OwnerId",
                table: "CarRepairWorkshops");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "CarRepairWorkshops",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.Sql("UPDATE CarRepairWorkshops " + "SET OwnerId = (SELECT TOP 1 Id FROM AspNetUsers)");

            migrationBuilder.AddForeignKey(
                name: "FK_CarRepairWorkshops_AspNetUsers_OwnerId",
                table: "CarRepairWorkshops",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarRepairWorkshops_AspNetUsers_OwnerId",
                table: "CarRepairWorkshops");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "CarRepairWorkshops",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_CarRepairWorkshops_AspNetUsers_OwnerId",
                table: "CarRepairWorkshops",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
