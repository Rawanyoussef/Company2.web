using Company.Data.Contexts;
using Company.Data.Models;
using Company.Reposatory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Reposatory.Reposatory
{
    public class EmployeeReposatory : GenaricReposatory<Employee>, IEmployeeReposatory
    {
        private readonly CompanyDBContext _context;

        public EmployeeReposatory(CompanyDBContext context): base(context) 
        {
            _context = context;
        }

        public IEnumerable<Employee> GetEmployeeByName(string name)
        => _context.Employees.Where(x => x.Name.Trim().ToLower().Contains(name.Trim().ToLower()));

        IEnumerable<Employee> IEmployeeReposatory.GetEmployeesByAddress(string Address)
        {
            throw new NotImplementedException();
        }
        //{
        //    _context = context;
        //}
        //public void Add(Employee employee)
        //{
        //    _context.Employees.Add(employee);
        //}

        //public void Delete(Employee employee)
        //{
        //    _context.Employees.Remove(employee);
        //}

        //public IEnumerable<Employee> GetAll()
        //{
        //    return _context.Employees.ToList();

        //}

        //public Employee GetById(int id)
        //{
        //    return _context.Employees.FirstOrDefault(x => x.Id == id);
        //}

        //public void Update(Employee employee)
        //{
        //    _context.Employees.Update(employee);
        //}
    }
}
