using TestApp.Application.DTOs;
using TestApp.Infrastructure.Data;

namespace TestApp.Application.Interfaces;

public interface IEmployeeInfoService
{
    List<EmployeeInfo> GetEmployeePage(int? pageNum, int? pageSize);

    EmployeeInfo GetEmployeeSpecific(int targetId);

    void AddEmployee(EmployeeInfo employeeInput);
        
    void UpdateEmployee(string targetCode, EmployeeInfo employeeInput);

    void DeleteEmployee(string targetCode);
}