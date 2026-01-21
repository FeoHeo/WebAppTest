using TestApp.Application.Services.DataTypes;
using TestApp.Application.DTOs;
using TestApp.Application.Interfaces;
namespace TestApp.Application.Services;

public class UserService : IUserService
{
    
    private readonly List<User> _userList = new List<User>();
    private readonly string[] _names = new[] {"Peter" , "Paul" , "Matthew" , "Simon" , "Andrew" , "James" , "John" , "Andrew" , "Phillip" , "Nathan"};
    public UserService()
    {
        for (int i = 0; i < 20; i++)
        {
            _userList.Add(
                new User(
                    i,
                    _names[Random.Shared.Next(_names.Length)],
                    Random.Shared.Next(20, 40)
                )
            );
        }
    }

    public User GetUserSpecific(int targetId)
    {
        return _userList[_userList.FindIndex(u => u.UserId == targetId)];
    }

    public List<UserDTO> GetUserPage(int? pageNum , int? pageSize)
    {
        // if (pageRequest == null)
        // {
        //     pageRequest = new PagingRequest();
        // }

        var pageFind = pageNum ?? 1;
        var pageNumFind = pageSize ?? 5;

        pageFind = Math.Max(1,pageFind);
        pageNumFind = Math.Clamp(pageNumFind, 1, 100);
        
        var listed = _userList
            .Skip((pageFind - 1) * pageNumFind)
            .Take(pageNumFind)
            .Select(u => new UserDTO(u.UserId , u.UserName))
            .ToList();
        return listed;
    }

    public void AddUser(User userInput)
    {
        _userList.Add(userInput);
    }

    public bool DeleteUser(int targetId)
    {

        var userRemove = _userList.FirstOrDefault(u => u.UserId == targetId);
        if (userRemove != null)
        {
            return _userList.Remove(userRemove);
        }
        Console.WriteLine("User remove is null");
        return false;
    }

    public void UpdateUser(int targetId , User userInput)
    {
        int updateIndex = _userList.FindIndex(u => u.UserId == targetId);
        _userList[updateIndex] = userInput;

    }
    
}