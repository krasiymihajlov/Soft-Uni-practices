namespace P01_Employees.DtoModels
{
    public class EmployeesBirthdayDto
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public int? ManagerId { get; set; }
    }
}
