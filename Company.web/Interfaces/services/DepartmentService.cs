using Company.Data.Models;
using Company.Reposatory.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Company.web.Interfaces.services
{
    public class DepartmentService : IDepartmentServices
    {
        private readonly IUnitOfWork _UnitOfWork;
        public DepartmentService(IUnitOfWork UnitOfWork) 
        {
            _UnitOfWork = UnitOfWork;
        }
        public void Add(Department department)
        {
            var mappedDEpartment = new Department
            {
                Code = department.Code,
                Name = department.Name,
                Createatd = department.Createatd,
            };
            _UnitOfWork.DepartmentReposatory.Add( mappedDEpartment );
            _UnitOfWork.Complete();

        }

        public void Delete(Department department)
        {
            _UnitOfWork.DepartmentReposatory.Delete(department);
            _UnitOfWork.Complete();


        }

        public IEnumerable<Department> GetAll()
        {
            var departments = _UnitOfWork.DepartmentReposatory.GetAll();
            return departments;
    
        }

        public Department GetById(int? id)
        {
          if(id == null )
                throw new  Exception("id IS NULL");
          var department =_UnitOfWork.DepartmentReposatory.GetById(id.Value);
            if (department == null)
                return null;
            return department;
        }
        public void Update(Department department)
        {
            var dept =GetById(department.Id);
            if (dept.Name != department.Name)
            {
                if (GetAll().Any(x => x.Name == department.Name))
                    throw new Exception("DEPLICATION NAME");
            }
            dept.Name = department.Name;
            dept.Code = department.Code;
            _UnitOfWork.DepartmentReposatory.Update(department);
            _UnitOfWork.Complete();

        }



    }
}
