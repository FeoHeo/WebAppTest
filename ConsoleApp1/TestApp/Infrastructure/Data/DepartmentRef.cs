using System.ComponentModel.DataAnnotations;

namespace TestApp.Infrastructure.Data;

public class DepartmentRef
{
    [Key]
    public int departmentId { get; set; }
    
    public string departmentName { get; set; }
}