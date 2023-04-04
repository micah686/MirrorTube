create table ChapterDataDto(
	UniqueVideoId varchar(40) primary key,
	StartTime float,
	EndTime float,
	Title text,
	Description text
)

create table CommentDataDto(
	UniqueVideoId varchar(40) primary key,
	CommentID text,
	Author text,
	AuthorID text,
	AuthorThumbnail bytea,
	HtmlComment text,
	TextComment text,
	CommentTimestamp timestamp,
	ParentComment text,
	LikeCount int,
	DislikeCount int,
	IsFavorited bool,
	AuthorIsUploader bool
)

create table FormatDataDto(
	VideoId text primary key,
	--Audio
	AudioBitrate float,
	AudioCodec text,
	AudioSamplingRate float,
	AudioChannels smallint,
	--Video
	DynamicRange text,
	VideoBitrate float,
	Framerate float,
	VideoCodec text,
	Resolution text,
	Width int,
	Heigh int,
	FriendlyVideoResolution text
)

create table SeriesDataDto(
	VideoId text primary key,
	Series text,
	seriesID text,
	Season text,
	SeasonNumber int,
	SeasonID text,
	Episode text,
	EpisodeNumber int,
	EpisodeID text
)


CREATE TYPE subtitleType AS ENUM ('Unknown', 'Vtt', 'Ttml', 'Srv3', 'Srv2', 'Srv1', 'Json3');
create table SubtitleDataDto(
	UniqueVideoId varchar(40) primary key,
	SubtitleData text,
	SubtitleType subtitleType
)

create table TrackDataDto(
	VideoId text primary key,
	Track text,
	TrackNumber int,
	TrackID text,
	Artist text,
	Genre text,
	Album text,
	AlbumType text,
	AlbumArtist text,
	DiscNumber int,
	ReleaseYear varchar(4),
	Composer text
)

create table VideoDataDto(
	UniqueVideoId varchar(40) primary key,
	MetadataScrapeDate timestamp,
	--AutomaticCaptions
	--Subtitles
	--Chapters
	--Comments
	ExtractorKey text,
	AgeLimit smallint,
	AverageRating float,
	"Cast" text[],
	Categories text[],
	Tags text[],
	Channel text,
	ChannelFollowerCount bigint,
	ChannelID text,
	ChannelURL text,
	Chapter text,
	ChapterNumber int,
	ChapterID text,
	CommentCount bigint,
	Description text,
	DislikeCount bigint,
	Duration float,
	Extension varchar(5),
	ModifiedDate timestamp,
	ModifiedDateTimestamp timestamp,
	Timestamp timestamp,
	Title text,
	UploadDate timestamp,
	Uploader text,
	UploaderID text,
	UploaderURL text,
	VideoID text,
	ViewCount bigint,
	WasLive bool,
	WebpageUrl text
	--FormatInfo
	--SeriesData
	--TrackData
)