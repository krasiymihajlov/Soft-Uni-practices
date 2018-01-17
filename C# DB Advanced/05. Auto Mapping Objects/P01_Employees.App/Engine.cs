namespace P01_Employees.App
{
    using P01_Employees.App.Configuration;
    using System;
    using System.Linq;

    public class Engine : IEngine
    {
        private readonly IServiceProvider serviceProvider;

        public Engine(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] commandTokens = input.Split();
                    string commandName = commandTokens[0];
                    string[] commandArgs = commandTokens.Skip(1).ToArray();
                    var command = CommandParser.ParseCommand(serviceProvider, commandName);
                    string result = command.Execute(commandArgs);
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
