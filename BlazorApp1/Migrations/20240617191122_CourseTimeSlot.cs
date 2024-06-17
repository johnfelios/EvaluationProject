using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp1.Migrations
{
    /// <inheritdoc />
    public partial class CourseTimeSlot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseTimeSlots",
                table: "CourseTimeSlots");

            migrationBuilder.DropIndex(
                name: "IX_CourseTimeSlots_CourseId",
                table: "CourseTimeSlots");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CourseTimeSlots",
                newName: "TimeSlotId");

            migrationBuilder.AlterColumn<int>(
                name: "TimeSlotId",
                table: "CourseTimeSlots",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseTimeSlots",
                table: "CourseTimeSlots",
                columns: new[] { "CourseId", "TimeSlotId" });

            migrationBuilder.CreateIndex(
                name: "IX_CourseTimeSlots_TimeSlotId",
                table: "CourseTimeSlots",
                column: "TimeSlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTimeSlots_TimeSlots_TimeSlotId",
                table: "CourseTimeSlots",
                column: "TimeSlotId",
                principalTable: "TimeSlots",
                principalColumn: "TimeSlotId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseTimeSlots_TimeSlots_TimeSlotId",
                table: "CourseTimeSlots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseTimeSlots",
                table: "CourseTimeSlots");

            migrationBuilder.DropIndex(
                name: "IX_CourseTimeSlots_TimeSlotId",
                table: "CourseTimeSlots");

            migrationBuilder.RenameColumn(
                name: "TimeSlotId",
                table: "CourseTimeSlots",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "CourseTimeSlots",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseTimeSlots",
                table: "CourseTimeSlots",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTimeSlots_CourseId",
                table: "CourseTimeSlots",
                column: "CourseId");
        }
    }
}
