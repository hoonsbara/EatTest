using System.Collections.Generic;
using JustEat.Restaurants.DTO;
using JustEat.Restaurants.Network;
using JustEat.Restaurants.UI;
using NUnit.Framework;

namespace JustEat.Restaurants.Test.UnitTest
{
    [TestFixture]
    public class DisplayManagerTest
    {
        [Test]
        public void DisplayRestaurant_WithRestaurant_ReturnOneLineString()
        {
            // Arrange
            var displayManager = new DisplayManager();
            const string expected = "Restaurant: Costa(cafe, food), 1.3/6(12)";
            var restaurant = new Restaurant
            {
                Name = "Costa",
                CuisineTypes = new[]
                {
                    new CuisineType {Name = "cafe"},
                    new CuisineType {Name = "food"}
                },
                RatingStars = 1.3,
                NumberOfRatings = 12
            };
            
            // Act
            var returned = displayManager.DisplayRestaurant(restaurant);

            // Assert
            Assert.That(returned, Is.EqualTo(expected));
        }
    }

}
