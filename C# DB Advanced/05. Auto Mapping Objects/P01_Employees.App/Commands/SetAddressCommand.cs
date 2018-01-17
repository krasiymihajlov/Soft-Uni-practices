namespace P01_Employees.App.Commands
{
    using P01_Employees.App.Commands.Contracts;
    using P01_Employees.Services.Contracts;
    using System.Linq;

    public class SetAddressCommand : ICommand
    {
        private readonly IEmployeeService employeeService;

        public SetAddressCommand(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] args)
        {
            int id = int.Parse(args[0]);
            string address = string.Join(" ", args.Skip(1));

            string employeeName = this.employeeService.SetAddress(id, address);
            return $"{employeeName}'s Address was set to {address}";
        }
    }
}
