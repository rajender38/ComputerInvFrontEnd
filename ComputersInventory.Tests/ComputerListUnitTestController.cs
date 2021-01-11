using ComputersInventory.DAL;
using ComputersInventory.DAL.DomainModels;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using Xunit;

namespace ComputersInventory.Tests
{
    [Collection("Sequential")]
    public class ComputerListUnitTestController : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;
        public ComputerListUnitTestController(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }
        [Fact]

        public async void ComputerList_Get_OkResult()
        {

            var httpResponse = await _client.GetAsync("/api/computerlist");

            httpResponse.EnsureSuccessStatusCode();

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResultSetDTO>(stringResponse);

            Assert.True(result != null);

        }

        [Fact]

        public async void Computer_Create_OkResult()
        {

            var jsonData = JsonConvert.SerializeObject(new Computer()
            {
                ComputerTypeId = 12,
                Processor="i3",
                Brand="Lenovo",
                ScreenSizeId=1,
                FormFactor=1

            });

            var httpResponse = await _client.SendAsync(new HttpRequestMessage(HttpMethod.Put, "/api/computerlist")
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
