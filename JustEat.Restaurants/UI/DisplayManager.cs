using JustEat.Restaurants.DTO;

namespace JustEat.Restaurants.UI
{
    public class DisplayManager
    {
        // name(type), rating 
        // ex) Costa(cafe, food), 1.3/5(12)
        private const string DisplayFormat = @"Restaurant: {0}({1}), {2}/6({3})";

        public string DisplayRestaurant(Restaurant restaurant)
        {
            return string.Format(DisplayFormat, restaurant.Name,
                restaurant.CuisineTypes.ToCusineList(),
                restaurant.RatingStars, 
                restaurant.NumberOfRatings);
        }
        

    }
}
