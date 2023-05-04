using MirrorTube.Common.Models.Database.UserData;
using YoutubeDLSharp.Metadata;

namespace MirrorTube.API.Helpers
{
    internal class VideoInfoFormatter
    {
        private static readonly HttpClient _httpClient = new HttpClient() {Timeout = TimeSpan.FromSeconds(45) };

        internal static async Task<List<VideoSubtitle>> GetSubtitleData(Dictionary<string, SubtitleData[]> input)
        {
            List<VideoSubtitle> output = new List<VideoSubtitle>();
            foreach (var langList in input)
            {
                foreach (var sub in langList.Value)
                {

                    var subData = new VideoSubtitle()
                    {
                        SubtitleLanguage = sub.Name, 
                    };
                    Enum.TryParse(sub.Ext, true, out SubtitleType subType);
                    subData.SubtitleType = subType;

                    try
                    {
                        var data = await _httpClient.GetStringAsync(sub.Url);
                        subData.SubtitleData = data;
                    }
                    catch (Exception) { continue; }
                    output.Add(subData);
                }
            }
            return output;
        }

        internal static VideoFormat GetFormatData(string? formatString, IEnumerable<FormatData> allFormats, string VideoID)
        {
            //Format_ID can be appended with a dash and a number, like so: 248+248-1
            var output = new VideoFormat();
            output.VideoID = VideoID;
            if (formatString == null) return new VideoFormat();
            var splitIds = formatString.Split('+');
            if (splitIds.Length > 0)
            {
                var formats = allFormats.Where(r => splitIds.Contains(r.FormatId));
                foreach (var format in formats)
                {
                    if (format.AudioBitrate != null)//audio format
                    {
                        output.AudioBitrate = format.AudioBitrate;
                        output.AudioCodec = format.AudioCodec;
                        output.AudioSamplingRate = format.AudioSamplingRate;
                        output.AudioChannels = (short?)format.AudioChannels;
                    }
                    else if (format.VideoBitrate != null)//video format
                    {
                        output.DynamicRange = format.DynamicRange;
                        output.VideoBitrate = format.VideoBitrate;
                        output.FrameRate = format.FrameRate;
                        output.VideoCodec = format.VideoCodec;
                        output.Resolution = format.Resolution;
                        output.Width = format.Width;
                        output.Height = format.Height;
                        output.FriendlyVideoResolution = format.FormatNote;
                    }
                    else { }
                }
            }
            return output;
        }

        internal static VideoSeries? GetSeriesData(VideoData data)
        {
            var series = new VideoSeries();
            series.VideoId = data.ID;
            series.Series = data.Series;
            series.SeriesId = data.SeriesId;
            series.Season = data.Season;
            series.SeasonNumber = data.SeasonNumber;
            series.SeasonId = data.SeasonId;
            series.Episode = data.Episode;
            series.EpisodeNumber = data.EpisodeNumber;
            series.EpisodeId = data.EpisodeId;

            var seriesData = $"{data.Series}{data.SeriesId}{data.Season}{data.SeasonNumber}{data.SeasonId}{data.Episode}{data.EpisodeNumber}{data.EpisodeId}";
            if (!string.IsNullOrEmpty(seriesData))
            {
                return series;
            }
            else { return null; }
        }

        internal static VideoTrack? GetTrackData(VideoData data)
        {
            var track = new VideoTrack();
            track.VideoID = data.ID;
            track.Track = data.Track;
            track.TrackNumber = data.TrackNumber;
            track.TrackId = data.TrackId;
            track.Artist = data.Artist;
            track.Genre = data.Genre;
            track.Album = data.Album;
            track.AlbumType = data.AlbumType;
            track.AlbumArtist = data.AlbumArtist;
            track.DiscNumber = data.DiscNumber;
            track.ReleaseYear = data.ReleaseYear;
            track.Composer = data.Composer;

            var trackData = $"{data.Track}{data.TrackNumber}{data.TrackId}{data.Artist}{data.Genre}{data.Album}{data.AlbumType}{data.AlbumArtist}{data.DiscNumber}{data.ReleaseYear}{data.Composer}";
            if (!string.IsNullOrEmpty(trackData))
            {
                return track;
            }
            else { return null; }
        }
    }
}
