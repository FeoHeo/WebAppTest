using TestApp.Infrastructure.Data;

namespace TestApp.Application.Interfaces;

public interface IEmployeeGovIdService
{
    List<EmployeeGovId> GetGovIdPage(int? pageNum, int? pageSize);

    EmployeeGovId GetGovIdSpecific(string targetGovId);

    void AddGovId(EmployeeGovId govIdInput);

    void DeleteGovId(string targetGovId);
}