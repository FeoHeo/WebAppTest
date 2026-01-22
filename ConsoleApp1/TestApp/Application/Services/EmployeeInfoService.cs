using Microsoft.EntityFrameworkCore;
using TestApp.Infrastructure.Data;
using TestApp.Application.DTOs; 
using TestApp.Application.Interfaces;
using TestApp.Infrastructure.Repository;

namespace TestApp.Application.Services;

public class EmployeeInfoService : IEmployeeInfoService
{
    private readonly EmployeeDbContext _db;
        
    public EmployeeInfoService(EmployeeDbContext eInfoDb)
    {
        _db = eInfoDb;
    }
    
    
    public List<EmployeeInfoDto> GetEmployeePage(int? pageNum, int? pageSize)
    {
        var pageFind = pageNum ?? 1;
        var pageNumFind = pageSize ?? 5;

        pageFind = Math.Max(1, pageFind);
        pageNumFind = Math.Clamp(pageNumFind , 1 , 100);

        var listed = _db.EmployeeInfo
            .OrderBy(e => e.employeeId)   
            .Skip((pageFind - 1) * pageNumFind)
            .Take(pageNumFind)
            .Select(e => new EmployeeInfoDto(e.employeeId, e.name, e.birthdate))
            .ToList();
        return listed;

    }

    public void AddEmployee(EmployeeInfo employeeInput)
    {
        _db.Add(employeeInput);
        _db.SaveChanges();
    }

    public void DeleteEmployee(int targetId)
    {
        var eRemove = _db.EmployeeInfo.Find(targetId);
        _db.EmployeeInfo.Remove(eRemove);
        _db.SaveChanges();
    }

    public void UpdateEmployee(int targetId, EmployeeInfo employeeInput)
    {
        var eUpdate = _db.EmployeeInfo.Find(targetId);
        eUpdate = employeeInput;
        _db.SaveChanges();
    }

    public EmployeeInfo GetEmployeeSpecific(int targetId)
    {
        return _db.EmployeeInfo.Find(targetId);
    }
}