namespace DesafioManipulaeHealth.Domain.Entities
{
    public class YoutubeSearchResultSnippet
    {
        public int YoutubeSearchResultSnippetId { get; set; }
        public string ChannelId { get; set; }
        public string ChannelTitle { get; set; }
        public string Description { get; set; }
        public string LiveBroadcastContent { get; set; }
        public string PublishedAt { get; set; }
        public int YoutubeThumbnailDetailsId { get; set; }
        public YoutubeThumbnailDetails YoutubeThumbnailDetails { get; set; }
        public string Title { get; set; }
        public string ETag { get; set; }
    }
}
