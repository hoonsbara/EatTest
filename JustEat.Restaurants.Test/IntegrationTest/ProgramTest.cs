using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace JustEat.Restaurants.Test.IntegrationTest
{
    [TestFixture]
    public class ProgramTest
    {
        [Test]
        public void Main_WhenInputOutcode_ShowSomeRestaurants()
        {
            using (var sw = new StringWriter())
            {
                using (var sr = new StringReader(@"SE19"))
                {
                    // Arrange
                    Console.SetOut(sw);
                    Console.SetIn(sr);

                    // Act
                    Program.Main(null);
                    var result = sw.ToString().Trim();

                    // Assert
                    Assert.That(result.IndexOf("Restaurant: ", StringComparison.Ordinal), Is.GreaterThan(-1));
                }
            }
        }
    }

}
