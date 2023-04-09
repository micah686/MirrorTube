--Collection
CREATE TABLE videoChapters(
	pk_chapterID BIGINT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	uniqueVideoId TEXT UNIQUE,
	startTime FLOAT,
	endTime FLOAT,
	title TEXT,
	chapterDescription TEXT,
	--ADD FOREIGN KEY TO VIDEOS
);

--Collection
CREATE TABLE videoComments(
	pk_commentID BIGINT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	videoID TEXT,
	author TEXT,
	authorID TEXT,
	authorThumbnail BYTEA,---------------------------------------------------CREATE SEPERATE TABLE AS LOOKUP?
	htmlComment TEXT,
	textComment TEXT,
	commentTimestamp TIMESTAMPZ,
	parentComment TEXT,
	likeCount INT,
	dislikeCount INT,
	isFavorited BOOL,
	authorIsUploader BOOL
);

--lookup table for author image
CREATE TABLE commentAuthorProfilePic(
	authorID TEXT PRIMARY KEY,
	authorThumbnail BYTEA
);


CREATE TABLE generatedCaptions(
	uniqueVideoId TEXT PRIMARY KEY,
	subtitleData TEXT,
	subtitleType TEXT
)

CREATE TABLE subtitles(
	uniqueVideoId TEXT PRIMARY KEY,
	subtitleData TEXT,
	subtitleType TEXT
)



CREATE TABLE videoFormat(
	pk_videoFormat BIGINT GENERATED ALWAYS AS IDENTITY PRIMARY KEY, --remove this
	videoId TEXT PRIMARY KEY, --don't make PK, use contraint to make a foreign key
	--Audio
	audioBitrate FLOAT,
	audioCodec TEXT,
	audioSamplingRate FLOAT,
	audioChannels smallint,
	--Video
	dynamicRange TEXT,
	videoBitrate FLOAT,
	framerate FLOAT,
	videoCodec TEXT,
	resolution TEXT,
	width INT,
	height INT,
	friendlyVideoResolution TEXT
)

CREATE TABLE videoSeries(
	videoId TEXT PRIMARY KEY,--set this as a foreign key (but also PRIMARY KEY)
	series TEXT,
	seriesID TEXT,
	season TEXT,
	seasonNumber INT,
	seasonID TEXT,
	episode TEXT,
	episodeNumber INT,
	episodeID TEXT
)

CREATE TABLE videoTracks(
	videoId TEXT PRIMARY KEY,--set this as a foreign key (but also PRIMARY KEY)
	track TEXT,
	trackNumber INT,
	trackID TEXT,
	artist TEXT,
	genre TEXT,
	album TEXT,
	albumType TEXT,
	albumArtist TEXT,
	discNumber INT,
	releaseYear TEXT,
	composer TEXT
)



CREATE TABLE videos(
	uniqueVideoId TEXT PRIMARY KEY,
	metadataScrapeDate TIMESTAMPZ,
	videoID TEXT,
	ageLimit SMALLINT,
	averageRating FLOAT,
	videoDescription TEXT,
	likeCount BIGINT,
	dislikeCount BIGINT,
	duration FLOAT,
	extension TEXT,
	modifiedDate TIMESTAMPZ,
	modifiedDateTimestamp TIMESTAMPZ,
	uploadDate TIMESTAMPZ,
	uploadDateTimestamp TIMESTAMPZ,
	title TEXT,
	wasLive BOOL,
	webpageUrl TEXT,
	viewCount BIGINT,
	commentCount BIGINT,
	channelID TEXT,
	channelURL TEXT,
	chapterID TEXT,
	extractorKey TEXT,



	--AutomaticCaptions
	--Subtitles
	--Chapters
	--Comments
	
		
	"Cast" TEXT[],
	Categories TEXT[],
	Tags TEXT[],
	
	
	

	--FormatInfo
	--SeriesData
	--TrackData
)

CREATE TABLE channels(
	channelID TEXT PRIMARY KEY,
	channelURL TEXT,
	channelName TEXT,
	channelFollowerCount BIGINT,
	channelDescription TEXT
)
