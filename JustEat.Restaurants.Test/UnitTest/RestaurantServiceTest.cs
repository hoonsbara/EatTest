using System.Collections.Generic;
using JustEat.Restaurants.DTO;
using JustEat.Restaurants.Network;
using JustEat.Restaurants.Service;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;

namespace JustEat.Restaurants.Test.UnitTest
{
    [TestFixture]
    public class RestaurantServiceTest
    {
        private Mock<INetworkManager> _networkManager;
        private RestaurantService _restaurantService;

        [SetUp]
        public void Init()
        {
            
            _networkManager = new Mock<INetworkManager>();
            _restaurantService = new RestaurantService(_networkManager.Object);
        }

        public void CleanUp()
        {
            _networkManager = null;
            _restaurantService = null;
        }

        private const string SampleJson = "{\"ShortResultText\":\"KT7\",\"Restaurants\":[{\"Id\":16142,\"Name\":\"Tasty Bite Pizza Bar\",\"Address\":\"64 Surbiton Road\",\"Postcode\":\"KT1 2HT\",\"City\":\"London\",\"CuisineTypes\":[{\"Id\":27,\"Name\":\"Italian\",\"SeoName\":null},{\"Id\":82,\"Name\":\"Pizza\",\"SeoName\":null}],\"Url\":\"http://tastybitepizzabarKT1.just-eat.co.uk\",\"IsOpenNow\":false,\"IsSponsored\":true,\"IsNew\":false,\"IsTemporarilyOffline\":false,\"ReasonWhyTemporarilyOffline\":\"Proactive Temp Offline - Onlined\",\"UniqueName\":\"tastybitepizzabarKT1\",\"IsCloseBy\":false,\"IsHalal\":false,\"DefaultDisplayRank\":2,\"IsOpenNowForDelivery\":false,\"IsOpenNowForCollection\":false,\"RatingStars\":5.01,\"Logo\":[{\"StandardResolutionURL\":\"http://d30v2pzvrfyzpo.cloudfront.net/uk/images/restaurants/16142.gif\"}],\"Deals\":[],\"NumberOfRatings\":519}]}";
        private const string EmptyResultJson = "{\"ShortResultText\":\"sffsd\",\"Restaurants\":[]}";
        private const string WrongFormatJson = "{\"array\":[1,2,3],\"boolean\":true,\"null\":null,\"number\":123,\"object\":{\"a\":\"b\",\"c\":\"d\",\"e\":\"f\"},\"string\":\"Hello World\"df}";

        [Test]
        public void GetRestaurantsByOutcode_WithSpecificOutcode_ReturnRestaurantsList()
        {
            // Arrange
            var url = "https://public.je-apis.com/restaurants?q=KT7";
            var outcode = "KT7";
            _networkManager.Setup(x => x.GetHttpResponse(url, JustEatHeader.Instance)).Returns(SampleJson);
            
            // Act
            var result = _restaurantService.GetRestaurantsByOutcode(outcode);

            // Assert
            Assert.That(result.Restaurants.Count, Is.GreaterThan(0));
        }

        [Test]
        public void GetRestaurantsByOutcode_WithSpecificOutcode_ReturnShortResultText()
        {
            // Arrange
            var url = "https://public.je-apis.com/restaurants?q=KT7";
            var outcode = "KT7";
            _networkManager.Setup(x => x.GetHttpResponse(url, JustEatHeader.Instance)).Returns(SampleJson);

            var expected = new RestaurantSearchResult { ShortResultText = outcode, Restaurants = new List<Restaurant>() };
            expected.Restaurants.Add(new Restaurant { Name = "Tasty Bite Pizza Bar" });
            
            // Act
            var result = _restaurantService.GetRestaurantsByOutcode(outcode);

            // Assert
            Assert.That(result.ShortResultText.ToUpper(), Is.EqualTo(expected.ShortResultText.ToUpper()));
        }


        [Test]
        public void GetRestaurantsByOutcode_WithWrongOutcode_ReturnEmptyResult()
        {
            // Arrange
            var url = "https://public.je-apis.com/restaurants?q=wrong code";
            var outcode = "wrong code";
            _networkManager.Setup(x => x.GetHttpResponse(url, JustEatHeader.Instance)).Returns(EmptyResultJson);
            
            // Act
            var result = _restaurantService.GetRestaurantsByOutcode(outcode);

            // Assert
            Assert.That(result.Restaurants, Is.Empty);
        }

        [Test]
        public void GetRestaurantsByOutcode_WithWrongJsonReturn_ThrowJsonReaderException()
        {
            // Arrange
            var url = "https://public.je-apis.com/restaurants?q=wrong format json";
            var outcode = "wrong format json";
            _networkManager.Setup(x => x.GetHttpResponse(url, JustEatHeader.Instance)).Returns(WrongFormatJson);
            
            // Act and Assert
            Assert.Throws<JsonReaderException>(() =>
            {
                _restaurantService.GetRestaurantsByOutcode(outcode);
            });
        }
    }
}
