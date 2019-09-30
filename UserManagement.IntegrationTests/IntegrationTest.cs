using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using UserManagementAPI;
using UserManagementAPI.Data;
using Xunit;

namespace UserManagement.IntegrationTests
{
    public class IntegrationTest
    {
        protected readonly HttpClient _client;

        protected IntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder => builder.ConfigureServices(services =>
                {
                    services.RemoveAll(typeof(AppDbContext));
                    services.AddDbContext<AppDbContext>(options => { options.UseInMemoryDatabase("TestUserDb"); });
                }));
            _client = appFactory.CreateClient();
        }

        //[Fact]
        //public void Test1()
        //{

        //}
    }
}
