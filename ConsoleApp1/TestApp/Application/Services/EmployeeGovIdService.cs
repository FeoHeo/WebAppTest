using TestApp.Application.Interfaces;
using TestApp.Infrastructure.Data;
using TestApp.Infrastructure.Repository;

namespace TestApp.Application.Services;

public class EmployeeGovIdService : IEmployeeGovIdService
{
    private readonly EmployeeDbContext _db;

    public EmployeeGovIdService(EmployeeDbContext eGovDb)
    {
        _db = eGovDb;
    }

    public List<EmployeeGovId> GetGovIdPage(int? pageNum, int? pageSize)
    {
        var pageFind = pageNum ?? 1;
        var pageNumFind = pageSize ?? 5;

        pageFind = Math.Max(1, pageFind);
        pageNumFind = Math.Clamp(pageNumFind , 1 , 100);

        var listed = _db.EmployeeGovId
            .OrderBy(g => g.employeeId)
            .Skip((pageFind - 1) * pageNumFind)
            .Take(pageNumFind)
            .ToList();
        return listed;
    }

    public EmployeeGovId GetGovIdSpecific(string targetGovId)
    {
        return _db.EmployeeGovId.Find(targetGovId);
    }

    public void AddGovId(EmployeeGovId govIdInput)
    {
        _db.EmployeeGovId.Add(govIdInput);
        _db.SaveChanges();
    }

    public void DeleteGovId(string targetGovId)
    {
        var gRemove = _db.EmployeeGovId.Find(targetGovId);
        _db.EmployeeGovId.Remove(gRemove);
    }
}