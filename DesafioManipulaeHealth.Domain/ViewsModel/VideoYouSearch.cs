using Microsoft.AspNetCore.Mvc;
using System;

namespace DesafioManipulaeHealth.Domain.ViewsModel
{
    public class VideoYouSearch
    {
        [FromQuery(Name = "title")]
        public string Title { get; set; }

        [FromQuery(Name = "channelTitle")]
        public string ChannelTitle { get; set; }

        [FromQuery(Name = "publishedAfter")]
        public DateTime publishedAfter { get; set; }

        [FromQuery(Name = "q")]
        public string Q { get; set; }
    }
}
