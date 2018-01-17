namespace P01_Employees.App.Commands
{
    using P01_Employees.App.Commands.Contracts;
    using P01_Employees.Services.Contracts;
    using System;
    using System.Globalization;

    public class SetBirthDayCommand : ICommand
    {
        private readonly IEmployeeService employeeService;

        public SetBirthDayCommand(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] args)
        {
            int employeeId = int.Parse(args[0]);
            DateTime date = DateTime.ParseExact(args[1], "dd-MM-yyyy", CultureInfo.InvariantCulture);

            string employeeName = this.employeeService.SetBirthDay(employeeId, date);

            return $"{employeeName}'s Birthday was set to {date}";
        }
    }
}
