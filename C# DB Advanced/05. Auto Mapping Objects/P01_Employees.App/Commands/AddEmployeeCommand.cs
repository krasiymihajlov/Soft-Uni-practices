namespace P01_Employees.App.Commands
{
    using P01_Employees.App.Commands.Contracts;
    using P01_Employees.DtoModels;
    using P01_Employees.Services.Contracts;

    public class AddEmployeeCommand : ICommand
    {
        private readonly IEmployeeService employeeService;

        public AddEmployeeCommand(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] args)
        {
            string firstName = args[0];
            string lastName = args[1];
            decimal salary = decimal.Parse(args[2]);

            var employeeDto = new EmployeeDto(firstName, lastName, salary);
            this.employeeService.AddEmployee(employeeDto);

            return $"Employee {firstName} {lastName} succuessfully added.";
        }
    }
}
