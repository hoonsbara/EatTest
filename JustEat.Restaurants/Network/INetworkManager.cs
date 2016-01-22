using System.Collections.Generic;

namespace JustEat.Restaurants.Network
{
    public interface INetworkManager
    {
        string GetHttpResponse(string url, Dictionary<string, string> headers);
    }
}
