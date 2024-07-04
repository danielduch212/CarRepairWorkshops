using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRepairWorkshops.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarPart_Repairs_RepairId",
                table: "CarPart");

            migrationBuilder.DropForeignKey(
                name: "FK_MechanicalService_Repairs_RepairId",
                table: "MechanicalService");

            migrationBuilder.AlterColumn<int>(
                name: "RepairId",
                table: "MechanicalService",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RepairId",
                table: "CarPart",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CarPart_Repairs_RepairId",
                table: "CarPart",
                column: "RepairId",
                principalTable: "Repairs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MechanicalService_Repairs_RepairId",
                table: "MechanicalService",
                column: "RepairId",
                principalTable: "Repairs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarPart_Repairs_RepairId",
                table: "CarPart");

            migrationBuilder.DropForeignKey(
                name: "FK_MechanicalService_Repairs_RepairId",
                table: "MechanicalService");

            migrationBuilder.AlterColumn<int>(
                name: "RepairId",
                table: "MechanicalService",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RepairId",
                table: "CarPart",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CarPart_Repairs_RepairId",
                table: "CarPart",
                column: "RepairId",
                principalTable: "Repairs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MechanicalService_Repairs_RepairId",
                table: "MechanicalService",
                column: "RepairId",
                principalTable: "Repairs",
                principalColumn: "Id");
        }
    }
}
