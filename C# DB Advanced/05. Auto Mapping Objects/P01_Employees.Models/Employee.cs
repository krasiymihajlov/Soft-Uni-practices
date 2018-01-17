namespace P01_Employees.Models
{
    using System;
    using System.Collections.Generic;

    public class Employee
    {
        public Employee()
        {
            this.Employees = new HashSet<Employee>();
        }

        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public DateTime? BirthDay { get; set; }

        public string Address { get; set; }

        public int? ManagerId { get; set; }
        public Employee Manager { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
