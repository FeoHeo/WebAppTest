using TestApp.Application.DTOs;
using TestApp.Application.Services.DataTypes;

namespace TestApp.Application.Interfaces;
public interface IUserService
{
    List<UserDTO> GetUserPage(int? pageNum , int? pageSize);

    User GetUserSpecific(int targetId);

    void AddUser(User userInput);

    void UpdateUser(int targetId , User userInput);

    bool DeleteUser(int targetId);
}