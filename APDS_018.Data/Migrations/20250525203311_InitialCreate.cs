using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APDS_018.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Respondents",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Surname = table.Column<string>(type: "TEXT", nullable: false),
                    NameResp = table.Column<string>(type: "TEXT", nullable: false),
                    Midlename = table.Column<string>(type: "TEXT", nullable: false),
                    Sex = table.Column<string>(type: "TEXT", nullable: false),
                    Born = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respondents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NameTest = table.Column<string>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    RunFile = table.Column<string>(type: "TEXT", nullable: false),
                    Instruction = table.Column<string>(type: "TEXT", nullable: false),
                    Help = table.Column<string>(type: "TEXT", nullable: false),
                    Developer = table.Column<string>(type: "TEXT", nullable: false),
                    Psycologist = table.Column<string>(type: "TEXT", nullable: false),
                    Version = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParamResults",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TestId = table.Column<long>(type: "INTEGER", nullable: false),
                    Parametr = table.Column<string>(type: "TEXT", nullable: false),
                    MinValue = table.Column<string>(type: "TEXT", nullable: false),
                    MaxValue = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParamResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParamResults_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TestId = table.Column<long>(type: "INTEGER", nullable: false),
                    NumQuestion = table.Column<long>(type: "INTEGER", nullable: false),
                    QuestionText = table.Column<string>(type: "TEXT", nullable: false),
                    QuestionType = table.Column<string>(type: "TEXT", nullable: false),
                    QuestionFile = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Testings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RespondentId = table.Column<long>(type: "INTEGER", nullable: false),
                    TestId = table.Column<long>(type: "INTEGER", nullable: false),
                    TestingDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TestingTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Testings_Respondents_RespondentId",
                        column: x => x.RespondentId,
                        principalTable: "Respondents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Testings_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TestId = table.Column<long>(type: "INTEGER", nullable: false),
                    NumQuestion = table.Column<long>(type: "INTEGER", nullable: false),
                    NumAnswer = table.Column<long>(type: "INTEGER", nullable: false),
                    AnswerText = table.Column<string>(type: "TEXT", nullable: false),
                    QuestionId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Answers_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ParamResultId = table.Column<long>(type: "INTEGER", nullable: false),
                    TestingId = table.Column<long>(type: "INTEGER", nullable: false),
                    ValueResult = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Results_ParamResults_ParamResultId",
                        column: x => x.ParamResultId,
                        principalTable: "ParamResults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Results_Testings_TestingId",
                        column: x => x.TestingId,
                        principalTable: "Testings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Protocols",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TestingId = table.Column<long>(type: "INTEGER", nullable: false),
                    NumAnswer = table.Column<long>(type: "INTEGER", nullable: false),
                    NumQuestion = table.Column<long>(type: "INTEGER", nullable: false),
                    TimeAnswer = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AnswerText = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Protocols", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Protocols_Answers_NumAnswer",
                        column: x => x.NumAnswer,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Protocols_Questions_NumQuestion",
                        column: x => x.NumQuestion,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Protocols_Testings_TestingId",
                        column: x => x.TestingId,
                        principalTable: "Testings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_TestId",
                table: "Answers",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_ParamResults_TestId",
                table: "ParamResults",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_Protocols_NumAnswer",
                table: "Protocols",
                column: "NumAnswer");

            migrationBuilder.CreateIndex(
                name: "IX_Protocols_NumQuestion",
                table: "Protocols",
                column: "NumQuestion");

            migrationBuilder.CreateIndex(
                name: "IX_Protocols_TestingId",
                table: "Protocols",
                column: "TestingId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TestId",
                table: "Questions",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_ParamResultId",
                table: "Results",
                column: "ParamResultId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_TestingId",
                table: "Results",
                column: "TestingId");

            migrationBuilder.CreateIndex(
                name: "IX_Testings_RespondentId",
                table: "Testings",
                column: "RespondentId");

            migrationBuilder.CreateIndex(
                name: "IX_Testings_TestId",
                table: "Testings",
                column: "TestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Protocols");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "ParamResults");

            migrationBuilder.DropTable(
                name: "Testings");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Respondents");

            migrationBuilder.DropTable(
                name: "Tests");
        }
    }
}
