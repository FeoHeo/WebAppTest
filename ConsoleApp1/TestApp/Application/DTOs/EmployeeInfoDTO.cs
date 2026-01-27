namespace TestApp.Application.DTOs;

public class EmployeeInfoDto
{
    public EmployeeInfoDto(int employeeIdInput, string nameInput, DateTime birthdateInput , string codeInput)
    {
        employeeId = employeeIdInput;
        name = nameInput;
        birthdate = birthdateInput;
        employeeCode = codeInput;
        // email = emailInput;
        // phoneNum = phoneInput;
    }
    
    public string employeeCode { get; set; }
    public int employeeId { get; set; }
    public string name { get; set; }
    public DateTime birthdate { get; set; }
    public string email { get; set; }
    public string phoneNum { get; set; }
}