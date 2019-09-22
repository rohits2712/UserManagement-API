using Microsoft.AspNetCore.Mvc;
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
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet(ApiRoutes.Users.GetAll)]
        public IActionResult Get()
        {
            return Ok(_userService.GetUsers());
        }

        [HttpGet(ApiRoutes.Users.Get)]
        public IActionResult Get([FromRoute]Guid userId)
        {
            var user = _userService.GetUserById(userId);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPatch(ApiRoutes.Users.Update)]
        public IActionResult Update([FromRoute]Guid userId, [FromBody]UpdateUserRequest request)
        {
            var user = new User
            {
                Id = userId,
                GivenName = request.GivenName
            };
            var updatedUser = _userService.UpdateUser(user);

            if (updatedUser)
                return Ok(user);

            return NotFound();
        }

        [HttpDelete(ApiRoutes.Users.Delete)]

        public IActionResult Delete([FromRoute] Guid guid)
        {
            var userdeleted = _userService.DeleteUser(guid);
            if (userdeleted) return NoContent();
            return NotFound();

        }

        [HttpPost(ApiRoutes.Users.Create)]
        public IActionResult Create([FromBody] CreateUserRequest userPostRequest)
        {
            var user = new User { Id = userPostRequest.Id, GivenName = userPostRequest.GivenName };
            if (user.Id != Guid.Empty)
                user.Id = Guid.NewGuid();
            _userService.GetUsers().Add(user);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUrl = baseUrl + "/" + ApiRoutes.Users.Get.Replace("{userId}", user.Id.ToString());

            var response = new CreateUserResponse { Id = user.Id, GivenName = userPostRequest.GivenName };
            return Created(locationUrl, user);

        }
    }
}
