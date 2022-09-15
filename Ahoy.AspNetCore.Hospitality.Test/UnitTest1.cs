using NUnit.Framework;

namespace Ahoy.AspNetCore.Hospitality.Test
{
    public class HotelControllerTest
    {
        private SUTFactory factory;
        private HttpClient _client;
        public TestControllerTests()
        {
            factory = new SUTFactory();
            _client = factory.CreateClient();
        }

        [Test]
        public async Task GetPatientInterviewID_ShouldReturnAllInterviewID()
        {
            // Arrange
            var id = "11";

            // Act
            var result = await _client.GetAsync($"Home/GetInfo/{id}");

            // Assert
            Assert.AreEqual(System.Net.HttpStatusCode.OK, result.StatusCode);
        }
    }
}