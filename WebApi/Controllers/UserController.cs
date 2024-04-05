using Domain.Models;
using Domain.Response;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController(IUserService userService):ControllerBase
    { 
        private readonly IUserService _userService=userService;

        [HttpGet]
        public async Task<Response<List<User>>> GetUserAsync()
        {
            return await _userService.GetAllUsersAsync();
        }

        [HttpGet("{UserId:int}")]
        public async Task<Response<User>> GeUserByIdAsync(int UserId)
        {
            return await _userService.GetUserByIdAsync(UserId);
        }

        [HttpPost]
        public async Task<Response<string>> AddUserAsync(User User)
        {
            return await _userService.AddUserAsync(User);
        }

        [HttpPut]
        public async Task<Response<string>> UpdateUserAsync(User User)
        {
            return await _userService.UpdateUserAsync(User);
        }

        [HttpDelete("{UserId}:int")]
        public async Task<Response<bool>> DeleteUserAsync(int UserId)
        {
            return await _userService.DeletUseryAsync(UserId);
        }
    }
}
