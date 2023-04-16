using Bulutay.AdvertisementApp.Common.Enums;

namespace Bulutay.AdvertisementApp.Common
{
    public class Response : IResponse
    {
        public string Message { get; set; }
        public ResponseType ResponseType { get; set; }

        public Response(ResponseType responseType, string message)
        {
            Message = message;
            ResponseType = responseType;
        }

        public Response(ResponseType responseType)
        {
            ResponseType = responseType;
        }
    }
}
