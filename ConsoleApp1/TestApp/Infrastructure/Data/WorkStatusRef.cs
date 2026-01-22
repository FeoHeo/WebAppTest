using System.ComponentModel.DataAnnotations;

namespace TestApp.Infrastructure.Data;

public class WorkStatusRef
{
    [Key]
    public int workStatusId { get; set; }
    
    public string workStatusName { get; set; }
}