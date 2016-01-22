using System.Collections.Generic;
using System.Net;

namespace JustEat.Restaurants.Network
{
    public class NetworkManager : INetworkManager
    {
        public string GetHttpResponse(string url, Dictionary<string, string> headers)
        {
            using (var client = new WebClient())
            {
                foreach (var header in headers)
                {
                    client.Headers.Add(header.Key, header.Value);
                }
                return client.DownloadString(url);
            }
        }
    }
}
