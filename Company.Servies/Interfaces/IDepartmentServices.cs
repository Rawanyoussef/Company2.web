using Company.Servies.Interfaces.services.Dto;

namespace Company.web.Interfaces
{
    public interface IDepartmentServices
    {
        DepartmentDto GetById(int? id);
        IEnumerable<DepartmentDto> GetAll();
        void Update(DepartmentDto department);
        void Delete(DepartmentDto department);
        void Add(DepartmentDto department);
    }
}
