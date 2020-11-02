using Flunt.Notifications;
using System.Collections.Generic;
using System.Net;

namespace DesafioManipulaeHealth.Domain.Response
{
    public class ServiceResult : ResultBase
    {
        public ServiceResult()
        {
        }

        public ServiceResult(string message) 
            : base(message)
        {
        }

        public ServiceResult(bool success, string message, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
            : base(success, message, httpStatusCode)
        {
        }

        public ServiceResult(string message, object data, HttpStatusCode httpStatusCode = HttpStatusCode.OK) 
            : base(message, data, httpStatusCode)
        {
        }

        public ServiceResult(bool success, string message, IReadOnlyCollection<Notification> notifications, HttpStatusCode httpStatusCode  = HttpStatusCode.OK)
            : base(success, message, notifications, httpStatusCode)
        {
        }
    }
}
