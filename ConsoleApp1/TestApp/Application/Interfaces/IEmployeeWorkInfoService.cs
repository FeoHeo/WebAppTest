using TestApp.Infrastructure.Data;
using TestApp.Application.DTOs;


namespace TestApp.Application.Interfaces;

public interface IEmployeeWorkInfoService
{
    List<EmployeeWorkInfoDto> GetWorkStatusPage(int? pageNum, int? pageSize);

    EmployeeWorkInfo GetWorkStatusSpecific(int targetId);

    void AddWorkStatus(EmployeeWorkInfo workStatusInput);

    void UpdateWorkStatus(int targetId, EmployeeWorkInfo workStatusInput);

    void DeleteWorkStatus(int targetId);
}