using DesafioManipulaeHealth.Domain.Entities;
using DesafioManipulaeHealth.Domain.Response;
using DesafioManipulaeHealth.Domain.Services;
using DesafioManipulaeHealth.Domain.ViewsModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioManipulaeHealth.Api.Controllers
{
    //[EnableCors("AllowSpecificOrigin")]
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class YouTubeController : ApiController
    {
        private readonly ILogger _logger;
        private readonly IApiYouTubeService _apiYouTubeService;

        public YouTubeController(ILogger logger, IApiYouTubeService apiYouTubeService)
        {
            _logger = logger;
            _apiYouTubeService = apiYouTubeService;
        }

        [HttpGet]
        public IResult Get()
        {
            try
            {
                var videos = _apiYouTubeService.GetVideos();

                return !videos.Any() ? ViewModelResult("Não há videos cadastrados") : ViewModelResult(videos);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Falha ao selecionar videos.");

                return ErrorResult("Falha ao selecionar videos");
            }
        }

        [Route("query")]
        [HttpGet]
        public IResult GetQuery([FromQuery] VideoYouSearch search)
        {
            try
            {
                var videos = Enumerable.Empty<VideoYoutube>();

                videos = _apiYouTubeService.Query(search);

                return !videos.Any() ? ViewModelResult("Não há videos cadastrados") : ViewModelResult(videos);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Falha ao selecionar videos.");

                return ErrorResult("Falha ao selecionar videos");
            }
        }

        [HttpPost]
        public async Task<IResult> Post([FromBody] InsertVideoYoutubeViewModel dadosVideoYoutubeViewModel)
        {
            try
            {
                var result = await _apiYouTubeService.InsertVideoAsync(dadosVideoYoutubeViewModel);

                return result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Falha ao cadastrar video.");

                return ErrorResult("Falha ao cadastrar video.");
            }
        }

        [HttpPut("{id}")]
        public IResult Put(int id, [FromBody] UpdateVideoYoutubeViewModel dadosVideoYoutubeViewModel)
        {
            try
            {
                var result = _apiYouTubeService.UpdateVideo(id, dadosVideoYoutubeViewModel);

                return result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Falha ao alterar video.");

                return ErrorResult("Falha ao alterar video.");
            }
        }

        [HttpDelete("{id}")]
        public IResult Delete(int id)
        {
            try
            {
                var result = _apiYouTubeService.DeleteVideo(id);

                return result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Falha ao deletar video.");

                return ErrorResult("Falha ao deletar video.");
            }
        }
    }
}
