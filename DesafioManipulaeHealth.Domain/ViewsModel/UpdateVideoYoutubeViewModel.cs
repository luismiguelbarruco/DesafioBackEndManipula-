using DesafioManipulaeHealth.Domain.Entities;
using DesafioManipulaeHealth.Domain.Enums;

namespace DesafioManipulaeHealth.Domain.ViewsModel
{
    public class UpdateVideoYoutubeViewModel
    {
        public int VideoYoutubeId { get; set; }
        public string ETag { get; set; } = string.Empty;
        public ResourceVideoYoutube ResourceVideoYoutube { get; set; }
        public string Kind { get; set; } = string.Empty;
        public YoutubeSearchResultSnippet YoutubeSearchResultSnippet { get; set; }
        public StatusCadastro Status { get; set; } = StatusCadastro.Normal;
    }
}