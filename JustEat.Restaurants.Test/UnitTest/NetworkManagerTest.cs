using System.Collections.Generic;
using System.Net;
using JustEat.Restaurants.Network;
using NUnit.Framework;

namespace JustEat.Restaurants.Test.UnitTest
{
    [TestFixture]
    public class NetworkManagerTest
    {
        private NetworkManager _networkManager;

        [SetUp]
        public void Init()
        {
            _networkManager = new NetworkManager();
        }

        [TearDown]
        public void Reset()
        {
            _networkManager = null;
        }

        [Test]
        [TestCase("http://www.google.co.uk")]
        [TestCase("http://www.bing.com")]
        public void GetHttpResponse_WithValidUrls_ReturnAnyString(string url)
        {
            // Act
            var returned = _networkManager.GetHttpResponse(url, new Dictionary<string, string>());

            // Assert
            Assert.That(returned, Is.Not.Empty);
        }

        [Test]
        [TestCase("http://www.google")]
        [TestCase("http://www.bing")]
        public void GetHttpResponse_WithWrongUrls_ThrowException(string url)
        {
            // Act and Assert
            Assert.Throws<WebException>(() =>
            {
                _networkManager.GetHttpResponse(url, new Dictionary<string, string>());
            });
        }
        
    }
}
