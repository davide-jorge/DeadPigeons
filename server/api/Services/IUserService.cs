using api.Dtos;
using efscaffold.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Services;

public interface IUserService
{
    Task<User> createUser(CreateUserDto userDto);
    Task<List<User>> GetAllUsers();
}