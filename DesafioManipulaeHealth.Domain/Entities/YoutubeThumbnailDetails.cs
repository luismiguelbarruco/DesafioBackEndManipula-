namespace DesafioManipulaeHealth.Domain.Entities
{
    public class YoutubeThumbnailDetails
    {
        public int YoutubeThumbnailDetailsId { get; set; }

        public int YoutubeThumbnailDefaultId { get; set; }
        public YoutubeThumbnail YoutubeThumbnailDefault { get; set; }

        public int YoutubeThumbnailHighId { get; set; }
        public YoutubeThumbnail YoutubeThumbnailHigh { get; set; }

        public int YoutubeThumbnailMaxresId { get; set; }
        public YoutubeThumbnail YoutubeThumbnailMaxres { get; set; }

        public int YoutubeThumbnailMediumId { get; set; }
        public YoutubeThumbnail YoutubeThumbnailMedium { get; set; }

        public int YoutubeThumbnailStandardId { get; set; }
        public YoutubeThumbnail YoutubeThumbnailStandard { get; set; }

        public string ETag { get; set; } = string.Empty;
    }
}
