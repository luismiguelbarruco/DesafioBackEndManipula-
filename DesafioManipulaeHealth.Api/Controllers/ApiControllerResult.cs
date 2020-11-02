using DesafioManipulaeHealth.Domain.Response;
using Flunt.Notifications;
using System.Collections.Generic;
using System.Net;

namespace DesafioManipulaeHealth.Api.Controllers
{
    public class ApiControllerResult : ResultBase
    {
        public ApiControllerResult()
        {
        }

        public ApiControllerResult(string message)
            : base(message)
        {
        }

        public ApiControllerResult(bool success, object data, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
            : base(success, data, httpStatusCode)
        {
        }

        public ApiControllerResult(bool success, string message, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
            : base(success, message, httpStatusCode)
        {
        }

        public ApiControllerResult(string message, object data, HttpStatusCode httpStatusCode = HttpStatusCode.OK) 
            : base(message, data, httpStatusCode)
        {
        }

        public ApiControllerResult(bool success, string message, IReadOnlyCollection<Notification> notifications, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
            : base(success, message, notifications, httpStatusCode)
        {
        }
    }
}
