using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddUserData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyPairs");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.CreateTable(
                name: "UserDatas",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDatas", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "QuizAnswers",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    QuizId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    QuestionAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserDataEmail = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizAnswers", x => new { x.QuizId, x.QuestionId, x.Email });
                    table.ForeignKey(
                        name: "FK_QuizAnswers_UserDatas_UserDataEmail",
                        column: x => x.UserDataEmail,
                        principalTable: "UserDatas",
                        principalColumn: "Email");
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuizAnswers_UserDataEmail",
                table: "QuizAnswers",
                column: "UserDataEmail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuizAnswers");

            migrationBuilder.DropTable(
                name: "UserDatas");

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "MyPairs",
                columns: table => new
                {
                    UserEmail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    AnswerEmail = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    QuestionAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyPairs", x => new { x.UserEmail, x.QuestionId });
                    table.ForeignKey(
                        name: "FK_MyPairs_Answers_AnswerEmail",
                        column: x => x.AnswerEmail,
                        principalTable: "Answers",
                        principalColumn: "Email");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MyPairs_AnswerEmail",
                table: "MyPairs",
                column: "AnswerEmail");
        }
    }
}
