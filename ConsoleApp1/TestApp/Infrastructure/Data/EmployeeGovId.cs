using System.ComponentModel.DataAnnotations;

namespace TestApp.Infrastructure.Data;

public class EmployeeGovId
{
    [Key]
    public string govId { get; set; } // PK
    
    public int employeeId { get; set; } // FK
    public DateTime govIdIssueDate { get; set; }
    public string govIdIssueLocation { get; set; }
}