namespace Nowadays.DataAccess.Dtos.Employee
{
    public class UpdateEmployeeDto
    {
        public string EmployeeId { get; set; } 
        public string TcIdentityNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}