using System;
using JustEat.Restaurants.DTO;
using JustEat.Restaurants.Network;
using Newtonsoft.Json;

namespace JustEat.Restaurants.Service
{
    public class RestaurantService : IDisposable, IRestaurantService
    {
        private INetworkManager _networkManager;
        private const string ApiUrl = @"https://public.je-apis.com/restaurants?q={0}";

        public void Dispose()
        {
            _networkManager = null;
        }
        
        public RestaurantService(INetworkManager networkManager)
        {
            _networkManager = networkManager;
        }

        public RestaurantSearchResult GetRestaurantsByOutcode(string outcode)
        {
            var url = string.Format(ApiUrl, outcode);
            var result = _networkManager.GetHttpResponse(url, JustEatHeader.Instance);

            return JsonConvert.DeserializeObject<RestaurantSearchResult>(result,
                new JsonSerializerSettings
                {
                    Error = (sender, args) =>
                    {
                        args.ErrorContext.Handled = true;
                        throw args.ErrorContext.Error;
                    }
                });
        }
    }
}
