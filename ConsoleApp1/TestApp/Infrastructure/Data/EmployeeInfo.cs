using System.ComponentModel.DataAnnotations;

namespace TestApp.Infrastructure.Data;

public class EmployeeInfo
{
    [Key]
    public int employeeId { get; set; } // PK
    
    public string employeeCode { get; set; }
    public string name { get; set; }
    public DateTime birthdate { get; set; }
    public bool isMale { get; set; }
    public string phoneNum { get; set; }
    public string email { get; set; }
}