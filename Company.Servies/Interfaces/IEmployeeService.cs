using Company.Data.Models;
using Company.Servies.Interfaces.services.Dto;

namespace Company.web.Interfaces
{
    public interface IEmployeeService
    { 
        EmployeeDto GetById(int? id);
        IEnumerable<EmployeeDto> GetAll();

        void Update(EmployeeDto employee);
        void Delete(EmployeeDto employee);
        void Add(EmployeeDto employee);
        public IEnumerable<EmployeeDto> GetEmployeeDtoByName(string name);



    }
}
