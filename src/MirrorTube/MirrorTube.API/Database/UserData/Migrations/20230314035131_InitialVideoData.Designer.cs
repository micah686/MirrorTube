﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MirrorTube.API.Database.UserData;

#nullable disable

namespace MirrorTube.API.Database.UserData.Migrations
{
    [DbContext(typeof(UserDatadbContext))]
    [Migration("20230314035131_InitialVideoData")]
    partial class InitialVideoData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("MirrorTube.API.Database.UserData.ModelsDto.YtDlp.FormatDataDto", b =>
                {
                    b.Property<string>("PK_ID")
                        .HasColumnType("TEXT");

                    b.Property<long?>("ApproximateFileSize")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("AudioBitrate")
                        .HasColumnType("REAL");

                    b.Property<int?>("AudioChannels")
                        .HasColumnType("INTEGER");

                    b.Property<string>("AudioCodec")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double?>("AudioSamplingRate")
                        .HasColumnType("REAL");

                    b.Property<double?>("Bitrate")
                        .HasColumnType("REAL");

                    b.Property<string>("ContainerFormat")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("DynamicRange")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long?>("FileSize")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Format")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FormatId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FormatNote")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FragmentBaseUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float?>("FrameRate")
                        .HasColumnType("REAL");

                    b.Property<bool?>("HasDRM")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Height")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("IsFromStart")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("LanguagePreference")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ManifestUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool?>("NoResume")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PlayerUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("Preference")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Protocol")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double?>("Quality")
                        .HasColumnType("REAL");

                    b.Property<string>("Resolution")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("SourcePreference")
                        .HasColumnType("INTEGER");

                    b.Property<float?>("StretchedRatio")
                        .HasColumnType("REAL");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double?>("VideoBitrate")
                        .HasColumnType("REAL");

                    b.Property<string>("VideoCodec")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("VideoDataDtoPK_ID")
                        .HasColumnType("TEXT");

