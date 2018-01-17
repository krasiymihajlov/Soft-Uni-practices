namespace P01_Employees.App.Commands
{
    using P01_Employees.App.Commands.Contracts;
    using P01_Employees.Services.Contracts;

    public class SetManagerCommand : ICommand
    {
        private readonly IEmployeeService employeeService;

        public SetManagerCommand(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] args)
        {
            int employeeId = int.Parse(args[0]);
            int managerId = int.Parse(args[1]);

            var managerName = this.employeeService.SetManager(employeeId, managerId);
            return $"{managerName}'s has new manager!";
        }
    }
}
