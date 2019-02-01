using System.Net;
using Newtonsoft.Json;
namespace TicketR.Common.Models
{
    public class ApiResponse
    {
        public HttpStatusCode Status { get; set; }

        public string Message { get; set; }

        public ApiResponse SetMessage(object msg)
        {
            Message = JsonConvert.SerializeObject(msg);
            return this;
        }
    }

    public class ApiResponse<T> : ApiResponse
        where T : class
    {
        public T Content { get; set; }
    }
}
