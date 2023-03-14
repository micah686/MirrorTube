using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MirrorTube.API.Database.UserData.Migrations
{
    /// <inheritdoc />
    public partial class InitialVideoData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VideoDataDto",
                columns: table => new
                {
                    PK_ID = table.Column<string>(type: "TEXT", nullable: false),
                    ResultType = table.Column<int>(type: "INTEGER", nullable: false),
                    Extractor = table.Column<string>(type: "TEXT", nullable: false),
                    ExtractorKey = table.Column<string>(type: "TEXT", nullable: false),
                    ID = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    Extension = table.Column<string>(type: "TEXT", nullable: false),
                    Format = table.Column<string>(type: "TEXT", nullable: false),
                    FormatID = table.Column<string>(type: "TEXT", nullable: false),
                    PlayerUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Direct = table.Column<bool>(type: "INTEGER", nullable: false),
                    AltTitle = table.Column<string>(type: "TEXT", nullable: false),
                    DisplayID = table.Column<string>(type: "TEXT", nullable: false),
                    Thumbnail = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Uploader = table.Column<string>(type: "TEXT", nullable: false),
                    License = table.Column<string>(type: "TEXT", nullable: false),
                    Creator = table.Column<string>(type: "TEXT", nullable: false),
                    ReleaseTimestamp = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UploadDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ModifiedTimestamp = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UploaderID = table.Column<string>(type: "TEXT", nullable: false),
                    UploaderUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Channel = table.Column<string>(type: "TEXT", nullable: false),
                    ChannelID = table.Column<string>(type: "TEXT", nullable: false),
                    ChannelUrl = table.Column<string>(type: "TEXT", nullable: false),
                    ChannelFollowerCount = table.Column<long>(type: "INTEGER", nullable: true),
                    Location = table.Column<string>(type: "TEXT", nullable: false),
                    Duration = table.Column<float>(type: "REAL", nullable: true),
                    ViewCount = table.Column<long>(type: "INTEGER", nullable: true),
                    ConcurrentViewCount = table.Column<long>(type: "INTEGER", nullable: true),
                    LikeCount = table.Column<long>(type: "INTEGER", nullable: true),
                    DislikeCount = table.Column<long>(type: "INTEGER", nullable: true),
                    RepostCount = table.Column<long>(type: "INTEGER", nullable: true),
                    AverageRating = table.Column<double>(type: "REAL", nullable: true),
                    CommentCount = table.Column<long>(type: "INTEGER", nullable: true),
                    AgeLimit = table.Column<int>(type: "INTEGER", nullable: true),
                    WebpageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Categories = table.Column<string>(type: "TEXT", nullable: false),
                    Tags = table.Column<string>(type: "TEXT", nullable: false),
                    Cast = table.Column<string>(type: "TEXT", nullable: false),
                    IsLive = table.Column<bool>(type: "INTEGER", nullable: true),
                    WasLive = table.Column<bool>(type: "INTEGER", nullable: true),
                    LiveStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    StartTime = table.Column<float>(type: "REAL", nullable: true),
                    EndTime = table.Column<float>(type: "REAL", nullable: true),
                    PlayableInEmbed = table.Column<string>(type: "TEXT", nullable: false),
                    Availability = table.Column<int>(type: "INTEGER", nullable: true),
                    Chapters = table.Column<string>(type: "TEXT", nullable: false),
                    Chapter = table.Column<string>(type: "TEXT", nullable: false),
                    ChapterNumber = table.Column<int>(type: "INTEGER", nullable: true),
                    ChapterId = table.Column<string>(type: "TEXT", nullable: false),
                    Series = table.Column<string>(type: "TEXT", nullable: false),
                    SeriesId = table.Column<string>(type: "TEXT", nullable: false),
                    Season = table.Column<string>(type: "TEXT", nullable: false),
                    SeasonNumber = table.Column<int>(type: "INTEGER", nullable: true),
                    SeasonId = table.Column<string>(type: "TEXT", nullable: false),
                    Episode = table.Column<string>(type: "TEXT", nullable: false),
                    EpisodeNumber = table.Column<int>(type: "INTEGER", nullable: true),
                    EpisodeId = table.Column<string>(type: "TEXT", nullable: false),
                    Track = table.Column<string>(type: "TEXT", nullable: false),
                    TrackNumber = table.Column<int>(type: "INTEGER", nullable: true),
                    TrackId = table.Column<string>(type: "TEXT", nullable: false),
                    Artist = table.Column<string>(type: "TEXT", nullable: false),
                    Genre = table.Column<string>(type: "TEXT", nullable: false),
                    Album = table.Column<string>(type: "TEXT", nullable: false),
                    AlbumType = table.Column<string>(type: "TEXT", nullable: false),
                    AlbumArtist = table.Column<string>(type: "TEXT", nullable: false),
                    DiscNumber = table.Column<int>(type: "INTEGER", nullable: true),
                    ReleaseYear = table.Column<string>(type: "TEXT", nullable: false),
                    Composer = table.Column<string>(type: "TEXT", nullable: false),
                    SectionStart = table.Column<long>(type: "INTEGER", nullable: true),
                    SectionEnd = table.Column<long>(type: "INTEGER", nullable: true),
                    StoryboardFragmentRows = table.Column<long>(type: "INTEGER", nullable: true),
                    StoryboardFragmentColumns = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoDataDto", x => x.PK_ID);
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
                    PK_ID = table.Column<string>(type: "TEXT", nullable: false),
                    VideoId = table.Column<string>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    ManifestUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Extension = table.Column<string>(type: "TEXT", nullable: false),
                    Format = table.Column<string>(type: "TEXT", nullable: false),
                    FormatId = table.Column<string>(type: "TEXT", nullable: false),
                    FormatNote = table.Column<string>(type: "TEXT", nullable: false),
                    Width = table.Column<int>(type: "INTEGER", nullable: true),
                    Height = table.Column<int>(type: "INTEGER", nullable: true),
                    Resolution = table.Column<string>(type: "TEXT", nullable: false),
                    DynamicRange = table.Column<string>(type: "TEXT", nullable: false),
                    Bitrate = table.Column<double>(type: "REAL", nullable: true),
                    AudioBitrate = table.Column<double>(type: "REAL", nullable: true),
                    AudioCodec = table.Column<string>(type: "TEXT", nullable: false),
                    AudioSamplingRate = table.Column<double>(type: "REAL", nullable: true),
                    AudioChannels = table.Column<int>(type: "INTEGER", nullable: true),
                    VideoBitrate = table.Column<double>(type: "REAL", nullable: true),
                    FrameRate = table.Column<float>(type: "REAL", nullable: true),
                    VideoCodec = table.Column<string>(type: "TEXT", nullable: false),
                    ContainerFormat = table.Column<string>(type: "TEXT", nullable: false),
                    FileSize = table.Column<long>(type: "INTEGER", nullable: true),
                    ApproximateFileSize = table.Column<long>(type: "INTEGER", nullable: true),
                    PlayerUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Protocol = table.Column<string>(type: "TEXT", nullable: false),
                    FragmentBaseUrl = table.Column<string>(type: "TEXT", nullable: false),
                    IsFromStart = table.Column<bool>(type: "INTEGER", nullable: true),
                    Preference = table.Column<int>(type: "INTEGER", nullable: true),
                    Language = table.Column<string>(type: "TEXT", nullable: false),
                    LanguagePreference = table.Column<int>(type: "INTEGER", nullable: true),
                    Quality = table.Column<double>(type: "REAL", nullable: true),
                    SourcePreference = table.Column<int>(type: "INTEGER", nullable: true),
                    StretchedRatio = table.Column<float>(type: "REAL", nullable: true),
                    NoResume = table.Column<bool>(type: "INTEGER", nullable: true),
                    HasDRM = table.Column<bool>(type: "INTEGER", nullable: true),
                    VideoDataDtoPK_ID = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormatDataDto", x => x.PK_ID);
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
                    LangCode = table.Column<string>(type: "TEXT", nullable: false),
                    SubtitleData = table.Column<string>(type: "TEXT", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "ThumbnailData",
                columns: table => new
                {
                    ID = table.Column<string>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    Preference = table.Column<int>(type: "INTEGER", nullable: true),
                    Width = table.Column<int>(type: "INTEGER", nullable: true),
                    Height = table.Column<int>(type: "INTEGER", nullable: true),
                    Resolution = table.Column<string>(type: "TEXT", nullable: true),
                    Filesize = table.Column<int>(type: "INTEGER", nullable: true),
                    VideoDataDtoPK_ID = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThumbnailData", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ThumbnailData_VideoDataDto_VideoDataDtoPK_ID",
                        column: x => x.VideoDataDtoPK_ID,
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
                name: "IX_ThumbnailData_VideoDataDtoPK_ID",
                table: "ThumbnailData",
                column: "VideoDataDtoPK_ID");
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
                name: "ThumbnailData");

            migrationBuilder.DropTable(
                name: "VideoDataDto");
        }
    }
}
