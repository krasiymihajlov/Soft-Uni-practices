﻿namespace P01_Employees.DtoModels
{
    using System.Collections.Generic;
    public class ManagerDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }        

        public ICollection<EmployeeDto> Employees { get; set; }
    }
}
