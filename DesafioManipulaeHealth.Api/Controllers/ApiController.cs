using DesafioManipulaeHealth.Domain.Response;
using Flunt.Notifications;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

namespace DesafioManipulaeHealth.Api.Controllers
{
    public class ApiController : ControllerBase
    {
        public IResult ErrorResult(string error) => new ApiControllerResult(false, error, HttpStatusCode.InternalServerError);

        public IResult ViewModelResult(object result) => new ApiControllerResult(true, result);

        public IResult ViewModelResult(IEnumerable<object> objects) => new ApiControllerResult(true, objects);

        public IResult ViewModelResult(string message) => new ApiControllerResult(true, message);

        public IResult ValidationViewModelResult(string error, IReadOnlyCollection<Notification> notifications) =>
            new ApiControllerResult(false, error, notifications);
    }
}
