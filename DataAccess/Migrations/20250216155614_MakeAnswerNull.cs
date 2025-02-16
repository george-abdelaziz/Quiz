using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MakeAnswerNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizAnswers",
                table: "QuizAnswers");

            migrationBuilder.DropIndex(
                name: "IX_QuizAnswers_UserDataEmail",
                table: "QuizAnswers");

            migrationBuilder.AlterColumn<string>(
                name: "QuestionAnswer",
                table: "QuizAnswers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizAnswers",
                table: "QuizAnswers",
                columns: new[] { "UserDataEmail", "QuizId", "QuestionId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizAnswers",
                table: "QuizAnswers");

            migrationBuilder.AlterColumn<string>(
                name: "QuestionAnswer",
                table: "QuizAnswers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizAnswers",
                table: "QuizAnswers",
                columns: new[] { "QuizId", "QuestionId", "UserDataEmail" });

            migrationBuilder.CreateIndex(
                name: "IX_QuizAnswers_UserDataEmail",
                table: "QuizAnswers",
                column: "UserDataEmail");
        }
    }
}
