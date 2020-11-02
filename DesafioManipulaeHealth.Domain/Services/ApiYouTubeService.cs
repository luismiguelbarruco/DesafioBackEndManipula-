using AutoMapper;
using DesafioManipulaeHealth.Domain.Database;
using DesafioManipulaeHealth.Domain.Entities;
using DesafioManipulaeHealth.Domain.Enums;
using DesafioManipulaeHealth.Domain.Response;
using DesafioManipulaeHealth.Domain.ViewsModel;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioManipulaeHealth.Domain.Queries;

namespace DesafioManipulaeHealth.Domain.Services
{
    public class ApiYouTubeService : IApiYouTubeService
    {
        private readonly ILogger _logger;
        private DatabaseContext _database;
        private IMapper _mapper;

        public ApiYouTubeService(ILogger logger, DatabaseContext database, IMapper mapper)
        {
            _logger = logger;
            _database = database;
            _mapper = mapper;
        }

        public async Task<IList<SearchResult>> ExecuteSearchAsync()
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApplicationName = "Discovery Sample",
                ApiKey = "AIzaSyAQtBgDrGu01NRrKUaaTfJwk5dBndZ4RGo"
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = "manipulação";
            searchListRequest.RegionCode = "BR";
            searchListRequest.MaxResults = 200;

            var searchListResponse = await searchListRequest.ExecuteAsync();

            return searchListResponse.Items;
        }

        public async Task<IResult> InsertDataYouTubeAsync(IList<SearchResult> searcListhResults)
        {
            try
            {
                var results = _mapper.Map<IList<VideoYoutube>>(searcListhResults);

                await _database.VideosYoutube.AddRangeAsync(results);

                await _database.SaveChangesAsync();

                return new ServiceResult("Videos cadastrados com sucesso!");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Falha ao inserir videos.");

                throw;
            }            
        }

        public async Task<IResult> InsertVideoAsync(InsertVideoYoutubeViewModel videoYoutubeViewModel)
        {
            try
            {
                var video = _mapper.Map<VideoYoutube>(videoYoutubeViewModel);

                await _database.VideosYoutube.AddAsync(video);

                await _database.SaveChangesAsync();

                return new ServiceResult("Video cadastrado com sucesso!", video);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Falha ao inserir video.");

                throw;
            }
        }

        public IResult UpdateVideo(int id, UpdateVideoYoutubeViewModel videoYoutubeViewModel)
        {
            try
            {
                var video = _database.VideosYoutube.AsNoTracking().FirstOrDefault(v => v.VideoYoutubeId == id);

                if (video == null)
                    return new ServiceResult(false, "Video não encontrado!");

                video = _mapper.Map<VideoYoutube>(videoYoutubeViewModel);

                _database.VideosYoutube.Update(video);

                _database.SaveChanges();

                return new ServiceResult("Video atualizado com sucesso!", video);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Falha ao atualizar video.");

                throw;
            }
        }

        public IResult DeleteVideo(int id)
        {
            try
            {
                var video = _database.VideosYoutube.AsNoTracking().FirstOrDefault(v => v.VideoYoutubeId == id);

                if (video == null)
                    return new ServiceResult(false, "Video não encontrado!");

                video.Status = StatusCadastro.Excluido;

                _database.Update(video);

                _database.SaveChanges();

                return new ServiceResult("Video excluido com sucesso!");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Falha ao excluir video.");

                throw;
            }
        }

        public IEnumerable<VideoYoutube> GetVideos()
        {
            try
            {
                var videos = _database.VideosYoutube
                    .Include(x => x.ResourceVideoYoutube)
                    .Include(x => x.YoutubeSearchResultSnippet).ThenInclude(x => x.YoutubeThumbnailDetails).ThenInclude(k =>  k.YoutubeThumbnailDefault)
                    .Include(x => x.YoutubeSearchResultSnippet).ThenInclude(x => x.YoutubeThumbnailDetails).ThenInclude(k => k.YoutubeThumbnailHigh)
                    .Include(x => x.YoutubeSearchResultSnippet).ThenInclude(x => x.YoutubeThumbnailDetails).ThenInclude(k => k.YoutubeThumbnailMaxres)
                    .Include(x => x.YoutubeSearchResultSnippet).ThenInclude(x => x.YoutubeThumbnailDetails).ThenInclude(k => k.YoutubeThumbnailMedium)
                    .Include(x => x.YoutubeSearchResultSnippet).ThenInclude(x => x.YoutubeThumbnailDetails).ThenInclude(k => k.YoutubeThumbnailStandard)
                    .AsNoTracking()
                    .AsEnumerable();

                return videos;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Falha ao selecionar videos.");

                throw;
            }
        }

        public IEnumerable<VideoYoutube> Query(VideoYouSearch search)
        {
            try
            {
                var videos = _database.VideosYoutube
                    .Include(x => x.ResourceVideoYoutube)
                    .Include(x => x.YoutubeSearchResultSnippet).ThenInclude(x => x.YoutubeThumbnailDetails).ThenInclude(k => k.YoutubeThumbnailDefault)
                    .Include(x => x.YoutubeSearchResultSnippet).ThenInclude(x => x.YoutubeThumbnailDetails).ThenInclude(k => k.YoutubeThumbnailHigh)
                    .Include(x => x.YoutubeSearchResultSnippet).ThenInclude(x => x.YoutubeThumbnailDetails).ThenInclude(k => k.YoutubeThumbnailMaxres)
                    .Include(x => x.YoutubeSearchResultSnippet).ThenInclude(x => x.YoutubeThumbnailDetails).ThenInclude(k => k.YoutubeThumbnailMedium)
                    .Include(x => x.YoutubeSearchResultSnippet).ThenInclude(x => x.YoutubeThumbnailDetails).ThenInclude(k => k.YoutubeThumbnailStandard)
                    .AsNoTracking()
                    .Where(VideoYoutubeQuery.CreateQueryCondition(search))
                    .AsEnumerable();

                return videos;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Falha ao selecionar videos.");

                throw;
            }
        }
    }
}
