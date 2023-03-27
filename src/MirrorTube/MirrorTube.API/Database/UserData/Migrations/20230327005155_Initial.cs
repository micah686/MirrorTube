using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MirrorTube.API.Database.UserData.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SeriesDataDto",
                columns: table => new
                {
                    PK_VideoID = table.Column<string>(type: "TEXT", nullable: false),
                    Series = table.Column<string>(type: "TEXT", nullable: true),
                    SeriesId = table.Column<string>(type: "TEXT", nullable: true),
                    Season = table.Column<string>(type: "TEXT", nullable: true),
                    SeasonNumber = table.Column<int>(type: "INTEGER", nullable: true),
                    SeasonId = table.Column<string>(type: "TEXT", nullable: true),
                    Episode = table.Column<string>(type: "TEXT", nullable: true),
                    EpisodeNumber = table.Column<int>(type: "INTEGER", nullable: true),
                    EpisodeId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesDataDto", x => x.PK_VideoID);
                });

            migrationBuilder.CreateTable(
                name: "TrackDataDto",
                columns: table => new
                {
                    PK_VideoID = table.Column<string>(type: "TEXT", nullable: false),
                    Track = table.Column<string>(type: "TEXT", nullable: true),
                    TrackNumber = table.Column<int>(type: "INTEGER", nullable: true),
                    TrackId = table.Column<string>(type: "TEXT", nullable: true),
                    Artist = table.Column<string>(type: "TEXT", nullable: true),
                    Genre = table.Column<string>(type: "TEXT", nullable: true),
                    Album = table.Column<string>(type: "TEXT", nullable: true),
                    AlbumType = table.Column<string>(type: "TEXT", nullable: true),
                    AlbumArtist = table.Column<string>(type: "TEXT", nullable: true),
                    DiscNumber = table.Column<int>(type: "INTEGER", nullable: true),
                    ReleaseYear = table.Column<string>(type: "TEXT", nullable: true),
                    Composer = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackDataDto", x => x.PK_VideoID);
                });

            migrationBuilder.CreateTable(
                name: "VideoDataDto",
                columns: table => new
                {
                    PK_ID = table.Column<string>(type: "TEXT", nullable: false),
                    Extractor = table.Column<string>(type: "TEXT", nullable: true),
                    ExtractorKey = table.Column<string>(type: "TEXT", nullable: true),
                    VideoID = table.Column<string>(type: "TEXT", nullable: true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    Extension = table.Column<string>(type: "TEXT", nullable: true),
                    FormatID = table.Column<string>(type: "TEXT", nullable: true),
                    AltTitle = table.Column<string>(type: "TEXT", nullable: true),
                    DisplayID = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Uploader = table.Column<string>(type: "TEXT", nullable: true),
                    License = table.Column<string>(type: "TEXT", nullable: true),
                    Creator = table.Column<string>(type: "TEXT", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UploadDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ModifiedTimestamp = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UploaderID = table.Column<string>(type: "TEXT", nullable: true),
                    UploaderUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Channel = table.Column<string>(type: "TEXT", nullable: true),
                    ChannelID = table.Column<string>(type: "TEXT", nullable: true),
                    ChannelUrl = table.Column<string>(type: "TEXT", nullable: true),
                    ChannelFollowerCount = table.Column<long>(type: "INTEGER", nullable: true),
                    Location = table.Column<string>(type: "TEXT", nullable: true),
                    Duration = table.Column<float>(type: "REAL", nullable: true),
                    ViewCount = table.Column<long>(type: "INTEGER", nullable: true),
                    ConcurrentViewCount = table.Column<long>(type: "INTEGER", nullable: true),
                    LikeCount = table.Column<long>(type: "INTEGER", nullable: true),
                    DislikeCount = table.Column<long>(type: "INTEGER", nullable: true),
                    RepostCount = table.Column<long>(type: "INTEGER", nullable: true),
                    AverageRating = table.Column<double>(type: "REAL", nullable: true),
                    CommentCount = table.Column<long>(type: "INTEGER", nullable: true),
                    AgeLimit = table.Column<int>(type: "INTEGER", nullable: true),
                    WebpageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Categories = table.Column<string>(type: "TEXT", nullable: true),
                    Tags = table.Column<string>(type: "TEXT", nullable: true),
                    Cast = table.Column<string>(type: "TEXT", nullable: true),
                    WasLive = table.Column<bool>(type: "INTEGER", nullable: true),
                    StartTime = table.Column<float>(type: "REAL", nullable: true),
                    EndTime = table.Column<float>(type: "REAL", nullable: true),
                    Availability = table.Column<int>(type: "INTEGER", nullable: true),
                    Chapters = table.Column<string>(type: "TEXT", nullable: true),
                    Chapter = table.Column<string>(type: "TEXT", nullable: true),
                    ChapterNumber = table.Column<int>(type: "INTEGER", nullable: true),
                    ChapterId = table.Column<string>(type: "TEXT", nullable: true),
                    SeriesDataPK_VideoID = table.Column<string>(type: "TEXT", nullable: true),
                    TrackDataPK_VideoID = table.Column<string>(type: "TEXT", nullable: true),
                    SectionStart = table.Column<long>(type: "INTEGER", nullable: true),
                    SectionEnd = table.Column<long>(type: "INTEGER", nullable: true),
                    StoryboardFragmentRows = table.Column<long>(type: "INTEGER", nullable: true),
                    StoryboardFragmentColumns = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoDataDto", x => x.PK_ID);
                    table.ForeignKey(
                        name: "FK_VideoDataDto_SeriesDataDto_SeriesDataPK_VideoID",
                        column: x => x.SeriesDataPK_VideoID,
                        principalTable: "SeriesDataDto",
                        principalColumn: "PK_VideoID");
                    table.ForeignKey(
                        name: "FK_VideoDataDto_TrackDataDto_TrackDataPK_VideoID",
                        column: x => x.TrackDataPK_VideoID,
                        principalTable: "TrackDataDto",
                        principalColumn: "PK_VideoID");
                });

            migrationBuilder.CreateTable(
                name: "CommentData",
                columns: table => new
                {
                    ID = table.Column<string>(type: "TEXT", nullable: false),
                    Author = table.Column<string>(type: "TEXT", nullable: true),
                    AuthorID = table.Column<string>(type: "TEXT", nullable: true),
                    AuthorThumbnail = table.Column<string>(type: "TEXT", nullable: true),
                    Html = table.Column<string>(type: "TEXT", nullable: true),
                    Text = table.Column<string>(type: "TEXT", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Parent = table.Column<string>(type: "TEXT", nullable: true),
                    LikeCount = table.Column<int>(type: "INTEGER", nullable: true),
                    DislikeCount = table.Column<int>(type: "INTEGER", nullable: true),
                    IsFavorited = table.Column<bool>(type: "INTEGER", nullable: true),
                    AuthorIsUploader = table.Column<bool>(type: "INTEGER", nullable: true),
                    VideoDataDtoPK_ID = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentData", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CommentData_VideoDataDto_VideoDataDtoPK_ID",
                        column: x => x.VideoDataDtoPK_ID,
                        principalTable: "VideoDataDto",
                        principalColumn: "PK_ID");
                });

            migrationBuilder.CreateTable(
                name: "FormatDataDto",
                columns: table => new
                {
                    PK_VideoFormatId = table.Column<string>(type: "TEXT", nullable: false),
                    FormatId = table.Column<string>(type: "TEXT", nullable: true),
                    VideoId = table.Column<string>(type: "TEXT", nullable: true),
                    Extension = table.Column<string>(type: "TEXT", nullable: true),
                    Format = table.Column<string>(type: "TEXT", nullable: true),
                    FormatNote = table.Column<string>(type: "TEXT", nullable: true),
                    Width = table.Column<int>(type: "INTEGER", nullable: true),
                    Height = table.Column<int>(type: "INTEGER", nullable: true),
                    Bitrate = table.Column<double>(type: "REAL", nullable: true),
                    FileSize = table.Column<long>(type: "INTEGER", nullable: true),
                    HasDRM = table.Column<bool>(type: "INTEGER", nullable: true),
                    DynamicRange = table.Column<string>(type: "TEXT", nullable: true),
                    VideoBitrate = table.Column<double>(type: "REAL", nullable: true),
                    FrameRate = table.Column<float>(type: "REAL", nullable: true),
                    VideoCodec = table.Column<string>(type: "TEXT", nullable: true),
                    Resolution = table.Column<string>(type: "TEXT", nullable: true),
                    AudioBitrate = table.Column<double>(type: "REAL", nullable: true),
                    AudioCodec = table.Column<string>(type: "TEXT", nullable: true),
                    AudioSamplingRate = table.Column<double>(type: "REAL", nullable: true),
                    AudioChannels = table.Column<int>(type: "INTEGER", nullable: true),
                    VideoDataDtoPK_ID = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormatDataDto", x => x.PK_VideoFormatId);
                    table.ForeignKey(
                        name: "FK_FormatDataDto_VideoDataDto_VideoDataDtoPK_ID",
                        column: x => x.VideoDataDtoPK_ID,
                        principalTable: "VideoDataDto",
                        principalColumn: "PK_ID");
                });

            migrationBuilder.CreateTable(
                name: "SubtitleDataDto",
                columns: table => new
                {
                    PK_ID = table.Column<string>(type: "TEXT", nullable: false),
                    LangCode = table.Column<string>(type: "TEXT", nullable: true),
                    SubtitleData = table.Column<string>(type: "TEXT", nullable: true),
                    SubtitleType = table.Column<int>(type: "INTEGER", nullable: false),
                    automatic_captions = table.Column<string>(type: "TEXT", nullable: true),
                    subtitles = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubtitleDataDto", x => x.PK_ID);
                    table.ForeignKey(
                        name: "FK_SubtitleDataDto_VideoDataDto_automatic_captions",
                        column: x => x.automatic_captions,
                        principalTable: "VideoDataDto",
                        principalColumn: "PK_ID");
                    table.ForeignKey(
                        name: "FK_SubtitleDataDto_VideoDataDto_subtitles",
                        column: x => x.subtitles,
                        principalTable: "VideoDataDto",
                        principalColumn: "PK_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentData_VideoDataDtoPK_ID",
                table: "CommentData",
                column: "VideoDataDtoPK_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FormatDataDto_VideoDataDtoPK_ID",
                table: "FormatDataDto",
                column: "VideoDataDtoPK_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SubtitleDataDto_automatic_captions",
                table: "SubtitleDataDto",
                column: "automatic_captions");

            migrationBuilder.CreateIndex(
                name: "IX_SubtitleDataDto_subtitles",
                table: "SubtitleDataDto",
                column: "subtitles");

            migrationBuilder.CreateIndex(
                name: "IX_VideoDataDto_SeriesDataPK_VideoID",
                table: "VideoDataDto",
                column: "SeriesDataPK_VideoID");

            migrationBuilder.CreateIndex(
                name: "IX_VideoDataDto_TrackDataPK_VideoID",
                table: "VideoDataDto",
                column: "TrackDataPK_VideoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentData");

            migrationBuilder.DropTable(
                name: "FormatDataDto");

            migrationBuilder.DropTable(
                name: "SubtitleDataDto");

            migrationBuilder.DropTable(
                name: "VideoDataDto");

            migrationBuilder.DropTable(
                name: "SeriesDataDto");

            migrationBuilder.DropTable(
                name: "TrackDataDto");
        }
    }
}