                    b.Property<string>("VideoId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("Width")
                        .HasColumnType("INTEGER");

                    b.HasKey("PK_ID");

                    b.HasIndex("VideoDataDtoPK_ID");

                    b.ToTable("FormatDataDto");
                });

            modelBuilder.Entity("MirrorTube.API.Database.UserData.ModelsDto.YtDlp.SubtitleDataDto", b =>
                {
                    b.Property<string>("PK_ID")
                        .HasColumnType("TEXT");

                    b.Property<string>("LangCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SubtitleData")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SubtitleType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("VideoId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("automatic_captions")
                        .HasColumnType("TEXT");

                    b.Property<string>("subtitles")
                        .HasColumnType("TEXT");

                    b.HasKey("PK_ID");

                    b.HasIndex("automatic_captions");

                    b.HasIndex("subtitles");

                    b.ToTable("SubtitleDataDto");
                });

            modelBuilder.Entity("MirrorTube.API.Database.UserData.ModelsDto.YtDlp.VideoDataDto", b =>
                {
                    b.Property<string>("PK_ID")
                        .HasColumnType("TEXT");

                    b.Property<int?>("AgeLimit")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Album")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AlbumArtist")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AlbumType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AltTitle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Artist")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("Availability")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("AverageRating")
                        .HasColumnType("REAL");

                    b.Property<string>("Cast")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Categories")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Channel")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long?>("ChannelFollowerCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ChannelID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ChannelUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Chapter")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ChapterId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("ChapterNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Chapters")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long?>("CommentCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Composer")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long?>("ConcurrentViewCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Creator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Direct")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DiscNumber")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("DislikeCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DisplayID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float?>("Duration")
                        .HasColumnType("REAL");

                    b.Property<float?>("EndTime")
                        .HasColumnType("REAL");

                    b.Property<string>("Episode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EpisodeId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("EpisodeNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Extractor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ExtractorKey")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Format")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FormatID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool?>("IsLive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("License")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long?>("LikeCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LiveStatus")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ModifiedTimestamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("PlayableInEmbed")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PlayerUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ReleaseTimestamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("ReleaseYear")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long?>("RepostCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ResultType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Season")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SeasonId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("SeasonNumber")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("SectionEnd")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("SectionStart")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Series")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SeriesId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float?>("StartTime")
                        .HasColumnType("REAL");

                    b.Property<long?>("StoryboardFragmentColumns")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("StoryboardFragmentRows")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Tags")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Thumbnail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Timestamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Track")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TrackId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("TrackNumber")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("UploadDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Uploader")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UploaderID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UploaderUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long?>("ViewCount")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("WasLive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("WebpageUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PK_ID");

                    b.ToTable("VideoDataDto");
                });

            modelBuilder.Entity("YoutubeDLSharp.Metadata.CommentData", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Author")
                        .HasColumnType("TEXT");

                    b.Property<string>("AuthorID")
                        .HasColumnType("TEXT");

                    b.Property<bool?>("AuthorIsUploader")
                        .HasColumnType("INTEGER");

                    b.Property<string>("AuthorThumbnail")
                        .HasColumnType("TEXT");

                    b.Property<int?>("DislikeCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Html")
                        .HasColumnType("TEXT");

                    b.Property<bool?>("IsFavorited")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("LikeCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Parent")
                        .HasColumnType("TEXT");

                    b.Property<string>("Text")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("VideoDataDtoPK_ID")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("VideoDataDtoPK_ID");

                    b.ToTable("CommentData");
                });

            modelBuilder.Entity("YoutubeDLSharp.Metadata.ThumbnailData", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Filesize")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Height")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Preference")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Resolution")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.Property<string>("VideoDataDtoPK_ID")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Width")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("VideoDataDtoPK_ID");

                    b.ToTable("ThumbnailData");
                });

            modelBuilder.Entity("MirrorTube.API.Database.UserData.ModelsDto.YtDlp.FormatDataDto", b =>
                {
                    b.HasOne("MirrorTube.API.Database.UserData.ModelsDto.YtDlp.VideoDataDto", null)
                        .WithMany("Formats")
                        .HasForeignKey("VideoDataDtoPK_ID");
                });

            modelBuilder.Entity("MirrorTube.API.Database.UserData.ModelsDto.YtDlp.SubtitleDataDto", b =>
                {
                    b.HasOne("MirrorTube.API.Database.UserData.ModelsDto.YtDlp.VideoDataDto", null)
                        .WithMany("AutomaticCaptions")
                        .HasForeignKey("automatic_captions");

                    b.HasOne("MirrorTube.API.Database.UserData.ModelsDto.YtDlp.VideoDataDto", null)
                        .WithMany("Subtitles")
                        .HasForeignKey("subtitles");
                });

            modelBuilder.Entity("YoutubeDLSharp.Metadata.CommentData", b =>
                {
                    b.HasOne("MirrorTube.API.Database.UserData.ModelsDto.YtDlp.VideoDataDto", null)
                        .WithMany("Comments")
                        .HasForeignKey("VideoDataDtoPK_ID");
                });

            modelBuilder.Entity("YoutubeDLSharp.Metadata.ThumbnailData", b =>
                {
                    b.HasOne("MirrorTube.API.Database.UserData.ModelsDto.YtDlp.VideoDataDto", null)
                        .WithMany("Thumbnails")
                        .HasForeignKey("VideoDataDtoPK_ID");
                });

            modelBuilder.Entity("MirrorTube.API.Database.UserData.ModelsDto.YtDlp.VideoDataDto", b =>
                {
                    b.Navigation("AutomaticCaptions");

                    b.Navigation("Comments");

                    b.Navigation("Formats");

                    b.Navigation("Subtitles");

                    b.Navigation("Thumbnails");
                });
#pragma warning restore 612, 618
        }
    }
}
