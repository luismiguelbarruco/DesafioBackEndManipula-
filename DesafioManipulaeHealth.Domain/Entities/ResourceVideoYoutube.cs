namespace DesafioManipulaeHealth.Domain.Entities
{
    public class ResourceVideoYoutube
    {
        public int ResourceVideoYoutubeId { get; set; }
        public string ChannelId { get; set; } = string.Empty;
        public string Kind { get; set; } = string.Empty;
        public string PlaylistId { get; set; } = string.Empty;
        public string VideoId { get; set; } = string.Empty;
        public string ETag { get; set; } = string.Empty;
    }
}
