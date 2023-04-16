using Bulutay.AdvertisementApp.Common.Enums;

namespace Bulutay.AdvertisementApp.Common
{
    public interface IResponse
    {
        string Message { get; set; }
        ResponseType ResponseType { get; set; }
    }
}
