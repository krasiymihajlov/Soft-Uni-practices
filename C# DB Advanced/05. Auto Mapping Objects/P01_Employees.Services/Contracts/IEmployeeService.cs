namespace P01_Employees.Services.Contracts
{
    using P01_Employees.DtoModels;
    using P01_Employees.Models;
    using System;

    public interface IEmployeeService
    {
        EmployeeDto ById(int employeeId);

        void AddEmployee(EmployeeDto employeeDto);

        string SetBirthDay(int id, DateTime date);

        string SetAddress(int id, string address);

        PersonalInfoDto EmployeePersonalInfo(int id);

        string SetManager(int employeeId, int managerId);

        ManagerDto ManagerInfo(int employeeId);

        EmployeesBirthdayDto[] ListEmployeesOlderThan(int age);
    }
}
