using Company.Data.Models;

namespace Company.web.Interfaces
{
    public interface IEmployeeService
    { 
        Employee GetById(int id);
        IEnumerable<Employee> GetAll();

        void Update(Employee employee);
        void Delete(Employee employee);
        void Add(Employee employee);
      
    }
}
