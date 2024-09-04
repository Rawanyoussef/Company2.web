using Company.Data.Models;

namespace Company.web.Interfaces
{
    public interface IDepartmentServices
    {
        Department GetById(int? id);
        IEnumerable<Department> GetAll();
        void Update(Department department);
        void Delete(Department department);
        void Add(Department department);
    }
}
