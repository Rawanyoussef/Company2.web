using AutoMapper;
using Company.Data.Models;
using Company.Servies.Interfaces.services.Dto;

namespace Company.Servies.Mapping
{
    public class DepartmentProfile :Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department,DepartmentDto>().ReverseMap();
        }


    }
}
