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
    private readonly IEmployeeGovIdService _eGovService;

    public EmployeeGovIdController(IEmployeeGovIdService eGovService)
    {
        _eGovService = eGovService;
    }
    
    public IActionResult Index()
    {
        return Ok("GovId Route is working");
    }

    [HttpGet("list")]
    public IActionResult GetGovIdList(int? pageNum, int? pageSize)
    {
        var listed = _eGovService.GetGovIdPage(pageNum, pageSize);
        return Ok(listed);
    }

    [HttpPost("add")]
    public IActionResult GovIdAdd([FromBody] EmployeeGovId govIdInput)
    {
        _eGovService.AddGovId(govIdInput);
        return Ok();
    }

    [HttpGet("get/{govIdInput}")]
    public IActionResult GovIdGet(string govIdInput)
    {
        return Ok(_eGovService.GetGovIdSpecific(govIdInput));
    }

    [HttpDelete("delete/{govIdInput}")]
    public IActionResult GovIdDelete(string govIdInput)
    {
        _eGovService.DeleteGovId(govIdInput);
        return Ok();
    }
    
}