namespace DesafioManipulaeHealth.Domain.Entities
{
    public class YoutubeThumbnail
    {
        public int YoutubeThumbnailId { get; set; }
        public long? Height { get; set; }
        public string Url { get; set; } = string.Empty;
        public long? Width { get; set; }
        public string ETag { get; set; } = string.Empty;
    }
}
