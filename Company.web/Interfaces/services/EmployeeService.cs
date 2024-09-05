using Company.Data.Models;
using Company.Reposatory.Interfaces;
using Company.Reposatory.Reposatory;

namespace Company.web.Interfaces.services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _UnitOfWork;

        public EmployeeService(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }
        public void Add(Employee employee)
        {
                var mappedEmployee = new Employee
                {
                    Name = employee.Name,
                    Age = employee.Age,
                    Salary = employee.Salary,
                    Address = employee.Address,
                    Email = employee.Email,
                    Phone = employee.Phone,
                    HiringDate = employee.HiringDate,
                    DepartmentID = employee.DepartmentID  


                };

                _UnitOfWork.EmployeeReposatory.Add(mappedEmployee);
                _UnitOfWork.Complete(); 
            

        }

        public void Delete(Employee employee)
        {

            _UnitOfWork.EmployeeReposatory.Delete(employee);
            _UnitOfWork.Complete();


        }

        public IEnumerable<Employee> GetAll()
        {
           var employees= _UnitOfWork.EmployeeReposatory.GetAll();
            return employees;
        }

      
        public Employee GetById(int id)
        {
            if (id == null)
                throw new Exception("id IS NULL");
            var employees = _UnitOfWork.EmployeeReposatory.GetById(id);
            if (employees == null)
                return null;
            return employees;
        }

        public void Update(Employee employee)
        {
            _UnitOfWork.EmployeeReposatory.Update(employee);
            _UnitOfWork.Complete();

        }
    }
}
