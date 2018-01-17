namespace P01_Employees.App.Commands
{
    using P01_Employees.App.Commands.Contracts;
    using P01_Employees.DtoModels;
    using P01_Employees.Services.Contracts;
    using System.Text;

    public class ManagerInfoCommand : ICommand
    {
        private readonly IEmployeeService employeeService;

        public ManagerInfoCommand(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] args)
        {
            int managerId = int.Parse(args[0]);
            ManagerDto managerInfo = this.employeeService.ManagerInfo(managerId);
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{managerInfo.FirstName} {managerInfo.LastName} | Employees: {managerInfo.Employees.Count}");

            foreach (var employees in managerInfo.Employees)
            {
                sb.AppendLine($"    - {employees.FirstName} {employees.LastName} - ${employees.Salary:F2}");
            }

            return sb.ToString().Trim();
        }
    }
}
