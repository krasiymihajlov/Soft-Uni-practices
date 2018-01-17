namespace P01_Employees.App.Commands
{
    using P01_Employees.App.Commands.Contracts;
    using System.Text;
    using System;
    using P01_Employees.Services.Contracts;
    using P01_Employees.DtoModels;

    public class EmployeePersonalInfoCommand : ICommand
    {
        private readonly IEmployeeService employeeService;

        public EmployeePersonalInfoCommand(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] args)
        {
            int id = int.Parse(args[0]);
            PersonalInfoDto employeeInfo = this.employeeService.EmployeePersonalInfo(id);
            string address = employeeInfo.Address ?? "No address specified.";
            string birthday = employeeInfo.BirthDay?.ToString("dd-MM-yyyy") ?? "No birthday specified.";
            StringBuilder sb = new StringBuilder();
            sb.Append($"ID: {employeeInfo.EmployeeId} - {employeeInfo.FirstName} {employeeInfo.LastName} - ${employeeInfo.Salary}")
                .Append(Environment.NewLine)
                .Append($"Birthday: {birthday}")
                .Append(Environment.NewLine)
                .Append($"Address: {address}");

            return sb.ToString().Trim();
        }
    }
}
