using Microsoft.AspNetCore.Mvc;
using TestApp.Application.Interfaces;
using TestApp.Infrastructure.Data;


namespace TestApp.WebApi.Controllers;

[ApiController]
[Route("employee")]
[Route("employee/[action]")]
public class EmployeeInfoController : Controller
{
    private readonly IEmployeeInfoService _eInfoService;

    public EmployeeInfoController(IEmployeeInfoService eInfoService)
    {
        _eInfoService = eInfoService;
    }
    
    // Starts with controlling route
    
    public IActionResult Index()
    {
        return Ok("Employee Route is working");
    }

    [HttpGet("")]
    public IActionResult EmployeeList(int? pageNum, int? pageSize)
    {
        var listed = _eInfoService.GetEmployeePage(pageNum, pageSize);
        return Ok(listed);
    }

    [HttpPost("")]
    public IActionResult EmployeeAdd([FromBody] EmployeeInfo employeeInput)
    {
        _eInfoService.AddEmployee(employeeInput);
        return Ok();
    }

    [HttpDelete("{codeInput}")]
    public IActionResult EmployeeDelete(string codeInput)
    {
        _eInfoService.DeleteEmployee(codeInput);
        return Ok();
    }

    [HttpGet("get/{idInput:int}")]
    public IActionResult EmployeeGet(int idInput)
    {
        return Ok(_eInfoService.GetEmployeeSpecific(idInput));
    }

    [HttpPut("{codeInput}")]
    public IActionResult EmployeeUpdate(string codeInput, [FromBody] EmployeeInfo employeeInput)
    {
        _eInfoService.UpdateEmployee(codeInput , employeeInput);
        return Ok();
    }
    
}