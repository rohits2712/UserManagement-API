using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using UserManagementAPI.Contracts;
using UserManagementAPI.Contracts.V1.Requests;
using UserManagementAPI.Domain;
using Xunit;

namespace UserManagement.IntegrationTests
{
    public class UserControllerTests : IntegrationTest
    {
        [Fact]
        public async Task Test_GetAllUsers()
        {
            //Arrange
            var response = await _client.GetAsync(ApiRoutes.Users.GetAll);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            (await response.Content.ReadAsAsync<List<User>>()).Should().BeEmpty();
        }

        [Fact]
        public async Task Test_CreateUser()
        {
            var guid = Guid.NewGuid();
            var createUserRequest = new CreateUserRequest { Id = guid,
                EmailAddress = $"abc{guid.ToString()}", GivenName = "UserName" + guid.ToString(), Surname = $"{guid}", ManagerId = Guid.NewGuid(), PhoneNumber = "3847329"
            };
           var response = await _client.PostAsJsonAsync(ApiRoutes.Users.Create, createUserRequest);
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            
        }

        [Fact]
        public async Task Test_GetUser()
        {
            var guid = Guid.NewGuid();
            var createUserRequest = new CreateUserRequest
            {
                Id = guid,
                EmailAddress = $"abc{guid.ToString()}",
                GivenName = "UserName" + guid.ToString(),
                Surname = $"{guid}",
                ManagerId = Guid.NewGuid(),
                PhoneNumber = "3847329"
            };
            var createdUser = await _client.PostAsJsonAsync(ApiRoutes.Users.Create, createUserRequest);
            var response = await _client.GetAsync(ApiRoutes.Users.Get.Replace("{userId}", guid.ToString()));
            response.StatusCode.Should().Be(HttpStatusCode.Found);
        }
        [Fact]
        public async Task Test_UpdateUser()
        {
            var guid = Guid.NewGuid();
            var createUserRequest = new CreateUserRequest
            {
                Id = guid,
                EmailAddress = $"abc{guid.ToString()}",
                GivenName = "UserName" + guid.ToString(),
                Surname = $"{guid}",
                ManagerId = Guid.NewGuid(),
                PhoneNumber = "3847329"
            };
            var updateUserRequest = new UpdateUserRequest
            {               
                Surname = Guid.NewGuid().ToString()
            };
            var createdUser = await _client.PostAsJsonAsync(ApiRoutes.Users.Update, createUserRequest);
            createUserRequest.Surname = Guid.NewGuid().ToString();
            var response = await _client.PatchJsonAsync(ApiRoutes.Users.Update.Replace("{userId}", guid.ToString()),
                typeof(UpdateUserRequest), updateUserRequest
                );

            response.StatusCode.Should().Be(HttpStatusCode.Found);

        }

        [Fact]
        public async Task Test_DeleteUser()
        {
            var guid = Guid.NewGuid();
            var createUserRequest = new CreateUserRequest
            {
                Id = guid,
                EmailAddress = $"abc{guid.ToString()}",
                GivenName = "UserName" + guid.ToString(),
                Surname = $"{guid}",
                ManagerId = Guid.NewGuid(),
                PhoneNumber = "3847329"
            };
            var createdUser = await _client.PostAsJsonAsync(ApiRoutes.Users.Create, createUserRequest);
            var response = await _client.DeleteAsync(ApiRoutes.Users.Delete.Replace("{userId}", guid.ToString()));
          
            response.StatusCode.Should().Be(HttpStatusCode.Found);

        }
    }

  
}
