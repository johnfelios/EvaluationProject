using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp1.Migrations
{
    /// <inheritdoc />
    public partial class Cleaner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CleanerTimeSlots_Cleaners_CleanerId",
                table: "CleanerTimeSlots");

            migrationBuilder.RenameColumn(
                name: "CleanerId",
                table: "CleanerTimeSlots",
                newName: "CleanerAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_CleanerTimeSlots_Cleaners_CleanerAccountId",
                table: "CleanerTimeSlots",
                column: "CleanerAccountId",
                principalTable: "Cleaners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CleanerTimeSlots_Cleaners_CleanerAccountId",
                table: "CleanerTimeSlots");

            migrationBuilder.RenameColumn(
                name: "CleanerAccountId",
                table: "CleanerTimeSlots",
                newName: "CleanerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CleanerTimeSlots_Cleaners_CleanerId",
                table: "CleanerTimeSlots",
                column: "CleanerId",
                principalTable: "Cleaners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
