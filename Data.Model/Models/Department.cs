using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data.Models
{
    public class Department : BaseEntity
    {
      
        public string Name { get; set; }
        public string Code { get; set; }
        [NotMapped]
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
