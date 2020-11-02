using AutoMapper;

namespace DesafioManipulaeHealth.Domain.AutomapperConfiguration
{
    public class MapperConfig
    {
        public static MapperConfiguration Configuration
        {
            get
            {
                return new MapperConfiguration(opt =>
                {
                    opt.AddProfile(typeof(VideoConfiguration));
                });
            }
        }
    }
}
;