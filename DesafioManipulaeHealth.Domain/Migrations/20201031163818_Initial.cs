using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioManipulaeHealth.Domain.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResourcesVideoYoutube",
                columns: table => new
                {
                    ResourceVideoYoutubeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ChannelId = table.Column<string>(nullable: true),
                    Kind = table.Column<string>(nullable: true),
                    PlaylistId = table.Column<string>(nullable: true),
                    VideoId = table.Column<string>(nullable: true),
                    ETag = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourcesVideoYoutube", x => x.ResourceVideoYoutubeId);
                });

            migrationBuilder.CreateTable(
                name: "YoutubeThumbnails",
                columns: table => new
                {
                    YoutubeThumbnailId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Height = table.Column<long>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Width = table.Column<long>(nullable: true),
                    ETag = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YoutubeThumbnails", x => x.YoutubeThumbnailId);
                });

            migrationBuilder.CreateTable(
                name: "YoutubeThumbnailDetails",
                columns: table => new
                {
                    YoutubeThumbnailDetailsId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    YoutubeThumbnailDefaultId = table.Column<int>(nullable: false),
                    YoutubeThumbnailHighId = table.Column<int>(nullable: false),
                    YoutubeThumbnailMaxresId = table.Column<int>(nullable: false),
                    YoutubeThumbnailMediumId = table.Column<int>(nullable: false),
                    YoutubeThumbnailStandardId = table.Column<int>(nullable: false),
                    ETag = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YoutubeThumbnailDetails", x => x.YoutubeThumbnailDetailsId);
                    table.ForeignKey(
                        name: "FK_YoutubeThumbnailDetails_YoutubeThumbnails_YoutubeThumbnailDefaultId",
                        column: x => x.YoutubeThumbnailDefaultId,
                        principalTable: "YoutubeThumbnails",
                        principalColumn: "YoutubeThumbnailId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_YoutubeThumbnailDetails_YoutubeThumbnails_YoutubeThumbnailHighId",
                        column: x => x.YoutubeThumbnailHighId,
                        principalTable: "YoutubeThumbnails",
                        principalColumn: "YoutubeThumbnailId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_YoutubeThumbnailDetails_YoutubeThumbnails_YoutubeThumbnailMaxresId",
                        column: x => x.YoutubeThumbnailMaxresId,
                        principalTable: "YoutubeThumbnails",
                        principalColumn: "YoutubeThumbnailId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_YoutubeThumbnailDetails_YoutubeThumbnails_YoutubeThumbnailMediumId",
                        column: x => x.YoutubeThumbnailMediumId,
                        principalTable: "YoutubeThumbnails",
                        principalColumn: "YoutubeThumbnailId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_YoutubeThumbnailDetails_YoutubeThumbnails_YoutubeThumbnailStandardId",
                        column: x => x.YoutubeThumbnailStandardId,
                        principalTable: "YoutubeThumbnails",
                        principalColumn: "YoutubeThumbnailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "YoutubeSearchsResultSnippet",
                columns: table => new
                {
                    YoutubeSearchResultSnippetId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ChannelId = table.Column<string>(nullable: true),
                    ChannelTitle = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    LiveBroadcastContent = table.Column<string>(nullable: true),
                    PublishedAt = table.Column<string>(nullable: true),
                    YoutubeThumbnailDetailsId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    ETag = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YoutubeSearchsResultSnippet", x => x.YoutubeSearchResultSnippetId);
                    table.ForeignKey(
                        name: "FK_YoutubeSearchsResultSnippet_YoutubeThumbnailDetails_YoutubeThumbnailDetailsId",
                        column: x => x.YoutubeThumbnailDetailsId,
                        principalTable: "YoutubeThumbnailDetails",
                        principalColumn: "YoutubeThumbnailDetailsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VideosYoutube",
                columns: table => new
                {
                    VideoYoutubeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ETag = table.Column<string>(nullable: true),
                    ResourceVideoYoutubeId = table.Column<int>(nullable: false),
                    Kind = table.Column<string>(nullable: true),
                    YoutubeSearchResultSnippetId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideosYoutube", x => x.VideoYoutubeId);
                    table.ForeignKey(
                        name: "FK_VideosYoutube_ResourcesVideoYoutube_ResourceVideoYoutubeId",
                        column: x => x.ResourceVideoYoutubeId,
                        principalTable: "ResourcesVideoYoutube",
                        principalColumn: "ResourceVideoYoutubeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideosYoutube_YoutubeSearchsResultSnippet_YoutubeSearchResultSnippetId",
                        column: x => x.YoutubeSearchResultSnippetId,
                        principalTable: "YoutubeSearchsResultSnippet",
                        principalColumn: "YoutubeSearchResultSnippetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VideosYoutube_ResourceVideoYoutubeId",
                table: "VideosYoutube",
                column: "ResourceVideoYoutubeId");

            migrationBuilder.CreateIndex(
                name: "IX_VideosYoutube_YoutubeSearchResultSnippetId",
                table: "VideosYoutube",
                column: "YoutubeSearchResultSnippetId");

            migrationBuilder.CreateIndex(
                name: "IX_YoutubeSearchsResultSnippet_YoutubeThumbnailDetailsId",
                table: "YoutubeSearchsResultSnippet",
                column: "YoutubeThumbnailDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_YoutubeThumbnailDetails_YoutubeThumbnailDefaultId",
                table: "YoutubeThumbnailDetails",
                column: "YoutubeThumbnailDefaultId");

            migrationBuilder.CreateIndex(
                name: "IX_YoutubeThumbnailDetails_YoutubeThumbnailHighId",
                table: "YoutubeThumbnailDetails",
                column: "YoutubeThumbnailHighId");

            migrationBuilder.CreateIndex(
                name: "IX_YoutubeThumbnailDetails_YoutubeThumbnailMaxresId",
                table: "YoutubeThumbnailDetails",
                column: "YoutubeThumbnailMaxresId");

            migrationBuilder.CreateIndex(
                name: "IX_YoutubeThumbnailDetails_YoutubeThumbnailMediumId",
                table: "YoutubeThumbnailDetails",
                column: "YoutubeThumbnailMediumId");

            migrationBuilder.CreateIndex(
                name: "IX_YoutubeThumbnailDetails_YoutubeThumbnailStandardId",
                table: "YoutubeThumbnailDetails",
                column: "YoutubeThumbnailStandardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VideosYoutube");

            migrationBuilder.DropTable(
                name: "ResourcesVideoYoutube");

            migrationBuilder.DropTable(
                name: "YoutubeSearchsResultSnippet");

            migrationBuilder.DropTable(
                name: "YoutubeThumbnailDetails");

            migrationBuilder.DropTable(
                name: "YoutubeThumbnails");
        }
    }
}
