namespace P01_Employees.Services
{
    using AutoMapper;
    using P01_Employees.Data;
    using P01_Employees.DtoModels;
    using P01_Employees.Models;
    using P01_Employees.Services.Contracts;
    using System;
    using System.Linq;
    using AutoMapper.QueryableExtensions;

    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeContext context;

        public EmployeeService(EmployeeContext context)
        {
            this.context = context;
        }

        public EmployeeDto ById(int employeeId)
        {
            Employee employee = this.context.Employees.Find(employeeId);
            var employeeDto = Mapper.Map<EmployeeDto>(employee);
            
            return employeeDto;
        }

        public void AddEmployee(EmployeeDto employeeDto)
        {
            var employee = Mapper.Map<Employee>(employeeDto);
            this.context.Add(employee);
            this.context.SaveChanges();
        }

        public string SetBirthDay(int id, DateTime date)
        {
            Employee employee = this.context.Employees.Find(id);
            employee.BirthDay = date;
            this.context.SaveChanges();

            return $"{employee.FirstName} {employee.LastName}";
        }

        public string SetAddress(int id, string address)
        {
            Employee employee = this.context.Employees.Find(id);
            employee.Address = address;
            this.context.SaveChanges();

            return $"{employee.FirstName} {employee.LastName}";
        }

        public PersonalInfoDto EmployeePersonalInfo(int id)
        {
            Employee employee = this.context.Employees.Find(id);
            PersonalInfoDto info = Mapper.Map<PersonalInfoDto>(employee);

            return info;
        }

        public string SetManager(int employeeId, int managerId)
        {
            Employee employee = this.context.Employees.Find(employeeId);
            employee.ManagerId = managerId;
            this.context.SaveChanges();

            return $"{employee.FirstName} {employee.LastName}";
        }

        public ManagerDto ManagerInfo(int managerId)
        {
            Employee manager = this.context.Employees
                .Where(m => m.EmployeeId == managerId).SingleOrDefault();

            ManagerDto managerInfo = Mapper.Map<ManagerDto>(manager);


            return managerInfo;
        }

        public EmployeesBirthdayDto[] ListEmployeesOlderThan(int age)
        {
            //var ss = this.context.Employees.Select(x => x.BirthDay.Value.TimeOfDay.Days).First();

            EmployeesBirthdayDto[] filterEmployeeOlderthen = this.context.Employees
                .Where(d => d.BirthDay.Value != null && (DateTime.Now.Year - d.BirthDay.Value.Year)  > age)
                .ProjectTo<EmployeesBirthdayDto>()
                .OrderByDescending(s => s.Salary)
                .ToArray();

            return filterEmployeeOlderthen;
        }
    }
}
