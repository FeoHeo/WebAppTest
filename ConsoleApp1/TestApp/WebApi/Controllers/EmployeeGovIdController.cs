using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TestApp.Application.Interfaces;
using TestApp.Infrastructure.Data;

namespace TestApp.WebApi.Controllers;


[ApiController]
[Route("employee/govid")]
[Route("employee/govid/[action]")]
public class EmployeeGovIdController : Controller
{


    public IActionResult Index()
    {
        return Ok("GovId Route is working");
    }
}