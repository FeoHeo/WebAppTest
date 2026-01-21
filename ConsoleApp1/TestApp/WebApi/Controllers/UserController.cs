using Microsoft.AspNetCore.Mvc;
using TestApp.Application.Interfaces;
using TestApp.Application.Services.DataTypes;


namespace TestApp.WebApi.Controllers;

public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    public IActionResult Index()
    {
        return Content("Controller is working");
    }

    [HttpGet("/UserList")]
    public IActionResult UserList(int? pageNum , int? pageSize)
    {
        var listed = _userService.GetUserPage(pageNum , pageSize);
        return Ok(listed);
    }

    [HttpPost("UserAdd")]
    public IActionResult UserAdd([FromBody]User userInput)
    {
        _userService.AddUser(userInput);
        return Ok();
    }

    [HttpDelete("UserDelete/{idInput:int}")]
    public IActionResult UserDelete(int idInput)
    {
        return Ok(_userService.DeleteUser(idInput));
    }

    [HttpGet("UserGet/{idInput:int}")]
    public IActionResult UserGet(int idInput)
    {
        return Ok(_userService.GetUserSpecific(idInput));
    }

    [HttpPut("UserUpdate/{idInput:int}")]
    public IActionResult UserUpdate([FromBody]User userInput , int idInput)
    {
        _userService.UpdateUser(idInput , userInput);
        return Ok();
    }
}