using Microsoft.AspNetCore.Mvc;
using TestApp.Application.Interfaces;
using TestApp.Infrastructure.Data;

namespace TestApp.WebApi.Controllers;


[ApiController]
[Route("workinfo")]
[Route("workinfo/[action]")]
public class EmployeeWorkInfoController : Controller
{
    private readonly IEmployeeWorkInfoService _eWorkInfoService;

    public EmployeeWorkInfoController(IEmployeeWorkInfoService eWorkInfoService)
    {
        _eWorkInfoService = eWorkInfoService;
    }
    
    // Starts control route

    public IActionResult Index()
    {
        return Ok("Work Info Route is working");
    }

    [HttpGet("list")]
    public IActionResult EmployeeWorkList(int? pageNum, int? pageSize)
    {
        var listed = _eWorkInfoService.GetWorkStatusPage(pageNum, pageSize);
        return Ok(listed);
    }

    [HttpGet("get/{targetId:int}")]
    public IActionResult EmployeeWorkspecific(int targetId)
    {
        return Ok(_eWorkInfoService.GetWorkStatusSpecific(targetId));
    }

    [HttpPost("add")]
    public IActionResult EmployeeWorkAdd(EmployeeWorkInfo workInfoInput)
    {
        _eWorkInfoService.AddWorkStatus(workInfoInput);
        return Ok();
    }

    [HttpPut("update/{targetId:int}")]
    public IActionResult EmployeeWorkUpdate(int targetId, EmployeeWorkInfo workInfoInput)
    {
        _eWorkInfoService.UpdateWorkStatus(targetId , workInfoInput);
        return Ok();
    }
}