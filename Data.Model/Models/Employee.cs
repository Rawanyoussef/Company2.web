using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data.Models
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
     //   public string IMG_URL { get; set; }
        public DateTime HiringDate { get; set; }
        public Department Department { get; set; }
        public int DepartmentID { get; set; }




    }
}
