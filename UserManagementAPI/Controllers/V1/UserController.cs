using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementAPI.Contracts;
using UserManagementAPI.Contracts.V1.Requests;
using UserManagementAPI.Contracts.V1.Responses;
using UserManagementAPI.Domain;
using UserManagementAPI.Services;

namespace UserManagementAPI.Controllers
{
    //[EnableCors("AllowOrigin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
                
        [HttpGet(ApiRoutes.Users.GetAll)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _userService.GetUsersAsync());
        }

        [HttpGet(ApiRoutes.Users.Get)]
        public async Task<IActionResult> Get([FromRoute]Guid userId)
        {
            var user = await _userService.GetUserByIdAsync(userId);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPatch(ApiRoutes.Users.Update)]
        public async Task<IActionResult> Update([FromRoute]Guid userId, [FromBody]UpdateUserRequest request)
        {
            var user = new User
            {
                Id = userId,
                GivenName = request.GivenName,
                Surname= request.Surname,
                EmailAddress=request.EmailAddress,
                PhoneNumber=request.PhoneNumber,
                ManagerId =request.ManagerId

            };
            var updatedUser = await _userService.UpdateUserAsync(user);

            if (updatedUser)
                return Ok(user);

            return NotFound();
        }

        [HttpDelete(ApiRoutes.Users.Delete)]
        public async Task<IActionResult> Delete([FromRoute]Guid guid)
        {
            var userdeleted = await _userService.DeleteUserAsync(guid);
            if (userdeleted) return NoContent();
            return NotFound();

        }

        [HttpPost(ApiRoutes.Users.Create)]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest userPostRequest)
        {
            var user = new User
            {
                Id = userPostRequest.Id == Guid.Empty ? Guid.NewGuid() : userPostRequest.Id,
                GivenName = userPostRequest.GivenName,
                Surname = userPostRequest.Surname,
                EmailAddress = userPostRequest.EmailAddress,
                ManagerId = userPostRequest.ManagerId,
                PhoneNumber = userPostRequest.PhoneNumber
            };

            await _userService.CreateUserAsync(user);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUrl = baseUrl + "/" + ApiRoutes.Users.Get.Replace("{userId}", user.Id.ToString());

            var response = new CreateUserResponse { Id = user.Id, GivenName = userPostRequest.GivenName };
            return Created(locationUrl, user);

        }
    }
}
