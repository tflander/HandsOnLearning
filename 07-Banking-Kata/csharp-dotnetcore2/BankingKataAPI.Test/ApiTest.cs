using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Xunit;

namespace BankingKataAPI.Test
{
    public class ApiTest : IDisposable
    {
        private readonly TestServer _server;

        public ApiTest()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
        }

        [Fact]
        public async Task ShouldReturnAccounts()
        {
            var client = _server.CreateClient();
            var response = await client.GetAsync("api/accounts");
            var json = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<string[]>(json);
            Assert.Equal("value1", values[0]);
            Assert.Equal("value2", values[1]);
        }

        public void Dispose()
        {
            _server?.Dispose();
        }
    }
}
