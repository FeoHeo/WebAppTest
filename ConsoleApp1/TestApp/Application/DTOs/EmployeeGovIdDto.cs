namespace TestApp.Application.DTOs;

public class EmployeeGovIdDto
{
    public int employeeId { get; set; } // FK
    public int employeeGovId { get; set; } // PK
    public DateTime govIdIssueDate { get; set; }
    public string govIdIssueLocation { get; set; }
}