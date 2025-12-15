using api.Dtos;
using efscaffold;
using efscaffold.Models;

namespace api.Services;

public class UserService(MyDbContext context) : IUserService
{
    public async Task<User> createUser(CreateUserDto userDto)
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

    public async Task<List<User>> GetAllUsers()
    {
        return context.Users.ToList();
    }
}