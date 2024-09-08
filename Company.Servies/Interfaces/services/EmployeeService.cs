using AutoMapper;
using Company.Data.Models;
using Company.Reposatory.Interfaces;
using Company.Servies.Helper;
using Company.Servies.Interfaces.services.Dto;

namespace Company.web.Interfaces.services
{
    public class EmployeeService :  IEmployeeService
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork UnitOfWork, IMapper mapper)
        {
            _UnitOfWork = UnitOfWork;
            _mapper = mapper;
        }

        public void Add(EmployeeDto employeeDto)
        {
            //var employee = new Employee
            //{
            //    Name = employeeDto.Name,
            //    Age = employeeDto.Age,
            //    Salary = employeeDto.Salary,
            //    Address = employeeDto.Address,
            //    Email = employeeDto.Email,
            //    Phone = employeeDto.Phone,
            //    HiringDate = employeeDto.HiringDate,
            //    DepartmentID = employeeDto.DepartmentID
            //};

            employeeDto.IMG_URL = DocumentSettings.UploadFile(employeeDto.Image, "Image");
            Employee employee = _mapper.Map<Employee>(employeeDto);
            _UnitOfWork.EmployeeReposatory.Add(employee);
            _UnitOfWork.Complete();
        }

        public void Delete(EmployeeDto employeeDto)
        {
            //var employee = new Employee
            //{
            //    Id = employeeDto.Id,
            //    Name = employeeDto.Name,
            //    Age = employeeDto.Age,
            //    Salary = employeeDto.Salary,
            //    Address = employeeDto.Address,
            //    Email = employeeDto.Email,
            //    Phone = employeeDto.Phone,
            //    HiringDate = employeeDto.HiringDate,
            //    DepartmentID = employeeDto.DepartmentID
            //};

            Employee employee = _mapper.Map<Employee>(employeeDto);
            _UnitOfWork.EmployeeReposatory.Delete(employee);
            _UnitOfWork.Complete();
        }

        public IEnumerable<EmployeeDto> GetAll()
        {
            var employees = _UnitOfWork.EmployeeReposatory.GetAll();
            //return employees.Select(e => new EmployeeDto
            //{
            //    Id = e.Id,
            //    Name = e.Name,
            //    Age = e.Age,
            //    Salary = e.Salary,
            //    Address = e.Address,
            //    Email = e.Email,
            //    Phone = e.Phone,
            //    HiringDate = e.HiringDate,
            //    DepartmentID = e.DepartmentID
            //});

            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        public EmployeeDto GetById(int id)
        {
            var employee = _UnitOfWork.EmployeeReposatory.GetById(id);
            if (employee == null)
                return null;

            //return new EmployeeDto
            //{
            //    Id = employee.Id,
            //    Name = employee.Name,
            //    Age = employee.Age,
            //    Salary = employee.Salary,
            //    Address = employee.Address,
            //    Email = employee.Email,
            //    Phone = employee.Phone,
            //    HiringDate = employee.HiringDate,
            //    DepartmentID = employee.DepartmentID
            //};

            return _mapper.Map<EmployeeDto>(employee);
        }

        public EmployeeDto GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmployeeDto> GetEmployeeDtoByName(string name)
        {
            var employees = _UnitOfWork.EmployeeReposatory.GetEmployeeByName(name);
            //return employees.Select(e => new EmployeeDto
            //{
            //    Id = e.Id,
            //    Name = e.Name,
            //    Age = e.Age,
            //    Salary = e.Salary,
            //    Address = e.Address,
            //    Email = e.Email,
            //    Phone = e.Phone,
            //    HiringDate = e.HiringDate,
            //    DepartmentID = e.DepartmentID
            //});

            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        public void Update(EmployeeDto employeeDto)
        {

        }
    }
}
