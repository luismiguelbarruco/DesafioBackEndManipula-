using Flunt.Notifications;
using System.Collections.Generic;
using System.Net;

namespace DesafioManipulaeHealth.Domain.Response
{
    public abstract class ResultBase : IResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }

        public ResultBase() { }

        public ResultBase(string message)
        {
            Success = true;
            Message = message;
            HttpStatusCode = HttpStatusCode.OK;
        }

        public ResultBase(string message, object data, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            Message = message;
            Success = true;
            Data = data;
            HttpStatusCode = httpStatusCode;
        }

        public ResultBase(bool success, object data, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            Success = success;
            Data = data;
            HttpStatusCode = httpStatusCode;
        }

        public ResultBase(bool success, string message, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            Success = success;
            Message = message;
            HttpStatusCode = httpStatusCode;
        }

        public ResultBase(bool success, string message, IReadOnlyCollection<Notification> notifications, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
            : this(success, notifications, httpStatusCode)
        {
            Success = success;
            Message = message;
            HttpStatusCode = httpStatusCode;
        }
    }
}
