using efscaffold;
using efscaffold.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
public class UserController(MyDbContext context) : ControllerBase
{
    [Route(nameof(GetAllUsers))]
    [HttpGet]
    public async Task<ActionResult<List<User>>> GetAllUsers()
    {
        var objects = context.Users.ToList();
        return objects;
    }

    [Route(nameof(CreateUser))]
    [HttpPost]
    public async Task<ActionResult<User>> CreateUser([FromBody]CreateUserDto userDto)
    {
        var myUser = new User()
        {
            Id = Guid.NewGuid(),
            Name = userDto.name,
            PasswordHash = "hgyt654htyr4",
            Role = userDto.role,
            CreatedAt = DateTime.Now,
        };
        context.Users.Add(myUser);
        context.SaveChanges();
        return myUser;
    }
}