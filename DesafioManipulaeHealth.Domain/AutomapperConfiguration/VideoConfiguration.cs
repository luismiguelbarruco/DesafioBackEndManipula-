using AutoMapper;
using DesafioManipulaeHealth.Domain.Entities;
using DesafioManipulaeHealth.Domain.ViewsModel;
using Google.Apis.YouTube.v3.Data;

namespace DesafioManipulaeHealth.Domain.AutomapperConfiguration
{
    public class VideoConfiguration : Profile
    {
        public VideoConfiguration()
        {
            CreateMap<SearchResult, VideoYoutube>()
                .ForMember(x => x.VideoYoutubeId, i => i.Ignore())
                .ForMember(x => x.ResourceVideoYoutubeId, i => i.Ignore())
                .ForMember(x => x.ResourceVideoYoutube, i => i.MapFrom(j => j.Id))
                .ForMember(x => x.YoutubeSearchResultSnippet, i => i.MapFrom(j => j.Snippet));

            CreateMap<ResourceId, ResourceVideoYoutube>()
                .ForMember(x => x.ResourceVideoYoutubeId, i => i.Ignore());

            CreateMap<SearchResultSnippet, YoutubeSearchResultSnippet>()
                .ForMember(x => x.YoutubeSearchResultSnippetId, i => i.Ignore())
                .ForMember(x => x.YoutubeThumbnailDetailsId, i => i.Ignore())
                .ForMember(x => x.YoutubeThumbnailDetails, i => i.MapFrom(j => j.Thumbnails));

            CreateMap<ThumbnailDetails, YoutubeThumbnailDetails>()
                .ForMember(x => x.YoutubeThumbnailDetailsId, i => i.Ignore())
                .ForMember(x => x.YoutubeThumbnailDefaultId, i => i.Ignore())
                .ForMember(x => x.YoutubeThumbnailHighId, i => i.Ignore())
                .ForMember(x => x.YoutubeThumbnailMediumId, i => i.Ignore())
                .ForMember(x => x.YoutubeThumbnailStandardId, i => i.Ignore())
                .ForMember(x => x.YoutubeThumbnailDefault, i => i.MapFrom(j => j.Default__))
                .ForMember(x => x.YoutubeThumbnailHigh, i => i.MapFrom(j => j.High))
                .ForMember(x => x.YoutubeThumbnailMaxres, i => i.MapFrom(j => j.Maxres))
                .ForMember(x => x.YoutubeThumbnailMedium, i => i.MapFrom(j => j.Medium))
                .ForMember(x => x.YoutubeThumbnailStandard, i => i.MapFrom(j => j.Standard))
                .ForMember(x => x.YoutubeThumbnailDefault, i => i.NullSubstitute(new Thumbnail()))
                .ForMember(x => x.YoutubeThumbnailHigh, i => i.NullSubstitute(new Thumbnail()))
                .ForMember(x => x.YoutubeThumbnailMaxres, i => i.NullSubstitute(new Thumbnail()))
                .ForMember(x => x.YoutubeThumbnailMedium, i => i.NullSubstitute(new Thumbnail()))
                .ForMember(x => x.YoutubeThumbnailStandard, i => i.NullSubstitute(new Thumbnail()));

            CreateMap<Thumbnail, YoutubeThumbnail>()
                .ForMember(x => x.YoutubeThumbnailId, i => i.Ignore());

            CreateMap<UpdateVideoYoutubeViewModel, VideoYoutube>()
                .ForMember(x => x.YoutubeSearchResultSnippetId, i => i.MapFrom(x => x.YoutubeSearchResultSnippet.YoutubeSearchResultSnippetId))
                .ForPath(x => x.YoutubeSearchResultSnippet.YoutubeThumbnailDetailsId, i => i.MapFrom(x => x.YoutubeSearchResultSnippet.YoutubeThumbnailDetails.YoutubeThumbnailDetailsId))
                .ForPath(x => x.YoutubeSearchResultSnippet.YoutubeThumbnailDetails.YoutubeThumbnailDefault, i => i.MapFrom(j => j.YoutubeSearchResultSnippet.YoutubeThumbnailDetails.YoutubeThumbnailDefault))
                .ForPath(x => x.YoutubeSearchResultSnippet.YoutubeThumbnailDetails.YoutubeThumbnailHigh, i => i.MapFrom(j => j.YoutubeSearchResultSnippet.YoutubeThumbnailDetails.YoutubeThumbnailDefault))
                .ForPath(x => x.YoutubeSearchResultSnippet.YoutubeThumbnailDetails.YoutubeThumbnailMaxres, i => i.MapFrom(j => j.YoutubeSearchResultSnippet.YoutubeThumbnailDetails.YoutubeThumbnailMaxres))
                .ForPath(x => x.YoutubeSearchResultSnippet.YoutubeThumbnailDetails.YoutubeThumbnailMedium, i => i.MapFrom(j => j.YoutubeSearchResultSnippet.YoutubeThumbnailDetails.YoutubeThumbnailMedium))
                .ForPath(x => x.YoutubeSearchResultSnippet.YoutubeThumbnailDetails.YoutubeThumbnailStandard, i => i.MapFrom(j => j.YoutubeSearchResultSnippet.YoutubeThumbnailDetails.YoutubeThumbnailStandard))
                .ForPath(x => x.YoutubeSearchResultSnippet.YoutubeThumbnailDetails.YoutubeThumbnailDefaultId, i => i.MapFrom(x => x.YoutubeSearchResultSnippet.YoutubeThumbnailDetails.YoutubeThumbnailDefault.YoutubeThumbnailId))
                .ForPath(x => x.YoutubeSearchResultSnippet.YoutubeThumbnailDetails.YoutubeThumbnailHighId, i => i.MapFrom(x => x.YoutubeSearchResultSnippet.YoutubeThumbnailDetails.YoutubeThumbnailDefault.YoutubeThumbnailId))
                .ForPath(x => x.YoutubeSearchResultSnippet.YoutubeThumbnailDetails.YoutubeThumbnailMediumId, i => i.MapFrom(x => x.YoutubeSearchResultSnippet.YoutubeThumbnailDetails.YoutubeThumbnailDefault.YoutubeThumbnailId))
                .ForPath(x => x.YoutubeSearchResultSnippet.YoutubeThumbnailDetails.YoutubeThumbnailMaxresId, i => i.MapFrom(x => x.YoutubeSearchResultSnippet.YoutubeThumbnailDetails.YoutubeThumbnailDefault.YoutubeThumbnailId))
                .ForPath(x => x.YoutubeSearchResultSnippet.YoutubeThumbnailDetails.YoutubeThumbnailStandardId, i => i.MapFrom(x => x.YoutubeSearchResultSnippet.YoutubeThumbnailDetails.YoutubeThumbnailDefault.YoutubeThumbnailId));

            CreateMap<InsertVideoYoutubeViewModel, VideoYoutube>()
                .ForMember(x => x.VideoYoutubeId, i => i.Ignore())
                .ForMember(x => x.YoutubeSearchResultSnippetId, i => i.Ignore())
                .ForPath(x => x.YoutubeSearchResultSnippet.YoutubeThumbnailDetailsId, i => i.Ignore())
                .ForPath(x => x.YoutubeSearchResultSnippet.YoutubeThumbnailDetails.YoutubeThumbnailDetailsId, i => i.Ignore())
                .ForPath(x => x.YoutubeSearchResultSnippet.YoutubeThumbnailDetails.YoutubeThumbnailDetailsId, i => i.Ignore())
                .ForPath(x => x.YoutubeSearchResultSnippet.YoutubeThumbnailDetails.YoutubeThumbnailHighId, i => i.Ignore())
                .ForPath(x => x.YoutubeSearchResultSnippet.YoutubeThumbnailDetails.YoutubeThumbnailMaxresId, i => i.Ignore())
                .ForPath(x => x.YoutubeSearchResultSnippet.YoutubeThumbnailDetails.YoutubeThumbnailMediumId, i => i.Ignore())
                .ForPath(x => x.YoutubeSearchResultSnippet.YoutubeThumbnailDetails.YoutubeThumbnailStandardId, i => i.Ignore())
                .ForPath(x => x.YoutubeSearchResultSnippet.YoutubeThumbnailDetails.YoutubeThumbnailDefault, i => i.MapFrom(j => j.YoutubeSearchResultSnippet.YoutubeThumbnailDetails.YoutubeThumbnailDefault))
                .ForPath(x => x.YoutubeSearchResultSnippet.YoutubeThumbnailDetails.YoutubeThumbnailHigh, i => i.MapFrom(j => j.YoutubeSearchResultSnippet.YoutubeThumbnailDetails.YoutubeThumbnailDefault))
                .ForPath(x => x.YoutubeSearchResultSnippet.YoutubeThumbnailDetails.YoutubeThumbnailMaxres, i => i.MapFrom(j => j.YoutubeSearchResultSnippet.YoutubeThumbnailDetails.YoutubeThumbnailMaxres))
                .ForPath(x => x.YoutubeSearchResultSnippet.YoutubeThumbnailDetails.YoutubeThumbnailMedium, i => i.MapFrom(j => j.YoutubeSearchResultSnippet.YoutubeThumbnailDetails.YoutubeThumbnailMedium))
                .ForPath(x => x.YoutubeSearchResultSnippet.YoutubeThumbnailDetails.YoutubeThumbnailStandard, i => i.MapFrom(j => j.YoutubeSearchResultSnippet.YoutubeThumbnailDetails.YoutubeThumbnailStandard))
                .ForPath(x => x.YoutubeSearchResultSnippet.YoutubeThumbnailDetails.YoutubeThumbnailDefaultId, i => i.Ignore())
                .ForPath(x => x.YoutubeSearchResultSnippet.YoutubeThumbnailDetails.YoutubeThumbnailHighId, i => i.Ignore())
                .ForPath(x => x.YoutubeSearchResultSnippet.YoutubeThumbnailDetails.YoutubeThumbnailMediumId, i => i.Ignore())
                .ForPath(x => x.YoutubeSearchResultSnippet.YoutubeThumbnailDetails.YoutubeThumbnailMaxresId, i => i.Ignore())
                .ForPath(x => x.YoutubeSearchResultSnippet.YoutubeThumbnailDetails.YoutubeThumbnailStandardId, i => i.Ignore());
        }
    }
}
