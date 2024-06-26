using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiftLogAPI.Migrations
{
    /// <inheritdoc />
    public partial class WeightLogstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeightLogs_Exercises_ExerciseId",
                table: "WeightLogs");

            migrationBuilder.DropIndex(
                name: "IX_WeightLogs_ExerciseId",
                table: "WeightLogs");

            migrationBuilder.AddColumn<float>(
                name: "Weight",
                table: "WeightLogs",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weight",
                table: "WeightLogs");

            migrationBuilder.CreateIndex(
                name: "IX_WeightLogs_ExerciseId",
                table: "WeightLogs",
                column: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeightLogs_Exercises_ExerciseId",
                table: "WeightLogs",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
