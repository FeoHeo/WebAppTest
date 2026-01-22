using System.ComponentModel.DataAnnotations;

namespace TestApp.Infrastructure.Data;

public class PositionRef
{
    [Key]
    public int positionId { get; set; }
    
    public string postionName { get; set; }
}