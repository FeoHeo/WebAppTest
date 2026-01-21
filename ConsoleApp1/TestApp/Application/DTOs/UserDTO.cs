
namespace TestApp.Application.DTOs;
public class UserDTO
{
    public UserDTO(int userId, string userName)
    {
        UserId = userId;
        UserName = userName;
    }
        
    public int UserId { get; set; }
    public string UserName { get; set; }
}