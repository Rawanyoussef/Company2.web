using Company.Data.Contexts;
using Company.Reposatory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Reposatory.Reposatory
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CompanyDBContext _context;

        public UnitOfWork(CompanyDBContext context)
        {
            _context = context;
            DepartmentReposatory =  new DepartmentReposatory(context);
            EmployeeReposatory = new EmployeeReposatory(context);
        }

        public IDepartmentReposatory DepartmentReposatory { get; set; }
        public IEmployeeReposatory EmployeeReposatory { get; set; }

        public object EmployeeRepository => throw new NotImplementedException();

        public int Complete()
        {
         return _context.SaveChanges();
        }
    }
}
