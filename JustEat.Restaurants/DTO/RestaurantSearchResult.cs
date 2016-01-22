using System.Collections.Generic;

namespace JustEat.Restaurants.DTO
{
    public class RestaurantSearchResult
    {
        public string ShortResultText { get; set; }
        public IList<Restaurant> Restaurants { get; set; }
    }
}