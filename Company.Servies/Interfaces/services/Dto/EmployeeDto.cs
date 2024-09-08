using Microsoft.AspNetCore.Http;

namespace Company.Servies.Interfaces.services.Dto
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public IFormFile Image { get; set; }
        public string? IMG_URL { get; set; }
        public DateTime HiringDate { get; set; }
        public DepartmentDto? Department { get; set; }
        public int? DepartmentID { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
