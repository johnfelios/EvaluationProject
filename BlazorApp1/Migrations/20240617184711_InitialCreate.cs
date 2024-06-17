using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CleanerTimeSlot");

            migrationBuilder.DropTable(
                name: "CourseTimeSlot");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "StudentsCourses",
                newName: "StudentAccountId");

            migrationBuilder.AddColumn<int>(
                name: "CleanerId",
                table: "TimeSlots",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TimeSlotId",
                table: "Courses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlots_CleanerId",
                table: "TimeSlots",
                column: "CleanerId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TimeSlotId",
                table: "Courses",
                column: "TimeSlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_TimeSlots_TimeSlotId",
                table: "Courses",
                column: "TimeSlotId",
                principalTable: "TimeSlots",
                principalColumn: "TimeSlotId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSlots_Cleaners_CleanerId",
                table: "TimeSlots",
                column: "CleanerId",
                principalTable: "Cleaners",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_TimeSlots_TimeSlotId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeSlots_Cleaners_CleanerId",
                table: "TimeSlots");

            migrationBuilder.DropIndex(
                name: "IX_TimeSlots_CleanerId",
                table: "TimeSlots");

            migrationBuilder.DropIndex(
                name: "IX_Courses_TimeSlotId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CleanerId",
                table: "TimeSlots");

            migrationBuilder.DropColumn(
                name: "TimeSlotId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "StudentAccountId",
                table: "StudentsCourses",
                newName: "AccountId");

            migrationBuilder.CreateTable(
                name: "CleanerTimeSlot",
                columns: table => new
                {
                    CleanersId = table.Column<int>(type: "INTEGER", nullable: false),
                    WorkingTimeSlotsTimeSlotId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CleanerTimeSlot", x => new { x.CleanersId, x.WorkingTimeSlotsTimeSlotId });
                    table.ForeignKey(
                        name: "FK_CleanerTimeSlot_Cleaners_CleanersId",
                        column: x => x.CleanersId,
                        principalTable: "Cleaners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CleanerTimeSlot_TimeSlots_WorkingTimeSlotsTimeSlotId",
                        column: x => x.WorkingTimeSlotsTimeSlotId,
                        principalTable: "TimeSlots",
                        principalColumn: "TimeSlotId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseTimeSlot",
                columns: table => new
                {
                    CoursesCourseId = table.Column<int>(type: "INTEGER", nullable: false),
                    TimeSlotId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTimeSlot", x => new { x.CoursesCourseId, x.TimeSlotId });
                    table.ForeignKey(
                        name: "FK_CourseTimeSlot_Courses_CoursesCourseId",
                        column: x => x.CoursesCourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseTimeSlot_TimeSlots_TimeSlotId",
                        column: x => x.TimeSlotId,
                        principalTable: "TimeSlots",
                        principalColumn: "TimeSlotId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CleanerTimeSlot_WorkingTimeSlotsTimeSlotId",
                table: "CleanerTimeSlot",
                column: "WorkingTimeSlotsTimeSlotId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTimeSlot_TimeSlotId",
                table: "CourseTimeSlot",
                column: "TimeSlotId");
        }
    }
}
