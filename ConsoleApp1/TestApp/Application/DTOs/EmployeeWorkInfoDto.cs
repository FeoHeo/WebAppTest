namespace TestApp.Application.DTOs;

public class EmployeeWorkInfoDto
{
    public int employeeId { get; set; }
    public int employeeWorkId { get; set; }
    public int positionId { get; set; }
    public int departmentId { get; set; }
    public uint baseSalary { get; set; }
    public int workStatusId { get; set; }
}