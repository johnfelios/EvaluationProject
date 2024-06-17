using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp1.Migrations
{
    /// <inheritdoc />
    public partial class InitialUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "CleanerTimeSlots",
                columns: table => new
                {
                    CleanerId = table.Column<int>(type: "INTEGER", nullable: false),
                    TimeSlotId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CleanerTimeSlots", x => new { x.CleanerId, x.TimeSlotId });
                    table.ForeignKey(
                        name: "FK_CleanerTimeSlots_Cleaners_CleanerId",
                        column: x => x.CleanerId,
                        principalTable: "Cleaners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CleanerTimeSlots_TimeSlots_TimeSlotId",
                        column: x => x.TimeSlotId,
                        principalTable: "TimeSlots",
                        principalColumn: "TimeSlotId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseTimeSlots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTimeSlots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseTimeSlots_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CleanerTimeSlots_TimeSlotId",
                table: "CleanerTimeSlots",
                column: "TimeSlotId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTimeSlots_CourseId",
                table: "CourseTimeSlots",
                column: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CleanerTimeSlots");

            migrationBuilder.DropTable(
                name: "CourseTimeSlots");

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
    }
}
