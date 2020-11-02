using DesafioManipulaeHealth.Domain.Entities;
using DesafioManipulaeHealth.Domain.Response;
using DesafioManipulaeHealth.Domain.ViewsModel;
using Google.Apis.YouTube.v3.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioManipulaeHealth.Domain.Services
{
    public interface IApiYouTubeService
    {
        IEnumerable<VideoYoutube> GetVideos();
        IEnumerable<VideoYoutube> Query(VideoYouSearch search);
        Task<IList<SearchResult>> ExecuteSearchAsync();
        Task<IResult> InsertDataYouTubeAsync(IList<SearchResult> searcListhResults);
        Task<IResult> InsertVideoAsync(InsertVideoYoutubeViewModel videoYoutubeViewModel);
        IResult UpdateVideo(int id, UpdateVideoYoutubeViewModel videoYoutubeViewModel);
        IResult DeleteVideo(int id);
    }
}
