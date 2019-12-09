using Microsoft.EntityFrameworkCore.Migrations;

namespace dreamgames.Migrations
{
    public partial class DreamGamesAp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    OutroVideo = table.Column<int>(nullable: false),
                    QuestionId = table.Column<int>(nullable: false),
                    AnswerOrder = table.Column<int>(nullable: false),
                    FollowUpQuestionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ScenarioId = table.Column<int>(nullable: false),
                    IntroVideoId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    MotivePath = table.Column<string>(nullable: true),
                    Ordering = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Scenarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Numbering = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scenarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sounds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VideoId = table.Column<int>(nullable: false),
                    UrlPath = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sounds", x => x.Id);
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
                });

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
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QuestionId = table.Column<int>(nullable: false),
                    Order = table.Column<int>(nullable: false),
                    UrlPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VideoSequences",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VideoId = table.Column<int>(nullable: false),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoSequences", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "AnswerOrder", "FollowUpQuestionId", "ImagePath", "OutroVideo", "QuestionId", "Text" },
                values: new object[] { 1, 1, 1, "A Path", 1, 1, "Text" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Description", "IntroVideoId", "MotivePath", "Ordering", "ScenarioId" },
                values: new object[] { 1, "Description", 0, null, 1, 1 });

            migrationBuilder.InsertData(
                table: "Scenarios",
                columns: new[] { "Id", "Numbering", "Title" },
                values: new object[] { 1, 1, "AScenario" });

            migrationBuilder.InsertData(
                table: "Sounds",
                columns: new[] { "Id", "Order", "UrlPath", "VideoId" },
                values: new object[] { 1, 1, "APathToSound", 1 });

            migrationBuilder.InsertData(
                table: "TagPoints",
                columns: new[] { "Id", "AnswerId", "Point", "TagId" },
                values: new object[] { 1, 1, 10, 2 });

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
                columns: new[] { "Id", "Order", "VideoId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "Order", "QuestionId", "UrlPath" },
                values: new object[] { 1, 1, 1, "APathToAVideo" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Scenarios");

            migrationBuilder.DropTable(
                name: "Sounds");

            migrationBuilder.DropTable(
                name: "TagPoints");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "VideoSequences");
        }
    }
}
