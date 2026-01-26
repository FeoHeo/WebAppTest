using System.ComponentModel.DataAnnotations;

namespace TestApp.Infrastructure.Data;

public class EmployeeWorkInfo
{
    [Key]
    public int employeeWorkId { get; set; }
    
    public int employeeId { get; set; }
    public int positionId { get; set; }
    public int departmentId { get; set; }
    public string taxNum { get; set; }
    public int baseSalary { get; set; }
    public DateTime joinDate { get; set; }
    public int workStatusId { get; set; }
}