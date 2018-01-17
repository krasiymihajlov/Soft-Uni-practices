namespace P01_Employees.App
{
    using P01_Employees.App.Commands.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    internal class CommandParser
    {
        public static ICommand ParseCommand(IServiceProvider serviceProvider, string commandName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Type[] commandTypes = assembly.GetTypes()
                .Where(i => i.GetInterfaces().Contains(typeof(ICommand)))
                .ToArray();

            Type commandType = commandTypes.SingleOrDefault(n => n.Name.ToLower() == $"{commandName}Command".ToLower());

            if (commandType == null)
            {
                throw new InvalidOperationException("Invalid Command!");
            }

            ConstructorInfo constructor = commandType.GetConstructors().First();

            Type[] constructorParametars = constructor
                .GetParameters()
                .Select(pt => pt.ParameterType)
                .ToArray();

            object[] services = constructorParametars
                .Select(serviceProvider.GetService)
                .ToArray();

            ICommand command = (ICommand)constructor.Invoke(services);

            return command;
        }
    }
}
