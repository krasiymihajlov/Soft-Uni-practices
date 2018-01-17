namespace P01_Employees.App.Commands
{
    using P01_Employees.App.Commands.Contracts;
    using P01_Employees.DtoModels;
    using P01_Employees.Services.Contracts;

    public class EmployeeInfoCommand : ICommand
    {
        private readonly IEmployeeService employeeService;

        public EmployeeInfoCommand(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] args)
        {
            int id = int.Parse(args[0]);
            EmployeeDto employee = this.employeeService.ById(id);

            return $"ID: {employee.EmployeeId} - {employee.FirstName} {employee.LastName} - ${employee.Salary:F2}";
        }
    }
}
