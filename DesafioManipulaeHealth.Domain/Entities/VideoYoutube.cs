using DesafioManipulaeHealth.Domain.Enums;

namespace DesafioManipulaeHealth.Domain.Entities
{
    public class VideoYoutube
    {
        public int VideoYoutubeId { get; set; }
        public string ETag { get; set; } = string.Empty;
        public int ResourceVideoYoutubeId { get; set; }
        public ResourceVideoYoutube ResourceVideoYoutube { get; set; }
        public string Kind { get; set; } = string.Empty;
        public int YoutubeSearchResultSnippetId { get; set; }
        public YoutubeSearchResultSnippet YoutubeSearchResultSnippet { get; set; }
        public StatusCadastro Status { get; set; } = StatusCadastro.Normal;
    }
}
