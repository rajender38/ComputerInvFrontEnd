using ComputersInventory.DAL;
using ComputersInventory.DAL.DomainModels;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using Xunit;

namespace ComputersInventory.Tests
{
    [Collection("Sequential")]
    public class ComputerTypeUnitTestController : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;
        public ComputerTypeUnitTestController(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }
        [Fact]

        public async void ComputerList_Get_OkResult()
        {

            var httpResponse = await _client.GetAsync("/api/computerTypes");

            httpResponse.EnsureSuccessStatusCode();

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResultSetDTO>(stringResponse);

            Assert.True(result != null);

        }

        [Fact]

        public async void Computer_Create_OkResult()
        {

            var jsonData = JsonConvert.SerializeObject(new ComputerType()
            {
                Name = "test",
                Processor = true,
                Brand = true,

            });

            var httpResponse = await _client.SendAsync(new HttpRequestMessage(HttpMethod.Put, "/api/computerTypes")
            {
                Content = new StringContent(jsonData, Encoding.UTF8,
                "application/json")
            });

            httpResponse.EnsureSuccessStatusCode();

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<int>(stringResponse);

            Assert.Equal(1, result);

        }
    }
}
