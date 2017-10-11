using System;

namespace _03.Mankind
{
    using System.Text;

    public class Worker : Human
    {
        private decimal weekSalary;
        private decimal workHoursPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, decimal workHoursPerDay) 
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WeekSalary
        {
            get { return this.weekSalary; }
            set
            {
                if (value <= 10)
                {
                    throw new ArgumentException($"Expected value mismatch! Argument: weekSalary");
                }

                this.weekSalary = value;
            }
        }

        public decimal WorkHoursPerDay
        {
            get { return this.workHoursPerDay; }
            set
            {
                if (value < 1 || value > 12 )
                {
                    throw new ArgumentException($"Expected value mismatch! Argument: workHoursPerDay");
                }
                this.workHoursPerDay = value;
            }
        }

        public decimal CalculateMoneyByHour()
        {
            return this.WeekSalary / (this.WorkHoursPerDay * 5m);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString())
                .AppendLine($"Week Salary: {this.WeekSalary:F2}")
                .AppendLine($"Hours per day: {this.WorkHoursPerDay:F2}")
                .AppendLine($"Salary per hour: {this.CalculateMoneyByHour():F2}");

            return sb.ToString();
        }
    }
}
