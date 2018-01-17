namespace P01_Employees.App.Commands
{
    using P01_Employees.App.Commands.Contracts;
    using P01_Employees.DtoModels;
    using P01_Employees.Services.Contracts;
    using System.Text;

    public class ListEmployeesOlderThanCommand : ICommand
    {
        private readonly IEmployeeService employeeService;

        public ListEmployeesOlderThanCommand(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] args)
        {
            int age = int.Parse(args[0]);
            EmployeesBirthdayDto[] employees = this.employeeService.ListEmployeesOlderThan(age);
            StringBuilder sb = new StringBuilder();
            
            foreach (var e in employees)
            {
                string manager;
                if (e.ManagerId == null)
                {
                    manager = "[no manager]";
                }
                else
                {
                    manager = e.ManagerId.ToString();
                }

                sb.AppendLine($"{e.FirstName} {e.LastName} - ${e.Salary:F2} - Manager: {manager}");
            }

            return sb.ToString().Trim();
        }
    }
}
