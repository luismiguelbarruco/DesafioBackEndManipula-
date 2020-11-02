using DesafioManipulaeHealth.Domain.Entities;
using DesafioManipulaeHealth.Domain.ViewsModel;
using System;
using System.Linq.Expressions;

namespace DesafioManipulaeHealth.Domain.Queries
{
    public class VideoYoutubeQuery : QueryBase
    {
        public static Expression<Func<VideoYoutube, bool>> CreateQueryCondition(VideoYouSearch search)
        {
            Expression<Func<VideoYoutube, bool>> expression = default;
            Expression<Func<VideoYoutube, bool>> expressionTitle = x => x.YoutubeSearchResultSnippet.Title == search.Title;
            Expression<Func<VideoYoutube, bool>> expressionChanel = x => x.YoutubeSearchResultSnippet.ChannelTitle == search.ChannelTitle;
            Expression<Func<VideoYoutube, bool>> expressionPublishedAfter = x => DateTime.Parse(x.YoutubeSearchResultSnippet.PublishedAt) >= search.publishedAfter;
            Expression<Func<VideoYoutube, bool>> expressionQ = CreateParameterQ(search.Q);

            if (!string.IsNullOrEmpty(search.Title))
                expression = expressionTitle;

            if (!string.IsNullOrEmpty(search.ChannelTitle))
                expression = expression == null ? expressionChanel : UpdateParameter(expressionChanel, expression.Parameters[0]);

            if (search.publishedAfter != default)
                expression = expression == null ? expressionPublishedAfter : UpdateParameter(expressionPublishedAfter, expression.Parameters[0]);

            if (!string.IsNullOrEmpty(search.Q))
                expression = expression == null ? expressionQ : UpdateParameter(expressionQ, expression.Parameters[0]);

            return expression;
        }

        private static Expression<Func<VideoYoutube, bool>> CreateParameterQ(string parameterQ)
        {
            var parameters = parameterQ.Split(';');

            Expression<Func<VideoYoutube, bool>> expressionQ =
                x => x.YoutubeSearchResultSnippet.Title == parameters[0]
                && x.YoutubeSearchResultSnippet.ChannelTitle == parameters[1]
                && x.YoutubeSearchResultSnippet.Description == parameters[2];

            return expressionQ;
        }
    }
}
