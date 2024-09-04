using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Reposatory.Interfaces
{
    public interface IUnitOfWork
    {
        public IDepartmentReposatory DepartmentReposatory { get; set; }
        public IEmployeeReposatory EmployeeReposatory { get; set; }

        int Complete();

    }
}
