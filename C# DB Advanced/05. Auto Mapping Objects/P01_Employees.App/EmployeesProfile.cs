namespace P01_Employees.App
{
    using AutoMapper;
    using P01_Employees.DtoModels;
    using P01_Employees.Models;

    public class EmployeesProfile : Profile
    {
        public EmployeesProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();
            CreateMap<Employee, EmployeesBirthdayDto>();
        }
    }
}
