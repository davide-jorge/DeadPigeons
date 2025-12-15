using api.Dtos;
using api.Services;
using efscaffold.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
public class UserController(IUserService userService) : ControllerBase
{
    [Route(nameof(GetAllUsers))]
    [HttpGet]
    public async Task<ActionResult<List<User>>> GetAllUsers()
    {
        var users = await userService.GetAllUsers();
        return users;
    }

    [Route(nameof(CreateUser))]
    [HttpPost]
    public async Task<ActionResult<User>> CreateUser([FromBody]CreateUserDto userDto)
    {
        var result = await userService.createUser(userDto);
        return result;
    }
}