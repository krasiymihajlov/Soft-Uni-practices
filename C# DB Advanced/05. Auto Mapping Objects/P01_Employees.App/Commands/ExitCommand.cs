namespace P01_Employees.App.Commands
{
    using P01_Employees.App.Commands.Contracts;
    using System;

    public class ExitCommand : ICommand
    {
        public string Execute(params string[] args)
        {
            Console.WriteLine("GoodBye!");
            Environment.Exit(0);
            return "";
        }
    }
}
