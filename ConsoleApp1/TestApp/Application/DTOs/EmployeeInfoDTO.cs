namespace TestApp.Application.DTOs;

public class EmployeeInfoDto
{
    public EmployeeInfoDto(int employeeIdInput, string nameInput, DateTime birthdateInput)
    {
        employeeId = employeeIdInput;
        name = nameInput;
        birthdate = birthdateInput;
    }
    
    
    public int employeeId { get; set; }
    public string name { get; set; }
    public DateTime birthdate { get; set; }
}