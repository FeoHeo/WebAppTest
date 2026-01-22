namespace TestApp.Application.DTOs;

public class EmployeeWorkInfoDto
{
    public EmployeeWorkInfoDto(int eIdInput , int pIdInput , int dIdInput , int wIdInput , uint salaryInput)
    {
        employeeId = eIdInput;
        positionId = pIdInput;
        departmentId = dIdInput;
        workStatusId = wIdInput;
        baseSalary = salaryInput;
    }
    
    public int employeeId { get; set; }
    public int positionId { get; set; }
    public int departmentId { get; set; }
    public int workStatusId { get; set; }
    public uint baseSalary { get; set; }
}