using NUnit.Framework;

namespace LoggingKata.Test
{
    [TestFixture]
    public class TacoParserTestFixture
    {
        [Test]
        public void ShouldReturnNullForEmptyString()
        {
            var testNull = "";
            var parser = new TacoParser();
            var result = parser.Parse(testNull);

            Assert.Null(result);
            
        }

        [Test]
        public void ShouldParseLine()
        {
            var tacoParser = new TacoParser();
            var tacoCoordinates =
                "-84.677017, 34.073638,Taco Bell Acwort... (Free trial * Add to Cart for a full POI info) ";

            var resultTaco = tacoParser.Parse(tacoCoordinates);

            Assert.IsNotNull(resultTaco);

            const double lat = 34.073638;
            const double lon = -84.677017;

            Assert.AreEqual(resultTaco.Location.Longitude, lon);
            Assert.AreEqual(resultTaco.Location.Latitude, lat);
        }

    }
}
