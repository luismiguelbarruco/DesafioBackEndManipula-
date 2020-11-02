using AutoMapper;
using DesafioManipulaeHealth.Domain.AutomapperConfiguration;
using DesafioManipulaeHealth.Domain.Database;
using DesafioManipulaeHealth.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Threading.Tasks;

namespace DesafioManipulaeHealth.Application
{
    public class Program
    {
        private static ILogger _logger { get; set; } = new LoggerConfiguration().CreateLogger();

        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Buscando dados do youtube...");

            try
            {
                InserDataYouTubeAsync().Wait();
            }
            catch (AggregateException ex)
            {
                foreach (var e in ex.InnerExceptions)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }

            Console.WriteLine("Busca finalizada...");
            Console.ReadKey();
        }

        private static async Task InserDataYouTubeAsync()
        {
            using (var databaseContext = new DatabaseContext(new DbContextOptions<DatabaseContext>()))
            {
                try
                {
                    var configuration = new Mapper(MapperConfig.Configuration);

                    var dataYouTubeService = new ApiYouTubeService(_logger, databaseContext, configuration);

                    var result = await dataYouTubeService.ExecuteSearchAsync();

                    await dataYouTubeService.InsertDataYouTubeAsync(result);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}
