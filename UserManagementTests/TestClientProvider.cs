using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using UserManagementAPI;
using UserManagementAPI.Data;
using Xunit;


namespace UserManagementTests
{
    public class TestClientProvider
    {
        private readonly AppDbContext _context;
        private readonly HttpClient _client;

        public TestClientProvider()
        {
            var server = new TestServer(new WebHostBuilder().UseEnvironment("Testing").UseStartup<Startup>());
            _context = server.Host.Services.GetService(typeof(AppDbContext)) as AppDbContext;
            _client = server.CreateClient();
        }

        [Fact]
        public async Task Test_GetAllUsers()
        {
            var client = new TestClientProvider();
            var response = await _client.GetAsync("/api/v1/users");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

    }
}
