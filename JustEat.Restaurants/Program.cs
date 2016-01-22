using System;
using JustEat.Restaurants.DTO;
using JustEat.Restaurants.Network;
using JustEat.Restaurants.Service;
using JustEat.Restaurants.UI;
using Newtonsoft.Json;

namespace JustEat.Restaurants
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please enter outcode to search restaurants");
            var outcode = Console.ReadLine();
            var displayManager = new DisplayManager();
            
            using (var task = new RestaurantService(new NetworkManager()))
            {
                try
                {
                    var result = task.GetRestaurantsByOutcode(outcode);

                    // Write restaurants
                    foreach (var restaurant in result.Restaurants)
                    {
                        Console.WriteLine(displayManager.DisplayRestaurant(restaurant));
                    }
                }
                catch (JsonReaderException exception)
                {
                    Console.WriteLine("Server isn't available this time");
                    // logging exception
                }
                catch (Exception exception)
                {
                    Console.WriteLine("There is something wrong in application");
                    // logging exception
                }
            }
        }
    }
}
