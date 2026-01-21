namespace TestApp.Application.Services.DataTypes;

public class User
{
    public User(int userId, string userName, int userAge)
    {
        UserId = userId;
        UserName = userName;
        UserAge = userAge;
    }
    public int UserId { get; set; }
    public string UserName { get; set; }
    public int UserAge { get; set; }
} 