namespace _03.Detail_Printer
{
    using System;
    using System.Collections.Generic;

    public class DetailsPrinter
    {
        private IList<Employee> employees;

        public DetailsPrinter(IList<Employee> employees)
        {
            this.employees = employees;
        }

        public void printDetails()
        {
            //TODO  Detail Printer need just to print details for all kind of employees
            foreach (Employee employee in this.employees)
            {
                employee.PrintDetails();
            }
        }
    }
}