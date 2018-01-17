namespace P01_Employees.App
{
    using System;
    using AutoMapper;
    using Microsoft.Extensions.DependencyInjection;
    using P01_Employees.Services;
    using P01_Employees.Data;
    using Microsoft.EntityFrameworkCore;
    using P01_Employees.Services.Contracts;

    public class StartUp
    {
        public static void Main()
        {
            IServiceProvider serviceProvider = ConfigureServices();
            EmployeesProfile employeesProfile = new EmployeesProfile();

            Engine engine = new Engine(serviceProvider);
            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<EmployeeContext>(options =>
            options.UseSqlServer(Config.FullDataBasePath));

            serviceCollection.AddTransient<IEmployeeService, EmployeeService>();

            //All Mapping it's happening in EmployeesProfile class
            serviceCollection.AddAutoMapper(cfg => cfg.AddProfile<EmployeesProfile>());

            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }        
    }
}
