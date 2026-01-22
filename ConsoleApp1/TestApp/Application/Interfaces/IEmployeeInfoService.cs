using TestApp.Application.DTOs;
using TestApp.Infrastructure.Data;

namespace TestApp.Application.Interfaces;

public interface IEmployeeInfoService
{
    List<EmployeeInfoDto> GetEmployeePage(int? pageNum, int? pageSize);

    EmployeeInfo GetEmployeeSpecific(int targetId);

    void AddEmployee(EmployeeInfo employeeInput);
        
    void UpdateEmployee(int targetId, EmployeeInfo employeeInput);

    void DeleteEmployee(int targetId);
}