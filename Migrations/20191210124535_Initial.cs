using Microsoft.EntityFrameworkCore.Migrations;

namespace dreamgames.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TagName = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true),
                    RawGTagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VideoSequences",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoSequences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true),
                    MotivePath = table.Column<string>(nullable: true),
                    Ordering = table.Column<int>(nullable: false),
                    IntroVideoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_VideoSequences_IntroVideoId",
                        column: x => x.IntroVideoId,
                        principalTable: "VideoSequences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Order = table.Column<int>(nullable: false),
                    Path = table.Column<string>(nullable: true),
                    AmbiencePath = table.Column<string>(nullable: true),
                    VideoSequenceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Videos_VideoSequences_VideoSequenceId",
                        column: x => x.VideoSequenceId,
                        principalTable: "VideoSequences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    AnswerOrder = table.Column<int>(nullable: false),
                    OutroVideoId = table.Column<int>(nullable: true),
                    QuestionId = table.Column<int>(nullable: false),
                    FollowUpQuestionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_FollowUpQuestionId",
                        column: x => x.FollowUpQuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Answers_VideoSequences_OutroVideoId",
                        column: x => x.OutroVideoId,
                        principalTable: "VideoSequences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TagPoints",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TagId = table.Column<int>(nullable: false),
                    AnswerId = table.Column<int>(nullable: false),
                    Point = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TagPoints_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Description", "IntroVideoId", "MotivePath", "Ordering" },
                values: new object[] { 1, "Description", null, null, 1 });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Description", "IntroVideoId", "MotivePath", "Ordering" },
                values: new object[] { 2, "Another question", null, null, 1 });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "RawGTagId", "Slug", "TagName" },
                values: new object[] { 1, 31, "singleplayer", "Singleplayer" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "RawGTagId", "Slug", "TagName" },
                values: new object[] { 2, 7, "multiplayer", "Multiplayer" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "RawGTagId", "Slug", "TagName" },
                values: new object[] { 3, 42, "great-soundtrack", "Great Soundtrack" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "RawGTagId", "Slug", "TagName" },
                values: new object[] { 4, 24, "rpg", "RPG" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "RawGTagId", "Slug", "TagName" },
                values: new object[] { 5, 118, "story-rich", "Story Rich" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "RawGTagId", "Slug", "TagName" },
                values: new object[] { 6, 36, "open-world", "Open World" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "RawGTagId", "Slug", "TagName" },
                values: new object[] { 7, 32, "sci-fi", "Sci-fi" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "RawGTagId", "Slug", "TagName" },
                values: new object[] { 8, 16, "horror", "Horror" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "RawGTagId", "Slug", "TagName" },
                values: new object[] { 9, 64, "fantasy", "Fantasy" });

            migrationBuilder.InsertData(
                table: "VideoSequences",
                column: "Id",
                value: 1);

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "AnswerOrder", "FollowUpQuestionId", "ImagePath", "OutroVideoId", "QuestionId", "Text" },
                values: new object[] { 1, 1, 2, null, 1, 1, "Text" });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "AnswerOrder", "FollowUpQuestionId", "ImagePath", "OutroVideoId", "QuestionId", "Text" },
                values: new object[] { 2, 1, null, null, 1, 2, "Some text" });

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "AmbiencePath", "Order", "Path", "VideoSequenceId" },
                values: new object[] { 1, null, 1, "APathToAVideo", 1 });

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "AmbiencePath", "Order", "Path", "VideoSequenceId" },
                values: new object[] { 2, null, 2, "APathToAVideo", 1 });

            migrationBuilder.InsertData(
                table: "TagPoints",
                columns: new[] { "Id", "AnswerId", "Point", "TagId" },
                values: new object[] { 1, 1, 10, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_FollowUpQuestionId",
                table: "Answers",
                column: "FollowUpQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_OutroVideoId",
                table: "Answers",
                column: "OutroVideoId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_IntroVideoId",
                table: "Questions",
                column: "IntroVideoId");

            migrationBuilder.CreateIndex(
                name: "IX_TagPoints_AnswerId",
                table: "TagPoints",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_VideoSequenceId",
                table: "Videos",
                column: "VideoSequenceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TagPoints");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "VideoSequences");
        }
    }
}
