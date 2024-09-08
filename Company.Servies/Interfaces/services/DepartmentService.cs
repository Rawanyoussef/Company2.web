using AutoMapper;
using Company.Data.Models;
using Company.Reposatory.Interfaces;
using Company.Servies.Interfaces.services.Dto;
using Company.web.Interfaces;

namespace Company.Services.Services
{
    public class DepartmentService : IDepartmentServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(DepartmentDto departmentDto)
        {
            var mappedDepartment = _mapper.Map<Department>(departmentDto);
            _unitOfWork.DepartmentReposatory.Add(mappedDepartment);
            _unitOfWork.Complete();
        }

        public void Delete(DepartmentDto departmentDto)
        {
            Department mappedDepartment = _mapper.Map<Department>(departmentDto);
            _unitOfWork.DepartmentReposatory.Delete(mappedDepartment);
            _unitOfWork.Complete();
        }

        public IEnumerable<DepartmentDto> GetAll()
        {
            var departments = _unitOfWork.DepartmentReposatory.GetAll();
            IEnumerable<DepartmentDto> mappedDepartments = _mapper.Map<IEnumerable<DepartmentDto>>(departments);
            return mappedDepartments;

        }

        public DepartmentDto GetById(int? id)
        {
            if (id is null)
                return null;

            var department = _unitOfWork.DepartmentReposatory.GetById(id.Value);

            if (department is null)
                return null;

            DepartmentDto mappedDepartment = _mapper.Map<DepartmentDto>(department);
            return mappedDepartment;
        }

        public void Update(DepartmentDto departmentDto)
        {
            var mappedDepartment = _mapper.Map<Department>(departmentDto);
            _unitOfWork.DepartmentReposatory.Update(mappedDepartment);
            _unitOfWork.Complete();
        }
    }
}
