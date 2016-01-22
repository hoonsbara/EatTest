using JustEat.Restaurants.DTO;

namespace JustEat.Restaurants.Service
{
    public interface IRestaurantService
    {
        RestaurantSearchResult GetRestaurantsByOutcode(string code);
    }
}