using TestApp.Application.DTOs;
using TestApp.Application.Interfaces;
using TestApp.Infrastructure.Repository;
using TestApp.Infrastructure.Data;

namespace TestApp.Application.Services;

public class EmployeeWorkInfoService : IEmployeeWorkInfoService
{
    private readonly EmployeeDbContext _db;

    public EmployeeWorkInfoService(EmployeeDbContext eWorkdb)
    {
        _db = eWorkdb;
    }

    public EmployeeWorkInfo GetWorkStatusSpecific(int targetId)
    {
        return _db.EmployeeWorkInfo.FirstOrDefault(w => w.employeeId == targetId);
    }

    public void AddWorkStatus(EmployeeWorkInfo workStatusInput)
    {
        _db.EmployeeWorkInfo.Add(workStatusInput);
        _db.SaveChanges();
    }

    public void UpdateWorkStatus(int targetId, EmployeeWorkInfo workStatusInput)
    {
        var wUpdate = _db.EmployeeWorkInfo.FirstOrDefault(w => w.employeeId == targetId);
        wUpdate = workStatusInput;
        _db.SaveChanges();
    }

    public void DeleteWorkStatus(int targetId)
    {
        var wRemove = _db.EmployeeWorkInfo.FirstOrDefault(w => w.employeeId == targetId);
        _db.EmployeeWorkInfo.Remove(wRemove);
        _db.SaveChanges();
    }

    public List<EmployeeWorkInfoDto> GetWorkStatusPage(int? pageNum, int? pageSize)
    {
        var pageFind = pageNum ?? 1;
        var pageNumFind = pageSize ?? 5;

        pageFind = Math.Max(1, pageFind);
        pageNumFind = Math.Clamp(pageNumFind , 1 , 100);

        var listed = _db.EmployeeWorkInfo
            .OrderBy(w => w.employeeId)
            .Skip((pageFind - 1) * pageNumFind)
            .Take(pageNumFind)
            .Select(w => new EmployeeWorkInfoDto(w.employeeId , w.positionId , w.departmentId , w.workStatusId , w.baseSalary))
            .ToList();
        return listed;
    }
}